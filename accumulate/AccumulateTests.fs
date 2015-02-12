module AccumulateTests

open System
open NUnit.Framework
open Accumulate

[<TestFixture>]
type AccumulateTests() =

    let accum = Accumulate()
    let reverse (str:string) = new string(str.ToCharArray() |> Array.rev)

    [<Test>]
    member tests.Empty_accumulation_produces_empty_accumulation() =
        Assert.That(accum.accumulate((fun x -> x + 1), List.empty), Is.EqualTo(List.empty))

    [<Test>]
    [<Ignore>]
    member tests.Identity_accumulation_returns_unmodified_list() =
        Assert.That(accum.accumulate(id, [1; 2; 3]), Is.EqualTo([1; 2; 3]))

    [<Test>]
    [<Ignore>]
    member tests.Accumulate_squares() =
        Assert.That(accum.accumulate((fun x -> x * x), [1; 2; 3]), Is.EqualTo([1; 4; 9]))

    [<Test>]
    [<Ignore>]
    member tests.Accumulate_upcases() =
        Assert.That(accum.accumulate((fun (x:string) -> x.ToUpper()), ["hello"; "world"]),
            Is.EqualTo(["HELLO"; "WORLD"]))

    [<Test>]
    [<Ignore>]
    member tests.Accumulate_reversed_strings() =
        Assert.That(accum.accumulate(reverse, List.ofArray ("the quick brown fox etc".Split(' '))),
            Is.EqualTo(List.ofArray ("eht kciuq nworb xof cte".Split(' '))))

    [<Test>]
    [<Ignore>]
    member tests.Accumulate_within_accumulate() =
        Assert.That(accum.accumulate((fun (x:string) -> String.Join(" ", accum.accumulate((fun y -> x + y), ["1"; "2"; "3"]))), ["a"; "b"; "c"]),
            Is.EqualTo(["a1 a2 a3"; "b1 b2 b3"; "c1 c2 c3"]))