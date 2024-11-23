~ "zipper.ua" ~ Zipper

subTree value left right = (tree value left right)
leaf value = subTree value None None

# Data is retained
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = tree 1 (subTree 2 None (leaf 3)) (leaf 4)
actual = zipper |> toTree
⍤⤙≍ expected actual

# Left, right and value
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = 3
actual = zipper |> left |> Option.get |> right |> Option.get |> value
⍤⤙≍ expected actual

# Dead end
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = None
actual = zipper |> left |> Option.get |> left
⍤⤙≍ expected actual

# Tree from deep focus
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = tree 1 (subTree 2 None (leaf 3)) (leaf 4)
actual = zipper |> left |> Option.get |> right |> Option.get |> toTree
⍤⤙≍ expected actual

# Traversing up from top
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = None
actual = zipper |> up
⍤⤙≍ expected actual

# Left, right, and up
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = 3
actual = zipper |> left |> Option.get |> up |> Option.get |> right |> Option.get |> up |> Option.get |> left |> Option.get |> right |> Option.get |> value
⍤⤙≍ expected actual

# Test ability to descend multiple levels and return
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = 1
actual = zipper |> left |> Option.get |> right |> Option.get |> up |> Option.get |> up |> Option.get |> value
⍤⤙≍ expected actual

# Set value
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = tree 1 (subTree 5 None (leaf 3)) (leaf 4)
actual = zipper |> left |> Option.get |> setValue 5 |> toTree
⍤⤙≍ expected actual

# Set value after traversing up
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = tree 1 (subTree 5 None (leaf 3)) (leaf 4)
actual = zipper |> left |> Option.get |> right |> Option.get |> up |> Option.get |> setValue 5 |> toTree
⍤⤙≍ expected actual

# Set left with leaf
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = tree 1 (subTree 2 (leaf 5) (leaf 3)) (leaf 4)
actual = zipper |> left |> Option.get |> setLeft (tree 5 None None) |> toTree
⍤⤙≍ expected actual

# Set right with null
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = tree 1 (leaf 2) (leaf 4)
actual = zipper |> left |> Option.get |> setRight None |> toTree
⍤⤙≍ expected actual

# Set right with subtree
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = tree 1 (subTree 2 None (leaf 3)) (subTree 6 (leaf 7) (leaf 8))
actual = zipper |> setRight (tree 6 (leaf 7 (leaf 8))) |> toTree
⍤⤙≍ expected actual

# Set value on deep focus
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = tree 1 (subTree 2 None (leaf 5)) (leaf 4)
actual = zipper |> left |> Option.get |> right |> Option.get |> setValue 5 |> toTree
⍤⤙≍ expected actual

# Different paths to same zipper
zipper = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4))
expected = fromTree (tree 1 (subTree 2 None (leaf 3)) (leaf 4)) |> right
actual = zipper |> left |> Option.get |> up |> Option.get |> right
⍤⤙≍ expected actual

