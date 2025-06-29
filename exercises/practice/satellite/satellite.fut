type Tree =
    | Empty
    | Node of value: []u8 * left: Tree * right: Tree

let tree_from_traversals inorder preorder =
    failwith "Please implement the 'treeFromTraversals' function"
