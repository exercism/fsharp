// This file was created manually and its version is 1.0.0.

module StrainTest


let ``Empty keep`` () =
    [] |> Seq.keep (fun x -> x < 10) |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]  
let ``Keep everything`` () =
    set [1; 2; 3] |> Seq.keep (fun x -> x < 10) |> Seq.toList |> should equal <| [1; 2; 3]

[<Fact(Skip = "Remove this Skip property to run this test")>] 
let ``Keep first and last`` () =
    [|1; 2; 3|] |> Seq.keep (fun x -> x % 2 <> 0) |> Seq.toList |> should equal [1; 3]

let ``Keep neither first nor last`` () =
    [1; 2; 3; 4; 5] |> Seq.keep (fun x -> x % 2 = 0) |> Seq.toList |> should equal [2; 4]

let ``Keep strings`` () =
    let words = "apple zebra banana zombies cherimoya zelot".Split(' ');
    words |> Seq.keep (fun (x:string) -> x.StartsWith("z")) |> Seq.toList |> should equal <| List.ofArray("zebra zombies zelot".Split(' '))

let ``Keep arrays`` () =
    let actual = [|
                    [|1; 2; 3|];
                    [|5; 5; 5|];
                    [|5; 1; 2|];
                    [|2; 1; 2|];
                    [|1; 5; 2|];
                    [|2; 2; 1|];
                    [|1; 2; 5|]
                    |]
    let expected = [ [|5; 5; 5|]; [|5; 1; 2|]; [|1; 5; 2|]; [|1; 2; 5|] ]
    actual |> Seq.keep (Array.exists ((=) 5)) |> Seq.toList |> should equal expected

let ``Empty discard`` () =
    [] |> Seq.discard (fun x -> x < 10) |> should be Empty

let ``Discard nothing`` () =
    set [1; 2; 3] |> Seq.discard (fun x -> x > 10) |> Seq.toList |> should equal <| [1; 2; 3]

let ``Discard first and last`` () =
    [|1; 2; 3|] |> Seq.discard (fun x -> x % 2 <> 0) |> Seq.toList |> should equal [2]

let ``Discard neither first nor last`` () =
    [1; 2; 3; 4; 5] |> Seq.discard (fun x -> x % 2 = 0) |> Seq.toList |> should equal [1; 3; 5]

let ``Discard strings`` () =
    let words = "apple zebra banana zombies cherimoya zelot".Split(' ')
    words |> Seq.discard (fun (x:string) -> x.StartsWith("z")) |> Seq.toList |> should equal <| List.ofArray("apple banana cherimoya".Split(' '))

let ``Discard arrays`` () =
    let actual = [|
                    [|1; 2; 3|];
                    [|5; 5; 5|];
                    [|5; 1; 2|];
                    [|2; 1; 2|];
                    [|1; 5; 2|];
                    [|2; 2; 1|];
                    [|1; 2; 5|]
                    |]
    let expected = [ [|1; 2; 3|]; [|2; 1; 2|]; [|2; 2; 1|] ]
    actual |> Seq.discard (Array.exists ((=) 5)) |> Seq.toList |> should equal expected