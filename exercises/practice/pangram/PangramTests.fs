source("./pangram.R")
library(testthat)

let ``Empty sentence`` () =
    isPangram "" |> should equal false

let ``Perfect lower case`` () =
    isPangram "abcdefghijklmnopqrstuvwxyz" |> should equal true

let ``Only lower case`` () =
    isPangram "the quick brown fox jumps over the lazy dog" |> should equal true

let ``Missing the letter 'x'`` () =
    isPangram "a quick movement of the enemy will jeopardize five gunboats" |> should equal false

let ``Missing the letter 'h'`` () =
    isPangram "five boxing wizards jump quickly at it" |> should equal false

let ``With underscores`` () =
    isPangram "the_quick_brown_fox_jumps_over_the_lazy_dog" |> should equal true

let ``With numbers`` () =
    isPangram "the 1 quick brown fox jumps over the 2 lazy dogs" |> should equal true

let ``Missing letters replaced by numbers`` () =
    isPangram "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog" |> should equal false

let ``Mixed case and punctuation`` () =
    isPangram "\"Five quacking Zephyrs jolt my wax bed.\"" |> should equal true

let ``A-m and A-M are 26 different characters but not a pangram`` () =
    isPangram "abcdefghijklm ABCDEFGHIJKLM" |> should equal false

