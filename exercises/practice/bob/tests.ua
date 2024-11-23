~ "bob.ua" ~ Bob

# Stating something
    response "Tom-ay-to, tom-aaaah-to." |> should equal "Whatever."

# Shouting
    response "WATCH OUT!" |> should equal "Whoa, chill out!"

# Shouting gibberish
    response "FCECDFCAAB" |> should equal "Whoa, chill out!"

# Asking a question
    response "Does this cryogenic chamber make me look fat?" |> should equal "Sure."

# Asking a numeric question
    response "You are, what, like 15?" |> should equal "Sure."

# Asking gibberish
    response "fffbbcbeab?" |> should equal "Sure."

# Talking forcefully
    response "Hi there!" |> should equal "Whatever."

# Using acronyms in regular speech
    response "It's OK if you don't want to go work for NASA." |> should equal "Whatever."

# Forceful question
    response "WHAT'S GOING ON?" |> should equal "Calm down, I know what I'm doing!"

# Shouting numbers
    response "1, 2, 3 GO!" |> should equal "Whoa, chill out!"

# No letters
    response "1, 2, 3" |> should equal "Whatever."

# Question with no letters
    response "4?" |> should equal "Sure."

# Shouting with special characters
    response "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!" |> should equal "Whoa, chill out!"

# Shouting with no exclamation mark
    response "I HATE THE DENTIST" |> should equal "Whoa, chill out!"

# Statement containing question mark
    response "Ending with ? means a question." |> should equal "Whatever."

# Non-letters with question
    response ":) ?" |> should equal "Sure."

# Prattling on
    response "Wait! Hang on. Are you going to be OK?" |> should equal "Sure."

# Silence
    response "" |> should equal "Fine. Be that way!"

# Prolonged silence
    response "          " |> should equal "Fine. Be that way!"

# Alternate silence
    response "\t\t\t\t\t\t\t\t\t\t" |> should equal "Fine. Be that way!"

# Multiple line question
    response "\nDoes this cryogenic chamber make me look fat?\nNo." |> should equal "Whatever."

# Starting with whitespace
    response "         hmmmmmmm..." |> should equal "Whatever."

# Ending with whitespace
    response "Okay if like my  spacebar  quite a bit?   " |> should equal "Sure."

# Other whitespace
    response "\n\r \t" |> should equal "Fine. Be that way!"

# Non-question ending with whitespace
    response "This is a statement ending with whitespace      " |> should equal "Whatever."

