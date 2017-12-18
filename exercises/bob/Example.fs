module Bob

open System

let response (input: string) = 
    let isEmpty = String.IsNullOrWhiteSpace input
    let isYell = Seq.exists Char.IsLetter input && input = input.ToUpperInvariant()
    let isQuestion = input.Trim().EndsWith "?"

    match input with 
        | _ when isEmpty -> 
            "Fine. Be that way!"
        | _ when isYell && isQuestion -> 
            "Calm down, I know what I'm doing!"
        | _ when isYell -> 
            "Whoa, chill out!"
        | _ when isQuestion -> 
            "Sure."
        | _ -> 
            "Whatever."