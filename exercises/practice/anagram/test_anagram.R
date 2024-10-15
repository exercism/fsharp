module AnagramTests

open FsUnit.Xunit
open Xunit

open Anagram

[<Fact>]
let ``No matches`` () =
    let candidates = ["hello"; "world"; "zombies"; "pants"]
    findAnagrams candidates "diaper" |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Detects two anagrams`` () =
    let candidates = ["lemons"; "cherry"; "melons"]
    findAnagrams candidates "solemn" |> should equal ["lemons"; "melons"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Does not detect anagram subsets`` () =
    let candidates = ["dog"; "goody"]
    findAnagrams candidates "good" |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Detects anagram`` () =
    let candidates = ["enlists"; "google"; "inlets"; "banana"]
    findAnagrams candidates "listen" |> should equal ["inlets"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Detects three anagrams`` () =
    let candidates = ["gallery"; "ballerina"; "regally"; "clergy"; "largely"; "leading"]
    findAnagrams candidates "allergy" |> should equal ["gallery"; "regally"; "largely"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Detects multiple anagrams with different case`` () =
    let candidates = ["Eons"; "ONES"]
    findAnagrams candidates "nose" |> should equal ["Eons"; "ONES"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Does not detect non-anagrams with identical checksum`` () =
    let candidates = ["last"]
    findAnagrams candidates "mass" |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Detects anagrams case-insensitively`` () =
    let candidates = ["cashregister"; "Carthorse"; "radishes"]
    findAnagrams candidates "Orchestra" |> should equal ["Carthorse"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Detects anagrams using case-insensitive subject`` () =
    let candidates = ["cashregister"; "carthorse"; "radishes"]
    findAnagrams candidates "Orchestra" |> should equal ["carthorse"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Detects anagrams using case-insensitive possible matches`` () =
    let candidates = ["cashregister"; "Carthorse"; "radishes"]
    findAnagrams candidates "orchestra" |> should equal ["Carthorse"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Does not detect an anagram if the original word is repeated`` () =
    let candidates = ["go Go GO"]
    findAnagrams candidates "go" |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Anagrams must use all letters exactly once`` () =
    let candidates = ["patter"]
    findAnagrams candidates "tapper" |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Words are not anagrams of themselves`` () =
    let candidates = ["BANANA"]
    findAnagrams candidates "BANANA" |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Words are not anagrams of themselves even if letter case is partially different`` () =
    let candidates = ["Banana"]
    findAnagrams candidates "BANANA" |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Words are not anagrams of themselves even if letter case is completely different`` () =
    let candidates = ["banana"]
    findAnagrams candidates "BANANA" |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Words other than themselves can be anagrams`` () =
    let candidates = ["LISTEN"; "Silent"]
    findAnagrams candidates "LISTEN" |> should equal ["Silent"]

