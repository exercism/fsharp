module TwoBucket

type Bucket = One | Two
type Result = { Moves: int; GoalBucket: Bucket; OtherBucket: int }

let measure bucketOneCapacity bucketTwoCapacity goal startBucket =
    
    let emptyFirst (_, bucketTwo) = (0, bucketTwo)
    let fillFirst  (_, bucketTwo) = (bucketOneCapacity, bucketTwo)
    let pourFirst  (bucketOne, bucketTwo) =
        if bucketOne + bucketTwo <= bucketTwoCapacity then
            (0, bucketOne + bucketTwo)
        else
            (bucketOne + bucketTwo - bucketTwoCapacity, bucketTwoCapacity)

    let emptySecond (bucketOne, _) = (bucketOne, 0)    
    let fillSecond  (bucketOne, _) = (bucketOne, bucketTwoCapacity)
    let pourSecond  (bucketOne, bucketTwo) =
        if bucketOne + bucketTwo <= bucketOneCapacity then
            (bucketOne + bucketTwo, 0)
        else
            (bucketOneCapacity, bucketOne + bucketTwo - bucketOneCapacity)

    let applyMoves states =
        [emptyFirst; fillFirst; pourFirst; emptySecond; fillSecond; pourSecond]
        |> Seq.collect (fun applyMove -> Seq.map (fun state -> applyMove state) states)
        |> set

    let solved moves (currentBucketOne, currentBucketTwo) =
        if currentBucketOne = goal then
            Some { Moves = moves; GoalBucket = One; OtherBucket = currentBucketTwo }
        elif currentBucketTwo = goal then
            Some { Moves = moves; GoalBucket = Two; OtherBucket = currentBucketOne }
        else
            None

    let rec solve moves visited states =
        match Seq.tryPick (solved moves) states with
        | Some result -> result
        | None ->            
            let newStates = Set.difference (applyMoves states) visited
            let newVisited = Set.union visited newStates                
            solve (moves + 1) newVisited newStates

    let startMoves = 1
    let startVisited = set [(bucketOneCapacity, 0); (0, bucketTwoCapacity)]
    let startState = 
        match startBucket with
        | One -> set [(bucketOneCapacity, 0)]
        | Two -> set [(0, bucketTwoCapacity)]

    solve startMoves startVisited startState