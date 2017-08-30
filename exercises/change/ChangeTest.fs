module ChangeTest

open Xunit
open FsUnit

open Change

[<Test>]
let ``Single coin change`` () =
    let actual = [1; 5; 10; 25; 100]
    let target = 25
    let expected = Some [25]
    change target actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple coin change`` () =
    let actual = [1; 5; 10; 25; 100]
    let target = 15
    let expected = Some [5; 10]
    change target actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Change with Lilliputian Coins`` () =
    let actual = [1; 4; 15; 20; 50]
    let target = 23
    let expected = Some [4; 4; 15]
    change target actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Change with Lower Elbonia Coins`` () =
    let actual = [1; 5; 10; 21; 25]
    let target = 63
    let expected = Some [21; 21; 21]
    change target actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Large target values`` () =
    let actual = [1; 2; 5; 10; 20; 50; 100]
    let target = 999
    let expected = Some [2; 2; 5; 20; 20; 50; 100; 100; 100; 100; 100; 100; 100; 100; 100]
    change target actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``No coins make 0 change`` () =
    let actual = [1; 5; 10; 21; 25]
    let target = 0
    let (expected: int list option) = Some []
    change target actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Error testing for change smaller than the smallest of coins`` () =
    let actual = [5; 10]
    let target = 3
    let expected = None
    change target actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Cannot find negative change values`` () =
    let actual = [1; 2; 5]
    let target = -5
    let expected = None
    change target actual |> should equal expected