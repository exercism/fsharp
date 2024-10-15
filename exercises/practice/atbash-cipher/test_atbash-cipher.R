source("./atbash-cipher.R")
library(testthat)




test_that("Encode yes", {
    encode "yes" |> should equal "bvh"


test_that("Encode no", {
    encode "no" |> should equal "ml"


test_that("Encode OMG", {
    encode "OMG" |> should equal "lnt"


test_that("Encode spaces", {
    encode "O M G" |> should equal "lnt"


test_that("Encode mindblowingly", {
    encode "mindblowingly" |> should equal "nrmwy oldrm tob"


test_that("Encode numbers", {
    encode "Testing,1 2 3, testing." |> should equal "gvhgr mt123 gvhgr mt"


test_that("Encode deep thought", {
    encode "Truth is fiction." |> should equal "gifgs rhurx grlm"


test_that("Encode all the letters", {
    encode "The quick brown fox jumps over the lazy dog." |> should equal "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt"


test_that("Decode exercism", {
    decode "vcvix rhn" |> should equal "exercism"


test_that("Decode a sentence", {
    decode "zmlyh gzxov rhlug vmzhg vkkrm thglm v" |> should equal "anobstacleisoftenasteppingstone"


test_that("Decode numbers", {
    decode "gvhgr mt123 gvhgr mt" |> should equal "testing123testing"


test_that("Decode all the letters", {
    decode "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt" |> should equal "thequickbrownfoxjumpsoverthelazydog"


test_that("Decode with too many spaces", {
    decode "vc vix    r hn" |> should equal "exercism"


test_that("Decode with no spaces", {
    decode "zmlyhgzxovrhlugvmzhgvkkrmthglmv" |> should equal "anobstacleisoftenasteppingstone"

