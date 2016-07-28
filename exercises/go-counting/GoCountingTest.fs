module GoCountingTest

open System

open NUnit.Framework

open GoCounting

let board5x5 =
    ["  B  ";
     " B B ";
     "B W B";
     " W W ";
     "  W  "]

let board9x9 =
    ["  B   B  ";
     "B   B   B";
     "WBBBWBBBW";
     "W W W W W";
     "         ";
     " W W W W ";
     "B B   B B";
     " W BBB W ";
     "   B B   "]

[<Test>]
let ``5x5 territory for black`` () =
    let expected = Some (Some Black, [(0, 0); (0, 1); (1, 0)])
    Assert.That(territoryFor board5x5 (0, 1), Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``5x5 territory for white`` () =
    let expected = Some (Some White, [(2, 3)])
    Assert.That(territoryFor board5x5 (2, 3), Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``5x5 open territory`` () =
    let expected = Some (None, [(0, 3); (0, 4); (1, 4)])
    Assert.That(territoryFor board5x5 (1, 4) = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``5x5 non-territory (stone)`` () =
    Assert.That(territoryFor board5x5 (1, 1), Is.EqualTo(None))

[<Test>]
[<Ignore("Remove to run test")>]
let ``5x5 non-territory (too low coordinate)`` () =
    Assert.That(territoryFor board5x5 (-1, 1), Is.EqualTo(None))

[<Test>]
[<Ignore("Remove to run test")>]
let ``5x5 non-territory (too high coordinate)`` () =
    Assert.That(territoryFor board5x5 (1, 5), Is.EqualTo(None))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Minimal board, no territories`` () =
    let input = ["B"]
    let expected = []

    Assert.That(territories input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One territory, covering the whole board`` () =
    let input = [" "]
    let expected = [(None, [(0, 0)])] |> Map.ofList

    Assert.That(territories input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Two territories, rectangular board`` () =
    let input = [" BW "; " BW "]
    let expected = [(Some Black, [(0, 0); (0, 1)]);
                    (Some White, [(3, 0); (3, 1)])]
                   |> Map.ofList

    Assert.That(territories input, Is.EqualTo(expected))