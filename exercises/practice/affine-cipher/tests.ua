~ "affine-cipher.ua" ~ AffineCipher

# Encode yes
⍤⤙≍ "xbt" encode 5 7 "yes"

# Encode no
⍤⤙≍ "fu" encode 15 18 "no"

# Encode OMG
⍤⤙≍ "lvz" encode 21 3 "OMG"

# Encode O M G
⍤⤙≍ "hjp" encode 25 47 "O M G"

# Encode mindblowingly
⍤⤙≍ "rzcwa gnxzc dgt" encode 11 15 "mindblowingly"

# Encode numbers
⍤⤙≍ "jqgjc rw123 jqgjc rw" encode 3 4 "Testing,1 2 3, testing."

# Encode deep thought
⍤⤙≍ "iynia fdqfb ifje" encode 5 17 "Truth is fiction."

# Encode all the letters
⍤⤙≍ "swxtj npvyk lruol iejdc blaxk swxmh qzglf" encode 17 33 "The quick brown fox jumps over the lazy dog."

# Encode with a not coprime to m
(fun () -> encode 6 17 "This is a test."|> ignore)
| > should throw typeof<System.ArgumentException>

# Decode exercism
⍤⤙≍ "exercism" decode 3 7 "tytgn fjr"

# Decode a sentence
⍤⤙≍ "anobstacleisoftenasteppingstone" decode 19 16 "qdwju nqcro muwhn odqun oppmd aunwd o"

# Decode numbers
⍤⤙≍ "testing123testing" decode 25 7 "odpoz ub123 odpoz ub"

# Decode all the letters
⍤⤙≍ "thequickbrownfoxjumpsoverthelazydog" decode 17 33 "swxtj npvyk lruol iejdc blaxk swxmh qzglf"

# Decode with no spaces in input
⍤⤙≍ "thequickbrownfoxjumpsoverthelazydog" decode 17 33 "swxtjnpvyklruoliejdcblaxkswxmhqzglf"

# Decode with too many spaces
⍤⤙≍ "jollygreengiant" decode 15 16 "vszzm    cly   yd cg    qdp"

# Decode with a not coprime to m
(fun () -> decode 13 5 "Test"|> ignore)
| > should throw typeof<System.ArgumentException>
