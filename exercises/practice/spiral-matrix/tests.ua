~ "SOLUTION" ~ SpiralMatrix

let ``Empty spiral`` () =
    spiralMatrix 0 |> should be Empty

let ``Trivial spiral`` () =
    spiralMatrix 1 |> should equal [[1]]

let ``Spiral of size 2`` () =
    spiralMatrix 2 |> should equal 
        [ [1; 2];
          [4; 3] ]

let ``Spiral of size 3`` () =
    spiralMatrix 3 |> should equal 
        [ [1; 2; 3];
          [8; 9; 4];
          [7; 6; 5] ]

let ``Spiral of size 4`` () =
    spiralMatrix 4 |> should equal 
        [ [1; 2; 3; 4];
          [12; 13; 14; 5];
          [11; 16; 15; 6];
          [10; 9; 8; 7] ]

let ``Spiral of size 5`` () =
    spiralMatrix 5 |> should equal 
        [ [1; 2; 3; 4; 5];
          [16; 17; 18; 19; 6];
          [15; 24; 25; 20; 7];
          [14; 23; 22; 21; 8];
          [13; 12; 11; 10; 9] ]

