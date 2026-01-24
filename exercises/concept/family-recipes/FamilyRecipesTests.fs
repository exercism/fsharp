module Tests

open FsUnit.Xunit
open Xunit

open FamilyRecipes

[<Fact>]
let ``Error on blank list`` () =
    let expected: Result<string, ValidationError> = Error EmptyList
    validate "" |> should equal expected

[<Fact>]
let ``Error on blank line`` () =
    let expected: Result<string, ValidationError> = Error EmptyList
    validate "\n" |> should equal expected

[<Fact>]
let ``Error on non-numeric ingredient quantity`` () =
    let expected: Result<string, ValidationError> = Error InvalidIngredientQuantity
    validate "foo bar" |> should equal expected

[<Fact>]
let ``Error on missing ingredient item`` () =
    let expected: Result<string, ValidationError> = Error MissingIngredientItem
    validate "24 " |> should equal expected

[<Fact>]
let ``Minimal valid list`` () =
    let input = """1 cup rice"""
    let expected: Result<string, ValidationError> = Ok input
    validate input |> should equal expected

[<Fact>]
let ``Valid list with multiple ingredients`` () =
    let input = """4 ounces of oatmeal
12 ounces of water
1 tablespoon of honey"""
    let expected: Result<string, ValidationError> = Ok input
    validate input |> should equal expected

[<Fact>]
let ``Blank lines within valid list are OK`` () =
    let input = "1 foo\n2 bar"
    let expected: Result<string, ValidationError> = Ok input
    validate input |> should equal expected
