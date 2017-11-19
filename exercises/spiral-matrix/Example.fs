module SpiralMatrix
 
let array2DToList array = 
  [ for x in Array2D.base1 array .. Array2D.length1 array - 1 ->
    [ for y in Array2D.base2 array .. Array2D.length2 array - 1 -> array.[x, y] ] ]  

let spiralMatrix size = 
    let numbersToPlace = size * size

    let mutable spiral = Array2D.create size size 0
    let mutable currentSpiralValue = 1
    let mutable firstPivot = 0
    let mutable secondPivot = size - 1

    let setValue x y = 
        spiral.[x, y] <- currentSpiralValue
        currentSpiralValue <- currentSpiralValue + 1

    while currentSpiralValue <= numbersToPlace do
        [firstPivot .. secondPivot] 
        |> List.iter (fun i -> setValue firstPivot i)

        [firstPivot + 1.. secondPivot] 
        |> List.iter (fun i -> setValue i secondPivot)

        [secondPivot - 1 .. -1 .. firstPivot] 
        |> List.iter (fun i -> setValue secondPivot i)

        [secondPivot - 1 .. -1 .. firstPivot + 1] 
        |> List.iter (fun i -> setValue i firstPivot)

        firstPivot <- firstPivot + 1
        secondPivot <- secondPivot - 1

    array2DToList spiral