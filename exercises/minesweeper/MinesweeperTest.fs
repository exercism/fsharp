// This file was auto-generated based on version 1.0.0 of the canonical data.

module MinesweeperTest

open FsUnit.Xunit
open Xunit

open Minesweeper

[<Fact>]
let ``No rows`` () =
    let input = []
    let expected = []
    annotate input |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``No columns`` () =
    let input = [""]
    let expected = [""]
    annotate input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``No mines`` () =
    let input = ["   "; "   "; "   "]
    let expected = ["   "; "   "; "   "]
    annotate input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Board with only mines`` () =
    let input = ["***"; "***"; "***"]
    let expected = ["***"; "***"; "***"]
    annotate input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Mine surrounded by spaces`` () =
    let input = ["   "; " * "; "   "]
    let expected = ["111"; "1*1"; "111"]
    annotate input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Space surrounded by mines`` () =
    let input = ["***"; "* *"; "***"]
    let expected = ["***"; "*8*"; "***"]
    annotate input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Horizontal line`` () =
    let input = [" * * "]
    let expected = ["1*2*1"]
    annotate input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Horizontal line, mines at edges`` () =
    let input = ["*   *"]
    let expected = ["*1 1*"]
    annotate input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Vertical line`` () =
    let input = [" "; "*"; " "; "*"; " "]
    let expected = ["1"; "*"; "2"; "*"; "1"]
    annotate input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Vertical line, mines at edges`` () =
    let input = ["*"; " "; " "; " "; "*"]
    let expected = ["*"; "1"; " "; "1"; "*"]
    annotate input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Cross`` () =
    let input = ["  *  "; "  *  "; "*****"; "  *  "; "  *  "]
    let expected = [" 2*2 "; "25*52"; "*****"; "25*52"; " 2*2 "]
    annotate input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Large board`` () =
    let input = [" *  * "; "  *   "; "    * "; "   * *"; " *  * "; "      "]
    let expected = ["1*22*1"; "12*322"; " 123*2"; "112*4*"; "1*22*2"; "111111"]
    annotate input |> should equal expected

