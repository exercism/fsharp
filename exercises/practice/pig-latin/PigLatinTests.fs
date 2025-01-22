source("./pig-latin.R")
library(testthat)

test_that("Word beginning with a", {
    expect_equal(translate "apple", "appleay")

test_that("Word beginning with e", {
    expect_equal(translate "ear", "earay")

test_that("Word beginning with i", {
    expect_equal(translate "igloo", "iglooay")

test_that("Word beginning with o", {
    expect_equal(translate "object", "objectay")

test_that("Word beginning with u", {
    expect_equal(translate "under", "underay")

test_that("Word beginning with a vowel and followed by a qu", {
    expect_equal(translate "equal", "equalay")

test_that("Word beginning with p", {
    expect_equal(translate "pig", "igpay")

test_that("Word beginning with k", {
    expect_equal(translate "koala", "oalakay")

test_that("Word beginning with x", {
    expect_equal(translate "xenon", "enonxay")

test_that("Word beginning with q without a following u", {
    expect_equal(translate "qat", "atqay")

test_that("Word beginning with ch", {
    expect_equal(translate "chair", "airchay")

test_that("Word beginning with qu", {
    expect_equal(translate "queen", "eenquay")

test_that("Word beginning with qu and a preceding consonant", {
    expect_equal(translate "square", "aresquay")

test_that("Word beginning with th", {
    expect_equal(translate "therapy", "erapythay")

test_that("Word beginning with thr", {
    expect_equal(translate "thrush", "ushthray")

test_that("Word beginning with sch", {
    expect_equal(translate "school", "oolschay")

test_that("Word beginning with yt", {
    expect_equal(translate "yttria", "yttriaay")

test_that("Word beginning with xr", {
    expect_equal(translate "xray", "xrayay")

test_that("Y is treated like a consonant at the beginning of a word", {
    expect_equal(translate "yellow", "ellowyay")

test_that("Y is treated like a vowel at the end of a consonant cluster", {
    expect_equal(translate "rhythm", "ythmrhay")

test_that("Y as second letter in two letter word", {
    expect_equal(translate "my", "ymay")

test_that("A whole phrase", {
    expect_equal(translate "quick fast run", "ickquay astfay unray")

