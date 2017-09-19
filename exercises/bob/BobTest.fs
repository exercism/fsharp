// This file was auto-generated based on version 1.0.0 of the canonical data.

module BobTest

open FsUnit.Xunit
open Xunit

open Bob

[<Fact>]
let ``stating something`` () =
    response "Tom-ay-to, tom-aaaah-to." |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``shouting`` () =
    response "WATCH OUT!" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``shouting gibberish`` () =
    response "FCECDFCAAB" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``asking a question`` () =
    response "Does this cryogenic chamber make me look fat?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``asking a numeric question`` () =
    response "You are, what, like 15?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``asking gibberish`` () =
    response "fffbbcbeab?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``talking forcefully`` () =
    response "Let's go make out behind the gym!" |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``using acronyms in regular speech`` () =
    response "It's OK if you don't want to go to the DMV." |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``forceful question`` () =
    response "WHAT THE HELL WERE YOU THINKING?" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``shouting numbers`` () =
    response "1, 2, 3 GO!" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``only numbers`` () =
    response "1, 2, 3" |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``question with only numbers`` () =
    response "4?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``shouting with special characters`` () =
    response "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``shouting with no exclamation mark`` () =
    response "I HATE YOU" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``statement containing question mark`` () =
    response "Ending with ? means a question." |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``non-letters with question`` () =
    response ":) ?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``prattling on`` () =
    response "Wait! Hang on. Are you going to be OK?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``silence`` () =
    response "" |> should equal "Fine. Be that way!"

[<Fact(Skip = "Remove to run test")>]
let ``prolonged silence`` () =
    response "          " |> should equal "Fine. Be that way!"

[<Fact(Skip = "Remove to run test")>]
let ``alternate silence`` () =
    response "\t\t\t\t\t\t\t\t\t\t" |> should equal "Fine. Be that way!"

[<Fact(Skip = "Remove to run test")>]
let ``multiple line question`` () =
    response "\nDoes this cryogenic chamber make me look fat?\nno" |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``starting with whitespace`` () =
    response "         hmmmmmmm..." |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``ending with whitespace`` () =
    response "Okay if like my  spacebar  quite a bit?   " |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``other whitespace`` () =
    response "\n\r \t" |> should equal "Fine. Be that way!"

[<Fact(Skip = "Remove to run test")>]
let ``non-question ending with whitespace`` () =
    response "This is a statement ending with whitespace      " |> should equal "Whatever."

