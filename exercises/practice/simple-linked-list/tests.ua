~ "SOLUTION" ~ SimpleLinkedList

# Empty list
list = nil
⍤⤙≍ 1 isNil list

# Single item list value
list = create 1 nil
⍤⤙≍ 1 datum list
        
# Single item list has no next item
list = create 1 nil
⍤⤙≍ 1 next list |> isNil
        
# Two item list first value
list = create 2 (create 1 nil)
⍤⤙≍ 2 datum list
    
# Two item list second value
list = create 2 (create 1 nil)
⍤⤙≍ 1 next list |> datum
    
# Two item list second item has no next
list = create 2 (create 1 nil)
⍤⤙≍ 1 next list |> next |> isNil
        
# To list
values = create 2 (create 1 nil) |> toList
⍤⤙≍ [2 1] values
        
# From list
list = fromList [11 7 5 3 2]
⍤⤙≍ 11 list |> datum
⍤⤙≍ 7 list |> next |> datum
⍤⤙≍ 5 list |> next |> next |> datum
⍤⤙≍ 3 list |> next |> next |> next |> datum
⍤⤙≍ 2 list |> next |> next |> next |> next |> datum

# Reverse length 1
values = [1..1]
list = fromList values
reversed = reverse list
⍤⤙≍ <| List.rev values reversed |> toList

# Reverse length 2
values = [1..2]
list = fromList values
reversed = reverse list
⍤⤙≍ <| List.rev values  reversed |> toList

# Reverse length 10
values = [1..10]
list = fromList values
reversed = reverse list
⍤⤙≍ <| List.rev values  reversed |> toList

# Reverse length 100
values = [1..100]
list = fromList values
reversed = reverse list
⍤⤙≍ <| List.rev values  reversed |> toList

# Roundtrip length 1
values = [1..1]
listValues = fromList values
⍤⤙≍ values listValues |> toList

# Roundtrip length 2
values = [1..2]
listValues = fromList values
⍤⤙≍ values listValues |> toList

# Roundtrip length 10
values = [1..10]
listValues = fromList values
⍤⤙≍ values listValues |> toList

# Roundtrip length 100
values = [1..100]
listValues = fromList values
⍤⤙≍ values listValues |> toList
