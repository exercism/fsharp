module ListOpsTest

open NUnit.Framework
open FsUnit

open ListOps

let big = 100000
let bigList = [1 .. big]
let odd x = x % 2 = 1

[<Test>]
let ``length of empty list`` () =
    length [] |> should equal 0

[<Test>]
[<Ignore("Remove to run test")>]
let ``length of non-empty list`` () =
    length [1 .. 4] |> should equal 4

[<Test>]
[<Ignore("Remove to run test")>]
let ``length of large list`` () =
    length [1 .. big] |> should equal big

[<Test>]
[<Ignore("Remove to run test")>]
let ``reverse of empty list`` () =
    reverse [] |> should equal []

[<Test>]
[<Ignore("Remove to run test")>]
let ``reverse of non-empty list`` () =
    reverse [1 .. 100] |> should equal [100 .. -1 .. 1]

[<Test>]
[<Ignore("Remove to run test")>]
let ``map of empty list`` () =
    map ((+) 1) [] |> should equal []

[<Test>]
[<Ignore("Remove to run test")>]
let ``map of non-empty list`` () =
    map ((+) 1) [1 .. 2 .. 7] |> should equal [2 .. 2 .. 8]

[<Test>]
[<Ignore("Remove to run test")>]
let ``filter of empty list`` () =
    filter id [] |> should equal []

[<Test>]
[<Ignore("Remove to run test")>]
let ``filter of normal list`` () =
    filter odd [1 .. 4] |> should equal [1; 3]

[<Test>]
[<Ignore("Remove to run test")>]
let ``foldl of empty list`` () =
    foldl (+) 0 [] |> should equal 0

[<Test>]
[<Ignore("Remove to run test")>]
let ``foldl of non-empty list`` () =
    foldl (+) -3 [1 .. 4] |> should equal 7

[<Test>]
[<Ignore("Remove to run test")>]
let ``foldl of huge list`` () =
    foldl (+) 0 [1 .. big] |> should equal big * (big + 1) / 2

[<Test>]
[<Ignore("Remove to run test")>]
let ``foldl with non-commutative function`` () =
    foldl (-) 10 [1 .. 4] |> should equal 0

[<Test>]
[<Ignore("Remove to run test")>]
let ``foldl is not just foldr . flip`` () =
    foldl (fun acc item -> item :: acc) [] (List.ofSeq "asdf") |> should equal List.ofSeq "fdsa"

[<Test>]
[<Ignore("Remove to run test")>]
let ``foldr as id`` () =
    foldr (fun item acc -> item :: acc) [1 .. big] [] = bigList |> should be true

[<Test>]
[<Ignore("Remove to run test")>]
let ``foldr as append`` () =
    foldr (fun item acc -> item :: acc) [1 .. 99] [100 .. big] = bigList |> should be true

[<Test>]
[<Ignore("Remove to run test")>]
let ``append of empty lists`` () =
    append [] [] |> should equal []

[<Test>]
[<Ignore("Remove to run test")>]
let ``append of empty and non-empty lists`` () =
    append [] [1 .. 4] |> should equal [1 .. 4]

[<Test>]
[<Ignore("Remove to run test")>]
let ``append of non-empty and empty lists`` () =
    append [1 .. 4] [] |> should equal [1 .. 4]

[<Test>]
[<Ignore("Remove to run test")>]
let ``append of non-empty lists`` () =
    append [1 .. 3] [4; 5] |> should equal [1 .. 5]

[<Test>]
[<Ignore("Remove to run test")>]
let ``append of large lists`` () =
    append [1 .. (big / 2)] [1 + big / 2 .. big] = bigList |> should be true

[<Test>]
[<Ignore("Remove to run test")>]
let ``concat of no lists`` () =
    concat [] |> should equal []

[<Test>]
[<Ignore("Remove to run test")>]
let ``concat of list of lists`` () =
    concat [[1; 2]; [3]; []; [4; 5; 6]] |> should equal [1 .. 6]

[<Test>]
[<Ignore("Remove to run test")>]
let ``concat of large list of small lists`` () =
    concat (map (fun x -> [x]) [1 .. big]) = bigList |> should be true