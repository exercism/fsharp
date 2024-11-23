~ "sgf-parsing.ua" ~ SgfParsing

# Empty input
⍤⤙≍ "TODO: insert error message" ⍣(parse "")

# Tree with no nodes
⍤⤙≍ "TODO: insert error message" ⍣(parse "()")

# Node without tree
⍤⤙≍ "TODO: insert error message" ⍣(parse ";")

# Node without properties
expected = (Node (Map.ofList [], []))
⍤⤙≍ expected parse "(;)"

# Single node tree
expected = (Node (Map.ofList [("A", ["B"])], []))
⍤⤙≍ expected parse "(;A[B])"

# Multiple properties
expected = (Node (Map.ofList [("A", ["b"]) ("C", ["d"])], []))
⍤⤙≍ expected parse "(;A[b]C[d])"

# Properties without delimiter
⍤⤙≍ "TODO: insert error message" ⍣(parse "(;A)")

# All lowercase property
⍤⤙≍ "TODO: insert error message" ⍣(parse "(;a[b])")

# Upper and lowercase property
⍤⤙≍ "TODO: insert error message" ⍣(parse "(;Aa[b])")

# Two nodes
expected = (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], [])]))
⍤⤙≍ expected parse "(;A[B];B[C])"

# Two child trees
expected = (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], []) Node (Map.ofList [("C", ["D"])], [])]))
⍤⤙≍ expected parse "(;A[B](;B[C])(;C[D]))"

# Multiple property values
expected = (Node (Map.ofList [("A", ["b" "c" "d"])], []))
⍤⤙≍ expected parse "(;A[b][c][d])"

# Semicolon in property value doesn't need to be escaped
expected = (Node (Map.ofList [("A", ["a;b" "foo"]) ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
⍤⤙≍ expected parse "(;A[a;b][foo]B[bar];C[baz])"

# Parentheses in property value don't need to be escaped
expected = (Node (Map.ofList [("A", ["x(y)z" "foo"]) ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
⍤⤙≍ expected parse "(;A[x(y)z][foo]B[bar];C[baz])"

