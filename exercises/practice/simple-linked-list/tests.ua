// This file was created manually and its version is 1.0.0.

module SimpleLinkedListTest



# Empty list
    let list = nil
⍤⤙≍ 1 isNil list

# Single item list value
    let list = create 1 nil
⍤⤙≍ 1 datum list
        
# Single item list has no next item
    let list = create 1 nil
⍤⤙≍ 1 next list |> isNil
        
# Two item list first value
    let list = create 2 (create 1 nil)
⍤⤙≍ 2 datum list
    
# Two item list second value
    let list = create 2 (create 1 nil)
⍤⤙≍ 1 next list |> datum
    
# Two item list second item has no next
    let list = create 2 (create 1 nil)
⍤⤙≍ 1 next list |> next |> isNil
        
# To list
    let values = create 2 (create 1 nil) |> toList
⍤⤙≍ [2 1] values
        
# From list
    let list = fromList [11 7 5 3 2]
⍤⤙≍ 11 list |> datum
⍤⤙≍ 7 list |> next |> datum
⍤⤙≍ 5 list |> next |> next |> datum
⍤⤙≍ 3 list |> next |> next |> next |> datum
⍤⤙≍ 2 list |> next |> next |> next |> next |> datum

# Reverse length 1
    let values = [1..1]
    let list = fromList values
    let reversed = reverse list
⍤⤙≍ <| List.rev values reversed |> toList

# Reverse length 2
    let values = [1..2]
    let list = fromList values
    let reversed = reverse list
⍤⤙≍ <| List.rev values  reversed |> toList

# Reverse length 10
    let values = [1..10]
    let list = fromList values
    let reversed = reverse list
⍤⤙≍ <| List.rev values  reversed |> toList

# Reverse length 100
    let values = [1..100]
    let list = fromList values
    let reversed = reverse list
⍤⤙≍ <| List.rev values  reversed |> toList

# Roundtrip length 1
    let values = [1..1]
    let listValues = fromList values
⍤⤙≍ values listValues |> toList

# Roundtrip length 2
    let values = [1..2]
    let listValues = fromList values
⍤⤙≍ values listValues |> toList

# Roundtrip length 10
    let values = [1..10]
    let listValues = fromList values
⍤⤙≍ values listValues |> toList

# Roundtrip length 100
    let values = [1..100]
    let listValues = fromList values
⍤⤙≍ values listValues |> toList
