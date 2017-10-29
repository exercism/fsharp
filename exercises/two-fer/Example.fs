module TwoFer

let name input =
    input 
    |> Option.defaultValue  "you"
    |> sprintf "One for %s, one for me."