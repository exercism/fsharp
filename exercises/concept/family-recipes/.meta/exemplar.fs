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


let removeTrailingNewline (text: string): string =
    if text[text.Length - 1] = '\n' then
        text[0..text.Length - 2]
    else
        text

let splitOnce (text: string) (separator: char): (string * string) option = 
    match text.IndexOf(separator) with
    | -1 -> None
    | index -> Some((text.Substring(0, index), text.Substring(index + 1)))

let parseIngredient (text: string): Result<Ingredient, ParseError> =
    match splitOnce text ' ' with
    | Some(head, tail) -> 
        let success, quantity = System.Int32.TryParse head
        if success then
            Ok {
                Quantity = quantity
                Item = tail
            }
        else
            Error InvalidIngredientQuantity
    | _ -> Error MissingIngredientItem

let rec parseLines (lines: string array, state: ParseState, recipe: Recipe): Result<Recipe, ParseError> = 
    match state with
    | ReadingTitle -> parseTitle lines recipe
    | SeekingIngredientsHeading -> parseIngredientsHeading lines recipe
    | ReadingIngredientsList -> parseIngredientsList lines recipe
    | SeekingInstructionsHeading -> parseInstructionsHeading lines recipe
    | ReadingInstructions -> parseReadingInstructions lines recipe

and parseTitle lines recipe = 
    if lines.Length = 0 || lines[0].Length = 0 then
        Error MissingTitle
    else
        parseLines(lines[1..], SeekingIngredientsHeading, {recipe with Title = lines[0]})

and parseIngredientsHeading lines recipe =
    if lines.Length = 0 then
        Error MissingIngredients
    else
        let nextState = if lines[0] = "Ingredients:" then ReadingIngredientsList else SeekingIngredientsHeading
        parseLines(lines[1..], nextState, recipe)

and parseIngredientsList lines recipe =
    if lines.Length = 0 then
        if recipe.Ingredients.Length = 0 then
            Error MissingIngredients
        else
            Error MissingInstructions
    elif lines[0].Length = 0 then
        if recipe.Ingredients.Length = 0 then
            Error MissingIngredients
        else
            parseLines(lines[1..], SeekingInstructionsHeading, recipe)
    else
        match parseIngredient lines[0] with
        | Ok ingredient -> parseLines(lines[1..], ReadingIngredientsList, {
                recipe with Ingredients = recipe.Ingredients @ [ingredient]
            })
        | Error e -> Error e

and parseInstructionsHeading lines recipe =
    if lines.Length = 0 then
        Error MissingInstructions
    else
        let nextState = if lines[0] = "Instructions:" then ReadingInstructions else SeekingInstructionsHeading
        parseLines(lines[1..], nextState, recipe)

and parseReadingInstructions lines recipe =
    if lines.Length = 0 then
        if recipe.Instructions.Length = 0 then
            Error MissingInstructions
        else
            Ok({ recipe with Instructions = recipe.Instructions |> removeTrailingNewline })
    else
        parseLines(lines[1..], ReadingInstructions, {recipe with Instructions = recipe.Instructions + lines[0] + "\n"})

let parse (input: string) : Result<Recipe, ParseError> = 
    parseLines(input.Split('\n'), ReadingTitle, {Title = ""; Ingredients = []; Instructions = ""})
