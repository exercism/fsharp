module Rectangles

open System

type Coord = int * int

type Cell = 
    | Corner 
    | HorizontalLine 
    | VerticalLine 
    | Empty
    
type Grid = Cell[,]

let parseCell = 
    function
    | '+' -> Corner
    | '-' -> HorizontalLine
    | '|' -> VerticalLine
    | ' ' -> Empty
    | _   -> failwith "Invalid cell type"

let parseGrid (lines: string list) =
    let rows = lines.Length
    let cols = if rows = 0 then 0 else lines.[0].Length
    Array2D.init rows cols (fun y x -> parseCell lines.[y].[x])

let rows grid = Array2D.length1 grid
let cols grid = Array2D.length2 grid

let cell grid (x, y) = Array2D.get grid y x

let findCorners grid = 
    [ for y in 0 .. rows grid - 1 do
      for x in 0 .. cols grid - 1 do
        if cell grid (x, y) = Corner then
            yield (x, y) ]

let connectedVertically grid (x, y) (_, y') = 
    let connectsVertically coord = cell grid coord = VerticalLine || cell grid coord = Corner
    let verticalIntermediateCoords = [for y'' in y + 1 .. y' - 1 do yield (x, y'')] 
    List.forall connectsVertically verticalIntermediateCoords

let connectedHorizontally grid (x, y) (x', _) = 
    let connectsHorizontally coord = cell grid coord = HorizontalLine || cell grid coord = Corner
    let horizontalIntermediateCoords = [for x'' in x + 1 .. x' - 1 do yield (x'', y)]
    List.forall connectsHorizontally horizontalIntermediateCoords
    
let isTopLineOfRectangle    grid (x, y) (x', y') = x' > x && y' = y && connectedHorizontally grid (x, y) (x', y')
let isRightLineOfRectangle  grid (x, y) (x', y') = x' = x && y' > y && connectedVertically   grid (x, y) (x', y')
let isBottomLineOfRectangle grid (x, y) (x', y') = x' > x && y' = y && connectedHorizontally grid (x, y) (x', y')
let isLeftLineOfRectangle   grid (x, y) (x', y') = x' = x && y' > y && connectedVertically   grid (x, y) (x', y')

let rectanglesForCorner grid corners topLeft =
    seq {
        for topRight    in corners |> Seq.filter (isTopLineOfRectangle grid topLeft) do
        for bottomLeft  in corners |> Seq.filter (isLeftLineOfRectangle grid topLeft) do
        for bottomRight in corners |> Seq.filter (isRightLineOfRectangle grid topRight)
                                   |> Seq.filter (isBottomLineOfRectangle grid bottomLeft) do
            yield bottomRight
    } |> Seq.length
    
let rectangles lines =
    let grid = parseGrid lines
    let corners = findCorners grid
    Seq.sumBy (rectanglesForCorner grid corners) corners