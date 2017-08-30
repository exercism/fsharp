module TwoBucketTest

open Xunit
open FsUnit

open TwoBucket

[<Fact>]
let ``First example``() =
    let bucketOneSize = 3
    let bucketTwoSize = 5
    let goal = 1
    let startBucket = Bucket.One

    let actual = moves bucketOneSize bucketTwoSize goal startBucket
    actual |> should equal <| Some (4, Bucket.One, 5)

[<Fact(Skip = "Remove to run test")>]
let ``Second example``() =
    let bucketOneSize = 3
    let bucketTwoSize = 5
    let goal = 1
    let startBucket = Bucket.Two

    let actual = moves bucketOneSize bucketTwoSize goal startBucket
    actual |> should equal <| Some (8, Bucket.Two, 3)

[<Fact(Skip = "Remove to run test")>]
let ``Third example``() =
    let bucketOneSize = 7
    let bucketTwoSize = 11
    let goal = 2
    let startBucket = Bucket.One

    let actual = moves bucketOneSize bucketTwoSize goal startBucket
    actual |> should equal <| Some (14, Bucket.One, 11)

[<Fact(Skip = "Remove to run test")>]
let ``Fourth example``() =
    let bucketOneSize = 7
    let bucketTwoSize = 11
    let goal = 2
    let startBucket = Bucket.Two

    let actual = moves bucketOneSize bucketTwoSize goal startBucket
    actual |> should equal <| Some (18, Bucket.Two, 7)