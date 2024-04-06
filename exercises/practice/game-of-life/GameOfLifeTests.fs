module GameOfLifeTests

open FsUnit.Xunit
open Xunit

open GameOfLife

[<Fact>]
let ``Empty matrix`` () =
    let matrix: int list list = []
    let expected: int list list = []
    tick matrix |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Live cells with zero live neighbors die`` () =
    let matrix = 
        [ [0; 0; 0];
          [0; 1; 0];
          [0; 0; 0] ]
    let expected = 
        [ [0; 0; 0];
          [0; 0; 0];
          [0; 0; 0] ]
    tick matrix |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Live cells with only one live neighbor die`` () =
    let matrix = 
        [ [0; 0; 0];
          [0; 1; 0];
          [0; 1; 0] ]
    let expected = 
        [ [0; 0; 0];
          [0; 0; 0];
          [0; 0; 0] ]
    tick matrix |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Live cells with two live neighbors stay alive`` () =
    let matrix = 
        [ [1; 0; 1];
          [1; 0; 1];
          [1; 0; 1] ]
    let expected = 
        [ [0; 0; 0];
          [1; 0; 1];
          [0; 0; 0] ]
    tick matrix |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Live cells with three live neighbors stay alive`` () =
    let matrix = 
        [ [0; 1; 0];
          [1; 0; 0];
          [1; 1; 0] ]
    let expected = 
        [ [0; 0; 0];
          [1; 0; 0];
          [1; 1; 0] ]
    tick matrix |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Dead cells with three live neighbors become alive`` () =
    let matrix = 
        [ [1; 1; 0];
          [0; 0; 0];
          [1; 0; 0] ]
    let expected = 
        [ [0; 0; 0];
          [1; 1; 0];
          [0; 0; 0] ]
    tick matrix |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Live cells with four or more neighbors die`` () =
    let matrix = 
        [ [1; 1; 1];
          [1; 1; 1];
          [1; 1; 1] ]
    let expected = 
        [ [1; 0; 1];
          [0; 0; 0];
          [1; 0; 1] ]
    tick matrix |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Bigger matrix`` () =
    let matrix = 
        [ [1; 1; 0; 1; 1; 0; 0; 0];
          [1; 0; 1; 1; 0; 0; 0; 0];
          [1; 1; 1; 0; 0; 1; 1; 1];
          [0; 0; 0; 0; 0; 1; 1; 0];
          [1; 0; 0; 0; 1; 1; 0; 0];
          [1; 1; 0; 0; 0; 1; 1; 1];
          [0; 0; 1; 0; 1; 0; 0; 1];
          [1; 0; 0; 0; 0; 0; 1; 1] ]
    let expected = 
        [ [1; 1; 0; 1; 1; 0; 0; 0];
          [0; 0; 0; 0; 0; 1; 1; 0];
          [1; 0; 1; 1; 1; 1; 0; 1];
          [1; 0; 0; 0; 0; 0; 0; 1];
          [1; 1; 0; 0; 1; 0; 0; 1];
          [1; 1; 0; 1; 0; 0; 0; 1];
          [1; 0; 0; 0; 0; 0; 0; 0];
          [0; 0; 0; 0; 0; 0; 1; 1] ]
    tick matrix |> should equal expected

