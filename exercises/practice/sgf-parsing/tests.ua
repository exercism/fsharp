~ "sgf-parsing.ua" ~ SgfParsing

# Empty input
    let expected = None
⍤⤙≍ expected parse ""

# Tree with no nodes
    let expected = None
⍤⤙≍ expected parse "()"

# Node without tree
    let expected = None
⍤⤙≍ expected parse ";"

# Node without properties
    let expected = Some (Node (Map.ofList [], []))
⍤⤙≍ expected parse "(;)"

# Single node tree
    let expected = Some (Node (Map.ofList [("A", ["B"])], []))
⍤⤙≍ expected parse "(;A[B])"

# Multiple properties
    let expected = Some (Node (Map.ofList [("A", ["b"]) ("C", ["d"])], []))
⍤⤙≍ expected parse "(;A[b]C[d])"

# Properties without delimiter
    let expected = None
⍤⤙≍ expected parse "(;A)"

# All lowercase property
    let expected = None
⍤⤙≍ expected parse "(;a[b])"

# Upper and lowercase property
    let expected = None
⍤⤙≍ expected parse "(;Aa[b])"

# Two nodes
    let expected = Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], [])]))
⍤⤙≍ expected parse "(;A[B];B[C])"

# Two child trees
    let expected = Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], []) Node (Map.ofList [("C", ["D"])], [])]))
⍤⤙≍ expected parse "(;A[B](;B[C])(;C[D]))"

# Multiple property values
    let expected = Some (Node (Map.ofList [("A", ["b" "c" "d"])], []))
⍤⤙≍ expected parse "(;A[b][c][d])"

# Semicolon in property value doesn't need to be escaped
    let expected = Some (Node (Map.ofList [("A", ["a;b" "foo"]) ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
⍤⤙≍ expected parse "(;A[a;b][foo]B[bar];C[baz])"

# Parentheses in property value don't need to be escaped
    let expected = Some (Node (Map.ofList [("A", ["x(y)z" "foo"]) ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
⍤⤙≍ expected parse "(;A[x(y)z][foo]B[bar];C[baz])"

