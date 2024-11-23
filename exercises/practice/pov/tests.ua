~ "pov.ua" ~ Pov

let rec graphToList (graph: Graph<'a>) = 
    let right =
        graph.children
        |> List.sortBy (fun x -> x.value)
        |> List.collect graphToList
    [graph.value] @ right
let mapToList graph = match graph with | Some x -> graphToList x | None -> []

# Results in the same tree if the input tree is a singleton
    let tree = mkGraph "x" []
    let expected = mkGraph "x" []
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Can reroot a tree with a parent and one sibling
    let tree = mkGraph "parent" [mkGraph "x" [] mkGraph "sibling" []]
    let expected = mkGraph "x" [mkGraph "parent" [mkGraph "sibling" []]]
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Can reroot a tree with a parent and many siblings
    let tree = mkGraph "parent" [mkGraph "a" [] mkGraph "x" [] mkGraph "b" [] mkGraph "c" []]
    let expected = mkGraph "x" [mkGraph "parent" [mkGraph "a" [] mkGraph "b" [] mkGraph "c" []]]
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Can reroot a tree with new root deeply nested in tree
    let tree = mkGraph "level-0" [mkGraph "level-1" [mkGraph "level-2" [mkGraph "level-3" [mkGraph "x" []]]]]
    let expected = mkGraph "x" [mkGraph "level-3" [mkGraph "level-2" [mkGraph "level-1" [mkGraph "level-0" []]]]]
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Moves children of the new root to same level as former parent
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []]]
    let expected = mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" [] mkGraph "parent" []]
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Can reroot a complex tree with cousins
    let tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []] mkGraph "sibling-0" [] mkGraph "sibling-1" []] mkGraph "uncle" [mkGraph "cousin-0" [] mkGraph "cousin-1" []]]
    let expected = mkGraph "x" [mkGraph "kid-1" [] mkGraph "kid-0" [] mkGraph "parent" [mkGraph "sibling-0" [] mkGraph "sibling-1" [] mkGraph "grandparent" [mkGraph "uncle" [mkGraph "cousin-0" [] mkGraph "cousin-1" []]]]]
⍤⤙≍ <| graphToList expected fromPOV "x" tree |> mapToList 

# Errors if target does not exist in a singleton tree
    let tree = mkGraph "x" []
⍤⤙≍ None fromPOV "nonexistent" tree 

# Errors if target does not exist in a large tree
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []] mkGraph "sibling-0" [] mkGraph "sibling-1" []]
⍤⤙≍ None fromPOV "nonexistent" tree 

# Can find path to parent
    let tree = mkGraph "parent" [mkGraph "x" [] mkGraph "sibling" []]
⍤⤙≍ <| Some ["x" "parent"] tracePathBetween "x" "parent" tree

# Can find path to sibling
    let tree = mkGraph "parent" [mkGraph "a" [] mkGraph "x" [] mkGraph "b" [] mkGraph "c" []]
⍤⤙≍ <| Some ["x" "parent" "b"] tracePathBetween "x" "b" tree

# Can find path to cousin
    let tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []] mkGraph "sibling-0" [] mkGraph "sibling-1" []] mkGraph "uncle" [mkGraph "cousin-0" [] mkGraph "cousin-1" []]]
⍤⤙≍ <| Some ["x" "parent" "grandparent" "uncle" "cousin-1"] tracePathBetween "x" "cousin-1" tree

# Can find path not involving root
    let tree = mkGraph "grandparent" [mkGraph "parent" [mkGraph "x" [] mkGraph "sibling-0" [] mkGraph "sibling-1" []]]
⍤⤙≍ <| Some ["x" "parent" "sibling-1"] tracePathBetween "x" "sibling-1" tree

# Can find path from nodes other than x
    let tree = mkGraph "parent" [mkGraph "a" [] mkGraph "x" [] mkGraph "b" [] mkGraph "c" []]
⍤⤙≍ <| Some ["a" "parent" "c"] tracePathBetween "a" "c" tree

# Errors if destination does not exist
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []] mkGraph "sibling-0" [] mkGraph "sibling-1" []]
⍤⤙≍ None tracePathBetween "x" "nonexistent" tree

# Errors if source does not exist
    let tree = mkGraph "parent" [mkGraph "x" [mkGraph "kid-0" [] mkGraph "kid-1" []] mkGraph "sibling-0" [] mkGraph "sibling-1" []]
⍤⤙≍ None tracePathBetween "nonexistent" "x" tree

