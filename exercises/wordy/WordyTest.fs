module WordyTest

open NUnit.Framework
open FsUnit
open Wordy

[<Test>]
let ``Can parse and solve addition problems`` () =
    solve "What is 1 plus 1?" |> should equal Some 2
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add double digit numbers`` () =
    solve "What is 53 plus 2?" |> should equal Some 55
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add negative numbers`` () =
    solve "What is -1 plus -10?" |> should equal Some -11
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add large numbers`` () =
    solve "What is 123 plus 45678?" |> should equal Some 45801
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can parse and solve subtraction problems`` () =
    solve "What is 4 minus -12?" |> should equal Some 16
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can parse and solve multiplication problems`` () =
    solve "What is -3 multiplied by 25?" |> should equal Some -75
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can parse and solve division problems`` () =
    solve "What is 33 divided by -3?" |> should equal Some -11
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add twice`` () =
    solve "What is 1 plus 1 plus 1?" |> should equal Some 3
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add then subtract`` () =
    solve "What is 1 plus 5 minus -2?" |> should equal Some 8
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can subtract twice`` () =
    solve "What is 20 minus 4 minus 13?" |> should equal Some 3
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can subtract then add`` () =
    solve "What is 17 minus 6 plus 3?" |> should equal Some 14
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can multiply twice`` () =
    solve "What is 2 multiplied by -2 multiplied by 3?" |> should equal Some -12
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add then multiply`` () =
    solve "What is -3 plus 7 multiplied by -2?" |> should equal Some -8
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can divide twice`` () =
    solve "What is -12 divided by 2 divided by -3?" |> should equal Some 2
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cubed is too advanced`` () =
    solve "What is 53 cubed?" |> should equal None
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Irrelevant problems are not valid`` () =
    solve "Who is the president of the United States?" |> should equal None
