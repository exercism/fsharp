import "flower_field"

let ``No rows`` () =
    let garden: [][]u8 = []
    let expected: [][]u8 = []
    annotate garden |> should equal expected

let ``No columns`` () =
    let garden = [""]
    let expected = [""]
    annotate garden |> should equal expected

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

let ``Horizontal line`` () =
    let garden = [" * * "]
    let expected = ["1*2*1"]
    annotate garden |> should equal expected

let ``Horizontal line, flowers at edges`` () =
    let garden = ["*   *"]
    let expected = ["*1 1*"]
    annotate garden |> should equal expected

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

