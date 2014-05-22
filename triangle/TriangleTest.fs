module TriangleTest

open NUnit.Framework
open Triangle

[<TestFixture>]
type TriangleTest() =

    [<Test>]
    member tests.Equilateral_triangles_have_equal_sides() =
        Assert.That(Triangle(2m, 2m, 2m).Kind(), Is.EqualTo(TriangleKind.Equilateral))

    [<Test>]
    [<Ignore>]
    member tests.Larger_equilateral_triangles_also_have_equal_sides() =
        Assert.That(Triangle(10m, 10m, 10m).Kind(), Is.EqualTo(TriangleKind.Equilateral))

    [<Test>]
    [<Ignore>]
    member tests.Isosceles_triangles_have_last_two_sides_equal() =
        Assert.That(Triangle(3m, 4m, 4m).Kind(), Is.EqualTo(TriangleKind.Isosceles))

    [<Test>]
    [<Ignore>]
    member tests.Isosceles_triangles_have_first_and_last_sides_equal() =
        Assert.That(Triangle(4m, 3m, 4m).Kind(), Is.EqualTo(TriangleKind.Isosceles))

    [<Test>]
    [<Ignore>]
    member tests.Isosceles_triangles_have_two_first_sides_equal() =
        Assert.That(Triangle(4m, 4m, 3m).Kind(), Is.EqualTo(TriangleKind.Isosceles))

    [<Test>]
    [<Ignore>]
    member tests.Isosceles_triangles_have_in_fact_exactly_two_sides_equal() =
        Assert.That(Triangle(10m, 10m, 3m).Kind(), Is.EqualTo(TriangleKind.Isosceles))

    [<Test>]
    [<Ignore>]
    member tests.Scalene_triangles_have_no_equal_sides() =
        Assert.That(Triangle(3m, 4m, 5m).Kind(), Is.EqualTo(TriangleKind.Scalene))

    [<Test>]
    [<Ignore>]
    member tests.Scalene_triangles_have_no_equal_sides_at_a_larger_scale_too() =
        Assert.That(Triangle(10m, 11m, 12m).Kind(), Is.EqualTo(TriangleKind.Scalene))

    [<Test>]
    [<Ignore>]
    member tests.Scalene_triangles_have_no_equal_sides_in_descending_order_either() =
        Assert.That(Triangle(5m, 4m, 2m).Kind(), Is.EqualTo(TriangleKind.Scalene))

    [<Test>]
    [<Ignore>]
    member tests.Very_small_triangles_are_legal() =
        Assert.That(Triangle(0.4m, 0.6m, 0.3m).Kind(), Is.EqualTo(TriangleKind.Scalene))

    [<Test>]
    [<Ignore>]
    member tests.Triangles_with_no_size_are_illegal() =
        Assert.Throws<System.InvalidOperationException>(fun () -> Triangle(0m, 0m, 0m).Kind() |> ignore) |> ignore

    [<Test>]
    [<Ignore>]
    member tests.Triangles_with_negative_sides_are_illegal() =
        Assert.Throws<System.InvalidOperationException>(fun () -> Triangle(3m, 4m, -5m).Kind() |> ignore) |> ignore

    [<Test>]
    [<Ignore>]
    member tests.Triangles_violating_triangle_inequality_are_illegal() =
        Assert.Throws<System.InvalidOperationException>(fun () -> Triangle(1m, 1m, 3m).Kind() |> ignore) |> ignore

    [<Test>]
    [<Ignore>]
    member tests.Triangles_violating_triangle_inequality_are_illegal_2() =
        Assert.Throws<System.InvalidOperationException>(fun () -> Triangle(2m, 4m, 2m).Kind() |> ignore) |> ignore

    [<Test>]
    [<Ignore>]
    member tests.Triangles_violating_triangle_inequality_are_illegal_3() =
        Assert.Throws<System.InvalidOperationException>(fun () -> Triangle(7m, 3m, 2m).Kind() |> ignore) |> ignore