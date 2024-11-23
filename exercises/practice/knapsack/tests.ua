module KnapsackTests

open FsUnit.Xunit
open Xunit

open Knapsack

[<Fact>]
let ``No items`` () =
    let items = []
    maximumValue items 100 |> should equal 0

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``One item, too heavy`` () =
    let items = [{ weight = 100; value = 1 }]
    maximumValue items 10 |> should equal 0

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Five items (cannot be greedy by weight)`` () =
    let items = 
        [ { weight = 2; value = 5 };
          { weight = 2; value = 5 };
          { weight = 2; value = 5 };
          { weight = 2; value = 5 };
          { weight = 10; value = 21 } ]
    maximumValue items 10 |> should equal 21

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Five items (cannot be greedy by value)`` () =
    let items = 
        [ { weight = 2; value = 20 };
          { weight = 2; value = 20 };
          { weight = 2; value = 20 };
          { weight = 2; value = 20 };
          { weight = 10; value = 50 } ]
    maximumValue items 10 |> should equal 80

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Example knapsack`` () =
    let items = 
        [ { weight = 5; value = 10 };
          { weight = 4; value = 40 };
          { weight = 6; value = 30 };
          { weight = 4; value = 50 } ]
    maximumValue items 10 |> should equal 90

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``8 items`` () =
    let items = 
        [ { weight = 25; value = 350 };
          { weight = 35; value = 400 };
          { weight = 45; value = 450 };
          { weight = 5; value = 20 };
          { weight = 25; value = 70 };
          { weight = 3; value = 8 };
          { weight = 2; value = 5 };
          { weight = 2; value = 5 } ]
    maximumValue items 104 |> should equal 900

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``15 items`` () =
    let items = 
        [ { weight = 70; value = 135 };
          { weight = 73; value = 139 };
          { weight = 77; value = 149 };
          { weight = 80; value = 150 };
          { weight = 82; value = 156 };
          { weight = 87; value = 163 };
          { weight = 90; value = 173 };
          { weight = 94; value = 184 };
          { weight = 98; value = 192 };
          { weight = 106; value = 201 };
          { weight = 110; value = 210 };
          { weight = 113; value = 214 };
          { weight = 115; value = 221 };
          { weight = 118; value = 229 };
          { weight = 120; value = 240 } ]
    maximumValue items 750 |> should equal 1458

