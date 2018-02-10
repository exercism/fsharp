module BinarySearchTree

type Node = { left: Node option; value: int; right: Node option }

let left node  = node.left
let right node = node.right
let data node = node.value

let private singleton value = { left = None; right = None; value = value }

let rec private insert newValue (tree: Node) =
    let loop newValue = 
        function
        | Some x -> Some <| insert newValue x
        | None   -> Some <| singleton newValue

    match newValue with
    | x when x <= tree.value -> 
        { tree with left  = loop newValue tree.left }
    | _ -> 
        { tree with right = loop newValue tree.right }

let sortedData tree = 
    let rec loop = 
        function
        | Some node -> loop node.left @ [node.value] @ loop node.right
        | None -> []

    loop <| Some tree

let create = 
    function
    | []    -> failwith "Cannot create tree from empty list."
    | x::xs -> List.fold (fun acc elem -> insert elem acc) (singleton x) xs
