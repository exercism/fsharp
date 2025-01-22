source("./tracks-on-tracks-on-tracks.R")
library(testthat)

test_that("New list", {
    let expected: string list = []
    expect_equal(newList, expected)

    expect_equal(test_that("Existing list", {

    expect_equal(test_that("Add language to new list", {

test_that("Add language to existing list", {
    expect_equal(addLanguage "Common Lisp" existingList, c( "Common Lisp", "F#", "Clojure", "Haskell" ))

    expect_equal(test_that("Add language to custom list", {

    expect_equal(test_that("Count languages on new list", {

    expect_equal(test_that("Count languages on existing list", {

    expect_equal(test_that("Count languages on custom list", {

test_that("Reverse order of new list", {
    let expected: string list = []
    expect_equal(reverseList(newList), expected)

    expect_equal(test_that("Reverse order of existing list", {

test_that("Reverse order of custom list", {
    expect_equal(reverseList c( "Kotlin", "Java", "Scala", "Clojure" ), c( "Clojure", "Scala", "Java", "Kotlin" ))

    expect_equal(test_that("Empty list is not exciting", {

    expect_equal(test_that("Singleton list with F# is exciting", {

    expect_equal(test_that("Singleton list without fsharp is not exciting", {

    expect_equal(test_that("Two-item list with F# as first item is exciting", {

    expect_equal(test_that("Two-item list with F# as second item is exciting", {

    expect_equal(test_that("Two-item list without F# is not exciting", {

test_that("Three-item list with F# as first item is exciting", {
    expect_true(excitingList c( "F#", "Lisp", "Clojure" ))

test_that("Three-item list with F# as second item is exciting", {
    expect_true(excitingList c( "Java", "F#", "C#" ))

test_that("Three-item list with F# as third item is not exciting", {
    expect_false(excitingList c( "Julia", "Assembly", "F#" ))

test_that("Four-item list with F# as first item is exciting", {
    expect_true(excitingList c( "F#", "C", "C++", "C#" ))

test_that("Four-item list with F# as second item is not exciting", {
    expect_false(excitingList c( "Elm", "F#", "C#", "Scheme" ))

test_that("Four-item list with F# as third item is not exciting", {
    expect_false(excitingList c( "Delphi", "D", "F#", "Prolog" ))

test_that("Four-item list with F# as fourth item is not exciting", {
    expect_false(excitingList c( "Julia", "Assembly", "Crystal", "F#" ))
