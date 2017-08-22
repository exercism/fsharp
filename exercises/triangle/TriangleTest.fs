module TriangleTest

open NUnit.Framework
open FsUnit
open Triangle
open System

[<Test>]
let ``Equilateral triangles have equal sides`` () =
    kind 2m 2m 2m |> should equal TriangleKind.Equilateral

[<Test>]
[<Ignore("Remove to run test")>]
let ``Larger equilateral triangles also have equal sides`` () =
    kind 10m 10m 10m |> should equal TriangleKind.Equilateral

[<Test>]
[<Ignore("Remove to run test")>]
let ``Isosceles triangles have last two sides equal`` () =
    kind 3m 4m 4m |> should equal TriangleKind.Isosceles

[<Test>]
[<Ignore("Remove to run test")>]
let ``Isosceles triangles have first and last sides equal`` () =
    kind 4m 3m 4m |> should equal TriangleKind.Isosceles

[<Test>]
[<Ignore("Remove to run test")>]
let ``Isosceles triangles have two first sides equal`` () =
    kind 4m 4m 3m |> should equal TriangleKind.Isosceles

[<Test>]
[<Ignore("Remove to run test")>]
let ``Isosceles triangles have in fact exactly two sides equal`` () =
    kind 10m 10m 3m |> should equal TriangleKind.Isosceles

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scalene triangles have no equal sides`` () =
    kind 3m 4m 5m |> should equal TriangleKind.Scalene

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scalene triangles have no equal sides at a larger scale too`` () =
    kind 10m 11m 12m |> should equal TriangleKind.Scalene

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scalene triangles have no equal sides in descending order either`` () =
    kind 5m 4m 2m |> should equal TriangleKind.Scalene

[<Test>]
[<Ignore("Remove to run test")>]
let ``Very small triangles are legal`` () =
    kind 0.4m 0.6m 0.3m |> should equal TriangleKind.Scalene

[<Test>]
[<Ignore("Remove to run test")>]
let ``Triangles with no size are illegal`` () =
    (fun () -> kind 0m 0m 0m |> ignore) |> should throw typeof<InvalidOperationException>

[<Test>]
[<Ignore("Remove to run test")>]
let ``Triangles with negative sides are illegal`` () =
    (fun () -> kind 3m 4m -5m |> ignore) |> should throw typeof<InvalidOperationException>

[<Test>]
[<Ignore("Remove to run test")>]
let ``Triangles violating triangle inequality are illegal`` () =
    (fun () -> kind 1m 1m 3m |> ignore) |> should throw typeof<InvalidOperationException>

[<Test>]
[<Ignore("Remove to run test")>]
let ``Triangles violating triangle inequality are illegal 3`` () =
    (fun () -> kind 7m 3m 2m |> ignore) |> should throw typeof<InvalidOperationException>