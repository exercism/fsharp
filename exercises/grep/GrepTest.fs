// This file was auto-generated based on version 1.1.0 of the canonical data.

module GrepTest

open FsUnit.Xunit
open Xunit
open System.IO

open Grep

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

type GrepTest() =

    [<Fact>]
    member this.``One file, one match, no flags`` () =
        let files = ["iliad.txt"]
        let flags = []
        let pattern = "Agamemnon"
        let expected = ["Of Atreus, Agamemnon, King of men."]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, one match, print line numbers flag`` () =
        let files = ["paradise-lost.txt"]
        let flags = ["-n"]
        let pattern = "Forbidden"
        let expected = ["2:Of that Forbidden Tree, whose mortal tast"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, one match, case-insensitive flag`` () =
        let files = ["paradise-lost.txt"]
        let flags = ["-i"]
        let pattern = "FORBIDDEN"
        let expected = ["Of that Forbidden Tree, whose mortal tast"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, one match, print file names flag`` () =
        let files = ["paradise-lost.txt"]
        let flags = ["-l"]
        let pattern = "Forbidden"
        let expected = ["paradise-lost.txt"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, one match, match entire lines flag`` () =
        let files = ["paradise-lost.txt"]
        let flags = ["-x"]
        let pattern = "With loss of Eden, till one greater Man"
        let expected = ["With loss of Eden, till one greater Man"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, one match, multiple flags`` () =
        let files = ["iliad.txt"]
        let flags = ["-n"; "-i"; "-x"]
        let pattern = "OF ATREUS, Agamemnon, KIng of MEN."
        let expected = ["9:Of Atreus, Agamemnon, King of men."]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, several matches, no flags`` () =
        let files = ["midsummer-night.txt"]
        let flags = []
        let pattern = "may"
        let expected = 
            [ "Nor how it may concern my modesty,";
              "But I beseech your grace that I may know";
              "The worst that may befall me in this case," ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, several matches, print line numbers flag`` () =
        let files = ["midsummer-night.txt"]
        let flags = ["-n"]
        let pattern = "may"
        let expected = 
            [ "3:Nor how it may concern my modesty,";
              "5:But I beseech your grace that I may know";
              "6:The worst that may befall me in this case," ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, several matches, match entire lines flag`` () =
        let files = ["midsummer-night.txt"]
        let flags = ["-x"]
        let pattern = "may"
        let expected: string list = []
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, several matches, case-insensitive flag`` () =
        let files = ["iliad.txt"]
        let flags = ["-i"]
        let pattern = "ACHILLES"
        let expected = 
            [ "Achilles sing, O Goddess! Peleus' son;";
              "The noble Chief Achilles from the son" ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, several matches, inverted flag`` () =
        let files = ["paradise-lost.txt"]
        let flags = ["-v"]
        let pattern = "Of"
        let expected = 
            [ "Brought Death into the World, and all our woe,";
              "With loss of Eden, till one greater Man";
              "Restore us, and regain the blissful Seat,";
              "Sing Heav'nly Muse, that on the secret top";
              "That Shepherd, who first taught the chosen Seed" ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``One file, no matches, various flags`` () =
        let files = ["iliad.txt"]
        let flags = ["-n"; "-l"; "-x"; "-i"]
        let pattern = "Gandalf"
        let expected: string list = []
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``Multiple files, one match, no flags`` () =
        let files = ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        let flags = []
        let pattern = "Agamemnon"
        let expected = ["iliad.txt:Of Atreus, Agamemnon, King of men."]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``Multiple files, several matches, no flags`` () =
        let files = ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        let flags = []
        let pattern = "may"
        let expected = 
            [ "midsummer-night.txt:Nor how it may concern my modesty,";
              "midsummer-night.txt:But I beseech your grace that I may know";
              "midsummer-night.txt:The worst that may befall me in this case," ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``Multiple files, several matches, print line numbers flag`` () =
        let files = ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        let flags = ["-n"]
        let pattern = "that"
        let expected = 
            [ "midsummer-night.txt:5:But I beseech your grace that I may know";
              "midsummer-night.txt:6:The worst that may befall me in this case,";
              "paradise-lost.txt:2:Of that Forbidden Tree, whose mortal tast";
              "paradise-lost.txt:6:Sing Heav'nly Muse, that on the secret top" ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``Multiple files, one match, print file names flag`` () =
        let files = ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        let flags = ["-l"]
        let pattern = "who"
        let expected = 
            [ "iliad.txt";
              "paradise-lost.txt" ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``Multiple files, several matches, case-insensitive flag`` () =
        let files = ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        let flags = ["-i"]
        let pattern = "TO"
        let expected = 
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

    [<Fact(Skip = "Remove to run test")>]
    member this.``Multiple files, several matches, inverted flag`` () =
        let files = ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        let flags = ["-v"]
        let pattern = "a"
        let expected = 
            [ "iliad.txt:Achilles sing, O Goddess! Peleus' son;";
              "iliad.txt:The noble Chief Achilles from the son";
              "midsummer-night.txt:If I refuse to wed Demetrius." ]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``Multiple files, one match, match entire lines flag`` () =
        let files = ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        let flags = ["-x"]
        let pattern = "But I beseech your grace that I may know"
        let expected = ["midsummer-night.txt:But I beseech your grace that I may know"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``Multiple files, one match, multiple flags`` () =
        let files = ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        let flags = ["-n"; "-i"; "-x"]
        let pattern = "WITH LOSS OF EDEN, TILL ONE GREATER MAN"
        let expected = ["paradise-lost.txt:4:With loss of Eden, till one greater Man"]
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

    [<Fact(Skip = "Remove to run test")>]
    member this.``Multiple files, no matches, various flags`` () =
        let files = ["iliad.txt"; "midsummer-night.txt"; "paradise-lost.txt"]
        let flags = ["-n"; "-l"; "-x"; "-i"]
        let pattern = "Frodo"
        let expected: string list = []
        
        createFiles() |> ignore
        grep files flags pattern |> should equal expected

