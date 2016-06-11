module TwoBucketTest

open NUnit.Framework

open TwoBucket

[<Test>]
let ``First example``() =
    let bucketOneSize = 3
    let bucketTwoSize = 5
    let goal = 1
    let startBucket = Bucket.One

    let actual = moves bucketOneSize bucketTwoSize goal startBucket
    Assert.That(actual, Is.EqualTo(Some (4, Bucket.One, 5)))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Second example``() =
    let bucketOneSize = 3
    let bucketTwoSize = 5
    let goal = 1
    let startBucket = Bucket.Two

    let actual = moves bucketOneSize bucketTwoSize goal startBucket
    Assert.That(actual, Is.EqualTo(Some (8, Bucket.Two, 3)))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Third example``() =
    let bucketOneSize = 7
    let bucketTwoSize = 11
    let goal = 2
    let startBucket = Bucket.One

    let actual = moves bucketOneSize bucketTwoSize goal startBucket
    Assert.That(actual, Is.EqualTo(Some (14, Bucket.One, 11)))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Fourth example``() =
    let bucketOneSize = 7
    let bucketTwoSize = 11
    let goal = 2
    let startBucket = Bucket.Two

    let actual = moves bucketOneSize bucketTwoSize goal startBucket
    Assert.That(actual, Is.EqualTo(Some (18, Bucket.Two, 7)))