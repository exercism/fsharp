module FamilyRecipes

type ValidationError = 
| EmptyList
| InvalidIngredientQuantity
| MissingIngredientItem

let parseInt (text: string) : Result<int, unit> =
    let success, value = System.Int32.TryParse text
    if success then Ok value else Error ()

let validate input = 
    failwith "Please implement this function"
