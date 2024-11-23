~ "SOLUTION" ~ DotDsl

# Empty graph
g = graph []

⍤⤙≍ [] nodes g
⍤⤙≍ [] edges g
⍤⤙≍ [] attrs g
    
# Graph with one node
g = graph [
                node "a" []
            ]            

⍤⤙≍ [node "a" []] nodes g
⍤⤙≍ [] edges g
⍤⤙≍ [] attrs g
    
# Graph with one node with keywords    
g = graph [
                node "a" [("color", "green")]
            ]            

⍤⤙≍ [node "a" [("color", "green")]] nodes g
⍤⤙≍ [] edges g
⍤⤙≍ [] attrs g

# Graph with one edge    
g = graph [
                edge "a" "b" []
            ]             

⍤⤙≍ [] nodes g
⍤⤙≍ [edge "a" "b" []] edges g
⍤⤙≍ [] attrs g

# Graph with one attribute 
g = graph [
                attr "foo" "1"
            ]             

⍤⤙≍ [] nodes g
⍤⤙≍ [] edges g
⍤⤙≍ [attr "foo" "1"] attrs g

# Graph with attributes    
g = graph [
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