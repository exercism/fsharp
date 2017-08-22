module PascalsTriangleTest

open NUnit.Framework
open FsUnit

open PascalsTriangle

[<Test>]
let ``One row`` () =
    triangle 1 |> should equal [[1]]
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Two rows`` () =
    triangle 2 |> should equal [[1]; [1; 1]]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Three rows`` () =
    triangle 3 |> should equal [[1]; [1; 1]; [1; 2; 1]]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Four rows`` () =
    triangle 4 |> should equal [[1]; [1; 1]; [1; 2; 1]; [1; 3; 3; 1]]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Five rows`` () =
    triangle 5 |> should equal [[1]; [1; 1]; [1; 2; 1]; [1; 3; 3; 1]; [1; 4; 6; 4; 1]]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Twenty rows`` () =
    triangle 20 |> List.last |> should equal [1; 19; 171; 969; 3876; 11628; 27132; 50388; 75582; 92378; 92378; 75582; 50388; 27132; 11628; 3876; 969; 171; 19; 1]