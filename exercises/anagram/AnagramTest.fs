module AnagramTest

open System
open NUnit.Framework
open Anagram

[<Test>]
let ``No matches`` () =
    let words = ["hello"; "world"; "zombies"; "pants"]
    let expected = []
    Assert.That(anagrams words "diaper", Is.EquivalentTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Detect simple anagram`` () =
    let words = ["tan"; "stand"; "at"]
    let expected = ["tan"]
    Assert.That(anagrams words "ant", Is.EquivalentTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Detect multiple anagrams`` () =
    let words = ["stream"; "pigeon"; "maters"]
    let expected = ["maters"; "stream"]
    Assert.That(anagrams words "master", Is.EquivalentTo(expected));

[<Test>]
[<Ignore("Remove to run test")>]
let ``Does not confuse different duplicates`` () =
    let words = ["eagle"]
    let expected = []
    Assert.That(anagrams words "galea", Is.EquivalentTo(expected));

[<Test>]
[<Ignore("Remove to run test")>]
let ``Identical word is not anagram`` () =
    let words = ["corn"; "dark"; "Corn"; "rank"; "CORN"; "cron"; "park"]
    let expected = ["cron"]
    Assert.That(anagrams words "corn", Is.EquivalentTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Eliminate anagrams with same checksum`` () =
    let words = ["last"]
    let expected = []
    Assert.That(anagrams words "mass", Is.EquivalentTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Eliminate anagram subsets`` () =
    let words = ["dog"; "goody"]
    let expected = []
    Assert.That(anagrams words "good", Is.EquivalentTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Detect anagrams`` () =
    let words = ["gallery"; "ballerina"; "regally"; "clergy"; "largely"; "leading"]
    let expected = ["gallery"; "largely"; "regally"]
    let actual = anagrams words "allergy"
    Assert.That(actual, Is.EquivalentTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Anagrams are case insensitive`` () =
    let words = ["cashregister"; "Carthorse"; "radishes"]
    let expected = ["Carthorse"]
    Assert.That(anagrams words "Orchestra", Is.EquivalentTo(expected))