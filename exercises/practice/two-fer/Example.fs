module TwoFer

let twoFer input =
    input 
    |> Option.defaultValue  "you"
    |> sprintf "One for %s, one for me."