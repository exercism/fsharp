module SpaceAgeTest

open Xunit
open FsUnit.Xunit
open SpaceAge
    
[<Fact>]
let ``Age on earth`` () =
    let seconds = 1000000000m
    spaceAge Planet.Earth seconds |> should equal 31.69m

[<Fact(Skip = "Remove to run test")>]
let ``Age on mercury`` () =
    let seconds = 2134835688m
    spaceAge Planet.Earth seconds |> should equal 67.65m
    spaceAge Planet.Mercury seconds |> should equal 280.88m

[<Fact(Skip = "Remove to run test")>]
let ``Age on venus`` () =
    let seconds = 189839836m
    spaceAge Planet.Earth seconds |> should equal 6.02m
    spaceAge Planet.Venus seconds |> should equal 9.78m

[<Fact(Skip = "Remove to run test")>]
let ``Age on mars`` () =
    let seconds = 2329871239m
    spaceAge Planet.Earth seconds |> should equal 73.83m
    spaceAge Planet.Mars seconds |> should equal 39.25m

[<Fact(Skip = "Remove to run test")>]
let ``Age on jupiter`` () =
    let seconds = 901876382m
    spaceAge Planet.Earth seconds |> should equal 28.58m
    spaceAge Planet.Jupiter seconds |> should equal 2.41m

[<Fact(Skip = "Remove to run test")>]
let ``Age on saturn`` () =
    let seconds = 3000000000m
    spaceAge Planet.Earth seconds |> should equal 95.06m
    spaceAge Planet.Saturn seconds |> should equal 3.23m

[<Fact(Skip = "Remove to run test")>]
let ``Age on uranus`` () =
    let seconds = 3210123456m
    spaceAge Planet.Earth seconds |> should equal 101.72m
    spaceAge Planet.Uranus seconds |> should equal 1.21m

[<Fact(Skip = "Remove to run test")>]
let ``Age on neptune`` () =
    let seconds = 8210123456m
    spaceAge Planet.Earth seconds |> should equal 260.16m
    spaceAge Planet.Neptune seconds |> should equal 1.58m