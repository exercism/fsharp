source("./interest-is-interesting.R")
library(testthat)

[<Task(1)>]
test_that("Minimal first interest rate", {

[<Task(1)>]
test_that("Tiny first interest rate", {

[<Task(1)>]
test_that("Maximum first interest rate", {

[<Task(1)>]
test_that("Minimal second interest rate", {

[<Task(1)>]
test_that("Tiny second interest rate", {

[<Task(1)>]
test_that("Maximum second interest rate", {

[<Task(1)>]
test_that("Minimal third interest rate", {

[<Task(1)>]
test_that("Tiny third interest rate", {

[<Task(1)>]
test_that("Large third interest rate", {

[<Task(1)>]
test_that("Minimal negative interest rate", {

[<Task(1)>]
test_that("Small negative interest rate", {

[<Task(1)>]
test_that("Regular negative interest rate", {

[<Task(1)>]
test_that("Large negative interest rate", {

[<Task(2)>]
test_that("Interest on negative balance", {

[<Task(2)>]
test_that("Interest on small balance", {

[<Task(2)>]
test_that("Interest on medium balance", {

[<Task(2)>]
test_that("Interest on large balance", {

[<Task(3)>]
test_that("Annual balance update for empty start balance", {

[<Task(3)>]
test_that("Annual balance update for small positive start balance", {
    annualBalanceUpdate 0.000001m |> should (equalWithin 0.001) 0.000001005m

[<Task(3)>]
test_that("Annual balance update for average positive start balance", {
    annualBalanceUpdate 1_000.0m |> should (equalWithin 0.001) 1016.210000m

[<Task(3)>]
test_that("Annual balance update for large positive start balance", {
    annualBalanceUpdate 1_000.0001m |> should (equalWithin 0.001) 1016.210101621m

[<Task(3)>]
test_that("Annual balance update for huge positive start balance", {
    annualBalanceUpdate 898124017.826243404425m |> should (equalWithin 0.001) 920352587.26744292868451875m

[<Task(3)>]
test_that("Annual balance update for small negative start balance", {
    annualBalanceUpdate -0.123M |> should (equalWithin 0.001) -0.12695199M

[<Task(3)>]
test_that("Annual balance update for large negative start balance", {
    annualBalanceUpdate -152964.231M |> should (equalWithin 0.001) -157878.97174203M

[<Task(4)>]
    expect_equal(test_that("Amount to donate for empty start balance", {

[<Task(4)>]
    expect_equal(test_that("Amount to donate for small positive start balance", {

[<Task(4)>]
    expect_equal(test_that("Amount to donate for average positive start balance", {

[<Task(4)>]
    expect_equal(test_that("Amount to donate for large positive start balance", {

[<Task(4)>]
test_that("Amount to donate for huge positive start balance", {
    expect_equal(amountToDonate 898124017.826243404425m 2.65, 47600572)

[<Task(4)>]
    expect_equal(test_that("Amount to donate for small negative start balance", {

[<Task(4)>]
    expect_equal(test_that("Amount to donate for large negative start balance", {
