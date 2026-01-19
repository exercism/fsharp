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

type ParseState = 
| ReadingTitle
| SeekingIngredientsHeading
| ReadingIngredientsList
| SeekingInstructionsHeading
| ReadingInstructions

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
        parseLines(lines[1..], ReadingIngredientsList, {recipe with Ingredients = lines[0]})

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
            Ok(recipe)
    else
        parseLines(lines[1..], ReadingInstructions, {recipe with Instructions = recipe.Instructions + lines[0]})

let parse (input: string) : Result<Recipe, ParseError> = 
    parseLines(input.Split('\n'), ReadingTitle, {Title = ""; Ingredients = ""; Instructions = ""})
