module AnagramTest

open System
open Xunit
open FsUnit.Xunit
open Anagram

[<Fact>]
let ``No matches`` () =
    let words = ["hello"; "world"; "zombies"; "pants"]
    anagrams words "diaper" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Detect simple anagram`` () =
    let words = ["tan"; "stand"; "at"]
    let expected = ["tan"]
    anagrams words "ant" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Detect multiple anagrams`` () =
    let words = ["stream"; "pigeon"; "maters"]
    let expected = ["stream"; "maters"]
    anagrams words "master" |> should equal expected;

[<Fact(Skip = "Remove to run test")>]
let ``Does not confuse different duplicates`` () =
    let words = ["eagle"]
    anagrams words "galea" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Identical word is not anagram`` () =
    let words = ["corn"; "dark"; "Corn"; "rank"; "CORN"; "cron"; "park"]
    let expected = ["cron"]
    anagrams words "corn" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Eliminate anagrams with same checksum`` () =
    let words = ["last"]
    anagrams words "mass" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Eliminate anagram subsets`` () =
    let words = ["dog"; "goody"]
    anagrams words "good" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Detect anagrams`` () =
    let words = ["gallery"; "ballerina"; "regally"; "clergy"; "largely"; "leading"]
    let expected = ["gallery"; "regally"; "largely"]
    let actual = anagrams words "allergy"
    actual |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Anagrams are case insensitive`` () =
    let words = ["cashregister"; "Carthorse"; "radishes"]
    let expected = ["Carthorse"]
    anagrams words "Orchestra" |> should equal expected