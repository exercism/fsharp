import "affine_cipher"

-- Encode yes
-- ==
-- input { 5 7 "yes" }
-- output { "xbt" }

-- Encode no
-- ==
-- input { 15 18 "no" }
-- output { "fu" }

-- Encode OMG
-- ==
-- input { 21 3 "OMG" }
-- output { "lvz" }

-- Encode O M G
-- ==
-- input { 25 47 "O M G" }
-- output { "hjp" }

-- Encode mindblowingly
-- ==
-- input { 11 15 "mindblowingly" }
-- output { "rzcwa gnxzc dgt" }

-- Encode numbers
-- ==
-- input { 3 4 "Testing,1 2 3, testing." }
-- output { "jqgjc rw123 jqgjc rw" }

-- Encode deep thought
-- ==
-- input { 5 17 "Truth is fiction." }
-- output { "iynia fdqfb ifje" }

-- Encode all the letters
-- ==
-- input { 17 33 "The quick brown fox jumps over the lazy dog." }
-- output { "swxtj npvyk lruol iejdc blaxk swxmh qzglf" }

let ``Encode with a not coprime to m`` () =
    (fun () -> encode 6 17 "This is a test." |> ignore) |> should throw typeof<System.ArgumentException>

-- Decode exercism
-- ==
-- input { 3 7 "tytgn fjr" }
-- output { "exercism" }

-- Decode a sentence
-- ==
-- input { 19 16 "qdwju nqcro muwhn odqun oppmd aunwd o" }
-- output { "anobstacleisoftenasteppingstone" }

-- Decode numbers
-- ==
-- input { 25 7 "odpoz ub123 odpoz ub" }
-- output { "testing123testing" }

-- Decode all the letters
-- ==
-- input { 17 33 "swxtj npvyk lruol iejdc blaxk swxmh qzglf" }
-- output { "thequickbrownfoxjumpsoverthelazydog" }

-- Decode with no spaces in input
-- ==
-- input { 17 33 "swxtjnpvyklruoliejdcblaxkswxmhqzglf" }
-- output { "thequickbrownfoxjumpsoverthelazydog" }

-- Decode with too many spaces
-- ==
-- input { 15 16 "vszzm    cly   yd cg    qdp" }
-- output { "jollygreengiant" }

let ``Decode with a not coprime to m`` () =
    (fun () -> decode 13 5 "Test" |> ignore) |> should throw typeof<System.ArgumentException>

