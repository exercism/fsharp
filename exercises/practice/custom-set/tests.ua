~ "custom-set.ua" ~ CustomSet

# Sets with no elements are empty
    let actual = CustomSet.isEmpty (CustomSet.fromList [])
⍤⤙≍ 1 actual

# Sets with elements are not empty
    let actual = CustomSet.isEmpty (CustomSet.fromList [1])
⍤⤙≍ 0 actual

# Nothing is contained in an empty set
    let setValue = CustomSet.fromList []
    let element = 1
    let actual = CustomSet.contains element setValue
⍤⤙≍ 0 actual

# When the element is in the set
    let setValue = CustomSet.fromList [1 2 3]
    let element = 1
    let actual = CustomSet.contains element setValue
⍤⤙≍ 1 actual

# When the element is not in the set
    let setValue = CustomSet.fromList [1 2 3]
    let element = 4
    let actual = CustomSet.contains element setValue
⍤⤙≍ 0 actual

# Empty set is a subset of another empty set
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isSubsetOf set1 set2
⍤⤙≍ 1 actual

# Empty set is a subset of non-empty set
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [1]
    let actual = CustomSet.isSubsetOf set1 set2
⍤⤙≍ 1 actual

# Non-empty set is not a subset of empty set
    let set1 = CustomSet.fromList [1]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isSubsetOf set1 set2
⍤⤙≍ 0 actual

# Set is a subset of set with exact same elements
    let set1 = CustomSet.fromList [1 2 3]
    let set2 = CustomSet.fromList [1 2 3]
    let actual = CustomSet.isSubsetOf set1 set2
⍤⤙≍ 1 actual

# Set is a subset of larger set with same elements
    let set1 = CustomSet.fromList [1 2 3]
    let set2 = CustomSet.fromList [4 1 2 3]
    let actual = CustomSet.isSubsetOf set1 set2
⍤⤙≍ 1 actual

# Set is not a subset of set that does not contain its elements
    let set1 = CustomSet.fromList [1 2 3]
    let set2 = CustomSet.fromList [4 1 3]
    let actual = CustomSet.isSubsetOf set1 set2
⍤⤙≍ 0 actual

# The empty set is disjoint with itself
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isDisjointFrom set1 set2
⍤⤙≍ 1 actual

# Empty set is disjoint with non-empty set
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [1]
    let actual = CustomSet.isDisjointFrom set1 set2
⍤⤙≍ 1 actual

# Non-empty set is disjoint with empty set
    let set1 = CustomSet.fromList [1]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isDisjointFrom set1 set2
⍤⤙≍ 1 actual

# Sets are not disjoint if they share an element
    let set1 = CustomSet.fromList [1 2]
    let set2 = CustomSet.fromList [2 3]
    let actual = CustomSet.isDisjointFrom set1 set2
⍤⤙≍ 0 actual

# Sets are disjoint if they share no elements
    let set1 = CustomSet.fromList [1 2]
    let set2 = CustomSet.fromList [3 4]
    let actual = CustomSet.isDisjointFrom set1 set2
⍤⤙≍ 1 actual

# Empty sets are equal
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isEqualTo set1 set2
⍤⤙≍ 1 actual

# Empty set is not equal to non-empty set
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [1 2 3]
    let actual = CustomSet.isEqualTo set1 set2
⍤⤙≍ 0 actual

# Non-empty set is not equal to empty set
    let set1 = CustomSet.fromList [1 2 3]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isEqualTo set1 set2
⍤⤙≍ 0 actual

# Sets with the same elements are equal
    let set1 = CustomSet.fromList [1 2]
    let set2 = CustomSet.fromList [2 1]
    let actual = CustomSet.isEqualTo set1 set2
⍤⤙≍ 1 actual

# Sets with different elements are not equal
    let set1 = CustomSet.fromList [1 2 3]
    let set2 = CustomSet.fromList [1 2 4]
    let actual = CustomSet.isEqualTo set1 set2
⍤⤙≍ 0 actual

# Set is not equal to larger set with same elements
    let set1 = CustomSet.fromList [1 2 3]
    let set2 = CustomSet.fromList [1 2 3 4]
    let actual = CustomSet.isEqualTo set1 set2
⍤⤙≍ 0 actual

# Add to empty set
    let setValue = CustomSet.fromList []
    let element = 3
    let actual = CustomSet.insert element setValue
    let expectedSet = CustomSet.fromList [3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Add to non-empty set
    let setValue = CustomSet.fromList [1 2 4]
    let element = 3
    let actual = CustomSet.insert element setValue
    let expectedSet = CustomSet.fromList [1 2 3 4]
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Adding an existing element does not change the set
    let setValue = CustomSet.fromList [1 2 3]
    let element = 3
    let actual = CustomSet.insert element setValue
    let expectedSet = CustomSet.fromList [1 2 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Intersection of two empty sets is an empty set
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Intersection of an empty set and non-empty set is an empty set
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [3 2 5]
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Intersection of a non-empty set and an empty set is an empty set
    let set1 = CustomSet.fromList [1 2 3 4]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Intersection of two sets with no shared elements is an empty set
    let set1 = CustomSet.fromList [1 2 3]
    let set2 = CustomSet.fromList [4 5 6]
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Intersection of two sets with shared elements is a set of the shared elements
    let set1 = CustomSet.fromList [1 2 3 4]
    let set2 = CustomSet.fromList [3 2 5]
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList [2 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Difference of two empty sets is an empty set
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Difference of empty set and non-empty set is an empty set
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [3 2 5]
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Difference of a non-empty set and an empty set is the non-empty set
    let set1 = CustomSet.fromList [1 2 3 4]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList [1 2 3 4]
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Difference of two non-empty sets is a set of elements that are only in the first set
    let set1 = CustomSet.fromList [3 2 1]
    let set2 = CustomSet.fromList [2 4]
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList [1 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Union of empty sets is an empty set
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Union of an empty set and non-empty set is the non-empty set
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [2]
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList [2]
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Union of a non-empty set and empty set is the non-empty set
    let set1 = CustomSet.fromList [1 3]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList [1 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

# Union of non-empty sets contains all unique elements
    let set1 = CustomSet.fromList [1 3]
    let set2 = CustomSet.fromList [2 3]
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList [3 2 1]
    let actualBool = CustomSet.isEqualTo actual expectedSet
⍤⤙≍ 1 actualBool

