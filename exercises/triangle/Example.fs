module Triangle

let private isValid triangle = 
    let nonZero = List.sum triangle <> 0.0
    let equality =
        let [x; y; z] = triangle
        x + y >= z && x + z >= y && y + z >= x
    
    equality && nonZero

let private distinctSides triangle = triangle |> List.distinct |> List.length

let equilateral triangle = isValid triangle && distinctSides triangle = 1

let isosceles triangle = isValid triangle && distinctSides triangle <= 2

let scalene triangle = isValid triangle && distinctSides triangle = 3