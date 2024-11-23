~ "satellite.ua" ~ Satellite

# Empty tree
expected: Result<Tree,string> = Ok (
        Empty
    )
⍤⤙≍ expected treeFromTraversals [] []

# Tree with one item
expected: Result<Tree,string> = Ok (
        Node("a", Empty, Empty)
    )
⍤⤙≍ expected treeFromTraversals ["a"] ["a"]

# Tree with many items
expected: Result<Tree,string> = Ok (
        Node(
            "a",
            Node("i", Empty, Empty),
            Node(
                "x",
                Node("f", Empty, Empty),
                Node("r", Empty, Empty)
            )
        )
    )
⍤⤙≍ expected treeFromTraversals ["i" "a" "f" "x" "r"] ["a" "i" "x" "f" "r"]

# Reject traversals of different length
expected: Result<Tree,string> = Error "traversals must have the same length"
⍤⤙≍ expected treeFromTraversals ["b" "a" "r"] ["a" "b"]

# Reject inconsistent traversals of same length
expected: Result<Tree,string> = Error "traversals must have the same elements"
⍤⤙≍ expected treeFromTraversals ["a" "b" "c"] ["x" "y" "z"]

# Reject traversals with repeated items
expected: Result<Tree,string> = Error "traversals must contain unique items"
⍤⤙≍ expected treeFromTraversals ["b" "a" "a"] ["a" "b" "a"]

