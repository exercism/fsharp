source("./affine-cipher.R")
library(testthat)

test_that("Encode yes", {
    encode 5 7 "yes" |> should equal "xbt"
})

test_that("Encode no", {
    encode 15 18 "no" |> should equal "fu"
})

test_that("Encode OMG", {
    encode 21 3 "OMG" |> should equal "lvz"
})

test_that("Encode O M G", {
    encode 25 47 "O M G" |> should equal "hjp"
})

test_that("Encode mindblowingly", {
    encode 11 15 "mindblowingly" |> should equal "rzcwa gnxzc dgt"
})

test_that("Encode numbers", {
    encode 3 4 "Testing,1 2 3, testing." |> should equal "jqgjc rw123 jqgjc rw"
})

test_that("Encode deep thought", {
    encode 5 17 "Truth is fiction." |> should equal "iynia fdqfb ifje"
})

test_that("Encode all the letters", {
    encode 17 33 "The quick brown fox jumps over the lazy dog." |> should equal "swxtj npvyk lruol iejdc blaxk swxmh qzglf"
})

test_that("Encode with a not coprime to m", {
    (fun () -> encode 6 17 "This is a test." |> ignore) |> should throw typeof<System.ArgumentException>
})

test_that("Decode exercism", {
    decode 3 7 "tytgn fjr" |> should equal "exercism"
})

test_that("Decode a sentence", {
    decode 19 16 "qdwju nqcro muwhn odqun oppmd aunwd o" |> should equal "anobstacleisoftenasteppingstone"
})

test_that("Decode numbers", {
    decode 25 7 "odpoz ub123 odpoz ub" |> should equal "testing123testing"
})

test_that("Decode all the letters", {
    decode 17 33 "swxtj npvyk lruol iejdc blaxk swxmh qzglf" |> should equal "thequickbrownfoxjumpsoverthelazydog"
})

test_that("Decode with no spaces in input", {
    decode 17 33 "swxtjnpvyklruoliejdcblaxkswxmhqzglf" |> should equal "thequickbrownfoxjumpsoverthelazydog"
})

test_that("Decode with too many spaces", {
    decode 15 16 "vszzm    cly   yd cg    qdp" |> should equal "jollygreengiant"
})

test_that("Decode with a not coprime to m", {
    (fun () -> decode 13 5 "Test" |> ignore) |> should throw typeof<System.ArgumentException>

