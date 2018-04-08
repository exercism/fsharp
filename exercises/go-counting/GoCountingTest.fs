// This file was auto-generated based on version 1.0.0 of the canonical data.

module GoCountingTest

open FsUnit.Xunit
open Xunit

open GoCounting

[<Fact>]
let ``Black corner territory on 5x5 board`` () =
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (0, 1)
    let expected = Option.Some (Owner.Black, [(0, 0); (0, 1); (1, 0)])
    territory board position |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``White center territory on 5x5 board`` () =
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (2, 3)
    let expected = Option.Some (Owner.White, [(2, 3)])
    territory board position |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Open corner territory on 5x5 board`` () =
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (1, 4)
    let expected = Option.Some (Owner.None, [(0, 3); (0, 4); (1, 4)])
    territory board position |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``A stone and not a territory on 5x5 board`` () =
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (1, 1)
    let expected: (Owner * (int * int) list) option = Option.Some (Owner.None, [])
    territory board position |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid because X is too low for 5x5 board`` () =
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (-1, 1)
    let expected = Option.None
    territory board position |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid because X is too high for 5x5 board`` () =
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (5, 1)
    let expected = Option.None
    territory board position |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid because Y is too low for 5x5 board`` () =
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (1, -1)
    let expected = Option.None
    territory board position |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Invalid because Y is too high for 5x5 board`` () =
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (1, 5)
    let expected = Option.None
    territory board position |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``One territory is the whole board`` () =
    let board = [" "]
    let expected = 
        [ (Owner.Black, []);
          (Owner.White, []);
          (Owner.None, [(0, 0)]) ]
        |> Map.ofList
    territories board |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Two territory rectangular board`` () =
    let board = 
        [ " BW ";
          " BW " ]
    let expected = 
        [ (Owner.Black, [(0, 0); (0, 1)]);
          (Owner.White, [(3, 0); (3, 1)]);
          (Owner.None, []) ]
        |> Map.ofList
    territories board |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Two region rectangular board`` () =
    let board = [" B "]
    let expected = 
        [ (Owner.Black, [(0, 0); (2, 0)]);
          (Owner.White, []);
          (Owner.None, []) ]
        |> Map.ofList
    territories board |> should equal expected

