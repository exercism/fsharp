source("./bob.R")
library(testthat)

test_that("Stating something", {
    response "Tom-ay-to, tom-aaaah-to." |> should equal "Whatever."
})

test_that("Shouting", {
    response "WATCH OUT!" |> should equal "Whoa, chill out!"
})

test_that("Shouting gibberish", {
    response "FCECDFCAAB" |> should equal "Whoa, chill out!"
})

test_that("Asking a question", {
    response "Does this cryogenic chamber make me look fat?" |> should equal "Sure."
})

test_that("Asking a numeric question", {
    response "You are, what, like 15?" |> should equal "Sure."
})

test_that("Asking gibberish", {
    response "fffbbcbeab?" |> should equal "Sure."
})

test_that("Talking forcefully", {
    response "Hi there!" |> should equal "Whatever."
})

test_that("Using acronyms in regular speech", {
    response "It's OK if you don't want to go work for NASA." |> should equal "Whatever."
})

test_that("Forceful question", {
    response "WHAT'S GOING ON?" |> should equal "Calm down, I know what I'm doing!"
})

test_that("Shouting numbers", {
    response "1, 2, 3 GO!" |> should equal "Whoa, chill out!"
})

test_that("No letters", {
    response "1, 2, 3" |> should equal "Whatever."
})

test_that("Question with no letters", {
    response "4?" |> should equal "Sure."
})

test_that("Shouting with special characters", {
    response "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!" |> should equal "Whoa, chill out!"
})

test_that("Shouting with no exclamation mark", {
    response "I HATE THE DENTIST" |> should equal "Whoa, chill out!"
})

test_that("Statement containing question mark", {
    response "Ending with ? means a question." |> should equal "Whatever."
})

test_that("Non-letters with question", {
    response ":) ?" |> should equal "Sure."
})

test_that("Prattling on", {
    response "Wait! Hang on. Are you going to be OK?" |> should equal "Sure."
})

test_that("Silence", {
    response "" |> should equal "Fine. Be that way!"
})

test_that("Prolonged silence", {
    response "          " |> should equal "Fine. Be that way!"
})

test_that("Alternate silence", {
    response "\t\t\t\t\t\t\t\t\t\t" |> should equal "Fine. Be that way!"
})

test_that("Multiple line question", {
    response "\nDoes this cryogenic chamber make me look fat?\nNo." |> should equal "Whatever."
})

test_that("Starting with whitespace", {
    response "         hmmmmmmm..." |> should equal "Whatever."
})

test_that("Ending with whitespace", {
    response "Okay if like my  spacebar  quite a bit?   " |> should equal "Sure."
})

test_that("Other whitespace", {
    response "\n\r \t" |> should equal "Fine. Be that way!"
})

test_that("Non-question ending with whitespace", {
    response "This is a statement ending with whitespace      " |> should equal "Whatever."

