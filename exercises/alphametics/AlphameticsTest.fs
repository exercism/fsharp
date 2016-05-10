module AlphameticsTest

open NUnit.Framework

open Alphametics

[<Test>]
let ``Can solve short puzzles`` () =
    let actual = solve "I + BB == ILL"
    let expected = ['I', 1; 'B', 9; 'L', 0] |> Map.ofList |> Some
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can solve long puzzles`` () =
    let actual = solve "SEND + MORE == MONEY"
    let expected = ['S', 9; 'E', 5; 'N', 6; 'D', 7; 'M', 1; 'O', 0; 'R', 8; 'Y', 2] |> Map.ofList |> Some
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can solve puzzles with multiplication`` () =
    let actual = solve "IF * DR == DORI"
    let expected = ['I', 8; 'F', 2; 'D', 3; 'R', 9; 'O', 1] |> Map.ofList |> Some
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can solve puzzles with any boolean expression`` () =
    let actual = solve "PI * R ^ 2 == AREA"
    let expected = ['P', 9; 'I', 6; 'R', 7; 'A', 4; 'E', 0] |> Map.ofList |> Some
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Cannot solve unsolvable puzzles`` () =
    let actual = solve "A * B == A + B"
    Assert.That(actual, Is.EqualTo(None))