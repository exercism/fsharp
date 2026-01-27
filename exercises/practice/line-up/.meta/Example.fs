module LineUp

let suffix (number: int): string =
    match number % 100 with
    | 11 | 12 | 13 -> "th"
    | _ ->
        match number % 10 with
        | 1 -> "st"
        | 2 -> "nd"
        | 3 -> "rd"
        | _ -> "th"

let format (name: string) (number: int): string =
    sprintf "%s, you are the %d%s customer we serve today. Thank you!" name number (suffix number)