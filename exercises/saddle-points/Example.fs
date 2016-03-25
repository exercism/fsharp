module SaddlePoints

let saddlePoints (matrix: int list list) = 
    let rec transpose = function
        | (_::_)::_ as M -> List.map List.head M :: transpose (List.map List.tail M)
        | _ -> []

    let rows = matrix |> List.length
    let cols = matrix |> List.head |> List.length

    let rowsMax = matrix |> List.map List.max
    let colsMin = matrix |> transpose |> List.map List.min

    let rowMax x = rowsMax |> List.item x
    let colMin y = colsMin |> List.item y

    let element x y = matrix |> List.item x |> List.item y
    let isSaddlePoint x y = element x y = rowMax x && element x y = colMin y

    [for x in 0 .. (rows - 1) do
        for y in 0 .. (cols - 1) do            
            if isSaddlePoint x y then
                yield (x, y)]