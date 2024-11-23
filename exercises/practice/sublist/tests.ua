~ "sublist.ua" ~ Sublist

# Empty lists
listOne ← []
listTwo ← []
⍤⤙≍ SublistType.Equal sublist listOne listTwo

# Empty list within non empty list
listOne ← []
listTwo ← [1 2 3]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# Non empty list contains empty list
listOne ← [1 2 3]
listTwo ← []
⍤⤙≍ SublistType.Superlist sublist listOne listTwo

# List equals itself
listOne ← [1 2 3]
listTwo ← [1 2 3]
⍤⤙≍ SublistType.Equal sublist listOne listTwo

# Different lists
listOne ← [1 2 3]
listTwo ← [2 3 4]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

# False start
listOne ← [1 2 5]
listTwo ← [0 1 2 3 1 2 5 6]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# Consecutive
listOne ← [1 1 2]
listTwo ← [0 1 1 1 2 1 2]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# Sublist at start
listOne ← [0 1 2]
listTwo ← [0 1 2 3 4 5]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# Sublist in middle
listOne ← [2 3 4]
listTwo ← [0 1 2 3 4 5]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# Sublist at end
listOne ← [3 4 5]
listTwo ← [0 1 2 3 4 5]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# At start of superlist
listOne ← [0 1 2 3 4 5]
listTwo ← [0 1 2]
⍤⤙≍ SublistType.Superlist sublist listOne listTwo

# In middle of superlist
listOne ← [0 1 2 3 4 5]
listTwo ← [2 3]
⍤⤙≍ SublistType.Superlist sublist listOne listTwo

# At end of superlist
listOne ← [0 1 2 3 4 5]
listTwo ← [3 4 5]
⍤⤙≍ SublistType.Superlist sublist listOne listTwo

# First list missing element from second list
listOne ← [1 3]
listTwo ← [1 2 3]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

# Second list missing element from first list
listOne ← [1 2 3]
listTwo ← [1 3]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

# First list missing additional digits from second list
listOne ← [1 2]
listTwo ← [1 22]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

# Order matters to a list
listOne ← [1 2 3]
listTwo ← [3 2 1]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

# Same digits but different numbers
listOne ← [1 0 1]
listTwo ← [10 1]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo
