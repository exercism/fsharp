module TriangleTest

open NUnit.Framework
open Triangle
open System

[<Test>]
let ``Equilateral triangles have equal sides`` () =
    Assert.That(kind 2m 2m 2m, Is.EqualTo(TriangleKind.Equilateral))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Larger equilateral triangles also have equal sides`` () =
    Assert.That(kind 10m 10m 10m, Is.EqualTo(TriangleKind.Equilateral))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Isosceles triangles have last two sides equal`` () =
    Assert.That(kind 3m 4m 4m, Is.EqualTo(TriangleKind.Isosceles))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Isosceles triangles have first and last sides equal`` () =
    Assert.That(kind 4m 3m 4m, Is.EqualTo(TriangleKind.Isosceles))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Isosceles triangles have two first sides equal`` () =
    Assert.That(kind 4m 4m 3m, Is.EqualTo(TriangleKind.Isosceles))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Isosceles triangles have in fact exactly two sides equal`` () =
    Assert.That(kind 10m 10m 3m, Is.EqualTo(TriangleKind.Isosceles))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scalene triangles have no equal sides`` () =
    Assert.That(kind 3m 4m 5m, Is.EqualTo(TriangleKind.Scalene))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scalene triangles have no equal sides at a larger scale too`` () =
    Assert.That(kind 10m 11m 12m, Is.EqualTo(TriangleKind.Scalene))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scalene triangles have no equal sides in descending order either`` () =
    Assert.That(kind 5m 4m 2m, Is.EqualTo(TriangleKind.Scalene))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Very small triangles are legal`` () =
    Assert.That(kind 0.4m 0.6m 0.3m, Is.EqualTo(TriangleKind.Scalene))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Triangles with no size are illegal`` () =
    Assert.That((fun () -> kind 0m 0m 0m |> ignore), Throws.InvalidOperationException)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Triangles with negative sides are illegal`` () =
    Assert.That((fun () -> kind 3m 4m -5m |> ignore), Throws.InvalidOperationException)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Triangles violating triangle inequality are illegal`` () =
    Assert.That((fun () -> kind 1m 1m 3m |> ignore), Throws.InvalidOperationException)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Triangles violating triangle inequality are illegal 2`` () =
    Assert.That((fun () -> kind 2m 4m 2m |> ignore), Throws.InvalidOperationException)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Triangles violating triangle inequality are illegal 3`` () =
    Assert.That((fun () -> kind 7m 3m 2m |> ignore), Throws.InvalidOperationException)