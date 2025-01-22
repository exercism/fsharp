source("./custom-set.R")
library(testthat)

let ``Sets with no elements are empty`` () =
    actual <- CustomSet.isEmpty (CustomSet.fromList [])
    actual |> should equal true

let ``Sets with elements are not empty`` () =
    actual <- CustomSet.isEmpty (CustomSet.fromList [1])
    actual |> should equal false

let ``Nothing is contained in an empty set`` () =
    setValue <- CustomSet.fromList []
    element <- 1
    actual <- CustomSet.contains element setValue
    actual |> should equal false

let ``When the element is in the set`` () =
    setValue <- CustomSet.fromList [1; 2; 3]
    element <- 1
    actual <- CustomSet.contains element setValue
    actual |> should equal true

let ``When the element is not in the set`` () =
    setValue <- CustomSet.fromList [1; 2; 3]
    element <- 4
    actual <- CustomSet.contains element setValue
    actual |> should equal false

let ``Empty set is a subset of another empty set`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList []
    actual <- CustomSet.isSubsetOf set1 set2
    actual |> should equal true

let ``Empty set is a subset of non-empty set`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList [1]
    actual <- CustomSet.isSubsetOf set1 set2
    actual |> should equal true

let ``Non-empty set is not a subset of empty set`` () =
    set1 <- CustomSet.fromList [1]
    set2 <- CustomSet.fromList []
    actual <- CustomSet.isSubsetOf set1 set2
    actual |> should equal false

let ``Set is a subset of set with exact same elements`` () =
    set1 <- CustomSet.fromList [1; 2; 3]
    set2 <- CustomSet.fromList [1; 2; 3]
    actual <- CustomSet.isSubsetOf set1 set2
    actual |> should equal true

let ``Set is a subset of larger set with same elements`` () =
    set1 <- CustomSet.fromList [1; 2; 3]
    set2 <- CustomSet.fromList [4; 1; 2; 3]
    actual <- CustomSet.isSubsetOf set1 set2
    actual |> should equal true

let ``Set is not a subset of set that does not contain its elements`` () =
    set1 <- CustomSet.fromList [1; 2; 3]
    set2 <- CustomSet.fromList [4; 1; 3]
    actual <- CustomSet.isSubsetOf set1 set2
    actual |> should equal false

let ``The empty set is disjoint with itself`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList []
    actual <- CustomSet.isDisjointFrom set1 set2
    actual |> should equal true

let ``Empty set is disjoint with non-empty set`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList [1]
    actual <- CustomSet.isDisjointFrom set1 set2
    actual |> should equal true

let ``Non-empty set is disjoint with empty set`` () =
    set1 <- CustomSet.fromList [1]
    set2 <- CustomSet.fromList []
    actual <- CustomSet.isDisjointFrom set1 set2
    actual |> should equal true

let ``Sets are not disjoint if they share an element`` () =
    set1 <- CustomSet.fromList [1; 2]
    set2 <- CustomSet.fromList [2; 3]
    actual <- CustomSet.isDisjointFrom set1 set2
    actual |> should equal false

let ``Sets are disjoint if they share no elements`` () =
    set1 <- CustomSet.fromList [1; 2]
    set2 <- CustomSet.fromList [3; 4]
    actual <- CustomSet.isDisjointFrom set1 set2
    actual |> should equal true

let ``Empty sets are equal`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList []
    actual <- CustomSet.isEqualTo set1 set2
    actual |> should equal true

let ``Empty set is not equal to non-empty set`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList [1; 2; 3]
    actual <- CustomSet.isEqualTo set1 set2
    actual |> should equal false

let ``Non-empty set is not equal to empty set`` () =
    set1 <- CustomSet.fromList [1; 2; 3]
    set2 <- CustomSet.fromList []
    actual <- CustomSet.isEqualTo set1 set2
    actual |> should equal false

let ``Sets with the same elements are equal`` () =
    set1 <- CustomSet.fromList [1; 2]
    set2 <- CustomSet.fromList [2; 1]
    actual <- CustomSet.isEqualTo set1 set2
    actual |> should equal true

let ``Sets with different elements are not equal`` () =
    set1 <- CustomSet.fromList [1; 2; 3]
    set2 <- CustomSet.fromList [1; 2; 4]
    actual <- CustomSet.isEqualTo set1 set2
    actual |> should equal false

