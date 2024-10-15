source("./matching-brackets.R")
library(testthat)




test_that("Paired square brackets", {
    isPaired "[]" |> should equal true


test_that("Empty string", {
    isPaired "" |> should equal true


test_that("Unpaired brackets", {
    isPaired "[[" |> should equal false


test_that("Wrong ordered brackets", {
    isPaired "}{" |> should equal false


test_that("Wrong closing bracket", {
    isPaired "{]" |> should equal false


test_that("Paired with whitespace", {
    isPaired "{ }" |> should equal true


test_that("Partially paired brackets", {
    isPaired "{[])" |> should equal false


test_that("Simple nested brackets", {
    isPaired "{[]}" |> should equal true


test_that("Several paired brackets", {
    isPaired "{}[]" |> should equal true


test_that("Paired and nested brackets", {
    isPaired "([{}({}[])])" |> should equal true


test_that("Unopened closing brackets", {
    isPaired "{[)][]}" |> should equal false


test_that("Unpaired and nested brackets", {
    isPaired "([{])" |> should equal false


test_that("Paired and wrong nested brackets", {
    isPaired "[({]})" |> should equal false


test_that("Paired and wrong nested brackets but innermost are correct", {
    isPaired "[({}])" |> should equal false


test_that("Paired and incomplete brackets", {
    isPaired "{}[" |> should equal false


test_that("Too many closing brackets", {
    isPaired "[]]" |> should equal false


test_that("Early unexpected brackets", {
    isPaired ")()" |> should equal false


test_that("Early mismatched brackets", {
    isPaired "{)()" |> should equal false


test_that("Math expression", {
    isPaired "(((185 + 223.85) * 15) - 543)/2" |> should equal true


test_that("Complex latex expression", {
    isPaired "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)" |> should equal true

