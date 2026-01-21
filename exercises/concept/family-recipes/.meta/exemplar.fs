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

type ParseState = 
| ReadingTitle
| SeekingIngredientsHeading
| ReadingIngredientsList
| SeekingInstructionsHeading
| ReadingInstructions


let splitOnce (text: string) (separator: char): (string * string) option = 
    match text.IndexOf(separator) with
    | -1 -> None
    | index -> Some (text.Substring(0, index), text.Substring(index + 1))

let parseIngredient (text: string): Result<Ingredient, ParseError> =
    match splitOnce text ' ' with
    | Some (head, tail) -> 
        let success, quantity = System.Int32.TryParse head
        if success then
            Ok {
                Quantity = quantity
                Item = tail
            }
        else
            Error InvalidIngredientQuantity
    | _ -> Error MissingIngredientItem

let parseTitle (line: string) (recipe: Recipe) : Result<ParseState * Recipe, ParseError> = 
    if line.Length = 0 then
        Error MissingTitle
    else
        Ok (SeekingIngredientsHeading, { recipe with Title = line })

let parseIngredientsHeading (line: string) (recipe: Recipe) : Result<ParseState * Recipe, ParseError> = 
    let nextState = if line = "Ingredients:" then ReadingIngredientsList else SeekingIngredientsHeading
    Ok (nextState, recipe)

let parseIngredientsList (line: string) (recipe: Recipe) : Result<ParseState * Recipe, ParseError> = 
    if recipe.Ingredients.Length = 0 && line.Length = 0 then
        Error MissingIngredients
    elif line.Length = 0 then
        Ok (SeekingInstructionsHeading, recipe)
    else
        match parseIngredient line with
        | Ok ingredient -> Ok (ReadingIngredientsList, {
                recipe with Ingredients = recipe.Ingredients @ [ingredient]
            })
        | Error e -> Error e

let parseInstructionsHeading (line: string) (recipe: Recipe) : Result<ParseState * Recipe, ParseError> = 
    let nextState = if line = "Instructions:" then ReadingInstructions else SeekingInstructionsHeading
    Ok (nextState, recipe)

let parseReadingInstructions (line: string) (recipe: Recipe) : Result<ParseState * Recipe, ParseError> = 
    let separator = if recipe.Instructions.Length = 0 then "" else "\n"
    Ok (ReadingInstructions, { 
        recipe with Instructions = recipe.Instructions + separator + line
    })

let parseLine (stateRecipe: Result<ParseState * Recipe, ParseError>) (line: string) : Result<ParseState * Recipe, ParseError> =
    match stateRecipe with
    | Ok (state, recipe) ->
        let lineParser = 
            match state with
            | ReadingTitle -> parseTitle
            | SeekingIngredientsHeading -> parseIngredientsHeading
            | ReadingIngredientsList -> parseIngredientsList
            | SeekingInstructionsHeading -> parseInstructionsHeading
            | ReadingInstructions -> parseReadingInstructions
        lineParser line recipe
    | Error e -> Error e

let parseLines (lines: string array): Result<Recipe, ParseError> = 
    let initialState: ParseState = ReadingTitle
    let initialRecipe: Recipe = { Title = ""; Ingredients = []; Instructions = "" }
    let result = lines |> Array.fold parseLine (Ok (initialState, initialRecipe))
    match result with 
    | Ok (_, recipe) -> Ok recipe
    | Error e -> Error e

let parse (input: string) : Result<Recipe, ParseError> = 
    match parseLines (input.Split('\n')) with
    | Ok recipe ->
        if recipe.Ingredients.Length = 0 then Error MissingIngredients
        elif recipe.Instructions.Length = 0 then Error MissingInstructions
        else Ok recipe
    | Error e -> Error e
