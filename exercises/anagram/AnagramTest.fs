module AnagramTest

open System
open Xunit
open FsUnit
open Anagram

[Fact]
let ``No matches`` () =
    let words = ["hello"; "world"; "zombies"; "pants"]
    let expected = []
    anagrams words "diaper" |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Detect simple anagram`` () =
    let words = ["tan"; "stand"; "at"]
    let expected = ["tan"]
    anagrams words "ant" |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Detect multiple anagrams`` () =
    let words = ["stream"; "pigeon"; "maters"]
    let expected = ["maters"; "stream"]
    anagrams words "master" |> should equal expected;

[Fact(Skip = "Remove to run test")]
let ``Does not confuse different duplicates`` () =
    let words = ["eagle"]
    let expected = []
    anagrams words "galea" |> should equal expected;

[Fact(Skip = "Remove to run test")]
let ``Identical word is not anagram`` () =
    let words = ["corn"; "dark"; "Corn"; "rank"; "CORN"; "cron"; "park"]
    let expected = ["cron"]
    anagrams words "corn" |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Eliminate anagrams with same checksum`` () =
    let words = ["last"]
    let expected = []
    anagrams words "mass" |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Eliminate anagram subsets`` () =
    let words = ["dog"; "goody"]
    let expected = []
    anagrams words "good" |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Detect anagrams`` () =
    let words = ["gallery"; "ballerina"; "regally"; "clergy"; "largely"; "leading"]
    let expected = ["gallery"; "largely"; "regally"]
    let actual = anagrams words "allergy"
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Anagrams are case insensitive`` () =
    let words = ["cashregister"; "Carthorse"; "radishes"]
    let expected = ["Carthorse"]
    anagrams words "Orchestra" |> should equal expected