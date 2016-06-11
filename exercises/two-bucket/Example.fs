module TwoBucket

type Bucket = One | Two

let contents = fst
let size = snd

let empty (_, size) = 0, size
let fill (_, size) = size, size 

let emptyFirstBucket (first, second) = empty first, second
let emptySecondBucket (first, second) = first, empty second

let fillFirstBucket (first, second) = fill first, second
let fillSecondBucket (first, second) = first, fill second

let pourFromFirstToSecond (first, second) =
    let amount = min (size second - contents second) (contents first)
    (contents first - amount, size first), (contents second + amount, size second)

let pourFromSecondToFirst (first, second) = 
    let amount = min (size first - contents first) (contents second)
    (contents first + amount, size first), (contents second - amount, size second)

let isEmpty (contents, _) = contents = 0
let isFull (contents, size) = contents = size

let firstBucketEmpty (first, _) = isEmpty first
let firstBucketFull (first, _) = isFull first

let secondBucketEmpty (_, second) = isEmpty second
let secondBucketFull (_, second) = isFull second

let canPourToFirstBucket (first, second) = contents first + contents second <> size first

let canPourToSecondBucket buckets = 
    (firstBucketFull buckets && not (secondBucketFull buckets)) ||
    (not (firstBucketFull buckets) && secondBucketEmpty buckets)

let startFromFirstBucket buckets = 
    if firstBucketEmpty buckets then fillFirstBucket buckets
    elif secondBucketFull buckets then emptySecondBucket buckets
    elif canPourToSecondBucket buckets then pourFromFirstToSecond buckets
    else failwith "Cannot transition from state"

let startFromSecondBucket buckets = 
    if firstBucketFull buckets then emptyFirstBucket buckets
    elif secondBucketEmpty buckets then fillSecondBucket buckets
    elif canPourToFirstBucket buckets then pourFromSecondToFirst buckets
    else failwith "Cannot transition from state"

let rec solve target strategy moves (first, second) = 
    if contents first = target then Some (moves, One, contents second)
    elif contents second = target then Some (moves, Two, contents first)
    else solve target strategy (moves + 1) (strategy (first, second))

let moves firstSize secondSize target =
    function
    | One -> solve target startFromFirstBucket 1 ((firstSize, firstSize), (0, secondSize))
    | Two -> solve target startFromSecondBucket 1 ((0, firstSize), (secondSize, secondSize))