module Satellite

type Tree =
    | Empty
    | Node of value: string * left: Tree * right: Tree

let treeFromTraversals inorder preorder =
    failwith "Please implement the 'treeFromTraversals' function"
