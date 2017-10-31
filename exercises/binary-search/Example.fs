module BinarySearch

let rec binarySearchAux index value =
    function
    | [||] -> 
        None
    | input ->   
        let middle = input.Length / 2
        let middleValue = input.[middle]
        
        if value < middleValue then binarySearchAux index value input.[0 .. middle - 1] 
        elif value > middleValue then binarySearchAux (index + middle + 1) value input.[middle + 1 ..]
        else Some (index + middle)

let find input value =
    if Array.sort input <> input then failwith "The input must be an ordered lists"
    else binarySearchAux 0 value input