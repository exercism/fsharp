~ "pov.ua" ~ Pov

rec graphToList (graph: Graph<'a>) = 
right =
        graph.children
        |> List.sortBy (fun x -> x.value)
        |> List.collect graphToList
    [graph.value] @ right
mapToList graph = match graph with | x -> graphToList x | None -> []

# Results in the same tree if the input tree is a singleton
tree = mkGraph "x" []
expected = mkGraph "x" []
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Can reroot a tree with a parent and one sibling
tree = mkGraph "parent" [mkGraph "x" [] mkGraph "sibling" []]
expected = mkGraph "x" [mkGraph "parent" [mkGraph "sibling" []]]
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Can reroot a tree with a parent and many siblings
tree = mkGraph "parent" [mkGraph "a" [] mkGraph "x" [] mkGraph "b" [] mkGraph "c" []]
expected = mkGraph "x" [mkGraph "parent" [mkGraph "a" [] mkGraph "b" [] mkGraph "c" []]]
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Can reroot a tree with new root deeply nested in tree
tree = mkGraph "level-0" [mkGraph "level-1" [mkGraph "level-2" [mkGraph "level-3" [mkGraph "x" []]]]]
expected = mkGraph "x" [mkGraph "level-3" [mkGraph "level-2" [mkGraph "level-1" [mkGraph "level-0" []]]]]
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Moves children of the new root to same level as former parent
tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []]]
expected = mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" [] mkGraph "parent" []]
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Can reroot a complex tree with cousins
tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []] mkGraph "sibling-0" [] mkGraph "sibling-1" []] mkGraph "uncle" [mkGraph "cousin-0" [] mkGraph "cousin-1" []]]
expected = mkGraph "x" [mkGraph "kid-1" [] mkGraph "kid-0" [] mkGraph "parent" [mkGraph "sibling-0" [] mkGraph "sibling-1" [] mkGraph "grandparent" [mkGraph "uncle" [mkGraph "cousin-0" [] mkGraph "cousin-1" []]]]]
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Errors if target does not exist in a singleton tree
tree = mkGraph "x" []
⍤⤙≍ "TODO: insert error message" ⍣(fromPOV "nonexistent" tree )

# Errors if target does not exist in a large tree
tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []] mkGraph "sibling-0" [] mkGraph "sibling-1" []]
⍤⤙≍ "TODO: insert error message" ⍣(fromPOV "nonexistent" tree )

# Can find path to parent
tree = mkGraph "parent" [mkGraph "x" [] mkGraph "sibling" []]
⍤⤙≍ <| ["x" "parent"] tracePathBetween "x" "parent" tree

# Can find path to sibling
tree = mkGraph "parent" [mkGraph "a" [] mkGraph "x" [] mkGraph "b" [] mkGraph "c" []]
⍤⤙≍ <| ["x" "parent" "b"] tracePathBetween "x" "b" tree

# Can find path to cousin
tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []] mkGraph "sibling-0" [] mkGraph "sibling-1" []] mkGraph "uncle" [mkGraph "cousin-0" [] mkGraph "cousin-1" []]]
⍤⤙≍ <| ["x" "parent" "grandparent" "uncle" "cousin-1"] tracePathBetween "x" "cousin-1" tree

# Can find path not involving root
tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [] mkGraph "sibling-0" [] mkGraph "sibling-1" []]]
⍤⤙≍ <| ["x" "parent" "sibling-1"] tracePathBetween "x" "sibling-1" tree

# Can find path from nodes other than x
tree = mkGraph "parent" [mkGraph "a" [] mkGraph "x" [] mkGraph "b" [] mkGraph "c" []]
⍤⤙≍ <| ["a" "parent" "c"] tracePathBetween "a" "c" tree

# Errors if destination does not exist
tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []] mkGraph "sibling-0" [] mkGraph "sibling-1" []]
⍤⤙≍ "TODO: insert error message" ⍣(tracePathBetween "x" "nonexistent" tree)

# Errors if source does not exist
tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []] mkGraph "sibling-0" [] mkGraph "sibling-1" []]
⍤⤙≍ "TODO: insert error message" ⍣(tracePathBetween "nonexistent" "x" tree)

