module CustomSetTest

open NUnit.Framework

open CustomSet

[<Test>]
let ``Sets with no elements are empty`` () =
    let actual = empty
    Assert.That(isEmpty actual, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sets with elements are not empty`` () =
    let actual = singleton 1
    Assert.That(isEmpty actual, Is.False)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Nothing is contained in an empty set`` () =
    let actual = empty
    Assert.That(contains 1 actual, Is.False)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Detect if the element is in the set`` () =
    let actual = fromList [1; 2; 3]
    Assert.That(contains 1 actual, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Detect if the element is not in the set`` () =
    let actual = fromList [1; 2; 3]
    Assert.That(contains 4 actual, Is.False)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty set is a subset of another empty set`` () =
    let left = empty
    let right = empty
    Assert.That(isSubsetOf left right, Is.True)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty set is a subset of non-empty set`` () =
    let left = empty
    let right = singleton 1
    Assert.That(isSubsetOf left right, Is.True)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Non-empty set is not a subset of empty set`` () =
    let left = singleton 1
    let right = empty
    Assert.That(isSubsetOf left right, Is.False)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Set is a subset of set with exact same elements`` () =
    let left = fromList [1; 2; 3]
    let right = fromList [1; 2; 3]
    Assert.That(isSubsetOf left right, Is.True)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Set is a subset of larger set with same elements`` () =
    let left = fromList [1; 2; 3]
    let right = fromList [4; 1; 2; 3]
    Assert.That(isSubsetOf left right, Is.True)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Set is not a subset of set that does not contain its elements`` () =
    let left = fromList [1; 2; 3]
    let right = fromList [4; 1; 3]
    Assert.That(isSubsetOf left right, Is.False)
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``The empty set is disjoint with itself`` () =
    let left = empty
    let right = empty
    Assert.That(isDisjointFrom left right, Is.True)    
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty set is disjoint with non-empty set`` () =
    let left = empty
    let right = singleton 1
    Assert.That(isDisjointFrom left right, Is.True)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Non-empty set is disjoint with empty set`` () =
    let left = singleton 1
    let right = empty
    Assert.That(isDisjointFrom left right, Is.True)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Sets are not disjoint if they share an element`` () =
    let left = fromList [1; 2]
    let right = fromList [2; 3]    
    Assert.That(isDisjointFrom left right, Is.False)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Sets are disjoint if they share no elements`` () =
    let left = fromList [1; 2]
    let right = fromList [3; 4]
    Assert.That(isDisjointFrom left right, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty sets are equal`` () =
    let left = empty
    let right = empty
    Assert.That((left = right))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty set is not equal to non-empty set`` () =
    let left = empty
    let right = fromList [1; 2; 3]
    Assert.That(left <> right)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Non-empty set is not equal to empty set`` () =
    let left = fromList [1; 2; 3]
    let right = empty
    Assert.That(left <> right)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sets with the same elements are equal`` () =
    let left = fromList [1; 2]
    let right = fromList [2; 1]
    Assert.That((left = right))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sets with different elements are not equal`` () =
    let left = fromList [1; 2; 3]
    let right = fromList [1; 2; 4]
    Assert.That(left <> right)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Add to empty set`` () =
    let actual = empty |> insert 3
    let expected = fromList [3]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Add to non-empty set`` () =
    let actual = fromList [1; 2; 4] |> insert 3
    let expected = fromList [1; 2; 3; 4]
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Adding an existing element does not change the set`` () =
    let actual = fromList [1; 2; 3] |> insert 3
    let expected = fromList [1; 2; 3]
    Assert.That(actual, Is.EqualTo(expected))
            
[<Test>]
[<Ignore("Remove to run test")>]
let ``Intersection of two empty sets is an empty set`` () =
    let left = empty
    let right = empty
    let expected = empty
    Assert.That(intersection left right = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Intersection of an empty set and non-empty set is an empty set`` () =
    let left = empty
    let right = fromList [3; 2; 5]
    let expected = empty
    Assert.That(intersection left right = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Intersection of a non-empty set and an empty set is an empty set`` () =
    let left = fromList [1; 2; 3; 4]
    let right = empty
    let expected = empty
    Assert.That(intersection left right = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Intersection of two sets with no shared elements is an empty set`` () =
    let left = fromList [1; 2; 3]
    let right = fromList [4; 5; 6]
    let expected = empty
    Assert.That(intersection left right = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Intersection of two sets with shared elements is a set of the shared elements`` () =
    let left = fromList [1; 2; 3; 4]
    let right = fromList [3; 2; 5]
    let expected = fromList [2; 3]
    Assert.That(intersection left right = expected)
            
[<Test>]
[<Ignore("Remove to run test")>]
let ``Difference of two empty sets is an empty set`` () =
    let left = empty
    let right = empty
    let expected = empty
    Assert.That(difference left right = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Difference of an empty set and non-empty set is an empty set`` () =
    let left = empty
    let right = fromList [3; 2; 5]
    let expected = empty
    Assert.That(difference left right = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Difference of a non-empty set and an empty set is an empty set`` () =
    let left = fromList [1; 2; 3; 4]
    let right = empty
    let expected = fromList [1; 2; 3; 4]
    Assert.That(difference left right = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Difference of two non-empty sets is a set of elements that are only in the first set`` () =
    let left = fromList [3; 2; 1]
    let right = fromList [2; 4]
    let expected = fromList [1; 3]
    Assert.That(difference left right = expected)
           
[<Test>]
[<Ignore("Remove to run test")>]
let ``Union of two empty sets is an empty set`` () =
    let left = empty
    let right = empty
    let expected = empty
    Assert.That(union left right = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Union of an empty set and non-empty set is the non-empty set`` () =
    let left = empty
    let right = fromList [2]
    let expected = fromList [2]
    Assert.That(union left right = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Union of a non-empty set and empty set is the non-empty set`` () =
    let left = fromList [1; 3]
    let right = empty
    let expected = fromList [1; 3]
    Assert.That(union left right = expected)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Union of non-empty sets contains all unique elements`` () =
    let left = fromList [1; 3]
    let right = fromList [2; 3]
    let expected = fromList [3; 2; 1]
    Assert.That(union left right = expected)