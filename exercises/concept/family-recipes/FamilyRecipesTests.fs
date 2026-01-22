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
            Title = "Glass of Apple Juice"
            Ingredients = [
                { Quantity = 1; Item = "cup of apple juice" }
            ]
            Instructions = "Pour apple juice into tumbler.\n"
        }
    let input = """Glass of Apple Juice

Ingredients:
1 cup of apple juice

Instructions:
Pour apple juice into tumbler.
"""
    parse input |> should equal expected

[<Fact>]
let ``Valid recipe with multiple ingredients, integer quantities and varying units`` () =
    let expected: Result<Recipe, ParseError> = Ok {
            Title = "Bowl of Oatmeal"
            Ingredients = [
                { Quantity = 4; Item = "ounces of oatmeal" };
                { Quantity = 12; Item = "ounces of water" };
                { Quantity = 1; Item = "tablespoon of honey" };
            ]
            Instructions = """Bring water to boil in a small pot.
Stir oatmeal into boiling water.
Reduce heat and cook for 10 minutes.
Pour cooked oatmeal into a bowl.
Serve with honey.
"""
        }
    let input = """Bowl of Oatmeal

Ingredients:
4 ounces of oatmeal
12 ounces of water
1 tablespoon of honey

Instructions:
Bring water to boil in a small pot.
Stir oatmeal into boiling water.
Reduce heat and cook for 10 minutes.
Pour cooked oatmeal into a bowl.
Serve with honey.
"""
    parse input |> should equal expected
