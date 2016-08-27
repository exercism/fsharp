module StrainTest

open System.Collections.Specialized
open NUnit.Framework

// Note: to add your own functions to an existing module, just put your 
// functions in a module matching the existing module name. Your code
// should thus look something like this:

// module Seq
//
// let keep pred xs = ???
// let discard pred xs = ???

[<Test>]
let ``Empty keep`` () =
    Assert.That([] |> Seq.keep (fun x -> x < 10), Is.EqualTo([]))

[<Test>]
[<Ignore("Remove to run test")>]  
let ``Keep everything`` () =
    Assert.That(set [1; 2; 3] |> Seq.keep (fun x -> x < 10), Is.EqualTo(set [1; 2; 3]))

[<Test>]
[<Ignore("Remove to run test")>] 
let ``Keep first and last`` () =
    Assert.That([|1; 2; 3|] |> Seq.keep (fun x -> x % 2 <> 0), Is.EqualTo([|1; 3|]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Keep neither first nor last`` () =
    Assert.That([1; 2; 3; 4; 5] |> Seq.keep (fun x -> x % 2 = 0), Is.EqualTo([2; 4]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Keep strings`` () =
    let words = "apple zebra banana zombies cherimoya zelot".Split(' ');
    Assert.That(words |> Seq.keep (fun (x:string) -> x.StartsWith("z")), Is.EqualTo("zebra zombies zelot".Split(' ')))

[<Test>]
[<Ignore("Remove to run test")>]
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
    let expected = [| [|5; 5; 5|]; [|5; 1; 2|]; [|1; 5; 2|]; [|1; 2; 5|] |]
    Assert.That(actual |> Seq.keep (Array.exists ((=) 5)), Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty discard`` () =
    Assert.That([] |> Seq.discard (fun x -> x < 10), Is.EqualTo([]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Discard nothing`` () =
    Assert.That(set [1; 2; 3] |> Seq.discard (fun x -> x > 10), Is.EqualTo(set [1; 2; 3]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Discard first and last`` () =
    Assert.That([|1; 2; 3|] |> Seq.discard (fun x -> x % 2 <> 0), Is.EqualTo([|2|]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Discard neither first nor last`` () =
    Assert.That([1; 2; 3; 4; 5] |> Seq.discard (fun x -> x % 2 = 0), Is.EqualTo([1; 3; 5]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Discard strings`` () =
    let words = "apple zebra banana zombies cherimoya zelot".Split(' ')
    Assert.That(words |> Seq.discard (fun (x:string) -> x.StartsWith("z")), Is.EqualTo("apple banana cherimoya".Split(' ')))

[<Test>]
[<Ignore("Remove to run test")>]
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
    let expected = [| [|1; 2; 3|]; [|2; 1; 2|]; [|2; 2; 1|] |]
    Assert.That(actual |> Seq.discard (Array.exists ((=) 5)), Is.EqualTo(expected))