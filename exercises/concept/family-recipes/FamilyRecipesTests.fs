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
    parse "A Title\n\nIngredients:\n1 ingredient" |> should equal expected

[<Fact>]
let ``Error on all required sections but with empty ingredients list`` () = 
    let expected: Result<Recipe, ParseError> = Error MissingIngredients
    parse "A Title\n\nIngredients:\n\nInstructions:\nSome instructions" |> should equal expected

[<Fact>]
let ``Error on all required sections but missing instructions`` () =
    let expected: Result<Recipe, ParseError> = Error MissingInstructions
    parse "A Title\n\nIngredients:\n1 ingredient\n\nInstructions:" |> should equal expected

[<Fact>]
let ``Error on non-numeric ingredient quantity`` () =
    let expected: Result<Recipe, ParseError> = Error InvalidIngredientQuantity
    parse "A Title\n\nIngredients:\nfoo bar\n\nInstructions:\nbuzz" |> should equal expected

[<Fact>]
let ``Error on missing ingredient item`` () =
    let expected: Result<Recipe, ParseError> = Error MissingIngredientItem
    parse "A Title\n\nIngredients:\n24\n\nInstructions:\nbuzz" |> should equal expected


[<Fact>]
let ``Minimal valid recipe`` () =
    let expected: Result<Recipe, ParseError> = Ok {
            Title = "Glass of Wine"
            Ingredients = [
                { Quantity = 1; Item = "cup of wine" }
            ]
            Instructions = "Pour wine into wine glass.\n"
        }
    let input = """Glass of Wine

Ingredients:
1 cup of wine

Instructions:
Pour wine into wine glass.
"""
    parse input |> should equal expected

[<Fact>]
let ``Valid recipe with multiple ingredients, integer quantities and varying units`` () =
    let expected: Result<Recipe, ParseError> = Ok {
            Title = "Gin and Tonic"
            Ingredients = [
                { Quantity = 1; Item = "cup tonic water" };
                { Quantity = 2; Item = "shots of gin" };
                { Quantity = 5; Item = "cubes of ice" };
            ]
            Instructions = """Put ice cubes into a glass.
Stir tonic water and gin in another glass.
Pour tonic water and gin mixture into glass with ice.
"""
        }
    let input = """Gin and Tonic

Ingredients:
1 cup tonic water
2 shots of gin
5 cubes of ice

Instructions:
Put ice cubes into a glass.
Stir tonic water and gin in another glass.
Pour tonic water and gin mixture into glass with ice.
"""
    parse input |> should equal expected

// TODO: (maybe) Test the ability to parse fractional quantities
// TODO: Organize into tasks
