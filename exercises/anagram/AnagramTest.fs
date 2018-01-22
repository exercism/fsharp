// This file was auto-generated based on version 1.2.0 of the canonical data.

module AnagramTest

open FsUnit.Xunit
open Xunit

open Anagram

[<Fact>]
let ``No matches`` () =
    let candidates = ["hello"; "world"; "zombies"; "pants"]
    anagrams candidates "diaper" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Detects two anagrams`` () =
    let candidates = ["stream"; "pigeon"; "maters"]
    anagrams candidates "master" |> should equal ["stream"; "maters"]

[<Fact(Skip = "Remove to run test")>]
let ``Does not detect anagram subsets`` () =
    let candidates = ["dog"; "goody"]
    anagrams candidates "good" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Detects anagram`` () =
    let candidates = ["enlists"; "google"; "inlets"; "banana"]
    anagrams candidates "listen" |> should equal ["inlets"]

[<Fact(Skip = "Remove to run test")>]
let ``Detects three anagrams`` () =
    let candidates = ["gallery"; "ballerina"; "regally"; "clergy"; "largely"; "leading"]
    anagrams candidates "allergy" |> should equal ["gallery"; "regally"; "largely"]

[<Fact(Skip = "Remove to run test")>]
let ``Does not detect non-anagrams with identical checksum`` () =
    let candidates = ["last"]
    anagrams candidates "mass" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Detects anagrams case-insensitively`` () =
    let candidates = ["cashregister"; "Carthorse"; "radishes"]
    anagrams candidates "Orchestra" |> should equal ["Carthorse"]

[<Fact(Skip = "Remove to run test")>]
let ``Detects anagrams using case-insensitive subject`` () =
    let candidates = ["cashregister"; "carthorse"; "radishes"]
    anagrams candidates "Orchestra" |> should equal ["carthorse"]

[<Fact(Skip = "Remove to run test")>]
let ``Detects anagrams using case-insensitive possible matches`` () =
    let candidates = ["cashregister"; "Carthorse"; "radishes"]
    anagrams candidates "orchestra" |> should equal ["Carthorse"]

[<Fact(Skip = "Remove to run test")>]
let ``Does not detect a anagram if the original word is repeated`` () =
    let candidates = ["go Go GO"]
    anagrams candidates "go" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Anagrams must use all letters exactly once`` () =
    let candidates = ["patter"]
    anagrams candidates "tapper" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Capital word is not own anagram`` () =
    let candidates = ["Banana"]
    anagrams candidates "BANANA" |> should be Empty

