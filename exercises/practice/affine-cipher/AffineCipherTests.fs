source("./affine-cipher.R")
library(testthat)

let ``Encode yes`` () =
    expect_equal(encode 5 7 "yes", "xbt")

let ``Encode no`` () =
    expect_equal(encode 15 18 "no", "fu")

let ``Encode OMG`` () =
    expect_equal(encode 21 3 "OMG", "lvz")

let ``Encode O M G`` () =
    expect_equal(encode 25 47 "O M G", "hjp")

let ``Encode mindblowingly`` () =
    expect_equal(encode 11 15 "mindblowingly", "rzcwa gnxzc dgt")

let ``Encode numbers`` () =
    expect_equal(encode 3 4 "Testing,1 2 3, testing.", "jqgjc rw123 jqgjc rw")

let ``Encode deep thought`` () =
    expect_equal(encode 5 17 "Truth is fiction.", "iynia fdqfb ifje")

let ``Encode all the letters`` () =
    expect_equal(encode 17 33 "The quick brown fox jumps over the lazy dog.", "swxtj npvyk lruol iejdc blaxk swxmh qzglf")

let ``Encode with a not coprime to m`` () =
    (fun () -> encode 6 17 "This is a test." |> ignore) |> should throw typeof<System.ArgumentException>

let ``Decode exercism`` () =
    expect_equal(decode 3 7 "tytgn fjr", "exercism")

let ``Decode a sentence`` () =
    expect_equal(decode 19 16 "qdwju nqcro muwhn odqun oppmd aunwd o", "anobstacleisoftenasteppingstone")

let ``Decode numbers`` () =
    expect_equal(decode 25 7 "odpoz ub123 odpoz ub", "testing123testing")

let ``Decode all the letters`` () =
    expect_equal(decode 17 33 "swxtj npvyk lruol iejdc blaxk swxmh qzglf", "thequickbrownfoxjumpsoverthelazydog")

let ``Decode with no spaces in input`` () =
    expect_equal(decode 17 33 "swxtjnpvyklruoliejdcblaxkswxmhqzglf", "thequickbrownfoxjumpsoverthelazydog")

let ``Decode with too many spaces`` () =
    expect_equal(decode 15 16 "vszzm    cly   yd cg    qdp", "jollygreengiant")

let ``Decode with a not coprime to m`` () =
    (fun () -> decode 13 5 "Test" |> ignore) |> should throw typeof<System.ArgumentException>

