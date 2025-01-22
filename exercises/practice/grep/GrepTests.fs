source("./grep.R")
library(testthat)

iliadFileName <- "iliad.txt"
iliadContents <- 
    """Achilles sing, O Goddess! Peleus' son;
His wrath pernicious, who ten thousand woes
Caused to Achaia's host, sent many a soul
Illustrious into Ades premature,
And Heroes gave (so stood the will of Jove)
To dogs and to all ravening fowls a prey,
When fierce dispute had separated once
The noble Chief Achilles from the son
Of Atreus, Agamemnon, King of men."""

midsummerNightFileName <- "midsummer-night.txt"
midsummerNightContents <- 
    """I do entreat your grace to pardon me.
I know not by what power I am made bold,
Nor how it may concern my modesty,
In such a presence here to plead my thoughts;
But I beseech your grace that I may know
The worst that may befall me in this case,
If I refuse to wed Demetrius."""

paradiseLostFileName <- "paradise-lost.txt"
paradiseLostContents <- 
    """Of Mans First Disobedience, and the Fruit
Of that Forbidden Tree, whose mortal tast
Brought Death into the World, and all our woe,
With loss of Eden, till one greater Man
Restore us, and regain the blissful Seat,
Sing Heav'nly Muse, that on the secret top
Of Oreb, or of Sinai, didst inspire
That Shepherd, who first taught the chosen Seed"""

let createFiles() =
    File.WriteAllText(iliadFileName, iliadContents)
    File.WriteAllText(midsummerNightFileName, midsummerNightContents)
    File.WriteAllText(paradiseLostFileName, paradiseLostContents)

