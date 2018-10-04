// This file was auto-generated based on version 1.3.0 of the canonical data.

module AnagramTest

open FsUnit.Xunit
open Xunit

open Anagram

[<Fact>]
let ``No matches`` () =
    let candidates = ["hello"; "world"; "zombies"; "pants"]
    findAnagrams candidates "diaper" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Detects two anagrams`` () =
    let candidates = ["stream"; "pigeon"; "maters"]
    findAnagrams candidates "master" |> should equal ["stream"; "maters"]

[<Fact(Skip = "Remove to run test")>]
let ``Does not detect anagram subsets`` () =
    let candidates = ["dog"; "goody"]
    findAnagrams candidates "good" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Detects anagram`` () =
    let candidates = ["enlists"; "google"; "inlets"; "banana"]
    findAnagrams candidates "listen" |> should equal ["inlets"]

[<Fact(Skip = "Remove to run test")>]
let ``Detects three anagrams`` () =
    let candidates = ["gallery"; "ballerina"; "regally"; "clergy"; "largely"; "leading"]
    findAnagrams candidates "allergy" |> should equal ["gallery"; "regally"; "largely"]

[<Fact(Skip = "Remove to run test")>]
let ``Does not detect non-anagrams with identical checksum`` () =
    let candidates = ["last"]
    findAnagrams candidates "mass" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Detects anagrams case-insensitively`` () =
    let candidates = ["cashregister"; "Carthorse"; "radishes"]
    findAnagrams candidates "Orchestra" |> should equal ["Carthorse"]

[<Fact(Skip = "Remove to run test")>]
let ``Detects anagrams using case-insensitive subject`` () =
    let candidates = ["cashregister"; "carthorse"; "radishes"]
    findAnagrams candidates "Orchestra" |> should equal ["carthorse"]

[<Fact(Skip = "Remove to run test")>]
let ``Detects anagrams using case-insensitive possible matches`` () =
    let candidates = ["cashregister"; "Carthorse"; "radishes"]
    findAnagrams candidates "orchestra" |> should equal ["Carthorse"]

[<Fact(Skip = "Remove to run test")>]
let ``Does not detect a anagram if the original word is repeated`` () =
    let candidates = ["go Go GO"]
    findAnagrams candidates "go" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Anagrams must use all letters exactly once`` () =
    let candidates = ["patter"]
    findAnagrams candidates "tapper" |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Capital word is not own anagram`` () =
    let candidates = ["Banana"]
    findAnagrams candidates "BANANA" |> should be Empty

