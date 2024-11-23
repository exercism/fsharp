~ "satellite.ua" ~ Satellite

# Empty tree
expected ← (
  Empty
)
⍤⤙≍ expected treeFromTraversals [] []

# Tree with one item
expected ← (
  Node"a"_Empty, Empty
)
⍤⤙≍ expected treeFromTraversals ["a"] ["a"]

# Tree with many items
expected ← (
  Node(
    "a",
    Node"i"_Empty, Empty,
    Node(
      "x",
      Node"f"_Empty, Empty,
      Node"r"_Empty, Empty
    )
  )
)
⍤⤙≍ expected treeFromTraversals ["i" "a" "f" "x" "r"] ["a" "i" "x" "f" "r"]

# Reject traversals of different length
expected ← Error "traversals must have the same length"
⍤⤙≍ expected treeFromTraversals ["b" "a" "r"] ["a" "b"]

# Reject inconsistent traversals of same length
expected ← Error "traversals must have the same elements"
⍤⤙≍ expected treeFromTraversals ["a" "b" "c"] ["x" "y" "z"]

# Reject traversals with repeated items
expected ← Error "traversals must contain unique items"
⍤⤙≍ expected treeFromTraversals ["b" "a" "a"] ["a" "b" "a"]
