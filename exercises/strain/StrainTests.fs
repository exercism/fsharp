module StrainTests

open System.Collections.Specialized
open NUnit.Framework

type StrainTests() =
    [<Test>]
    member tests.Empty_keep() =
        Assert.That([] |> Seq.keep (fun x -> x < 10), Is.EqualTo([]))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Keep_everything() =
        Assert.That(set [1; 2; 3] |> Seq.keep (fun x -> x < 10), Is.EqualTo(set [1; 2; 3]))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Keep_first_and_last() =
        Assert.That([|1; 2; 3|] |> Seq.keep (fun x -> x % 2 <> 0), Is.EqualTo([|1; 3|]))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Keep_neither_first_nor_last() =
        Assert.That([1; 2; 3; 4; 5] |> Seq.keep (fun x -> x % 2 = 0), Is.EqualTo([2; 4]))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Keep_strings() =
        let words = "apple zebra banana zombies cherimoya zelot".Split(' ');
        Assert.That(words |> Seq.keep (fun (x:string) -> x.StartsWith("z")), Is.EqualTo("zebra zombies zelot".Split(' ')))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Keep_arrays() =
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
    member tests.Empty_discard() =
        Assert.That([] |> Seq.discard (fun x -> x < 10), Is.EqualTo([]))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Discard_nothing() =
        Assert.That(set [1; 2; 3] |> Seq.discard (fun x -> x > 10), Is.EqualTo(set [1; 2; 3]))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Discard_first_and_last() =
        Assert.That([|1; 2; 3|] |> Seq.discard (fun x -> x % 2 <> 0), Is.EqualTo([|2|]))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Discard_neither_first_nor_last() =
        Assert.That([1; 2; 3; 4; 5] |> Seq.discard (fun x -> x % 2 = 0), Is.EqualTo([1; 3; 5]))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Discard_strings() =
        let words = "apple zebra banana zombies cherimoya zelot".Split(' ')
        Assert.That(words |> Seq.discard (fun (x:string) -> x.StartsWith("z")), Is.EqualTo("apple banana cherimoya".Split(' ')))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Discard_arrays() =
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