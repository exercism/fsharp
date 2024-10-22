module Satellite

type Tree =
    | Empty
    | Node of value: string * left: Tree * right: Tree

let treeFromTraversals preorder inorder =
    failwith "Please implement the 'treeFromTraversals' function"
