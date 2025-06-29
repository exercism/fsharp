import "bob"

-- Stating something
-- ==
-- input { "Tom-ay-to, tom-aaaah-to." }
-- output { "Whatever." }

-- Shouting
-- ==
-- input { "WATCH OUT!" }
-- output { "Whoa, chill out!" }

-- Shouting gibberish
-- ==
-- input { "FCECDFCAAB" }
-- output { "Whoa, chill out!" }

-- Asking a question
-- ==
-- input { "Does this cryogenic chamber make me look fat?" }
-- output { "Sure." }

-- Asking a numeric question
-- ==
-- input { "You are, what, like 15?" }
-- output { "Sure." }

-- Asking gibberish
-- ==
-- input { "fffbbcbeab?" }
-- output { "Sure." }

-- Talking forcefully
-- ==
-- input { "Hi there!" }
-- output { "Whatever." }

-- Using acronyms in regular speech
-- ==
-- input { "It's OK if you don't want to go work for NASA." }
-- output { "Whatever." }

-- Forceful question
-- ==
-- input { "WHAT'S GOING ON?" }
-- output { "Calm down, I know what I'm doing!" }

-- Shouting numbers
-- ==
-- input { "1, 2, 3 GO!" }
-- output { "Whoa, chill out!" }

-- No letters
-- ==
-- input { "1, 2, 3" }
-- output { "Whatever." }

-- Question with no letters
-- ==
-- input { "4?" }
-- output { "Sure." }

-- Shouting with special characters
-- ==
-- input { "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!" }
-- output { "Whoa, chill out!" }

-- Shouting with no exclamation mark
-- ==
-- input { "I HATE THE DENTIST" }
-- output { "Whoa, chill out!" }

-- Statement containing question mark
-- ==
-- input { "Ending with ? means a question." }
-- output { "Whatever." }

-- Non-letters with question
-- ==
-- input { ":) ?" }
-- output { "Sure." }

-- Prattling on
-- ==
-- input { "Wait! Hang on. Are you going to be OK?" }
-- output { "Sure." }

-- Silence
-- ==
-- input { "" }
-- output { "Fine. Be that way!" }

-- Prolonged silence
-- ==
-- input { "          " }
-- output { "Fine. Be that way!" }

-- Alternate silence
-- ==
-- input { "\t\t\t\t\t\t\t\t\t\t" }
-- output { "Fine. Be that way!" }

-- Multiple line question
-- ==
-- input { "\nDoes this cryogenic chamber make me look fat?\nNo." }
-- output { "Whatever." }

-- Starting with whitespace
-- ==
-- input { "         hmmmmmmm..." }
-- output { "Whatever." }

-- Ending with whitespace
-- ==
-- input { "Okay if like my  spacebar  quite a bit?   " }
-- output { "Sure." }

-- Other whitespace
-- ==
-- input { "\n\r \t" }
-- output { "Fine. Be that way!" }

-- Non-question ending with whitespace
-- ==
-- input { "This is a statement ending with whitespace      " }
-- output { "Whatever." }

