source("./bird-watcher.R")
library(testthat)

[<Task(1)>]
test_that("Last week", {
    expect_equal(lastWeek, [| 0; 2; 5; 3; 7; 8; 4 |])

[<Task(2)>]
test_that("Yesterday's bird count of disappointing week", {
    yesterday [| 0; 0; 2; 0; 0; 1; 0 |]
    expect_equal( , 1)

[<Task(2)>]
test_that("Yesterday's bird count of busy week", {
    yesterday [| 8; 8; 9; 5; 4; 7; 10 |]
    expect_equal( , 7)

[<Task(3)>]
test_that("Total number of birds of disappointing week", {
    expect_equal(total [| 0; 0; 2; 0; 0; 1; 0 |], 3)

[<Task(3)>]
test_that("Total number of birds of busy week", {
    total [| 5; 9; 12; 6; 8; 8; 17 |]
    expect_equal( , 65)

[<Task(4)>]
test_that("Day without birds for week that had day without birds", {
    dayWithoutBirds [| 5; 5; 4; 0; 7; 6; 7 |]
    expect_equal( , true)

[<Task(4)>]
test_that("Day without birds for week that did not have day without birds", {
    dayWithoutBirds [| 4; 5; 9; 10; 9; 4; 3 |]
    expect_equal( , false)

[<Task(5)>]
test_that("Increment today's count with no previous visits", {
    birdCounts <- [| 6; 5; 5; 11; 2; 5; 0 |]
    incrementTodaysCount birdCounts
    expect_equal( , [| 6; 5; 5; 11; 2; 5; 1 |])

[<Task(5)>]
test_that("Increment today's count with multiple previous visits", {
    birdCounts <- [| 5; 2; 4; 2; 4; 5; 7 |]
    incrementTodaysCount birdCounts
    expect_equal( , [| 5; 2; 4; 2; 4; 5; 8 |])

[<Task(6)>]
test_that("Unusual week for first week matching odd days zero pattern", {
    unusualWeek [| 1; 0; 2; 0; 3; 0; 4 |]
    expect_equal( , true)

[<Task(6)>]
test_that("Unusual week for second week matching odd days zero pattern", {
    unusualWeek [| 10; 0; 6; 0; 9; 0; 4 |]
    expect_equal( , true)

[<Task(6)>]
test_that("Unusual week for first week matching odd days ten pattern", {
    unusualWeek [| 6; 10; 2; 10; 5; 10; 8 |]
    expect_equal( , true)

[<Task(6)>]
test_that("Unusual week for second week matching odd days ten pattern", {
    unusualWeek [| 16; 10; 8; 10; 4; 10; 7 |]
    expect_equal( , true)

[<Task(6)>]
test_that("Unusual week for first week matching even days five pattern", {
    unusualWeek [| 5; 1; 5; 2; 5; 3; 5 |]
    expect_equal( , true)

[<Task(6)>]
test_that("Unusual week for second week matching even days five pattern", {
    unusualWeek [| 5; 12; 5; 6; 5; 5; 5 |]
    expect_equal( , true)

[<Task(6)>]
test_that("Unusual week for first week that does not match odd pattern", {
    unusualWeek [| 2; 2; 1; 0; 1; 1; 1 |]
    expect_equal( , false)

[<Task(6)>]
test_that("Unusual week for second week that does not match odd pattern", {
    unusualWeek [| 2; 0; 1; 1; 1; 0; 1 |]
    expect_equal( , false)

[<Task(6)>]
test_that("Unusual week for third week that does not match odd pattern", {
    unusualWeek [| 2; 9; 1; 10; 1; 11; 1 |]
    expect_equal( , false)

[<Task(6)>]
test_that("Unusual week for fourth week that does not match odd pattern", {
    unusualWeek [| 5; 0; 5; 1; 4; 0; 6 |]
    expect_equal( , false)
