source("./pizza-pricing.R")
library(testthat)

    expect_equal(test_that("Price for pizza margherita", {

    expect_equal(test_that("Price for pizza formaggio", {

    expect_equal(test_that("Price for pizza caprese", {

    expect_equal(test_that("Price for pizza margherita with extra sauce", {

    expect_equal(test_that("Price for pizza caprese with extra toppings", {

test_that("Price for pizza formaggio with extra sauce and toppings", {
    expect_equal(pizzaPrice (ExtraSauce(ExtraToppings Caprese)), 12)

test_that("Price for pizza caprese with extra sauce and toppings", {
    expect_equal(pizzaPrice (ExtraToppings(ExtraSauce Formaggio)), 13)

    expect_equal(test_that("Order price for no pizzas", {

    expect_equal(test_that("Order price for single pizza caprese", {

test_that("Order price for single pizza formaggio with extra sauce", {
    expect_equal(orderPrice c( ExtraSauce Formaggio ), 14)

test_that("Order price for one pizza margherita and one pizza caprese with extra toppings", {
    orderPrice
        [ Margherita
          ExtraToppings Caprese ]
    expect_equal( , 20)

test_that("Order price for very large order", {
    orderPrice
        [ Margherita
          ExtraSauce Margherita
          Caprese
          ExtraToppings Caprese
          Formaggio
          ExtraSauce Formaggio
          ExtraToppings(ExtraSauce Formaggio)
          ExtraToppings(ExtraSauce Formaggio) ]
    expect_equal( , 82)

    expect_equal(test_that("Order price for gigantic order", {
