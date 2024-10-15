source("./pig-latin.R")
library(testthat)




test_that("Word beginning with a", {
    translate "apple" |> should equal "appleay"


test_that("Word beginning with e", {
    translate "ear" |> should equal "earay"


test_that("Word beginning with i", {
    translate "igloo" |> should equal "iglooay"


test_that("Word beginning with o", {
    translate "object" |> should equal "objectay"


test_that("Word beginning with u", {
    translate "under" |> should equal "underay"


test_that("Word beginning with a vowel and followed by a qu", {
    translate "equal" |> should equal "equalay"


test_that("Word beginning with p", {
    translate "pig" |> should equal "igpay"


test_that("Word beginning with k", {
    translate "koala" |> should equal "oalakay"


test_that("Word beginning with x", {
    translate "xenon" |> should equal "enonxay"


test_that("Word beginning with q without a following u", {
    translate "qat" |> should equal "atqay"


test_that("Word beginning with ch", {
    translate "chair" |> should equal "airchay"


test_that("Word beginning with qu", {
    translate "queen" |> should equal "eenquay"


test_that("Word beginning with qu and a preceding consonant", {
    translate "square" |> should equal "aresquay"


test_that("Word beginning with th", {
    translate "therapy" |> should equal "erapythay"


test_that("Word beginning with thr", {
    translate "thrush" |> should equal "ushthray"


test_that("Word beginning with sch", {
    translate "school" |> should equal "oolschay"


test_that("Word beginning with yt", {
    translate "yttria" |> should equal "yttriaay"


test_that("Word beginning with xr", {
    translate "xray" |> should equal "xrayay"


test_that("Y is treated like a consonant at the beginning of a word", {
    translate "yellow" |> should equal "ellowyay"


test_that("Y is treated like a vowel at the end of a consonant cluster", {
    translate "rhythm" |> should equal "ythmrhay"


test_that("Y as second letter in two letter word", {
    translate "my" |> should equal "ymay"


test_that("A whole phrase", {
    translate "quick fast run" |> should equal "ickquay astfay unray"

