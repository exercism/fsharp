module PhoneNumber

let clean input : Result<uint64, string> =
    let clean oldValue (input: string) = input.Replace(oldValue, "")
    let trim (input:string) = input.Trim()

    let cleaned = input |> clean "." |> clean "(" |> clean ")" |> clean "-" |> clean "+" |> clean " " |> trim

    match cleaned.Length with
    | 10 -> Ok(cleaned |> uint64)
    | 11 when cleaned[0] = '1' -> Ok(cleaned[1..] |> uint64)
    | 11 -> Error "11 digits must start with 1"
    | x when x > 11 -> Error "more than 11 digits"
    | _ -> Error "incorrect number of digits"
