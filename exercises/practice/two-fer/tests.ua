

let ``No name given`` () =
    twoFer None |> should equal "One for you, one for me."

let ``A name given`` () =
    twoFer (Some "Alice") |> should equal "One for Alice, one for me."

let ``Another name given`` () =
    twoFer (Some "Bob") |> should equal "One for Bob, one for me."

