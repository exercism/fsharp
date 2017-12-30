// This file was auto-generated based on version 1.2.0 of the canonical data.

module BobTest

open FsUnit.Xunit
open Xunit

open Bob

[<Fact>]
let ``Stating something`` () =
    response "Tom-ay-to, tom-aaaah-to." |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``Shouting`` () =
    response "WATCH OUT!" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``Shouting gibberish`` () =
    response "FCECDFCAAB" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``Asking a question`` () =
    response "Does this cryogenic chamber make me look fat?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Asking a numeric question`` () =
    response "You are, what, like 15?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Asking gibberish`` () =
    response "fffbbcbeab?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Talking forcefully`` () =
    response "Let's go make out behind the gym!" |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``Using acronyms in regular speech`` () =
    response "It's OK if you don't want to go to the DMV." |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``Forceful question`` () =
    response "WHAT THE HELL WERE YOU THINKING?" |> should equal "Calm down, I know what I'm doing!"

[<Fact(Skip = "Remove to run test")>]
let ``Shouting numbers`` () =
    response "1, 2, 3 GO!" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``Only numbers`` () =
    response "1, 2, 3" |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``Question with only numbers`` () =
    response "4?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Shouting with special characters`` () =
    response "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``Shouting with no exclamation mark`` () =
    response "I HATE YOU" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``Statement containing question mark`` () =
    response "Ending with ? means a question." |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``Non-letters with question`` () =
    response ":) ?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Prattling on`` () =
    response "Wait! Hang on. Are you going to be OK?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Silence`` () =
    response "" |> should equal "Fine. Be that way!"

[<Fact(Skip = "Remove to run test")>]
let ``Prolonged silence`` () =
    response "          " |> should equal "Fine. Be that way!"

[<Fact(Skip = "Remove to run test")>]
let ``Alternate silence`` () =
    response "\t\t\t\t\t\t\t\t\t\t" |> should equal "Fine. Be that way!"

[<Fact(Skip = "Remove to run test")>]
let ``Multiple line question`` () =
    response "\nDoes this cryogenic chamber make me look fat?\nno" |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``Starting with whitespace`` () =
    response "         hmmmmmmm..." |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``Ending with whitespace`` () =
    response "Okay if like my  spacebar  quite a bit?   " |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Other whitespace`` () =
    response "\n\r \t" |> should equal "Fine. Be that way!"

[<Fact(Skip = "Remove to run test")>]
let ``Non-question ending with whitespace`` () =
    response "This is a statement ending with whitespace      " |> should equal "Whatever."

