module CollatzConjectureTests

open FsUnit.Xunit
open Xunit

open CollatzConjecture

[<Fact>]
let ``Zero steps for one`` () =
    steps 1 |> should equal (Some 0)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Divide if even`` () =
    steps 16 |> should equal (Some 4)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Even and odd steps`` () =
    steps 12 |> should equal (Some 9)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Large number of even and odd steps`` () =
    steps 1000000 |> should equal (Some 152)

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Zero is an error`` () =
    steps 0 |> should equal None

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Negative value is an error`` () =
    steps -15 |> should equal None

