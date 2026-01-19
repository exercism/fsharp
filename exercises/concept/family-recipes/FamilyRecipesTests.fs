module Tests

open FsUnit.Xunit
open Xunit

open FamilyRecipes

[<Fact>]
let ``Error on blank recipe`` () =
    let expected: Result<Recipe, ParseError> = Error MissingTitle
    parse "" |> should equal expected

[<Fact>]
let ``Error on title without ingredients or instructions`` () =
    let expected: Result<Recipe, ParseError> = Error MissingIngredients
    parse "foo" |> should equal expected

[<Fact>]
let ``Error on title and ingredients heading without ingredients list`` () =
    let expected: Result<Recipe, ParseError> = Error MissingIngredients
    parse "A Title\n\nIngredients:" |> should equal expected

[<Fact>]
let ``Error on title and ingredients without instructions`` () =
    let expected: Result<Recipe, ParseError> = Error MissingInstructions
    parse "A Title\n\nIngredients:\nsome ingredient" |> should equal expected

[<Fact>]
let ``Error on all required sections but with empty ingredients list`` () = 
    let expected: Result<Recipe, ParseError> = Error MissingIngredients
    parse "A Title\n\nIngredients:\n\nInstructions:\nSome instructions" |> should equal expected

[<Fact>]
let ``Error on all required sections but missing instructions`` () =
    let expected: Result<Recipe, ParseError> = Error MissingInstructions
    parse "A Title\n\nIngredients:\nSome ingredient\n\nInstructions:" |> should equal expected

[<Fact>]
let ``Success on minimal recipe`` () =
    let expected: Result<Recipe, ParseError> = Ok {
            Title = "Glass of Wine"
            Ingredients = "1 cup wine"
            Instructions = "Pour wine into wine glass."
        }
    let input = """Glass of Wine

Ingredients:
1 cup wine

Instructions:
Pour wine into wine glass.
"""
    parse input |> should equal expected

// TODO: Make Ingredients a list of Ingredient records, with quantity, units, and substance
// TODO: Add Ingredients tests for missing/bad quantities, missing/bad units, missing substance
// TODO: Test the ability to parse fractional quantities
// TODO: Organize into tasks
