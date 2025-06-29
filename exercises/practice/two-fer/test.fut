import "two_fer"

let ``No name given`` () =
    twoFer None |> should equal "One for you, one for me."

let ``A name given`` () =
    twoFer "Alice" |> should equal "One for Alice, one for me."

let ``Another name given`` () =
    twoFer "Bob" |> should equal "One for Bob, one for me."

