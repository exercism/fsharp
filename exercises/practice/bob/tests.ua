~ "bob.ua" ~ Bob

let ``Stating something`` () =
    response "Tom-ay-to, tom-aaaah-to." |> should equal "Whatever."

let ``Shouting`` () =
    response "WATCH OUT!" |> should equal "Whoa, chill out!"

let ``Shouting gibberish`` () =
    response "FCECDFCAAB" |> should equal "Whoa, chill out!"

let ``Asking a question`` () =
    response "Does this cryogenic chamber make me look fat?" |> should equal "Sure."

let ``Asking a numeric question`` () =
    response "You are, what, like 15?" |> should equal "Sure."

let ``Asking gibberish`` () =
    response "fffbbcbeab?" |> should equal "Sure."

let ``Talking forcefully`` () =
    response "Hi there!" |> should equal "Whatever."

let ``Using acronyms in regular speech`` () =
    response "It's OK if you don't want to go work for NASA." |> should equal "Whatever."

let ``Forceful question`` () =
    response "WHAT'S GOING ON?" |> should equal "Calm down, I know what I'm doing!"

let ``Shouting numbers`` () =
    response "1, 2, 3 GO!" |> should equal "Whoa, chill out!"

let ``No letters`` () =
    response "1, 2, 3" |> should equal "Whatever."

let ``Question with no letters`` () =
    response "4?" |> should equal "Sure."

let ``Shouting with special characters`` () =
    response "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!" |> should equal "Whoa, chill out!"

let ``Shouting with no exclamation mark`` () =
    response "I HATE THE DENTIST" |> should equal "Whoa, chill out!"

let ``Statement containing question mark`` () =
    response "Ending with ? means a question." |> should equal "Whatever."

let ``Non-letters with question`` () =
    response ":) ?" |> should equal "Sure."

let ``Prattling on`` () =
    response "Wait! Hang on. Are you going to be OK?" |> should equal "Sure."

let ``Silence`` () =
    response "" |> should equal "Fine. Be that way!"

let ``Prolonged silence`` () =
    response "          " |> should equal "Fine. Be that way!"

let ``Alternate silence`` () =
    response "\t\t\t\t\t\t\t\t\t\t" |> should equal "Fine. Be that way!"

let ``Multiple line question`` () =
    response "\nDoes this cryogenic chamber make me look fat?\nNo." |> should equal "Whatever."

let ``Starting with whitespace`` () =
    response "         hmmmmmmm..." |> should equal "Whatever."

let ``Ending with whitespace`` () =
    response "Okay if like my  spacebar  quite a bit?   " |> should equal "Sure."

let ``Other whitespace`` () =
    response "\n\r \t" |> should equal "Fine. Be that way!"

let ``Non-question ending with whitespace`` () =
    response "This is a statement ending with whitespace      " |> should equal "Whatever."

