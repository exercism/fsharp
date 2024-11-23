module ReverseStringTests



let ``An empty string`` () =
    reverse "" |> should equal ""

let ``A word`` () =
    reverse "robot" |> should equal "tobor"

let ``A capitalized word`` () =
    reverse "Ramen" |> should equal "nemaR"

let ``A sentence with punctuation`` () =
    reverse "I'm hungry!" |> should equal "!yrgnuh m'I"

let ``A palindrome`` () =
    reverse "racecar" |> should equal "racecar"

let ``An even-sized word`` () =
    reverse "drawer" |> should equal "reward"

