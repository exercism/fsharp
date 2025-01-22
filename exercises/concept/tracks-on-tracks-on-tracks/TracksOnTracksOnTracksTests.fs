source("./tracks-on-tracks-on-tracks.R")
library(testthat)

[<Task(1)>]
test_that("New list", {
    let expected: string list = []
    expect_equal(newList, expected)

[<Task(2)>]
    expect_equal(test_that("Existing list", {

[<Task(3)>]
    expect_equal(test_that("Add language to new list", {

[<Task(3)>]
test_that("Add language to existing list", {
    expect_equal(addLanguage "Common Lisp" existingList, [ "Common Lisp"; "F#"; "Clojure"; "Haskell" ])

[<Task(3)>]
    expect_equal(test_that("Add language to custom list", {

[<Task(4)>]
    expect_equal(test_that("Count languages on new list", {

[<Task(4)>]
    expect_equal(test_that("Count languages on existing list", {

[<Task(4)>]
    expect_equal(test_that("Count languages on custom list", {

[<Task(5)>]
test_that("Reverse order of new list", {
    let expected: string list = []
    expect_equal(reverseList newList, expected)

[<Task(5)>]
    expect_equal(test_that("Reverse order of existing list", {

[<Task(5)>]
test_that("Reverse order of custom list", {
    expect_equal(reverseList [ "Kotlin"; "Java"; "Scala"; "Clojure" ], [ "Clojure"; "Scala"; "Java"; "Kotlin" ])

[<Task(6)>]
    expect_equal(test_that("Empty list is not exciting", {

[<Task(6)>]
    expect_equal(test_that("Singleton list with F# is exciting", {

[<Task(6)>]
    expect_equal(test_that("Singleton list without fsharp is not exciting", {

[<Task(6)>]
    expect_equal(test_that("Two-item list with F# as first item is exciting", {

[<Task(6)>]
    expect_equal(test_that("Two-item list with F# as second item is exciting", {

[<Task(6)>]
    expect_equal(test_that("Two-item list without F# is not exciting", {

[<Task(6)>]
test_that("Three-item list with F# as first item is exciting", {
    expect_equal(excitingList [ "F#"; "Lisp"; "Clojure" ], true)

[<Task(6)>]
test_that("Three-item list with F# as second item is exciting", {
    expect_equal(excitingList [ "Java"; "F#"; "C#" ], true)

[<Task(6)>]
test_that("Three-item list with F# as third item is not exciting", {
    expect_equal(excitingList [ "Julia"; "Assembly"; "F#" ], false)

[<Task(6)>]
test_that("Four-item list with F# as first item is exciting", {
    expect_equal(excitingList [ "F#"; "C"; "C++"; "C#" ], true)

[<Task(6)>]
test_that("Four-item list with F# as second item is not exciting", {
    expect_equal(excitingList [ "Elm"; "F#"; "C#"; "Scheme" ], false)

[<Task(6)>]
test_that("Four-item list with F# as third item is not exciting", {
    expect_equal(excitingList [ "Delphi"; "D"; "F#"; "Prolog" ], false)

[<Task(6)>]
test_that("Four-item list with F# as fourth item is not exciting", {
    expect_equal(excitingList [ "Julia"; "Assembly"; "Crystal"; "F#" ], false)
