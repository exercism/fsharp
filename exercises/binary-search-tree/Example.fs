module BinarySearchTree

type Node = { left: Node option; value: int; right: Node option }

let left node = node.left
let right node = node.right
let value node = node.value

let singleton value = { left = None; right = None; value = value }

let rec insert newValue (tree: Node) =
    let loop newValue node = 
        match node with
        | Some tree -> Some (insert newValue tree)
        | None -> Some (singleton newValue)

    if newValue <= tree.value then { tree with left = loop newValue tree.left }
    else { tree with right = loop newValue tree.right }

let toList tree = 
    let rec loop x = 
        match x with
        | Some node -> loop node.left @ [node.value] @ loop node.right
        | None -> []

    loop (Some tree)

let fromList list = 
    match list with
    | []    -> failwith "Cannot create tree from empty list."
    | x::xs -> List.fold (fun acc elem -> insert elem acc) (singleton x) xs