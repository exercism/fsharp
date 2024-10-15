source("./grep.R")
library(testthat)



let iliadFileName = "iliad.txt"
let iliadContents = 
    """Achilles sing, O Goddess! Peleus' son;
His wrath pernicious, who ten thousand woes
Caused to Achaia's host, sent many a soul
Illustrious into Ades premature,
And Heroes gave (so stood the will of Jove)
To dogs and to all ravening fowls a prey,
When fierce dispute had separated once
The noble Chief Achilles from the son
Of Atreus, Agamemnon, King of men."""

let midsummerNightFileName = "midsummer-night.txt"
let midsummerNightContents = 
    """I do entreat your grace to pardon me.
I know not by what power I am made bold,
Nor how it may concern my modesty,
In such a presence here to plead my thoughts;
But I beseech your grace that I may know
The worst that may befall me in this case,
If I refuse to wed Demetrius."""

let paradiseLostFileName = "paradise-lost.txt"
let paradiseLostContents = 
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

    
    member this.``One file, one match, no flags", {
        let files = c("iliad.txt")
        let flags = c()
        let pattern = "Agamemnon"
      expected <- c("Of Atreus, Agamemnon, King of men.")
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, one match, print line numbers flag", {
        let files = c("paradise-lost.txt")
        let flags = c("-n")
        let pattern = "Forbidden"
      expected <- c("2:Of that Forbidden Tree, whose mortal tast")
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, one match, case-insensitive flag", {
        let files = c("paradise-lost.txt")
        let flags = c("-i")
        let pattern = "FORBIDDEN"
      expected <- c("Of that Forbidden Tree, whose mortal tast")
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, one match, print file names flag", {
        let files = c("paradise-lost.txt")
        let flags = c("-l")
        let pattern = "Forbidden"
      expected <- c("paradise-lost.txt")
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, one match, match entire lines flag", {
        let files = c("paradise-lost.txt")
        let flags = c("-x")
        let pattern = "With loss of Eden, till one greater Man"
      expected <- c("With loss of Eden, till one greater Man")
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, one match, multiple flags", {
        let files = c("iliad.txt")
        let flags = c("-n", "-i", "-x")
        let pattern = "OF ATREUS, Agamemnon, KIng of MEN."
      expected <- c("9:Of Atreus, Agamemnon, King of men.")
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, several matches, no flags", {
        let files = c("midsummer-night.txt")
        let flags = c()
        let pattern = "may"
      expected <- 
            c( "Nor how it may concern my modesty,",
              "But I beseech your grace that I may know",
              "The worst that may befall me in this case," )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, several matches, print line numbers flag", {
        let files = c("midsummer-night.txt")
        let flags = c("-n")
        let pattern = "may"
      expected <- 
            c( "3:Nor how it may concern my modesty,",
              "5:But I beseech your grace that I may know",
              "6:The worst that may befall me in this case," )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, several matches, match entire lines flag", {
        let files = c("midsummer-night.txt")
        let flags = c("-x")
        let pattern = "may"
        let expected: string list = c()
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, several matches, case-insensitive flag", {
        let files = c("iliad.txt")
        let flags = c("-i")
        let pattern = "ACHILLES"
      expected <- 
            c( "Achilles sing, O Goddess! Peleus' son;",
              "The noble Chief Achilles from the son" )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, several matches, inverted flag", {
        let files = c("paradise-lost.txt")
        let flags = c("-v")
        let pattern = "Of"
      expected <- 
            c( "Brought Death into the World, and all our woe,",
              "With loss of Eden, till one greater Man",
              "Restore us, and regain the blissful Seat,",
              "Sing Heav'nly Muse, that on the secret top",
              "That Shepherd, who first taught the chosen Seed" )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, no matches, various flags", {
        let files = c("iliad.txt")
        let flags = c("-n", "-l", "-x", "-i")
        let pattern = "Gandalf"
        let expected: string list = c()
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, one match, file flag takes precedence over line flag", {
        let files = c("iliad.txt")
        let flags = c("-n", "-l")
        let pattern = "ten"
      expected <- c("iliad.txt")
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``One file, several matches, inverted and match entire lines flags", {
        let files = c("iliad.txt")
        let flags = c("-x", "-v")
        let pattern = "Illustrious into Ades premature,"
      expected <- 
            c( "Achilles sing, O Goddess! Peleus' son;",
              "His wrath pernicious, who ten thousand woes",
              "Caused to Achaia's host, sent many a soul",
              "And Heroes gave (so stood the will of Jove)",
              "To dogs and to all ravening fowls a prey,",
              "When fierce dispute had separated once",
              "The noble Chief Achilles from the son",
              "Of Atreus, Agamemnon, King of men." )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, one match, no flags", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c()
        let pattern = "Agamemnon"
      expected <- c("iliad.txt:Of Atreus, Agamemnon, King of men.")
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, several matches, no flags", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c()
        let pattern = "may"
      expected <- 
            c( "midsummer-night.txt:Nor how it may concern my modesty,",
              "midsummer-night.txt:But I beseech your grace that I may know",
              "midsummer-night.txt:The worst that may befall me in this case," )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, several matches, print line numbers flag", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c("-n")
        let pattern = "that"
      expected <- 
            c( "midsummer-night.txt:5:But I beseech your grace that I may know",
              "midsummer-night.txt:6:The worst that may befall me in this case,",
              "paradise-lost.txt:2:Of that Forbidden Tree, whose mortal tast",
              "paradise-lost.txt:6:Sing Heav'nly Muse, that on the secret top" )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, one match, print file names flag", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c("-l")
        let pattern = "who"
      expected <- 
            c( "iliad.txt",
              "paradise-lost.txt" )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, several matches, case-insensitive flag", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c("-i")
        let pattern = "TO"
      expected <- 
            c( "iliad.txt:Caused to Achaia's host, sent many a soul",
              "iliad.txt:Illustrious into Ades premature,",
              "iliad.txt:And Heroes gave (so stood the will of Jove)",
              "iliad.txt:To dogs and to all ravening fowls a prey,",
              "midsummer-night.txt:I do entreat your grace to pardon me.",
              "midsummer-night.txt:In such a presence here to plead my thoughts;",
              "midsummer-night.txt:If I refuse to wed Demetrius.",
              "paradise-lost.txt:Brought Death into the World, and all our woe,",
              "paradise-lost.txt:Restore us, and regain the blissful Seat,",
              "paradise-lost.txt:Sing Heav'nly Muse, that on the secret top" )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, several matches, inverted flag", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c("-v")
        let pattern = "a"
      expected <- 
            c( "iliad.txt:Achilles sing, O Goddess! Peleus' son;",
              "iliad.txt:The noble Chief Achilles from the son",
              "midsummer-night.txt:If I refuse to wed Demetrius." )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, one match, match entire lines flag", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c("-x")
        let pattern = "But I beseech your grace that I may know"
      expected <- c("midsummer-night.txt:But I beseech your grace that I may know")
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, one match, multiple flags", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c("-n", "-i", "-x")
        let pattern = "WITH LOSS OF EDEN, TILL ONE GREATER MAN"
      expected <- c("paradise-lost.txt:4:With loss of Eden, till one greater Man")
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, no matches, various flags", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c("-n", "-l", "-x", "-i")
        let pattern = "Frodo"
        let expected: string list = c()
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, several matches, file flag takes precedence over line number flag", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c("-n", "-l")
        let pattern = "who"
      expected <- 
            c( "iliad.txt",
              "paradise-lost.txt" )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})    
    member this.``Multiple files, several matches, inverted and match entire lines flags", {
        let files = c("iliad.txt", "midsummer-night.txt", "paradise-lost.txt")
        let flags = c("-x", "-v")
        let pattern = "Illustrious into Ades premature,"
      expected <- 
            c( "iliad.txt:Achilles sing, O Goddess! Peleus' son;",
              "iliad.txt:His wrath pernicious, who ten thousand woes",
              "iliad.txt:Caused to Achaia's host, sent many a soul",
              "iliad.txt:And Heroes gave (so stood the will of Jove)",
              "iliad.txt:To dogs and to all ravening fowls a prey,",
              "iliad.txt:When fierce dispute had separated once",
              "iliad.txt:The noble Chief Achilles from the son",
              "iliad.txt:Of Atreus, Agamemnon, King of men.",
              "midsummer-night.txt:I do entreat your grace to pardon me.",
              "midsummer-night.txt:I know not by what power I am made bold,",
              "midsummer-night.txt:Nor how it may concern my modesty,",
              "midsummer-night.txt:In such a presence here to plead my thoughts;",
              "midsummer-night.txt:But I beseech your grace that I may know",
              "midsummer-night.txt:The worst that may befall me in this case,",
              "midsummer-night.txt:If I refuse to wed Demetrius.",
              "paradise-lost.txt:Of Mans First Disobedience, and the Fruit",
              "paradise-lost.txt:Of that Forbidden Tree, whose mortal tast",
              "paradise-lost.txt:Brought Death into the World, and all our woe,",
              "paradise-lost.txt:With loss of Eden, till one greater Man",
              "paradise-lost.txt:Restore us, and regain the blissful Seat,",
              "paradise-lost.txt:Sing Heav'nly Muse, that on the secret top",
              "paradise-lost.txt:Of Oreb, or of Sinai, didst inspire",
              "paradise-lost.txt:That Shepherd, who first taught the chosen Seed" )
        
        createFiles() |> ignore
  expect_equal(    grep files flags pattern, expected)
})