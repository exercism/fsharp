import "two_bucket"

let ``Measure using bucket one of size 3 and bucket two of size 5 - start with bucket one`` () =
    let bucket_one = 3
    let bucket_two = 5
    let goal = 1
    let start_bucket = Bucket.One
    let expected = { Moves = 4; GoalBucket = Bucket.One; OtherBucket = 5 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``Measure using bucket one of size 3 and bucket two of size 5 - start with bucket two`` () =
    let bucket_one = 3
    let bucket_two = 5
    let goal = 1
    let start_bucket = Bucket.Two
    let expected = { Moves = 8; GoalBucket = Bucket.Two; OtherBucket = 3 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``Measure using bucket one of size 7 and bucket two of size 11 - start with bucket one`` () =
    let bucket_one = 7
    let bucket_two = 11
    let goal = 2
    let start_bucket = Bucket.One
    let expected = { Moves = 14; GoalBucket = Bucket.One; OtherBucket = 11 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``Measure using bucket one of size 7 and bucket two of size 11 - start with bucket two`` () =
    let bucket_one = 7
    let bucket_two = 11
    let goal = 2
    let start_bucket = Bucket.Two
    let expected = { Moves = 18; GoalBucket = Bucket.Two; OtherBucket = 7 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``Measure one step using bucket one of size 1 and bucket two of size 3 - start with bucket two`` () =
    let bucket_one = 1
    let bucket_two = 3
    let goal = 3
    let start_bucket = Bucket.Two
    let expected = { Moves = 1; GoalBucket = Bucket.Two; OtherBucket = 0 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``Measure using bucket one of size 2 and bucket two of size 3 - start with bucket one and end with bucket two`` () =
    let bucket_one = 2
    let bucket_two = 3
    let goal = 3
    let start_bucket = Bucket.One
    let expected = { Moves = 2; GoalBucket = Bucket.Two; OtherBucket = 2 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``With the same buckets but a different goal, then it is possible`` () =
    let bucket_one = 6
    let bucket_two = 15
    let goal = 9
    let start_bucket = Bucket.One
    let expected = { Moves = 10; GoalBucket = Bucket.Two; OtherBucket = 0 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

