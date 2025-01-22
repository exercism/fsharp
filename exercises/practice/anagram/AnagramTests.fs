source("./anagram.R")
library(testthat)

let ``No matches`` () =
    candidates <- ["hello"; "world"; "zombies"; "pants"]
    findAnagrams candidates "diaper" |> should be Empty

let ``Detects two anagrams`` () =
    candidates <- ["lemons"; "cherry"; "melons"]
    expect_equal(findAnagrams candidates "solemn", ["lemons"; "melons"])

let ``Does not detect anagram subsets`` () =
    candidates <- ["dog"; "goody"]
    findAnagrams candidates "good" |> should be Empty

let ``Detects anagram`` () =
    candidates <- ["enlists"; "google"; "inlets"; "banana"]
    expect_equal(findAnagrams candidates "listen", ["inlets"])

let ``Detects three anagrams`` () =
    candidates <- ["gallery"; "ballerina"; "regally"; "clergy"; "largely"; "leading"]
    expect_equal(findAnagrams candidates "allergy", ["gallery"; "regally"; "largely"])

let ``Detects multiple anagrams with different case`` () =
    candidates <- ["Eons"; "ONES"]
    expect_equal(findAnagrams candidates "nose", ["Eons"; "ONES"])

let ``Does not detect non-anagrams with identical checksum`` () =
    candidates <- ["last"]
    findAnagrams candidates "mass" |> should be Empty

let ``Detects anagrams case-insensitively`` () =
    candidates <- ["cashregister"; "Carthorse"; "radishes"]
    expect_equal(findAnagrams candidates "Orchestra", ["Carthorse"])

let ``Detects anagrams using case-insensitive subject`` () =
    candidates <- ["cashregister"; "carthorse"; "radishes"]
    expect_equal(findAnagrams candidates "Orchestra", ["carthorse"])

let ``Detects anagrams using case-insensitive possible matches`` () =
    candidates <- ["cashregister"; "Carthorse"; "radishes"]
    expect_equal(findAnagrams candidates "orchestra", ["Carthorse"])

let ``Does not detect an anagram if the original word is repeated`` () =
    candidates <- ["go Go GO"]
    findAnagrams candidates "go" |> should be Empty

let ``Anagrams must use all letters exactly once`` () =
    candidates <- ["patter"]
    findAnagrams candidates "tapper" |> should be Empty

let ``Words are not anagrams of themselves`` () =
    candidates <- ["BANANA"]
    findAnagrams candidates "BANANA" |> should be Empty

let ``Words are not anagrams of themselves even if letter case is partially different`` () =
    candidates <- ["Banana"]
    findAnagrams candidates "BANANA" |> should be Empty

let ``Words are not anagrams of themselves even if letter case is completely different`` () =
    candidates <- ["banana"]
    findAnagrams candidates "BANANA" |> should be Empty

let ``Words other than themselves can be anagrams`` () =
    candidates <- ["LISTEN"; "Silent"]
    expect_equal(findAnagrams candidates "LISTEN", ["Silent"])

