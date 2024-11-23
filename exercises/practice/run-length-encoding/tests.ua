~ "run-length-encoding.ua" ~ RunLengthEncoding

# Encode empty string
⍤⤙≍ "" encode ""

# Encode single characters only are encoded without count
⍤⤙≍ "XYZ" encode "XYZ"

# Encode string with no single characters
⍤⤙≍ "2A3B4C" encode "AABBBCCCC"

# Encode single characters mixed with repeated characters
⍤⤙≍ "12WB12W3B24WB" encode "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"

# Encode multiple whitespace mixed in string
⍤⤙≍ "2 hs2q q2w2 " encode "  hsqq qww  "

# Encode lowercase characters
⍤⤙≍ "2a3b4c" encode "aabbbcccc"

# Decode empty string
⍤⤙≍ "" decode ""

# Decode single characters only
⍤⤙≍ "XYZ" decode "XYZ"

# Decode string with no single characters
⍤⤙≍ "AABBBCCCC" decode "2A3B4C"

# Decode single characters with repeated characters
⍤⤙≍ "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB" decode "12WB12W3B24WB"

# Decode multiple whitespace mixed in string
⍤⤙≍ "  hsqq qww  " decode "2 hs2q q2w2 "

# Decode lowercase string
⍤⤙≍ "aabbbcccc" decode "2a3b4c"

# Encode followed by decode gives original string
⍤⤙≍ "zzz ZZ  zZ" "zzz ZZ  zZ" |> encode |> decode