type GrepTests() =

        member this.``One file, one match, no flags`` () =
        files <- c("iliad.txt")
        flags <- []
        pattern <- "Agamemnon"
        expected <- c("Of Atreus, Agamemnon, King of men.")
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, one match, print line numbers flag`` () =
        files <- c("paradise-lost.txt")
        flags <- c("-n")
        pattern <- "Forbidden"
        expected <- c("2:Of that Forbidden Tree, whose mortal tast")
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, one match, case-insensitive flag`` () =
        files <- c("paradise-lost.txt")
        flags <- c("-i")
        pattern <- "FORBIDDEN"
        expected <- c("Of that Forbidden Tree, whose mortal tast")
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, one match, print file names flag`` () =
        files <- c("paradise-lost.txt")
        flags <- c("-l")
        pattern <- "Forbidden"
        expected <- c("paradise-lost.txt")
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, one match, match entire lines flag`` () =
        files <- c("paradise-lost.txt")
        flags <- c("-x")
        pattern <- "With loss of Eden, till one greater Man"
        expected <- c("With loss of Eden, till one greater Man")
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, one match, multiple flags`` () =
        files <- c("iliad.txt")
        flags <- c("-n", "-i", "-x")
        pattern <- "OF ATREUS, Agamemnon, KIng of MEN."
        expected <- c("9:Of Atreus, Agamemnon, King of men.")
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, several matches, no flags`` () =
        files <- c("midsummer-night.txt")
        flags <- []
        pattern <- "may"
        expected <- 
            [ "Nor how it may concern my modesty,";
              "But I beseech your grace that I may know";
              "The worst that may befall me in this case," ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, several matches, print line numbers flag`` () =
        files <- c("midsummer-night.txt")
        flags <- c("-n")
        pattern <- "may"
        expected <- 
            [ "3:Nor how it may concern my modesty,";
              "5:But I beseech your grace that I may know";
              "6:The worst that may befall me in this case," ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, several matches, match entire lines flag`` () =
        files <- c("midsummer-night.txt")
        flags <- c("-x")
        pattern <- "may"
        let expected: string list = []
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, several matches, case-insensitive flag`` () =
        files <- c("iliad.txt")
        flags <- c("-i")
        pattern <- "ACHILLES"
        expected <- 
            [ "Achilles sing, O Goddess! Peleus' son;";
              "The noble Chief Achilles from the son" ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, several matches, inverted flag`` () =
        files <- c("paradise-lost.txt")
        flags <- c("-v")
        pattern <- "Of"
        expected <- 
            [ "Brought Death into the World, and all our woe,";
              "With loss of Eden, till one greater Man";
              "Restore us, and regain the blissful Seat,";
              "Sing Heav'nly Muse, that on the secret top";
              "That Shepherd, who first taught the chosen Seed" ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, no matches, various flags`` () =
        files <- c("iliad.txt")
        flags <- c("-n", "-l", "-x", "-i")
        pattern <- "Gandalf"
        let expected: string list = []
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, one match, file flag takes precedence over line flag`` () =
        files <- c("iliad.txt")
        flags <- c("-n", "-l")
        pattern <- "ten"
        expected <- c("iliad.txt")
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``One file, several matches, inverted and match entire lines flags`` () =
        files <- c("iliad.txt")
        flags <- c("-x", "-v")
        pattern <- "Illustrious into Ades premature,"
        expected <- 
            [ "Achilles sing, O Goddess! Peleus' son;";
              "His wrath pernicious, who ten thousand woes";
              "Caused to Achaia's host, sent many a soul";
              "And Heroes gave (so stood the will of Jove)";
              "To dogs and to all ravening fowls a prey,";
              "When fierce dispute had separated once";
              "The noble Chief Achilles from the son";
              "Of Atreus, Agamemnon, King of men." ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, one match, no flags`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- []
        pattern <- "Agamemnon"
        expected <- c("iliad.txt:Of Atreus, Agamemnon, King of men.")
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, several matches, no flags`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- []
        pattern <- "may"
        expected <- 
            [ "midsummer-night.txt:Nor how it may concern my modesty,";
              "midsummer-night.txt:But I beseech your grace that I may know";
              "midsummer-night.txt:The worst that may befall me in this case," ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, several matches, print line numbers flag`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- c("-n")
        pattern <- "that"
        expected <- 
            [ "midsummer-night.txt:5:But I beseech your grace that I may know";
              "midsummer-night.txt:6:The worst that may befall me in this case,";
              "paradise-lost.txt:2:Of that Forbidden Tree, whose mortal tast";
              "paradise-lost.txt:6:Sing Heav'nly Muse, that on the secret top" ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, one match, print file names flag`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- c("-l")
        pattern <- "who"
        expected <- 
            [ "iliad.txt";
              "paradise-lost.txt" ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, several matches, case-insensitive flag`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- c("-i")
        pattern <- "TO"
        expected <- 
            [ "iliad.txt:Caused to Achaia's host, sent many a soul";
              "iliad.txt:Illustrious into Ades premature,";
              "iliad.txt:And Heroes gave (so stood the will of Jove)";
              "iliad.txt:To dogs and to all ravening fowls a prey,";
              "midsummer-night.txt:I do entreat your grace to pardon me.";
              "midsummer-night.txt:In such a presence here to plead my thoughts;";
              "midsummer-night.txt:If I refuse to wed Demetrius.";
              "paradise-lost.txt:Brought Death into the World, and all our woe,";
              "paradise-lost.txt:Restore us, and regain the blissful Seat,";
              "paradise-lost.txt:Sing Heav'nly Muse, that on the secret top" ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, several matches, inverted flag`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- c("-v")
        pattern <- "a"
        expected <- 
            [ "iliad.txt:Achilles sing, O Goddess! Peleus' son;";
              "iliad.txt:The noble Chief Achilles from the son";
              "midsummer-night.txt:If I refuse to wed Demetrius." ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, one match, match entire lines flag`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- c("-x")
        pattern <- "But I beseech your grace that I may know"
        expected <- c("midsummer-night.txt:But I beseech your grace that I may know")
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, one match, multiple flags`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- c("-n", "-i", "-x")
        pattern <- "WITH LOSS OF EDEN, TILL ONE GREATER MAN"
        expected <- c("paradise-lost.txt:4:With loss of Eden, till one greater Man")
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, no matches, various flags`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- c("-n", "-l", "-x", "-i")
        pattern <- "Frodo"
        let expected: string list = []
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, several matches, file flag takes precedence over line number flag`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- c("-n", "-l")
        pattern <- "who"
        expected <- 
            [ "iliad.txt";
              "paradise-lost.txt" ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)

        member this.``Multiple files, several matches, inverted and match entire lines flags`` () =
        files <- c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        flags <- c("-x", "-v")
        pattern <- "Illustrious into Ades premature,"
        expected <- 
            [ "iliad.txt:Achilles sing, O Goddess! Peleus' son;";
              "iliad.txt:His wrath pernicious, who ten thousand woes";
              "iliad.txt:Caused to Achaia's host, sent many a soul";
              "iliad.txt:And Heroes gave (so stood the will of Jove)";
              "iliad.txt:To dogs and to all ravening fowls a prey,";
              "iliad.txt:When fierce dispute had separated once";
              "iliad.txt:The noble Chief Achilles from the son";
              "iliad.txt:Of Atreus, Agamemnon, King of men.";
              "midsummer-night.txt:I do entreat your grace to pardon me.";
              "midsummer-night.txt:I know not by what power I am made bold,";
              "midsummer-night.txt:Nor how it may concern my modesty,";
              "midsummer-night.txt:In such a presence here to plead my thoughts;";
              "midsummer-night.txt:But I beseech your grace that I may know";
              "midsummer-night.txt:The worst that may befall me in this case,";
              "midsummer-night.txt:If I refuse to wed Demetrius.";
              "paradise-lost.txt:Of Mans First Disobedience, and the Fruit";
              "paradise-lost.txt:Of that Forbidden Tree, whose mortal tast";
              "paradise-lost.txt:Brought Death into the World, and all our woe,";
              "paradise-lost.txt:With loss of Eden, till one greater Man";
              "paradise-lost.txt:Restore us, and regain the blissful Seat,";
              "paradise-lost.txt:Sing Heav'nly Muse, that on the secret top";
              "paradise-lost.txt:Of Oreb, or of Sinai, didst inspire";
              "paradise-lost.txt:That Shepherd, who first taught the chosen Seed" ]
        
        createFiles() |> ignore
    expect_equal(grep files flags pattern, expected)
})
