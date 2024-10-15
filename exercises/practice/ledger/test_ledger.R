source("./ledger.R")
library(testthat)

test_that("Empty ledger", {
    let currency = "USD"
    let locale = "en-US"
    let entries = c()
    let expected =
        "Date       | Description               | Change       "

  expect_equal(formatLedger currency locale entries, expected)
})

test_that("One entry", {
    let currency = "USD"
    let locale = "en-US"
    let entries =
        c(
            mkEntry "2015-01-01" "Buy present" -1000
        )
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      ($10.00)"

  expect_equal(formatLedger currency locale entries, expected)
})

test_that("Credit and debit", {
    let currency = "USD"
    let locale = "en-US"
    let entries =
        c(
            mkEntry "2015-01-02" "Get present"  1000;
            mkEntry "2015-01-01" "Buy present" -1000
        )
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      ($10.00)" + System.Environment.NewLine +
        "01/02/2015 | Get present               |       $10.00 "

  expect_equal(formatLedger currency locale entries, expected)
 

test_that("Multiple entries on same date ordered by description", {
    let currency = "USD"
    let locale = "en-US"
    let entries =
        c(
            mkEntry "2015-01-01" "Buy present" -1000;
            mkEntry "2015-01-01" "Get present"  1000
        )
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      ($10.00)" + System.Environment.NewLine +
        "01/01/2015 | Get present               |       $10.00 "

  expect_equal(formatLedger currency locale entries, expected)
   

test_that("Final order tie breaker is change", {
    let currency = "USD"
    let locale = "en-US"
    let entries =
        c(
            mkEntry "2015-01-01" "Something" 0;
            mkEntry "2015-01-01" "Something" -1;
            mkEntry "2015-01-01" "Something" 1
        )
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Something                 |       ($0.01)" + System.Environment.NewLine +
        "01/01/2015 | Something                 |        $0.00 " + System.Environment.NewLine +
        "01/01/2015 | Something                 |        $0.01 "

  expect_equal(formatLedger currency locale entries, expected)
  

test_that("Overlong descriptions", {
    let currency = "USD"
    let locale = "en-US"
    let entries =
        c(
            mkEntry "2015-01-01" "Freude schoner Gotterfunken" -123456
        )
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Freude schoner Gotterf... |   ($1,234.56)"

  expect_equal(formatLedger currency locale entries, expected)
  

test_that("Euros", {
    let currency = "EUR"
    let locale = "en-US"
    let entries =
        c(
            mkEntry "2015-01-01" "Buy present" -1000
        )
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      (€10.00)"

  expect_equal(formatLedger currency locale entries, expected)
   

test_that("Dutch locale", {
    let currency = "USD"
    let locale = "nl-NL"
    let entries =
        c(
            mkEntry "2015-03-12" "Buy present" 123456
        )
    let expected =
        "Datum      | Omschrijving              | Verandering  " + System.Environment.NewLine +
        "12-03-2015 | Buy present               |   $ 1.234,56 "

  expect_equal(formatLedger currency locale entries, expected)
 

test_that("Dutch negative number with 3 digits before decimal point", {
    let currency = "USD"
    let locale = "nl-NL"
    let entries =
        c(
            mkEntry "2015-03-12" "Buy present" -12345
        )
    let expected =
        "Datum      | Omschrijving              | Verandering  " + System.Environment.NewLine +
        "12-03-2015 | Buy present               |     $ -123,45"

  expect_equal(formatLedger currency locale entries, expected)
   

test_that("American negative number with 3 digits before decimal point", {
    let currency = "USD"
    let locale = "en-US"
    let entries =
        c(
            mkEntry "2015-03-12" "Buy present" -12345
        )
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "03/12/2015 | Buy present               |     ($123.45)"

  expect_equal(formatLedger currency locale entries, expected)