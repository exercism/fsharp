source("./two-bucket.R")
library(testthat)

let ``Measure using bucket one of size 3 and bucket two of size 5 - start with bucket one`` () =
    bucketOne <- 3
    bucketTwo <- 5
    goal <- 1
    startBucket <- Bucket.One
    expected <- { Moves = 4; GoalBucket = Bucket.One; OtherBucket = 5 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``Measure using bucket one of size 3 and bucket two of size 5 - start with bucket two`` () =
    bucketOne <- 3
    bucketTwo <- 5
    goal <- 1
    startBucket <- Bucket.Two
    expected <- { Moves = 8; GoalBucket = Bucket.Two; OtherBucket = 3 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``Measure using bucket one of size 7 and bucket two of size 11 - start with bucket one`` () =
    bucketOne <- 7
    bucketTwo <- 11
    goal <- 2
    startBucket <- Bucket.One
    expected <- { Moves = 14; GoalBucket = Bucket.One; OtherBucket = 11 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``Measure using bucket one of size 7 and bucket two of size 11 - start with bucket two`` () =
    bucketOne <- 7
    bucketTwo <- 11
    goal <- 2
    startBucket <- Bucket.Two
    expected <- { Moves = 18; GoalBucket = Bucket.Two; OtherBucket = 7 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``Measure one step using bucket one of size 1 and bucket two of size 3 - start with bucket two`` () =
    bucketOne <- 1
    bucketTwo <- 3
    goal <- 3
    startBucket <- Bucket.Two
    expected <- { Moves = 1; GoalBucket = Bucket.Two; OtherBucket = 0 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``Measure using bucket one of size 2 and bucket two of size 3 - start with bucket one and end with bucket two`` () =
    bucketOne <- 2
    bucketTwo <- 3
    goal <- 3
    startBucket <- Bucket.One
    expected <- { Moves = 2; GoalBucket = Bucket.Two; OtherBucket = 2 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

let ``With the same buckets but a different goal, then it is possible`` () =
    bucketOne <- 6
    bucketTwo <- 15
    goal <- 9
    startBucket <- Bucket.One
    expected <- { Moves = 10; GoalBucket = Bucket.Two; OtherBucket = 0 }
    measure bucketOne bucketTwo goal startBucket |> should equal expected

