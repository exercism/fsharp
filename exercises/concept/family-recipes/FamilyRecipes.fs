module FamilyRecipes

type ParseError = 
| MissingTitle
| MissingIngredients
| MissingInstructions

type Recipe = {
    Title: string
    Ingredients: string
    Instructions: string 
}

let parse input = 
    failwith "Please implement this function"
