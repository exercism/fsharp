~ "anagram.ua" ~ Anagram

# No matches
    let candidates = ["hello" "world" "zombies" "pants"]
    findAnagrams candidates "diaper" |> should be Empty

# Detects two anagrams
    let candidates = ["lemons" "cherry" "melons"]
⍤⤙≍ ["lemons" "melons"] findAnagrams candidates "solemn"

# Does not detect anagram subsets
    let candidates = ["dog" "goody"]
    findAnagrams candidates "good" |> should be Empty

# Detects anagram
    let candidates = ["enlists" "google" "inlets" "banana"]
⍤⤙≍ ["inlets"] findAnagrams candidates "listen"

# Detects three anagrams
    let candidates = ["gallery" "ballerina" "regally" "clergy" "largely" "leading"]
⍤⤙≍ ["gallery" "regally" "largely"] findAnagrams candidates "allergy"

# Detects multiple anagrams with different case
    let candidates = ["Eons" "ONES"]
⍤⤙≍ ["Eons" "ONES"] findAnagrams candidates "nose"

# Does not detect non-anagrams with identical checksum
    let candidates = ["last"]
    findAnagrams candidates "mass" |> should be Empty

# Detects anagrams case-insensitively
    let candidates = ["cashregister" "Carthorse" "radishes"]
⍤⤙≍ ["Carthorse"] findAnagrams candidates "Orchestra"

# Detects anagrams using case-insensitive subject
    let candidates = ["cashregister" "carthorse" "radishes"]
⍤⤙≍ ["carthorse"] findAnagrams candidates "Orchestra"

# Detects anagrams using case-insensitive possible matches
    let candidates = ["cashregister" "Carthorse" "radishes"]
⍤⤙≍ ["Carthorse"] findAnagrams candidates "orchestra"

# Does not detect an anagram if the original word is repeated
    let candidates = ["go Go GO"]
    findAnagrams candidates "go" |> should be Empty

# Anagrams must use all letters exactly once
    let candidates = ["patter"]
    findAnagrams candidates "tapper" |> should be Empty

# Words are not anagrams of themselves
    let candidates = ["BANANA"]
    findAnagrams candidates "BANANA" |> should be Empty

# Words are not anagrams of themselves even if letter case is partially different
    let candidates = ["Banana"]
    findAnagrams candidates "BANANA" |> should be Empty

# Words are not anagrams of themselves even if letter case is completely different
    let candidates = ["banana"]
    findAnagrams candidates "BANANA" |> should be Empty

# Words other than themselves can be anagrams
    let candidates = ["LISTEN" "Silent"]
⍤⤙≍ ["Silent"] findAnagrams candidates "LISTEN"

