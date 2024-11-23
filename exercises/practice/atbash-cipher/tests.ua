~ "atbash-cipher.ua" ~ AtbashCipher

# Encode yes
    encode "yes" |> should equal "bvh"

# Encode no
    encode "no" |> should equal "ml"

# Encode OMG
    encode "OMG" |> should equal "lnt"

# Encode spaces
    encode "O M G" |> should equal "lnt"

# Encode mindblowingly
    encode "mindblowingly" |> should equal "nrmwy oldrm tob"

# Encode numbers
    encode "Testing,1 2 3, testing." |> should equal "gvhgr mt123 gvhgr mt"

# Encode deep thought
    encode "Truth is fiction." |> should equal "gifgs rhurx grlm"

# Encode all the letters
    encode "The quick brown fox jumps over the lazy dog." |> should equal "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt"

# Decode exercism
    decode "vcvix rhn" |> should equal "exercism"

# Decode a sentence
    decode "zmlyh gzxov rhlug vmzhg vkkrm thglm v" |> should equal "anobstacleisoftenasteppingstone"

# Decode numbers
    decode "gvhgr mt123 gvhgr mt" |> should equal "testing123testing"

# Decode all the letters
    decode "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt" |> should equal "thequickbrownfoxjumpsoverthelazydog"

# Decode with too many spaces
    decode "vc vix    r hn" |> should equal "exercism"

# Decode with no spaces
    decode "zmlyhgzxovrhlugvmzhgvkkrmthglmv" |> should equal "anobstacleisoftenasteppingstone"

