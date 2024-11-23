module ResistorColorDuoTests

open FsUnit.Xunit
open Xunit

open ResistorColorDuo

[<Fact>]
let ``Brown and black`` () =
    value ["brown"; "black"] |> should equal 10

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Blue and grey`` () =
    value ["blue"; "grey"] |> should equal 68

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Yellow and violet`` () =
    value ["yellow"; "violet"] |> should equal 47

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``White and red`` () =
    value ["white"; "red"] |> should equal 92

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Orange and orange`` () =
    value ["orange"; "orange"] |> should equal 33

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Ignore additional colors`` () =
    value ["green"; "brown"; "orange"] |> should equal 51

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Black and brown, one-digit`` () =
    value ["black"; "brown"] |> should equal 1

