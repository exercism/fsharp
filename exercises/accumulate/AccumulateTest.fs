module AccumulateTest

open System
open NUnit.Framework
open Accumulate

let reverse (str:string) = new string(str.ToCharArray() |> Array.rev)

[<Test>]
let ``Empty accumulation produces empty accumulation`` () =
    Assert.That(accumulate (fun x -> x + 1) List.empty, Is.EqualTo(List.empty))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Identity accumulation returns unmodified list`` () =
    Assert.That(accumulate id [1; 2; 3], Is.EqualTo([1; 2; 3]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Accumulate squares`` () =
    Assert.That(accumulate (fun x -> x * x) [1; 2; 3], Is.EqualTo([1; 4; 9]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Accumulate upcases`` () =
    Assert.That(accumulate (fun (x:string) -> x.ToUpper()) ["hello"; "world"],
        Is.EqualTo(["HELLO"; "WORLD"]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Accumulate reversed strings`` () =
    Assert.That(accumulate reverse (List.ofArray ("the quick brown fox etc".Split(' '))),
        Is.EqualTo(List.ofArray ("eht kciuq nworb xof cte".Split(' '))))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Accumulate within accumulate`` () =
    Assert.That(accumulate (fun (x:string) -> String.Join(" ", accumulate (fun y -> x + y) ["1"; "2"; "3"])) ["a"; "b"; "c"],
        Is.EqualTo(["a1 a2 a3"; "b1 b2 b3"; "c1 c2 c3"]))