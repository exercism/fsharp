module BobTest

open Xunit
open FsUnit
open Bob
    
[<Fact>]
let ``Stating something`` () =
    hey "Tom-ay-to, tom-aaaah-to." |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``Shouting`` () =
    hey "WATCH OUT!" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``Asking a question`` () =
    hey "Does this cryogenic chamber make me look fat?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Asking a numeric question`` () =
    hey "You are, what, like 15?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Forceful questions`` () =
    hey "WHAT THE HELL WERE YOU THINKING?" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``Shouting numbers`` () =
    hey "1, 2, 3 GO!" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``Only numbers`` () =
    hey "1, 2, 3" |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``Question only with numbers`` () =
    hey "4?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Shouting with special characters`` () =
    hey "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``Shouting with no exlamation mark`` () =
    hey "I HATE YOU" |> should equal "Whoa, chill out!"

[<Fact(Skip = "Remove to run test")>]
let ``Statement containing question mark`` () =
    hey "Ending with ? means a question." |> should equal "Whatever."

[<Fact(Skip = "Remove to run test")>]
let ``Prattling on`` () =
    hey "Wait! Hang on. Are you going to be OK?" |> should equal "Sure."

[<Fact(Skip = "Remove to run test")>]
let ``Silence`` () =
    hey "" |> should equal "Fine. Be that way!"

[<Fact(Skip = "Remove to run test")>]
let ``Prolonged silence`` () =
    hey "    " |> should equal "Fine. Be that way!"

[<Fact(Skip = "Remove to run test")>]
let ``Multiple line question`` () =
    hey "Does this cryogenic chamber make me look fat?\nno" |> should equal "Whatever."