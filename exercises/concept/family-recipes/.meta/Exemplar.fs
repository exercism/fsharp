module FamilyRecipes

type ValidationError = 
| EmptyList
| InvalidIngredientQuantity
| MissingIngredientItem

let parseInt (text: string) : Result<int, unit> =
    let success, value = System.Int32.TryParse text
    if success then Ok value else Error ()

let splitOnce (text: string) (separator: char) : (string * string) option = 
    match text.IndexOf(separator) with
    | -1 -> None
    | index -> Some (text.Substring(0, index), text.Substring(index + 1))

let validateIngredient (text: string): Result<unit, ValidationError> =
    match splitOnce text ' ' with
    | Some (quantity, item) -> 
        match parseInt quantity with
        | Ok _ -> 
            if item.Length = 0 then 
                Error MissingIngredientItem
            else
                Ok ()
        | Error _ -> Error InvalidIngredientQuantity
    | _ -> Error MissingIngredientItem

let validate (input: string) : Result<string, ValidationError> = 
    let nonblankLines =
        input.Split('\n')
        |> Array.filter (fun l -> l.Length > 0)
    if nonblankLines.Length = 0 then Error EmptyList
    else
        let firstError = 
            nonblankLines
            |> Array.map validateIngredient
            |> Array.tryFind (fun r -> r.IsError)
        match firstError with
        | Some (Error error) -> Error error
        | _ -> Ok input
