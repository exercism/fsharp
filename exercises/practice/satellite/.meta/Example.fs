module Satellite

type Tree =
    | Empty
    | Node of value: string * left: Tree * right: Tree

let rec createTree inorder preorder =
    match preorder with
    | [] -> Empty
    | hd :: tail ->
        let hdIdx = inorder |> List.findIndex (fun x -> x = hd)
        let leftInorder, rightInorder = inorder[0 .. hdIdx - 1], inorder[hdIdx + 1 ..]
        let leftPreorder, rightPreorder = tail[0 .. leftInorder.Length - 1], tail[leftInorder.Length ..]
        Node(hd, createTree leftInorder leftPreorder, createTree rightInorder rightPreorder)

let treeFromTraversals inorder preorder =
    if List.length preorder <> List.length inorder then
        Error "traversals must have the same length"
    elif List.sort preorder <> List.sort inorder then
        Error "traversals must have the same elements"
    elif List.distinct preorder <> preorder then
        Error "traversals must contain unique items"
    else
        Ok(createTree inorder preorder)
