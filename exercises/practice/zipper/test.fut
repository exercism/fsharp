import "zipper"

let sub_tree value left right = Some (tree value left right)
let leaf value = subTree value None None

let ``Data is retained`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 2 None (leaf 3)) (leaf 4)
    let actual = zipper |> toTree
    actual |> should equal expected

let ``Left, right and value`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = 3
    let actual = zipper |> left |> Option.get |> right |> Option.get |> value
    actual |> should equal expected

let ``Dead end`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = None
    let actual = zipper |> left |> Option.get |> left
    actual |> should equal expected

let ``Tree from deep focus`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 2 None (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> right |> Option.get |> toTree
    actual |> should equal expected

let ``Traversing up from top`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = None
    let actual = zipper |> up
    actual |> should equal expected

let ``Left, right, and up`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = 3
    let actual = zipper |> left |> Option.get |> up |> Option.get |> right |> Option.get |> up |> Option.get |> left |> Option.get |> right |> Option.get |> value
    actual |> should equal expected

let ``Test ability to descend multiple levels and return`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = 1
    let actual = zipper |> left |> Option.get |> right |> Option.get |> up |> Option.get |> up |> Option.get |> value
    actual |> should equal expected

let ``Set value`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 5 None (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> setValue 5 |> toTree
    actual |> should equal expected

let ``Set value after traversing up`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 5 None (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> right |> Option.get |> up |> Option.get |> setValue 5 |> toTree
    actual |> should equal expected

let ``Set left with leaf`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 2 (leaf 5) (leaf 3)) (leaf 4)
    let actual = zipper |> left |> Option.get |> setLeft (tree 5 None None) |> toTree
    actual |> should equal expected

let ``Set right with null`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (leaf 2) (leaf 4)
    let actual = zipper |> left |> Option.get |> setRight None |> toTree
    actual |> should equal expected

let ``Set right with subtree`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 2 None (leaf 3)) (subTree 6 (leaf 7) (leaf 8))
    let actual = zipper |> setRight (tree 6 (leaf 7 (leaf 8))) |> toTree
    actual |> should equal expected

let ``Set value on deep focus`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = tree 1 (subTree 2 None (leaf 5)) (leaf 4)
    let actual = zipper |> left |> Option.get |> right |> Option.get |> setValue 5 |> toTree
    actual |> should equal expected

let ``Different paths to same zipper`` () =
    let zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
    let expected = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4)) |> right
    let actual = zipper |> left |> Option.get |> up |> Option.get |> right
    actual |> should equal expected

