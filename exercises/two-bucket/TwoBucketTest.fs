// This file was auto-generated based on version 1.4.0 of the canonical data.

module TwoBucketTest

open FsUnit.Xunit
open Xunit

open TwoBucket

[<Fact>]
let ``Measure using bucket one of size 3 and bucket two of size 5 - start with bucket one`` () =
    let bucketOne = 3
    let bucketTwo = 5
    let goal = 1
    let startBucket = Bucket.One
    let expected = { Moves = 4; GoalBucket = Bucket.One; OtherBucket = 5 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Measure using bucket one of size 3 and bucket two of size 5 - start with bucket two`` () =
    let bucketOne = 3
    let bucketTwo = 5
    let goal = 1
    let startBucket = Bucket.Two
    let expected = { Moves = 8; GoalBucket = Bucket.Two; OtherBucket = 3 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Measure using bucket one of size 7 and bucket two of size 11 - start with bucket one`` () =
    let bucketOne = 7
    let bucketTwo = 11
    let goal = 2
    let startBucket = Bucket.One
    let expected = { Moves = 14; GoalBucket = Bucket.One; OtherBucket = 11 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Measure using bucket one of size 7 and bucket two of size 11 - start with bucket two`` () =
    let bucketOne = 7
    let bucketTwo = 11
    let goal = 2
    let startBucket = Bucket.Two
    let expected = { Moves = 18; GoalBucket = Bucket.Two; OtherBucket = 7 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Measure one step using bucket one of size 1 and bucket two of size 3 - start with bucket two`` () =
    let bucketOne = 1
    let bucketTwo = 3
    let goal = 3
    let startBucket = Bucket.Two
    let expected = { Moves = 1; GoalBucket = Bucket.Two; OtherBucket = 0 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Measure using bucket one of size 2 and bucket two of size 3 - start with bucket one and end with bucket two`` () =
    let bucketOne = 2
    let bucketTwo = 3
    let goal = 3
    let startBucket = Bucket.One
    let expected = { Moves = 2; GoalBucket = Bucket.Two; OtherBucket = 2 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

