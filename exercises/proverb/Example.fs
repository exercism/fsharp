module Proverb

let subjects = ["nail"; "shoe"; "horse"; "rider"; "message"; "battle"; "kingdom"]

let line number = 
    match number with
    | 7 -> "And all for the want of a horseshoe nail."
    | _ -> sprintf "For want of a %s the %s was lost." (List.item (number - 1) subjects) (List.item number subjects) 

let proverb = 
    [1..7]
    |> List.map line
    |> List.reduce (fun x y -> x + "\n" + y)