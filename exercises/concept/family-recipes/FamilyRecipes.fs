module FamilyRecipes

type ParseError = 
| MissingTitle
| MissingIngredients
| MissingInstructions
| InvalidIngredientQuantity
| MissingIngredientItem

type Ingredient = {
    Quantity: int
    Item: string
}

type Recipe = {
    Title: string
    Ingredients: Ingredient list
    Instructions: string 
}

let parse input = 
    failwith "Please implement this function"
