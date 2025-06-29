import "run_length_encoding"

-- Encode empty string
-- ==
-- input { "" }
-- output { "" }

-- Encode single characters only are encoded without count
-- ==
-- input { "XYZ" }
-- output { "XYZ" }

-- Encode string with no single characters
-- ==
-- input { "AABBBCCCC" }
-- output { "2A3B4C" }

-- Encode single characters mixed with repeated characters
-- ==
-- input { "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB" }
-- output { "12WB12W3B24WB" }

-- Encode multiple whitespace mixed in string
-- ==
-- input { "  hsqq qww  " }
-- output { "2 hs2q q2w2 " }

-- Encode lowercase characters
-- ==
-- input { "aabbbcccc" }
-- output { "2a3b4c" }

-- Decode empty string
-- ==
-- input { "" }
-- output { "" }

-- Decode single characters only
-- ==
-- input { "XYZ" }
-- output { "XYZ" }

-- Decode string with no single characters
-- ==
-- input { "2A3B4C" }
-- output { "AABBBCCCC" }

-- Decode single characters with repeated characters
-- ==
-- input { "12WB12W3B24WB" }
-- output { "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB" }

-- Decode multiple whitespace mixed in string
-- ==
-- input { "2 hs2q q2w2 " }
-- output { "  hsqq qww  " }

-- Decode lowercase string
-- ==
-- input { "2a3b4c" }
-- output { "aabbbcccc" }

let ``Encode followed by decode gives original string`` () =
    "zzz ZZ  zZ" |> encode |> decode |> should equal "zzz ZZ  zZ"

