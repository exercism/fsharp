~ "anagram.ua" ~ Anagram

let ``No matches`` () =
    let candidates = ["hello"; "world"; "zombies"; "pants"]
    findAnagrams candidates "diaper" |> should be Empty

let ``Detects two anagrams`` () =
    let candidates = ["lemons"; "cherry"; "melons"]
    findAnagrams candidates "solemn" |> should equal ["lemons"; "melons"]

let ``Does not detect anagram subsets`` () =
    let candidates = ["dog"; "goody"]
    findAnagrams candidates "good" |> should be Empty

let ``Detects anagram`` () =
    let candidates = ["enlists"; "google"; "inlets"; "banana"]
    findAnagrams candidates "listen" |> should equal ["inlets"]

let ``Detects three anagrams`` () =
    let candidates = ["gallery"; "ballerina"; "regally"; "clergy"; "largely"; "leading"]
    findAnagrams candidates "allergy" |> should equal ["gallery"; "regally"; "largely"]

let ``Detects multiple anagrams with different case`` () =
    let candidates = ["Eons"; "ONES"]
    findAnagrams candidates "nose" |> should equal ["Eons"; "ONES"]

let ``Does not detect non-anagrams with identical checksum`` () =
    let candidates = ["last"]
    findAnagrams candidates "mass" |> should be Empty

let ``Detects anagrams case-insensitively`` () =
    let candidates = ["cashregister"; "Carthorse"; "radishes"]
    findAnagrams candidates "Orchestra" |> should equal ["Carthorse"]

let ``Detects anagrams using case-insensitive subject`` () =
    let candidates = ["cashregister"; "carthorse"; "radishes"]
    findAnagrams candidates "Orchestra" |> should equal ["carthorse"]

let ``Detects anagrams using case-insensitive possible matches`` () =
    let candidates = ["cashregister"; "Carthorse"; "radishes"]
    findAnagrams candidates "orchestra" |> should equal ["Carthorse"]

let ``Does not detect an anagram if the original word is repeated`` () =
    let candidates = ["go Go GO"]
    findAnagrams candidates "go" |> should be Empty

let ``Anagrams must use all letters exactly once`` () =
    let candidates = ["patter"]
    findAnagrams candidates "tapper" |> should be Empty

let ``Words are not anagrams of themselves`` () =
    let candidates = ["BANANA"]
    findAnagrams candidates "BANANA" |> should be Empty

let ``Words are not anagrams of themselves even if letter case is partially different`` () =
    let candidates = ["Banana"]
    findAnagrams candidates "BANANA" |> should be Empty

let ``Words are not anagrams of themselves even if letter case is completely different`` () =
    let candidates = ["banana"]
    findAnagrams candidates "BANANA" |> should be Empty

let ``Words other than themselves can be anagrams`` () =
    let candidates = ["LISTEN"; "Silent"]
    findAnagrams candidates "LISTEN" |> should equal ["Silent"]

