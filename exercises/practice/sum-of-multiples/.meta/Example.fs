module SumOfMultiples

let sum numbers upperBound =
    let isMultiple x = numbers |> List.exists (fun y -> y <> 0 && x % y = 0) 
    
    [1 .. upperBound - 1] 
    |> List.filter isMultiple 
    |> List.sum