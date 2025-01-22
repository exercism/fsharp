source("./interest-is-interesting.R")
library(testthat)

test_that("Minimal first interest rate", {

test_that("Tiny first interest rate", {

test_that("Maximum first interest rate", {

test_that("Minimal second interest rate", {

test_that("Tiny second interest rate", {

test_that("Maximum second interest rate", {

test_that("Minimal third interest rate", {

test_that("Tiny third interest rate", {

test_that("Large third interest rate", {

test_that("Minimal negative interest rate", {

test_that("Small negative interest rate", {

test_that("Regular negative interest rate", {

test_that("Large negative interest rate", {

test_that("Interest on negative balance", {

test_that("Interest on small balance", {

test_that("Interest on medium balance", {

test_that("Interest on large balance", {

test_that("Annual balance update for empty start balance", {

test_that("Annual balance update for small positive start balance", {
    annualBalanceUpdate 0.000001m |> should (equalWithin 0.001) 0.000001005m

test_that("Annual balance update for average positive start balance", {
    annualBalanceUpdate 1_000.0m |> should (equalWithin 0.001) 1016.210000m

test_that("Annual balance update for large positive start balance", {
    annualBalanceUpdate 1_000.0001m |> should (equalWithin 0.001) 1016.210101621m

test_that("Annual balance update for huge positive start balance", {
    annualBalanceUpdate 898124017.826243404425m |> should (equalWithin 0.001) 920352587.26744292868451875m

test_that("Annual balance update for small negative start balance", {
    annualBalanceUpdate -0.123M |> should (equalWithin 0.001) -0.12695199M

test_that("Annual balance update for large negative start balance", {
    annualBalanceUpdate -152964.231M |> should (equalWithin 0.001) -157878.97174203M

    expect_equal(test_that("Amount to donate for empty start balance", {

    expect_equal(test_that("Amount to donate for small positive start balance", {

    expect_equal(test_that("Amount to donate for average positive start balance", {

    expect_equal(test_that("Amount to donate for large positive start balance", {

test_that("Amount to donate for huge positive start balance", {
    expect_equal(amountToDonate 898124017.826243404425m 2.65, 47600572)

    expect_equal(test_that("Amount to donate for small negative start balance", {

    expect_equal(test_that("Amount to donate for large negative start balance", {
