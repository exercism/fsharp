// This file was auto-generated based on version 1.3.0 of the canonical data.

module CustomSetTest

open FsUnit.Xunit
open Xunit

open CustomSet

[<Fact>]
let ``Sets with no elements are empty`` () =
    let actual = CustomSet.isEmpty (CustomSet.fromList [])
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Sets with elements are not empty`` () =
    let actual = CustomSet.isEmpty (CustomSet.fromList [1])
    actual |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Nothing is contained in an empty set`` () =
    let setValue = CustomSet.fromList []
    let element = 1
    let actual = CustomSet.contains element setValue
    actual |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``When the element is in the set`` () =
    let setValue = CustomSet.fromList [1; 2; 3]
    let element = 1
    let actual = CustomSet.contains element setValue
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``When the element is not in the set`` () =
    let setValue = CustomSet.fromList [1; 2; 3]
    let element = 4
    let actual = CustomSet.contains element setValue
    actual |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Empty set is a subset of another empty set`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isSubsetOf set1 set2
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Empty set is a subset of non-empty set`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [1]
    let actual = CustomSet.isSubsetOf set1 set2
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Non-empty set is not a subset of empty set`` () =
    let set1 = CustomSet.fromList [1]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isSubsetOf set1 set2
    actual |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Set is a subset of set with exact same elements`` () =
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [1; 2; 3]
    let actual = CustomSet.isSubsetOf set1 set2
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Set is a subset of larger set with same elements`` () =
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [4; 1; 2; 3]
    let actual = CustomSet.isSubsetOf set1 set2
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Set is not a subset of set that does not contain its elements`` () =
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [4; 1; 3]
    let actual = CustomSet.isSubsetOf set1 set2
    actual |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``The empty set is disjoint with itself`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isDisjointFrom set1 set2
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Empty set is disjoint with non-empty set`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [1]
    let actual = CustomSet.isDisjointFrom set1 set2
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Non-empty set is disjoint with empty set`` () =
    let set1 = CustomSet.fromList [1]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isDisjointFrom set1 set2
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Sets are not disjoint if they share an element`` () =
    let set1 = CustomSet.fromList [1; 2]
    let set2 = CustomSet.fromList [2; 3]
    let actual = CustomSet.isDisjointFrom set1 set2
    actual |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Sets are disjoint if they share no elements`` () =
    let set1 = CustomSet.fromList [1; 2]
    let set2 = CustomSet.fromList [3; 4]
    let actual = CustomSet.isDisjointFrom set1 set2
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Empty sets are equal`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isEqualTo set1 set2
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Empty set is not equal to non-empty set`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [1; 2; 3]
    let actual = CustomSet.isEqualTo set1 set2
    actual |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Non-empty set is not equal to empty set`` () =
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isEqualTo set1 set2
    actual |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Sets with the same elements are equal`` () =
    let set1 = CustomSet.fromList [1; 2]
    let set2 = CustomSet.fromList [2; 1]
    let actual = CustomSet.isEqualTo set1 set2
    actual |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Sets with different elements are not equal`` () =
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [1; 2; 4]
    let actual = CustomSet.isEqualTo set1 set2
    actual |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Set is not equal to larger set with same elements`` () =
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [1; 2; 3; 4]
    let actual = CustomSet.isEqualTo set1 set2
    actual |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Add to empty set`` () =
    let setValue = CustomSet.fromList []
    let element = 3
    let actual = CustomSet.insert element setValue
    let expectedSet = CustomSet.fromList [3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Add to non-empty set`` () =
    let setValue = CustomSet.fromList [1; 2; 4]
    let element = 3
    let actual = CustomSet.insert element setValue
    let expectedSet = CustomSet.fromList [1; 2; 3; 4]
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Adding an existing element does not change the set`` () =
    let setValue = CustomSet.fromList [1; 2; 3]
    let element = 3
    let actual = CustomSet.insert element setValue
    let expectedSet = CustomSet.fromList [1; 2; 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Intersection of two empty sets is an empty set`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Intersection of an empty set and non-empty set is an empty set`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [3; 2; 5]
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Intersection of a non-empty set and an empty set is an empty set`` () =
    let set1 = CustomSet.fromList [1; 2; 3; 4]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Intersection of two sets with no shared elements is an empty set`` () =
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [4; 5; 6]
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Intersection of two sets with shared elements is a set of the shared elements`` () =
    let set1 = CustomSet.fromList [1; 2; 3; 4]
    let set2 = CustomSet.fromList [3; 2; 5]
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList [2; 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Difference of two empty sets is an empty set`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Difference of empty set and non-empty set is an empty set`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [3; 2; 5]
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Difference of a non-empty set and an empty set is the non-empty set`` () =
    let set1 = CustomSet.fromList [1; 2; 3; 4]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList [1; 2; 3; 4]
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Difference of two non-empty sets is a set of elements that are only in the first set`` () =
    let set1 = CustomSet.fromList [3; 2; 1]
    let set2 = CustomSet.fromList [2; 4]
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList [1; 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Union of empty sets is an empty set`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Union of an empty set and non-empty set is the non-empty set`` () =
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [2]
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList [2]
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Union of a non-empty set and empty set is the non-empty set`` () =
    let set1 = CustomSet.fromList [1; 3]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList [1; 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Union of non-empty sets contains all unique elements`` () =
    let set1 = CustomSet.fromList [1; 3]
    let set2 = CustomSet.fromList [2; 3]
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList [3; 2; 1]
    let actualBool = CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

