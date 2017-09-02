module GoCountingTest

open System

open Xunit
open FsUnit.Xunit

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

[<Fact>]
let ``5x5 territory for black`` () =
    let expected = Some (Some Black, [(0, 0); (0, 1); (1, 0)])
    territoryFor board5x5 (0, 1) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``5x5 territory for white`` () =
    let expected = Some (Some White, [(2, 3)])
    territoryFor board5x5 (2, 3) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``5x5 open territory`` () =
    let expected = Some ((None: Color option), [(0, 3); (0, 4); (1, 4)])
    territoryFor board5x5 (1, 4) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``5x5 non-territory (stone)`` () =
    territoryFor board5x5 (1, 1) |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``5x5 non-territory (too low coordinate)`` () =
    territoryFor board5x5 (-1, 1) |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``5x5 non-territory (too high coordinate)`` () =
    territoryFor board5x5 (1, 5) |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Minimal board, no territories`` () =
    let input = ["B"]
    let expected = []

    territories input |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``One territory, covering the whole board`` () =
    let input = [" "]
    let expected = [((None: Color option), [(0, 0)])] |> Map.ofList

    territories input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Two territories, rectangular board`` () =
    let input = [" BW "; " BW "]
    let expected = [(Some Black, [(0, 0); (0, 1)]);
                    (Some White, [(3, 0); (3, 1)])]
                   |> Map.ofList

    territories input |> should equal expected