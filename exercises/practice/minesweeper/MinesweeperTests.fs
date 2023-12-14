module MinesweeperTests

open FsUnit.Xunit
open Xunit

open Minesweeper

[<Fact>]
let ``No rows`` () =
    let minefield: string list = []
    let expected: string list = []
    annotate minefield |> should equal expected

[<Fact>]
let ``No columns`` () =
    let minefield = [""]
    let expected = [""]
    annotate minefield |> should equal expected

[<Fact>]
let ``No mines`` () =
    let minefield = 
        [ "   ";
          "   ";
          "   " ]
    let expected = 
        [ "   ";
          "   ";
          "   " ]
    annotate minefield |> should equal expected

[<Fact>]
let ``Minefield with only mines`` () =
    let minefield = 
        [ "***";
          "***";
          "***" ]
    let expected = 
        [ "***";
          "***";
          "***" ]
    annotate minefield |> should equal expected

[<Fact>]
let ``Mine surrounded by spaces`` () =
    let minefield = 
        [ "   ";
          " * ";
          "   " ]
    let expected = 
        [ "111";
          "1*1";
          "111" ]
    annotate minefield |> should equal expected

[<Fact>]
let ``Space surrounded by mines`` () =
    let minefield = 
        [ "***";
          "* *";
          "***" ]
    let expected = 
        [ "***";
          "*8*";
          "***" ]
    annotate minefield |> should equal expected

[<Fact>]
let ``Horizontal line`` () =
    let minefield = [" * * "]
    let expected = ["1*2*1"]
    annotate minefield |> should equal expected

[<Fact>]
let ``Horizontal line, mines at edges`` () =
    let minefield = ["*   *"]
    let expected = ["*1 1*"]
    annotate minefield |> should equal expected

[<Fact>]
let ``Vertical line`` () =
    let minefield = 
        [ " ";
          "*";
          " ";
          "*";
          " " ]
    let expected = 
        [ "1";
          "*";
          "2";
          "*";
          "1" ]
    annotate minefield |> should equal expected

[<Fact>]
let ``Vertical line, mines at edges`` () =
    let minefield = 
        [ "*";
          " ";
          " ";
          " ";
          "*" ]
    let expected = 
        [ "*";
          "1";
          " ";
          "1";
          "*" ]
    annotate minefield |> should equal expected

[<Fact>]
let ``Cross`` () =
    let minefield = 
        [ "  *  ";
          "  *  ";
          "*****";
          "  *  ";
          "  *  " ]
    let expected = 
        [ " 2*2 ";
          "25*52";
          "*****";
          "25*52";
          " 2*2 " ]
    annotate minefield |> should equal expected

[<Fact>]
let ``Large minefield`` () =
    let minefield = 
        [ " *  * ";
          "  *   ";
          "    * ";
          "   * *";
          " *  * ";
          "      " ]
    let expected = 
        [ "1*22*1";
          "12*322";
          " 123*2";
          "112*4*";
          "1*22*2";
          "111111" ]
    annotate minefield |> should equal expected

