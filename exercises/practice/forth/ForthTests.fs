source("./forth.R")
library(testthat)

test_that("Parsing and numbers - numbers just get pushed onto the stack", {
    expected <- Some [1; 2; 3; 4; 5]
    expect_equal(evaluate ["1 2 3 4 5"], expected)

test_that("Parsing and numbers - pushes negative numbers onto the stack", {
    expected <- Some [-1; -2; -3; -4; -5]
    expect_equal(evaluate ["-1 -2 -3 -4 -5"], expected)

test_that("Addition - can add two numbers", {
    expected <- Some [3]
    expect_equal(evaluate ["1 2 +"], expected)

test_that("Addition - errors if there is nothing on the stack", {
    expected <- None
    expect_equal(evaluate ["+"], expected)

test_that("Addition - errors if there is only one value on the stack", {
    expected <- None
    expect_equal(evaluate ["1 +"], expected)

test_that("Subtraction - can subtract two numbers", {
    expected <- Some [-1]
    expect_equal(evaluate ["3 4 -"], expected)

test_that("Subtraction - errors if there is nothing on the stack", {
    expected <- None
    expect_equal(evaluate ["-"], expected)

test_that("Subtraction - errors if there is only one value on the stack", {
    expected <- None
    expect_equal(evaluate ["1 -"], expected)

test_that("Multiplication - can multiply two numbers", {
    expected <- Some [8]
    expect_equal(evaluate ["2 4 *"], expected)

test_that("Multiplication - errors if there is nothing on the stack", {
    expected <- None
    expect_equal(evaluate ["*"], expected)

test_that("Multiplication - errors if there is only one value on the stack", {
    expected <- None
    expect_equal(evaluate ["1 *"], expected)

test_that("Division - can divide two numbers", {
    expected <- Some [4]
    expect_equal(evaluate ["12 3 /"], expected)

test_that("Division - performs integer division", {
    expected <- Some [2]
    expect_equal(evaluate ["8 3 /"], expected)

test_that("Division - errors if dividing by zero", {
    expected <- None
    expect_equal(evaluate ["4 0 /"], expected)

test_that("Division - errors if there is nothing on the stack", {
    expected <- None
    expect_equal(evaluate ["/"], expected)

test_that("Division - errors if there is only one value on the stack", {
    expected <- None
    expect_equal(evaluate ["1 /"], expected)

test_that("Combined arithmetic - addition and subtraction", {
    expected <- Some [-1]
    expect_equal(evaluate ["1 2 + 4 -"], expected)

test_that("Combined arithmetic - multiplication and division", {
    expected <- Some [2]
    expect_equal(evaluate ["2 4 * 3 /"], expected)

test_that("Dup - copies a value on the stack", {
    expected <- Some [1; 1]
    expect_equal(evaluate ["1 dup"], expected)

test_that("Dup - copies the top value on the stack", {
    expected <- Some [1; 2; 2]
    expect_equal(evaluate ["1 2 dup"], expected)

test_that("Dup - errors if there is nothing on the stack", {
    expected <- None
    expect_equal(evaluate ["dup"], expected)

test_that("Drop - removes the top value on the stack if it is the only one", {
    let expected: int list option = Some []
    expect_equal(evaluate ["1 drop"], expected)

test_that("Drop - removes the top value on the stack if it is not the only one", {
    expected <- Some [1]
    expect_equal(evaluate ["1 2 drop"], expected)

test_that("Drop - errors if there is nothing on the stack", {
    expected <- None
    expect_equal(evaluate ["drop"], expected)

test_that("Swap - swaps the top two values on the stack if they are the only ones", {
    expected <- Some [2; 1]
    expect_equal(evaluate ["1 2 swap"], expected)

test_that("Swap - swaps the top two values on the stack if they are not the only ones", {
    expected <- Some [1; 3; 2]
    expect_equal(evaluate ["1 2 3 swap"], expected)

test_that("Swap - errors if there is nothing on the stack", {
    expected <- None
    expect_equal(evaluate ["swap"], expected)

test_that("Swap - errors if there is only one value on the stack", {
    expected <- None
    expect_equal(evaluate ["1 swap"], expected)

test_that("Over - copies the second element if there are only two", {
    expected <- Some [1; 2; 1]
    expect_equal(evaluate ["1 2 over"], expected)

test_that("Over - copies the second element if there are more than two", {
    expected <- Some [1; 2; 3; 2]
    expect_equal(evaluate ["1 2 3 over"], expected)

test_that("Over - errors if there is nothing on the stack", {
    expected <- None
    expect_equal(evaluate ["over"], expected)

test_that("Over - errors if there is only one value on the stack", {
    expected <- None
    expect_equal(evaluate ["1 over"], expected)

test_that("User-defined words - can consist of built-in words", {
    expected <- Some [1; 1; 1]
    expect_equal(evaluate [": dup-twice dup dup ;"; "1 dup-twice"], expected)

test_that("User-defined words - execute in the right order", {
    expected <- Some [1; 2; 3]
    expect_equal(evaluate [": countup 1 2 3 ;"; "countup"], expected)

test_that("User-defined words - can override other user-defined words", {
    expected <- Some [1; 1; 1]
    expect_equal(evaluate [": foo dup ;"; ": foo dup dup ;"; "1 foo"], expected)

test_that("User-defined words - can override built-in words", {
    expected <- Some [1; 1]
    expect_equal(evaluate [": swap dup ;"; "1 swap"], expected)

test_that("User-defined words - can override built-in operators", {
    expected <- Some [12]
    expect_equal(evaluate [": + * ;"; "3 4 +"], expected)

test_that("User-defined words - can use different words with the same name", {
    expected <- Some [5; 6]
    expect_equal(evaluate [": foo 5 ;"; ": bar foo ;"; ": foo 6 ;"; "bar foo"], expected)

test_that("User-defined words - can define word that uses word with the same name", {
    expected <- Some [11]
    expect_equal(evaluate [": foo 10 ;"; ": foo foo 1 + ;"; "foo"], expected)

test_that("User-defined words - cannot redefine non-negative numbers", {
    expected <- None
    expect_equal(evaluate [": 1 2 ;"], expected)

test_that("User-defined words - cannot redefine negative numbers", {
    expected <- None
    expect_equal(evaluate [": -1 2 ;"], expected)

test_that("User-defined words - errors if executing a non-existent word", {
    expected <- None
    expect_equal(evaluate ["foo"], expected)

test_that("User-defined words - only defines locally", {
    expect_equal(evaluate [": + - ;"; "1 1 +"], (Some [0]))
    expect_equal(evaluate ["1 1 +"], (Some [2]))

test_that("Case-insensitivity - DUP is case-insensitive", {
    expected <- Some [1; 1; 1; 1]
    expect_equal(evaluate ["1 DUP Dup dup"], expected)

test_that("Case-insensitivity - DROP is case-insensitive", {
    expected <- Some [1]
    expect_equal(evaluate ["1 2 3 4 DROP Drop drop"], expected)

test_that("Case-insensitivity - SWAP is case-insensitive", {
    expected <- Some [2; 3; 4; 1]
    expect_equal(evaluate ["1 2 SWAP 3 Swap 4 swap"], expected)

test_that("Case-insensitivity - OVER is case-insensitive", {
    expected <- Some [1; 2; 1; 2; 1]
    expect_equal(evaluate ["1 2 OVER Over over"], expected)

test_that("Case-insensitivity - user-defined words are case-insensitive", {
    expected <- Some [1; 1; 1; 1]
    expect_equal(evaluate [": foo dup ;"; "1 FOO Foo foo"], expected)

test_that("Case-insensitivity - definitions are case-insensitive", {
    expected <- Some [1; 1; 1; 1]
    expect_equal(evaluate [": SWAP DUP Dup dup ;"; "1 swap"], expected)

