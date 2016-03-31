module SumOfMultiples

let sumOfMultiples numbers upperBound =
    let isMultiple x = numbers |> List.exists (fun y -> x % y = 0) 
    
    [1 .. upperBound - 1] 
    |> List.filter isMultiple 
    |> List.sum