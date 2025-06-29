import "atbash_cipher"

let ``Encode yes`` () =
    encode "yes" |> should equal "bvh"

let ``Encode no`` () =
    encode "no" |> should equal "ml"

let ``Encode OMG`` () =
    encode "OMG" |> should equal "lnt"

let ``Encode spaces`` () =
    encode "O M G" |> should equal "lnt"

let ``Encode mindblowingly`` () =
    encode "mindblowingly" |> should equal "nrmwy oldrm tob"

let ``Encode numbers`` () =
    encode "Testing,1 2 3, testing." |> should equal "gvhgr mt123 gvhgr mt"

let ``Encode deep thought`` () =
    encode "Truth is fiction." |> should equal "gifgs rhurx grlm"

let ``Encode all the letters`` () =
    encode "The quick brown fox jumps over the lazy dog." |> should equal "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt"

let ``Decode exercism`` () =
    decode "vcvix rhn" |> should equal "exercism"

let ``Decode a sentence`` () =
    decode "zmlyh gzxov rhlug vmzhg vkkrm thglm v" |> should equal "anobstacleisoftenasteppingstone"

let ``Decode numbers`` () =
    decode "gvhgr mt123 gvhgr mt" |> should equal "testing123testing"

let ``Decode all the letters`` () =
    decode "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt" |> should equal "thequickbrownfoxjumpsoverthelazydog"

let ``Decode with too many spaces`` () =
    decode "vc vix    r hn" |> should equal "exercism"

let ``Decode with no spaces`` () =
    decode "zmlyhgzxovrhlugvmzhgvkkrmthglmv" |> should equal "anobstacleisoftenasteppingstone"

