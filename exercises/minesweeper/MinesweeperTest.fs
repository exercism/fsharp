module MinesweeperTest

open NUnit.Framework

open Minesweeper

let concat = List.reduce (fun x y -> x + "\n" + y)

[<Test>]
let ``Zero size board`` () =
    let actual = ""
    let expected = ""
    Assert.That(annotate actual, Is.EqualTo(expected))

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

    Assert.That(annotate actual, Is.EqualTo(expected))

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

    Assert.That(annotate actual, Is.EqualTo(expected))

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

    Assert.That(annotate actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Horizontal line`` () =    
    let actual = [" * * "] |> concat
    let expected = ["1*2*1"] |> concat

    Assert.That(annotate actual, Is.EqualTo(expected))

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

    Assert.That(annotate actual, Is.EqualTo(expected))

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

    Assert.That(annotate actual, Is.EqualTo(expected))

