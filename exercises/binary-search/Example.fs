module BinarySearch

let rec binarySearchAux index value =
    function
    | [] -> None
    | xs ->   
        let middle = xs.Length / 2
        let middleValue = xs.[middle]
        
        if value < middleValue then binarySearchAux index value xs.[0 .. middle - 1] 
        elif value > middleValue then binarySearchAux (index + middle + 1) value xs.[middle + 1 ..]
        else Some (index + middle)

let binarySearch list value =
    if List.sort list <> list then failwith "The input must be an ordered lists"
    else binarySearchAux 0 value list