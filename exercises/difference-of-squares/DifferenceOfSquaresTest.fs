module DifferenceOfSquaresTests

open NUnit.Framework
open DifferenceOfSquares

type DifferenceOfSquaresTests() =
    
    [<Test>]
    member test.Square_of_sums_to_5() =
        Assert.That(DifferenceOfSquares(5).squareOfSums(), Is.EqualTo(225))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member test.Sum_of_squares_to_5() =
        Assert.That(DifferenceOfSquares(5).sumOfSquares(), Is.EqualTo(55))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member test.Difference_of_sums_to_5() =
        Assert.That(DifferenceOfSquares(5).difference(), Is.EqualTo(170))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member test.Square_of_sums_to_10() =
        Assert.That(DifferenceOfSquares(10).squareOfSums(), Is.EqualTo(3025))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member test.Sum_of_squares_to_10() =
        Assert.That(DifferenceOfSquares(10).sumOfSquares(), Is.EqualTo(385))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member test.Difference_of_sums_to_10() =
        Assert.That(DifferenceOfSquares(10).difference(), Is.EqualTo(2640))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member test.Square_of_sums_to_100() =
        Assert.That(DifferenceOfSquares(100).squareOfSums(), Is.EqualTo(25502500))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member test.Sum_of_squares_to_100() =
        Assert.That(DifferenceOfSquares(100).sumOfSquares(), Is.EqualTo(338350))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member test.Difference_of_sums_to_100() =
        Assert.That(DifferenceOfSquares(100).difference(), Is.EqualTo(25164150))