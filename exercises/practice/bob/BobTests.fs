source("./bob.R")
library(testthat)

let ``Stating something`` () =
    expect_equal(response "Tom-ay-to, tom-aaaah-to.", "Whatever.")

let ``Shouting`` () =
    expect_equal(response "WATCH OUT!", "Whoa, chill out!")

let ``Shouting gibberish`` () =
    expect_equal(response "FCECDFCAAB", "Whoa, chill out!")

let ``Asking a question`` () =
    expect_equal(response "Does this cryogenic chamber make me look fat?", "Sure.")

let ``Asking a numeric question`` () =
    expect_equal(response "You are, what, like 15?", "Sure.")

let ``Asking gibberish`` () =
    expect_equal(response "fffbbcbeab?", "Sure.")

let ``Talking forcefully`` () =
    expect_equal(response "Hi there!", "Whatever.")

let ``Using acronyms in regular speech`` () =
    expect_equal(response "It's OK if you don't want to go work for NASA.", "Whatever.")

let ``Forceful question`` () =
    expect_equal(response "WHAT'S GOING ON?", "Calm down, I know what I'm doing!")

let ``Shouting numbers`` () =
    expect_equal(response "1, 2, 3 GO!", "Whoa, chill out!")

let ``No letters`` () =
    expect_equal(response "1, 2, 3", "Whatever.")

let ``Question with no letters`` () =
    expect_equal(response "4?", "Sure.")

let ``Shouting with special characters`` () =
    expect_equal(response "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!", "Whoa, chill out!")

let ``Shouting with no exclamation mark`` () =
    expect_equal(response "I HATE THE DENTIST", "Whoa, chill out!")

let ``Statement containing question mark`` () =
    expect_equal(response "Ending with ? means a question.", "Whatever.")

let ``Non-letters with question`` () =
    expect_equal(response ":) ?", "Sure.")

let ``Prattling on`` () =
    expect_equal(response "Wait! Hang on. Are you going to be OK?", "Sure.")

let ``Silence`` () =
    expect_equal(response "", "Fine. Be that way!")

let ``Prolonged silence`` () =
    expect_equal(response "          ", "Fine. Be that way!")

let ``Alternate silence`` () =
    expect_equal(response "\t\t\t\t\t\t\t\t\t\t", "Fine. Be that way!")

let ``Multiple line question`` () =
    expect_equal(response "\nDoes this cryogenic chamber make me look fat?\nNo.", "Whatever.")

let ``Starting with whitespace`` () =
    expect_equal(response "         hmmmmmmm...", "Whatever.")

let ``Ending with whitespace`` () =
    expect_equal(response "Okay if like my  spacebar  quite a bit?   ", "Sure.")

let ``Other whitespace`` () =
    expect_equal(response "\n\r \t", "Fine. Be that way!")

let ``Non-question ending with whitespace`` () =
    expect_equal(response "This is a statement ending with whitespace      ", "Whatever.")

