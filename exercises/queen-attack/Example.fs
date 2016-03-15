module QueenAttack

open System

let abs (x:int) = Math.Abs x

let canAttack (row1, col1) (row2, col2) =
    if row1 = row2 && col1 = col2 then failwith "The queens cannot be positioned at the same place."
    else row1 = row2 || col1 = col2 || (row1 - row2 |> abs) = (col1 - col2 |> abs)