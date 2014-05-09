module SumOfMultiplesTest

open NUnit.Framework
open SumOfMultiples

[<TestFixture>]
type SumOfMultiplesTest() =
    let mutable sumOfMultiples = SumOfMultiples()
    
    [<Test>]
    member tc.Sum_to_1() = 
        Assert.That(sumOfMultiples.To(0), Is.EqualTo(0))

    [<Test>]
    [<Ignore>]
    member tc.Sum_to_3() = 
        Assert.That(sumOfMultiples.To(3), Is.EqualTo(0))

    [<Test>]
    [<Ignore>]
    member tc.Sum_to_10() = 
        Assert.That(sumOfMultiples.To(10), Is.EqualTo(23))

    [<Test>]
    [<Ignore>]
    member tc.Configurable_7_13_17_to_20() = 
        Assert.That(SumOfMultiples([7; 13; 17]).To(20), Is.EqualTo(51))

    [<Test>]
    [<Ignore>]
    member tc.Configurable_43_47_to_10000() = 
        Assert.That(SumOfMultiples([43; 47]).To(10000), Is.EqualTo(2203160))