let ``Set is not equal to larger set with same elements`` () =
    set1 <- CustomSet.fromList [1; 2; 3]
    set2 <- CustomSet.fromList [1; 2; 3; 4]
    actual <- CustomSet.isEqualTo set1 set2
    actual |> should equal false

let ``Add to empty set`` () =
    setValue <- CustomSet.fromList []
    element <- 3
    actual <- CustomSet.insert element setValue
    expectedSet <- CustomSet.fromList [3]
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Add to non-empty set`` () =
    setValue <- CustomSet.fromList [1; 2; 4]
    element <- 3
    actual <- CustomSet.insert element setValue
    expectedSet <- CustomSet.fromList [1; 2; 3; 4]
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Adding an existing element does not change the set`` () =
    setValue <- CustomSet.fromList [1; 2; 3]
    element <- 3
    actual <- CustomSet.insert element setValue
    expectedSet <- CustomSet.fromList [1; 2; 3]
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Intersection of two empty sets is an empty set`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList []
    actual <- CustomSet.intersection set1 set2
    expectedSet <- CustomSet.fromList []
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Intersection of an empty set and non-empty set is an empty set`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList [3; 2; 5]
    actual <- CustomSet.intersection set1 set2
    expectedSet <- CustomSet.fromList []
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Intersection of a non-empty set and an empty set is an empty set`` () =
    set1 <- CustomSet.fromList [1; 2; 3; 4]
    set2 <- CustomSet.fromList []
    actual <- CustomSet.intersection set1 set2
    expectedSet <- CustomSet.fromList []
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Intersection of two sets with no shared elements is an empty set`` () =
    set1 <- CustomSet.fromList [1; 2; 3]
    set2 <- CustomSet.fromList [4; 5; 6]
    actual <- CustomSet.intersection set1 set2
    expectedSet <- CustomSet.fromList []
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Intersection of two sets with shared elements is a set of the shared elements`` () =
    set1 <- CustomSet.fromList [1; 2; 3; 4]
    set2 <- CustomSet.fromList [3; 2; 5]
    actual <- CustomSet.intersection set1 set2
    expectedSet <- CustomSet.fromList [2; 3]
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Difference of two empty sets is an empty set`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList []
    actual <- CustomSet.difference set1 set2
    expectedSet <- CustomSet.fromList []
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Difference of empty set and non-empty set is an empty set`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList [3; 2; 5]
    actual <- CustomSet.difference set1 set2
    expectedSet <- CustomSet.fromList []
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Difference of a non-empty set and an empty set is the non-empty set`` () =
    set1 <- CustomSet.fromList [1; 2; 3; 4]
    set2 <- CustomSet.fromList []
    actual <- CustomSet.difference set1 set2
    expectedSet <- CustomSet.fromList [1; 2; 3; 4]
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Difference of two non-empty sets is a set of elements that are only in the first set`` () =
    set1 <- CustomSet.fromList [3; 2; 1]
    set2 <- CustomSet.fromList [2; 4]
    actual <- CustomSet.difference set1 set2
    expectedSet <- CustomSet.fromList [1; 3]
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Union of empty sets is an empty set`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList []
    actual <- CustomSet.union set1 set2
    expectedSet <- CustomSet.fromList []
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Union of an empty set and non-empty set is the non-empty set`` () =
    set1 <- CustomSet.fromList []
    set2 <- CustomSet.fromList [2]
    actual <- CustomSet.union set1 set2
    expectedSet <- CustomSet.fromList [2]
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Union of a non-empty set and empty set is the non-empty set`` () =
    set1 <- CustomSet.fromList [1; 3]
    set2 <- CustomSet.fromList []
    actual <- CustomSet.union set1 set2
    expectedSet <- CustomSet.fromList [1; 3]
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

let ``Union of non-empty sets contains all unique elements`` () =
    set1 <- CustomSet.fromList [1; 3]
    set2 <- CustomSet.fromList [2; 3]
    actual <- CustomSet.union set1 set2
    expectedSet <- CustomSet.fromList [3; 2; 1]
    actualBool <- CustomSet.isEqualTo actual expectedSet
    actualBool |> should equal true

