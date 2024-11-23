~ "binary-search.ua" ~ BinarySearch

# Finds a value in an array with one element
    let array =  [6 ]
    let value = 6
    let expected = Some 0
⍤⤙≍ expected find array value

# Finds a value in the middle of an array
    let array =  [1 3 4 6 8 9 11 ]
    let value = 6
    let expected = Some 3
⍤⤙≍ expected find array value

# Finds a value at the beginning of an array
    let array =  [1 3 4 6 8 9 11 ]
    let value = 1
    let expected = Some 0
⍤⤙≍ expected find array value

# Finds a value at the end of an array
    let array =  [1 3 4 6 8 9 11 ]
    let value = 11
    let expected = Some 6
⍤⤙≍ expected find array value

# Finds a value in an array of odd length
    let array =  [1 3 5 8 13 21 34 55 89 144 233 377 634 ]
    let value = 144
    let expected = Some 9
⍤⤙≍ expected find array value

# Finds a value in an array of even length
    let array =  [1 3 5 8 13 21 34 55 89 144 233 377 ]
    let value = 21
    let expected = Some 5
⍤⤙≍ expected find array value

# Identifies that a value is not included in the array
    let array =  [1 3 4 6 8 9 11 ]
    let value = 7
    let expected = None
⍤⤙≍ expected find array value

# A value smaller than the array's smallest value is not found
    let array =  [1 3 4 6 8 9 11 ]
    let value = 0
    let expected = None
⍤⤙≍ expected find array value

# A value larger than the array's largest value is not found
    let array =  [1 3 4 6 8 9 11 ]
    let value = 13
    let expected = None
⍤⤙≍ expected find array value

# Nothing is found in an empty array
    let array =  [ ]
    let value = 1
    let expected = None
⍤⤙≍ expected find array value

# Nothing is found when the left and right bounds cross
    let array =  [1 2 ]
    let value = 0
    let expected = None
⍤⤙≍ expected find array value

