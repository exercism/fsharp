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
        files <- ["iliad.txt"]
        flags <- []
        pattern <- "Agamemnon"
        expected <- ["Of Atreus, Agamemnon, King of men."]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, one match, print line numbers flag`` () =
        files <- ["paradise-lost.txt"]
        flags <- ["-n"]
        pattern <- "Forbidden"
        expected <- ["2:Of that Forbidden Tree, whose mortal tast"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, one match, case-insensitive flag`` () =
        files <- ["paradise-lost.txt"]
        flags <- ["-i"]
        pattern <- "FORBIDDEN"
        expected <- ["Of that Forbidden Tree, whose mortal tast"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, one match, print file names flag`` () =
        files <- ["paradise-lost.txt"]
        flags <- ["-l"]
        pattern <- "Forbidden"
        expected <- ["paradise-lost.txt"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, one match, match entire lines flag`` () =
        files <- ["paradise-lost.txt"]
        flags <- ["-x"]
        pattern <- "With loss of Eden, till one greater Man"
        expected <- ["With loss of Eden, till one greater Man"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, one match, multiple flags`` () =
        files <- ["iliad.txt"]
        flags <- ["-n"; "-i"; "-x"]
        pattern <- "OF ATREUS, Agamemnon, KIng of MEN."
        expected <- ["9:Of Atreus, Agamemnon, King of men."]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, several matches, no flags`` () =
        files <- ["midsummer-night.txt"]
        flags <- []
        pattern <- "may"
        expected <- 
            [ "Nor how it may concern my modesty,";
              "But I beseech your grace that I may know";
              "The worst that may befall me in this case," ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, several matches, print line numbers flag`` () =
        files <- ["midsummer-night.txt"]
        flags <- ["-n"]
        pattern <- "may"
        expected <- 
            [ "3:Nor how it may concern my modesty,";
              "5:But I beseech your grace that I may know";
              "6:The worst that may befall me in this case," ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, several matches, match entire lines flag`` () =
        files <- ["midsummer-night.txt"]
        flags <- ["-x"]
        pattern <- "may"
        let expected: string list = []
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, several matches, case-insensitive flag`` () =
        files <- ["iliad.txt"]
        flags <- ["-i"]
        pattern <- "ACHILLES"
        expected <- 
            [ "Achilles sing, O Goddess! Peleus' son;";
              "The noble Chief Achilles from the son" ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, several matches, inverted flag`` () =
        files <- ["paradise-lost.txt"]
        flags <- ["-v"]
        pattern <- "Of"
        expected <- 
            [ "Brought Death into the World, and all our woe,";
              "With loss of Eden, till one greater Man";
              "Restore us, and regain the blissful Seat,";
              "Sing Heav'nly Muse, that on the secret top";
              "That Shepherd, who first taught the chosen Seed" ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, no matches, various flags`` () =
        files <- ["iliad.txt"]
        flags <- ["-n"; "-l"; "-x"; "-i"]
        pattern <- "Gandalf"
        let expected: string list = []
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, one match, file flag takes precedence over line flag`` () =
        files <- ["iliad.txt"]
        flags <- ["-n"; "-l"]
        pattern <- "ten"
        expected <- ["iliad.txt"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``One file, several matches, inverted and match entire lines flags`` () =
        files <- ["iliad.txt"]
        flags <- ["-x"; "-v"]
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
        grep files flags pattern |> should equal expected

        member this.``Multiple files, one match, no flags`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- []
        pattern <- "Agamemnon"
        expected <- ["iliad.txt:Of Atreus, Agamemnon, King of men."]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``Multiple files, several matches, no flags`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- []
        pattern <- "may"
        expected <- 
            [ "midsummer-night.txt:Nor how it may concern my modesty,";
              "midsummer-night.txt:But I beseech your grace that I may know";
              "midsummer-night.txt:The worst that may befall me in this case," ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``Multiple files, several matches, print line numbers flag`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- ["-n"]
        pattern <- "that"
        expected <- 
            [ "midsummer-night.txt:5:But I beseech your grace that I may know";
              "midsummer-night.txt:6:The worst that may befall me in this case,";
              "paradise-lost.txt:2:Of that Forbidden Tree, whose mortal tast";
              "paradise-lost.txt:6:Sing Heav'nly Muse, that on the secret top" ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``Multiple files, one match, print file names flag`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- ["-l"]
        pattern <- "who"
        expected <- 
            [ "iliad.txt";
              "paradise-lost.txt" ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``Multiple files, several matches, case-insensitive flag`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- ["-i"]
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
        grep files flags pattern |> should equal expected

        member this.``Multiple files, several matches, inverted flag`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- ["-v"]
        pattern <- "a"
        expected <- 
            [ "iliad.txt:Achilles sing, O Goddess! Peleus' son;";
              "iliad.txt:The noble Chief Achilles from the son";
              "midsummer-night.txt:If I refuse to wed Demetrius." ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``Multiple files, one match, match entire lines flag`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- ["-x"]
        pattern <- "But I beseech your grace that I may know"
        expected <- ["midsummer-night.txt:But I beseech your grace that I may know"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``Multiple files, one match, multiple flags`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- ["-n"; "-i"; "-x"]
        pattern <- "WITH LOSS OF EDEN, TILL ONE GREATER MAN"
        expected <- ["paradise-lost.txt:4:With loss of Eden, till one greater Man"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``Multiple files, no matches, various flags`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- ["-n"; "-l"; "-x"; "-i"]
        pattern <- "Frodo"
        let expected: string list = []
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``Multiple files, several matches, file flag takes precedence over line number flag`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- ["-n"; "-l"]
        pattern <- "who"
        expected <- 
            [ "iliad.txt";
              "paradise-lost.txt" ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

        member this.``Multiple files, several matches, inverted and match entire lines flags`` () =
        files <- ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        flags <- ["-x"; "-v"]
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
        grep files flags pattern |> should equal expected

