// This file was created manually and its version is 1.0.0.

module DotDslTest



# Empty graph
    let g = graph []

    nodes g |> should be Empty
    edges g |> should be Empty
    attrs g |> should be Empty
    
# Graph with one node
    let g = graph [
                node "a" []
            ]            

⍤⤙≍ [node "a" []] nodes g
    edges g |> should be Empty
    attrs g |> should be Empty
    
# Graph with one node with keywords    
    let g = graph [
                node "a" [("color", "green")]
            ]            

⍤⤙≍ [node "a" [("color", "green")]] nodes g
    edges g |> should be Empty
    attrs g |> should be Empty

# Graph with one edge    
    let g = graph [
                edge "a" "b" []
            ]             

    nodes g |> should be Empty
⍤⤙≍ [edge "a" "b" []] edges g
    attrs g |> should be Empty

# Graph with one attribute 
    let g = graph [
                attr "foo" "1"
            ]             

    nodes g |> should be Empty
    edges g |> should be Empty
⍤⤙≍ [attr "foo" "1"] attrs g

# Graph with attributes    
    let g = graph [
                attr "foo" "1"
                attr "title" "Testing Attrs"
                node "a" [("color", "green")]
                node "c" []
                node "b" [("label", "Beta!")]                
                edge "b" "c" []
                edge "a" "b" [("color", "blue")]                
                attr "bar" "true"
            ]             

⍤⤙≍ [node "a" [("color", "green")] node "b" [("label", "Beta!")] node "c" []] nodes g
⍤⤙≍ [edge "a" "b" [("color", "blue")] edge "b" "c" []] edges g
⍤⤙≍ [attr "bar" "true" attr "foo" "1" attr "title" "Testing Attrs"] attrs g