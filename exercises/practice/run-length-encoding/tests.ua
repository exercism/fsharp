~ "run-length-encoding.ua" ~ RunLengthEncoding

# Encode empty string
    encode "" |> should equal ""

# Encode single characters only are encoded without count
    encode "XYZ" |> should equal "XYZ"

# Encode string with no single characters
    encode "AABBBCCCC" |> should equal "2A3B4C"

# Encode single characters mixed with repeated characters
    encode "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB" |> should equal "12WB12W3B24WB"

# Encode multiple whitespace mixed in string
    encode "  hsqq qww  " |> should equal "2 hs2q q2w2 "

# Encode lowercase characters
    encode "aabbbcccc" |> should equal "2a3b4c"

# Decode empty string
    decode "" |> should equal ""

# Decode single characters only
    decode "XYZ" |> should equal "XYZ"

# Decode string with no single characters
    decode "2A3B4C" |> should equal "AABBBCCCC"

# Decode single characters with repeated characters
    decode "12WB12W3B24WB" |> should equal "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"

# Decode multiple whitespace mixed in string
    decode "2 hs2q q2w2 " |> should equal "  hsqq qww  "

# Decode lowercase string
    decode "2a3b4c" |> should equal "aabbbcccc"

# Encode followed by decode gives original string
    "zzz ZZ  zZ" |> encode |> decode |> should equal "zzz ZZ  zZ"

