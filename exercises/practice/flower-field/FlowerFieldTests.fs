module FlowerFieldTests

open FsUnit.Xunit
open Xunit

open FlowerField

[<Fact>]
let ``No rows`` () =
    let garden: string list = []
    let expected: string list = []
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``No columns`` () =
    let garden = [""]
    let expected = [""]
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``No flowers`` () =
    let garden = 
        [ "   ";
          "   ";
          "   " ]
    let expected = 
        [ "   ";
          "   ";
          "   " ]
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``garden full of flowers`` () =
    let garden = 
        [ "***";
          "***";
          "***" ]
    let expected = 
        [ "***";
          "***";
          "***" ]
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Flower surrounded by spaces`` () =
    let garden = 
        [ "   ";
          " * ";
          "   " ]
    let expected = 
        [ "111";
          "1*1";
          "111" ]
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Space surrounded by flowers`` () =
    let garden = 
        [ "***";
          "* *";
          "***" ]
    let expected = 
        [ "***";
          "*8*";
          "***" ]
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Horizontal line`` () =
    let garden = [" * * "]
    let expected = ["1*2*1"]
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Horizontal line, flowers at edges`` () =
    let garden = ["*   *"]
    let expected = ["*1 1*"]
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Vertical line`` () =
    let garden = 
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
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Vertical line, flowers at edges`` () =
    let garden = 
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
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Cross`` () =
    let garden = 
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
    annotate garden |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Large garden`` () =
    let garden = 
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
    annotate garden |> should equal expected

