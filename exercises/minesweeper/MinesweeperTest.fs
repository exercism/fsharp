module MinesweeperTest

open Xunit
open FsUnit

open Minesweeper

let concat = List.reduce (fun x y -> x + "\n" + y)

[<Test>]
let ``Zero size board`` () =
    let actual = ""
    let expected = ""
    annotate actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty board`` () =
    let actual = 
        ["   ";
         "   ";
         "   "]
        |> concat

    let expected = 
        ["   ";
         "   ";
         "   "]
        |> concat

    annotate actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Board full of mines`` () =
    let actual = 
        ["***";
         "***";
         "***"]
        |> concat

    let expected = 
        ["***";
         "***";
         "***"]
        |> concat

    annotate actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Surrounded`` () =    
    let actual = 
        ["***";
         "* *";
         "***"]
        |> concat

    let expected = 
        ["***";
         "*8*";
         "***"]
        |> concat

    annotate actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Horizontal line`` () =    
    let actual = [" * * "] |> concat
    let expected = ["1*2*1"] |> concat

    annotate actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Vertical line`` () =   
    let actual = 
        [" ";
         "*";
         " ";
         "*";
         " "]
        |> concat

    let expected = 
        ["1";
         "*";
         "2";
         "*";
         "1"]
        |> concat

    annotate actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Cross`` () = 
    let actual = 
        ["  *  ";
         "  *  ";
         "*****";
         "  *  ";
         "  *  "]
        |> concat

    let expected = 
        [" 2*2 ";
         "25*52";
         "*****";
         "25*52";
         " 2*2 "]
        |> concat

    annotate actual |> should equal expected

