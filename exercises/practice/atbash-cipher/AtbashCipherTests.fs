source("./atbash-cipher.R")
library(testthat)

let ``Encode yes`` () =
    expect_equal(encode "yes", "bvh")

let ``Encode no`` () =
    expect_equal(encode "no", "ml")

let ``Encode OMG`` () =
    expect_equal(encode "OMG", "lnt")

let ``Encode spaces`` () =
    expect_equal(encode "O M G", "lnt")

let ``Encode mindblowingly`` () =
    expect_equal(encode "mindblowingly", "nrmwy oldrm tob")

let ``Encode numbers`` () =
    expect_equal(encode "Testing,1 2 3, testing.", "gvhgr mt123 gvhgr mt")

let ``Encode deep thought`` () =
    expect_equal(encode "Truth is fiction.", "gifgs rhurx grlm")

let ``Encode all the letters`` () =
    expect_equal(encode "The quick brown fox jumps over the lazy dog.", "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt")

let ``Decode exercism`` () =
    expect_equal(decode "vcvix rhn", "exercism")

let ``Decode a sentence`` () =
    expect_equal(decode "zmlyh gzxov rhlug vmzhg vkkrm thglm v", "anobstacleisoftenasteppingstone")

let ``Decode numbers`` () =
    expect_equal(decode "gvhgr mt123 gvhgr mt", "testing123testing")

let ``Decode all the letters`` () =
    expect_equal(decode "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt", "thequickbrownfoxjumpsoverthelazydog")

let ``Decode with too many spaces`` () =
    expect_equal(decode "vc vix    r hn", "exercism")

let ``Decode with no spaces`` () =
    expect_equal(decode "zmlyhgzxovrhlugvmzhgvkkrmthglmv", "anobstacleisoftenasteppingstone")

