import "game_of_life"

let ``Empty matrix`` () =
    let matrix: int[,] = array2D []
    let expected: int[,] = array2D []
    tick matrix |> should equal expected

let ``Live cells with zero live neighbors die`` () =
    let matrix = 
        array2D [ [0; 0; 0];
                  [0; 1; 0];
                  [0; 0; 0] ]
    let expected = 
        array2D [ [0; 0; 0];
                  [0; 0; 0];
                  [0; 0; 0] ]
    tick matrix |> should equal expected

let ``Live cells with only one live neighbor die`` () =
    let matrix = 
        array2D [ [0; 0; 0];
                  [0; 1; 0];
                  [0; 1; 0] ]
    let expected = 
        array2D [ [0; 0; 0];
                  [0; 0; 0];
                  [0; 0; 0] ]
    tick matrix |> should equal expected

let ``Live cells with two live neighbors stay alive`` () =
    let matrix = 
        array2D [ [1; 0; 1];
                  [1; 0; 1];
                  [1; 0; 1] ]
    let expected = 
        array2D [ [0; 0; 0];
                  [1; 0; 1];
                  [0; 0; 0] ]
    tick matrix |> should equal expected

let ``Live cells with three live neighbors stay alive`` () =
    let matrix = 
        array2D [ [0; 1; 0];
                  [1; 0; 0];
                  [1; 1; 0] ]
    let expected = 
        array2D [ [0; 0; 0];
                  [1; 0; 0];
                  [1; 1; 0] ]
    tick matrix |> should equal expected

let ``Dead cells with three live neighbors become alive`` () =
    let matrix = 
        array2D [ [1; 1; 0];
                  [0; 0; 0];
                  [1; 0; 0] ]
    let expected = 
        array2D [ [0; 0; 0];
                  [1; 1; 0];
                  [0; 0; 0] ]
    tick matrix |> should equal expected

let ``Live cells with four or more neighbors die`` () =
    let matrix = 
        array2D [ [1; 1; 1];
                  [1; 1; 1];
                  [1; 1; 1] ]
    let expected = 
        array2D [ [1; 0; 1];
                  [0; 0; 0];
                  [1; 0; 1] ]
    tick matrix |> should equal expected

let ``Bigger matrix`` () =
    let matrix = 
        array2D [ [1; 1; 0; 1; 1; 0; 0; 0];
                  [1; 0; 1; 1; 0; 0; 0; 0];
                  [1; 1; 1; 0; 0; 1; 1; 1];
                  [0; 0; 0; 0; 0; 1; 1; 0];
                  [1; 0; 0; 0; 1; 1; 0; 0];
                  [1; 1; 0; 0; 0; 1; 1; 1];
                  [0; 0; 1; 0; 1; 0; 0; 1];
                  [1; 0; 0; 0; 0; 0; 1; 1] ]
    let expected = 
        array2D [ [1; 1; 0; 1; 1; 0; 0; 0];
                  [0; 0; 0; 0; 0; 1; 1; 0];
                  [1; 0; 1; 1; 1; 1; 0; 1];
                  [1; 0; 0; 0; 0; 0; 0; 1];
                  [1; 1; 0; 0; 1; 0; 0; 1];
                  [1; 1; 0; 1; 0; 0; 0; 1];
                  [1; 0; 0; 0; 0; 0; 0; 0];
                  [0; 0; 0; 0; 0; 0; 1; 1] ]
    tick matrix |> should equal expected

