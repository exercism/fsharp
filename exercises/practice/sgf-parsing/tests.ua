~ "sgf-parsing.ua" ~ SgfParsing

# Empty input
    let expected = None
    parse "" |> should equal expected

# Tree with no nodes
    let expected = None
    parse "()" |> should equal expected

# Node without tree
    let expected = None
    parse ";" |> should equal expected

# Node without properties
    let expected = Some (Node (Map.ofList [], []))
    parse "(;)" |> should equal expected

# Single node tree
    let expected = Some (Node (Map.ofList [("A", ["B"])], []))
    parse "(;A[B])" |> should equal expected

# Multiple properties
    let expected = Some (Node (Map.ofList [("A", ["b"]); ("C", ["d"])], []))
    parse "(;A[b]C[d])" |> should equal expected

# Properties without delimiter
    let expected = None
    parse "(;A)" |> should equal expected

# All lowercase property
    let expected = None
    parse "(;a[b])" |> should equal expected

# Upper and lowercase property
    let expected = None
    parse "(;Aa[b])" |> should equal expected

# Two nodes
    let expected = Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], [])]))
    parse "(;A[B];B[C])" |> should equal expected

# Two child trees
    let expected = Some (Node (Map.ofList [("A", ["B"])], [Node (Map.ofList [("B", ["C"])], []); Node (Map.ofList [("C", ["D"])], [])]))
    parse "(;A[B](;B[C])(;C[D]))" |> should equal expected

# Multiple property values
    let expected = Some (Node (Map.ofList [("A", ["b"; "c"; "d"])], []))
    parse "(;A[b][c][d])" |> should equal expected

# Semicolon in property value doesn't need to be escaped
    let expected = Some (Node (Map.ofList [("A", ["a;b"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    parse "(;A[a;b][foo]B[bar];C[baz])" |> should equal expected

# Parentheses in property value don't need to be escaped
    let expected = Some (Node (Map.ofList [("A", ["x(y)z"; "foo"]); ("B", ["bar"])], [Node (Map.ofList [("C", ["baz"])], [])]))
    parse "(;A[x(y)z][foo]B[bar];C[baz])" |> should equal expected

