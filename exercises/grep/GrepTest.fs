module GrepTest

open NUnit.Framework

open Grep

open System.IO

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
Of Atreus, Agamemnon, King of men.
"""

let midsummerNightFileName = "midsummer-night.txt"
let midsummerNightContents = 
    """I do entreat your grace to pardon me.
I know not by what power I am made bold,
Nor how it may concern my modesty,
In such a presence here to plead my thoughts;
But I beseech your grace that I may know
The worst that may befall me in this case,
If I refuse to wed Demetrius.
"""

let paradiseLostFileName = "paradise-lost.txt"
let paradiseLostContents = 
    """Of Mans First Disobedience, and the Fruit
Of that Forbidden Tree, whose mortal tast
Brought Death into the World, and all our woe,
With loss of Eden, till one greater Man
Restore us, and regain the blissful Seat,
Sing Heav'nly Muse, that on the secret top
Of Oreb, or of Sinai, didst inspire
That Shepherd, who first taught the chosen Seed
"""

[<OneTimeSetUp>]
let setUp () =
    Directory.SetCurrentDirectory(Path.GetTempPath());
    File.WriteAllText(iliadFileName, iliadContents)
    File.WriteAllText(midsummerNightFileName, midsummerNightContents)
    File.WriteAllText(paradiseLostFileName, paradiseLostContents)

[<OneTimeTearDown>]
let tearDown () =
    File.Delete(iliadFileName)
    File.Delete(midsummerNightFileName)
    File.Delete(paradiseLostFileName)

[<Test>]
let ``One file, one match, no flags`` () =
    let pattern = "Agamemnon"
    let flags = ""
    let files = [iliadFileName]

    let expected = 
        "Of Atreus, Agamemnon, King of men.\n"
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, one match, print line numbers flag`` () =
    let pattern = "Forbidden"
    let flags = "-n"
    let files = [paradiseLostFileName]

    let expected = 
        "2:Of that Forbidden Tree, whose mortal tast\n"
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, one match, case-insensitive flag`` () =
    let pattern = "Forbidden"
    let flags = "-i"
    let files = [paradiseLostFileName]

    let expected = 
        "Of that Forbidden Tree, whose mortal tast\n"
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, one match, print file names flag`` () =
    let pattern = "Forbidden"
    let flags = "-l"
    let files = [paradiseLostFileName]

    let expected = 
        sprintf "%s\n" paradiseLostFileName
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, one match, match entire lines flag`` () =
    let pattern = "With loss of Eden, till one greater Man"
    let flags = "-x"
    let files = [paradiseLostFileName]

    let expected = 
        "With loss of Eden, till one greater Man\n"
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, one match, multiple flags`` () =
    let pattern = "OF ATREUS, Agamemnon, KIng of MEN."
    let files = [iliadFileName]
    let flags = "-n -i -x"
    let expected = 
        "9:Of Atreus, Agamemnon, King of men.\n"
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, several matches, no flags`` () =
    let pattern = "may"
    let flags = ""
    let files = [midsummerNightFileName]

    let expected = 
        "Nor how it may concern my modesty,\n" +
        "But I beseech your grace that I may know\n" +
        "The worst that may befall me in this case,\n"
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, several matches, print line numbers flag`` () =
    let pattern = "may"
    let flags = "-n"
    let files = [midsummerNightFileName]

    let expected = 
        "3:Nor how it may concern my modesty,\n" +
        "5:But I beseech your grace that I may know\n" +
        "6:The worst that may befall me in this case,\n"
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, several matches, match entire lines flag`` () =
    let pattern = "may"
    let flags = "-x"
    let files = [midsummerNightFileName]

    let expected = ""
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, several matches, case-insensitive flag`` () =
    let pattern = "ACHILLES"
    let flags = "-i"
    let files = [iliadFileName]

    let expected = 
        "Achilles sing, O Goddess! Peleus' son;\n" + 
        "The noble Chief Achilles from the son\n"
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, several matches, inverted flag`` () =
    let pattern = "Of"
    let flags = "-v"
    let files = [paradiseLostFileName]

    let expected =             
        "Brought Death into the World, and all our woe,\n" + 
        "With loss of Eden, till one greater Man\n" + 
        "Restore us, and regain the blissful Seat,\n" + 
        "Sing Heav'nly Muse, that on the secret top\n" + 
        "That Shepherd, who first taught the chosen Seed\n"
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, case-insensitive and entire line flags`` () =
    let pattern = "ATREUS"
    let files = [iliadFileName]
    let flags = "-i -x"
    let expected = ""
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, case-insensitive and inverted flags`` () =
    let pattern = "THE"
    let files = [paradiseLostFileName]
    let flags = "-i -v"
    let expected =
        "Of that Forbidden Tree, whose mortal tast\n" +
        "With loss of Eden, till one greater Man\n" +
        "Of Oreb, or of Sinai, didst inspire\n"

    Assert.That(grep pattern flags files, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, inverted and entire line flags`` () =
    let pattern = "the"
    let files = [paradiseLostFileName]
    let flags = "-v -x"
    let expected =
        "Of Mans First Disobedience, and the Fruit\n" +
        "Of that Forbidden Tree, whose mortal tast\n" +
        "Brought Death into the World, and all our woe,\n" +
        "With loss of Eden, till one greater Man\n" +
        "Restore us, and regain the blissful Seat,\n" +
        "Sing Heav'nly Muse, that on the secret top\n" +
        "Of Oreb, or of Sinai, didst inspire\n" +
        "That Shepherd, who first taught the chosen Seed\n"

    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One file, case-insensitive, inverted and entire line flags`` () =
    let pattern = "if i rEFuse To Wed DeMETrius."
    let files = [midsummerNightFileName]
    let flags = "-i -v -x"
    let expected =
        "I do entreat your grace to pardon me.\n" +
        "I know not by what power I am made bold,\n" +
        "Nor how it may concern my modesty,\n" +
        "In such a presence here to plead my thoughts;\n" +
        "But I beseech your grace that I may know\n" +
        "The worst that may befall me in this case,\n"

    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<TestCase("", Ignore = "Remove to run test case")>]
[<TestCase("-n", Ignore = "Remove to run test case")>]
[<TestCase("-l", Ignore = "Remove to run test case")>]
[<TestCase("-x", Ignore = "Remove to run test case")>]
[<TestCase("-i", Ignore = "Remove to run test case")>]
[<TestCase("-n -l -x -i", Ignore = "Remove to run test case")>]
let ``One file, no matches, various flags`` (flags) =
    let pattern = "Gandalf"
    let files = [iliadFileName]
    let expected = ""
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple files, one match, no flags`` () =
    let pattern = "Agamemnon"
    let flags = ""
    let files = [iliadFileName; midsummerNightFileName; paradiseLostFileName]

    let expected = 
        sprintf "%s:Of Atreus, Agamemnon, King of men.\n" iliadFileName
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple files, several matches, no flags`` () =
    let pattern = "may"
    let flags = ""
    let files = [iliadFileName; midsummerNightFileName; paradiseLostFileName]

    let expected = 
        sprintf "%s:Nor how it may concern my modesty,\n" midsummerNightFileName +
        sprintf "%s:But I beseech your grace that I may know\n" midsummerNightFileName +
        sprintf "%s:The worst that may befall me in this case,\n" midsummerNightFileName
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple files, several matches, print line numbers flag`` () =
    let pattern = "that"
    let flags = "-n"
    let files = [iliadFileName; midsummerNightFileName; paradiseLostFileName]

    let expected = 
        sprintf "%s:5:But I beseech your grace that I may know\n" midsummerNightFileName +
        sprintf "%s:6:The worst that may befall me in this case,\n" midsummerNightFileName +
        sprintf "%s:2:Of that Forbidden Tree, whose mortal tast\n" paradiseLostFileName +
        sprintf "%s:6:Sing Heav'nly Muse, that on the secret top\n" paradiseLostFileName
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple files, several matches, print file names flag`` () =
    let pattern = "who"
    let flags = "-l"
    let files = [iliadFileName; midsummerNightFileName; paradiseLostFileName]

    let expected = 
        sprintf "%s\n" iliadFileName +
        sprintf "%s\n" paradiseLostFileName
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple files, several matches, case-insensitive flag`` () =
    let pattern = "TO"
    let flags = "-i"
    let files = [iliadFileName; midsummerNightFileName; paradiseLostFileName]

    let expected = 
        sprintf "%s:Caused to Achaia's host, sent many a soul\n" iliadFileName +
        sprintf "%s:Illustrious into Ades premature,\n" iliadFileName +
        sprintf "%s:And Heroes gave (so stood the will of Jove)\n" iliadFileName +
        sprintf "%s:To dogs and to all ravening fowls a prey,\n" iliadFileName +
        sprintf "%s:I do entreat your grace to pardon me.\n" midsummerNightFileName +
        sprintf "%s:In such a presence here to plead my thoughts;\n" midsummerNightFileName +
        sprintf "%s:If I refuse to wed Demetrius.\n" midsummerNightFileName +
        sprintf "%s:Brought Death into the World, and all our woe,\n" paradiseLostFileName +
        sprintf "%s:Restore us, and regain the blissful Seat,\n" paradiseLostFileName +
        sprintf "%s:Sing Heav'nly Muse, that on the secret top\n" paradiseLostFileName 
            
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple files, several matches, inverted flag`` () =
    let pattern = "a"
    let flags = "-v"
    let files = [iliadFileName; midsummerNightFileName; paradiseLostFileName]

    let expected = 
        sprintf "%s:Achilles sing, O Goddess! Peleus' son;\n" iliadFileName +
        sprintf "%s:The noble Chief Achilles from the son\n" iliadFileName +
        sprintf "%s:If I refuse to wed Demetrius.\n" midsummerNightFileName
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple files, one match, match entire lines flag`` () =
    let pattern = "But I beseech your grace that I may know"
    let flags = "-x"
    let files = [iliadFileName; midsummerNightFileName; paradiseLostFileName]

    let expected = 
        sprintf "%s:But I beseech your grace that I may know\n" midsummerNightFileName
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple files, one match, multiple flags`` () =
    let pattern = "WITH LOSS OF EDEN, TILL ONE GREATER MAN"
    let files = [iliadFileName; midsummerNightFileName; paradiseLostFileName]
    let flags = "-n -i -x"
    let expected = 
        sprintf "%s:4:With loss of Eden, till one greater Man\n" paradiseLostFileName
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))

[<TestCase("", Ignore = "Remove to run test case")>]
[<TestCase("-n", Ignore = "Remove to run test case")>]
[<TestCase("-l", Ignore = "Remove to run test case")>]
[<TestCase("-x", Ignore = "Remove to run test case")>]
[<TestCase("-i", Ignore = "Remove to run test case")>]
[<TestCase("-n -l -x -i", Ignore = "Remove to run test case")>]
let ``Multiple files, no matches, various flags`` (flags) =
    let pattern = "Frodo"
    let files = [iliadFileName; midsummerNightFileName; paradiseLostFileName]

    let expected = ""
    
    Assert.That(grep pattern flags files, Is.EqualTo(expected))
