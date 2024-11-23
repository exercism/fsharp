~ "anagram.ua" ~ Anagram

# No matches
candidates = ["hello" "world" "zombies" "pants"]
⍤⤙≍ [] findAnagrams candidates "diaper"

# Detects two anagrams
candidates = ["lemons" "cherry" "melons"]
⍤⤙≍ ["lemons" "melons"] findAnagrams candidates "solemn"

# Does not detect anagram subsets
candidates = ["dog" "goody"]
⍤⤙≍ [] findAnagrams candidates "good"

# Detects anagram
candidates = ["enlists" "google" "inlets" "banana"]
⍤⤙≍ ["inlets"] findAnagrams candidates "listen"

# Detects three anagrams
candidates = ["gallery" "ballerina" "regally" "clergy" "largely" "leading"]
⍤⤙≍ ["gallery" "regally" "largely"] findAnagrams candidates "allergy"

# Detects multiple anagrams with different case
candidates = ["Eons" "ONES"]
⍤⤙≍ ["Eons" "ONES"] findAnagrams candidates "nose"

# Does not detect non-anagrams with identical checksum
candidates = ["last"]
⍤⤙≍ [] findAnagrams candidates "mass"

# Detects anagrams case-insensitively
candidates = ["cashregister" "Carthorse" "radishes"]
⍤⤙≍ ["Carthorse"] findAnagrams candidates "Orchestra"

# Detects anagrams using case-insensitive subject
candidates = ["cashregister" "carthorse" "radishes"]
⍤⤙≍ ["carthorse"] findAnagrams candidates "Orchestra"

# Detects anagrams using case-insensitive possible matches
candidates = ["cashregister" "Carthorse" "radishes"]
⍤⤙≍ ["Carthorse"] findAnagrams candidates "orchestra"

# Does not detect an anagram if the original word is repeated
candidates = ["go Go GO"]
⍤⤙≍ [] findAnagrams candidates "go"

# Anagrams must use all letters exactly once
candidates = ["patter"]
⍤⤙≍ [] findAnagrams candidates "tapper"

# Words are not anagrams of themselves
candidates = ["BANANA"]
⍤⤙≍ [] findAnagrams candidates "BANANA"

# Words are not anagrams of themselves even if letter case is partially different
candidates = ["Banana"]
⍤⤙≍ [] findAnagrams candidates "BANANA"

# Words are not anagrams of themselves even if letter case is completely different
candidates = ["banana"]
⍤⤙≍ [] findAnagrams candidates "BANANA"

# Words other than themselves can be anagrams
candidates = ["LISTEN" "Silent"]
⍤⤙≍ ["Silent"] findAnagrams candidates "LISTEN"

