~ "sublist.ua" ~ Sublist

# Empty lists
    let listOne = []
    let listTwo = []
⍤⤙≍ SublistType.Equal sublist listOne listTwo

# Empty list within non empty list
    let listOne = []
    let listTwo = [1 2 3]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# Non empty list contains empty list
    let listOne = [1 2 3]
    let listTwo = []
⍤⤙≍ SublistType.Superlist sublist listOne listTwo

# List equals itself
    let listOne = [1 2 3]
    let listTwo = [1 2 3]
⍤⤙≍ SublistType.Equal sublist listOne listTwo

# Different lists
    let listOne = [1 2 3]
    let listTwo = [2 3 4]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

# False start
    let listOne = [1 2 5]
    let listTwo = [0 1 2 3 1 2 5 6]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# Consecutive
    let listOne = [1 1 2]
    let listTwo = [0 1 1 1 2 1 2]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# Sublist at start
    let listOne = [0 1 2]
    let listTwo = [0 1 2 3 4 5]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# Sublist in middle
    let listOne = [2 3 4]
    let listTwo = [0 1 2 3 4 5]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# Sublist at end
    let listOne = [3 4 5]
    let listTwo = [0 1 2 3 4 5]
⍤⤙≍ SublistType.Sublist sublist listOne listTwo

# At start of superlist
    let listOne = [0 1 2 3 4 5]
    let listTwo = [0 1 2]
⍤⤙≍ SublistType.Superlist sublist listOne listTwo

# In middle of superlist
    let listOne = [0 1 2 3 4 5]
    let listTwo = [2 3]
⍤⤙≍ SublistType.Superlist sublist listOne listTwo

# At end of superlist
    let listOne = [0 1 2 3 4 5]
    let listTwo = [3 4 5]
⍤⤙≍ SublistType.Superlist sublist listOne listTwo

# First list missing element from second list
    let listOne = [1 3]
    let listTwo = [1 2 3]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

# Second list missing element from first list
    let listOne = [1 2 3]
    let listTwo = [1 3]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

# First list missing additional digits from second list
    let listOne = [1 2]
    let listTwo = [1 22]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

# Order matters to a list
    let listOne = [1 2 3]
    let listTwo = [3 2 1]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

# Same digits but different numbers
    let listOne = [1 0 1]
    let listTwo = [10 1]
⍤⤙≍ SublistType.Unequal sublist listOne listTwo

