module SpaceAgeTests

open NUnit.Framework
open SpaceAge

[<TestFixture>]
type SpaceAgeTest() =
    
    [<Test>]
    member tests.Age_in_seconds() =
        Assert.That(SpaceAge(1000000m).Seconds, Is.EqualTo(1000000))

    [<Test>]
    [<Ignore>]
    member tests.Age_on_earth() =
        Assert.That(SpaceAge(1000000000m).onEarth, Is.EqualTo(31.69))

    [<Test>]
    [<Ignore>]
    member tests.Age_on_mercury() =
        let spaceAge = SpaceAge(2134835688m)

        Assert.That(spaceAge.onEarth, Is.EqualTo(67.65))
        Assert.That(spaceAge.onMercury, Is.EqualTo(280.88))

    [<Test>]
    [<Ignore>]
    member tests.Age_on_venus() =
        let spaceAge = SpaceAge(189839836m)

        Assert.That(spaceAge.onEarth, Is.EqualTo(6.02))
        Assert.That(spaceAge.onVenus, Is.EqualTo(9.78))

    [<Test>]
    [<Ignore>]
    member tests.Age_on_mars() =
        let spaceAge = SpaceAge(2329871239m)

        Assert.That(spaceAge.onEarth, Is.EqualTo(73.83))
        Assert.That(spaceAge.onMars, Is.EqualTo(39.25))

    [<Test>]
    [<Ignore>]
    member tests.Age_on_jupiter() =
        let spaceAge = SpaceAge(901876382m)

        Assert.That(spaceAge.onEarth, Is.EqualTo(28.58))
        Assert.That(spaceAge.onJupiter, Is.EqualTo(2.41))

    [<Test>]
    [<Ignore>]
    member tests.Age_on_saturn() =
        let spaceAge = SpaceAge(3000000000m)

        Assert.That(spaceAge.onEarth, Is.EqualTo(95.06))
        Assert.That(spaceAge.onSaturn, Is.EqualTo(3.23))

    [<Test>]
    [<Ignore>]
    member tests.Age_on_uranus() =
        let spaceAge = SpaceAge(3210123456m)

        Assert.That(spaceAge.onEarth, Is.EqualTo(101.72))
        Assert.That(spaceAge.onUranus, Is.EqualTo(1.21))

    [<Test>]
    [<Ignore>]
    member tests.Age_on_neptune() =
        let spaceAge = SpaceAge(8210123456m)

        Assert.That(spaceAge.onEarth, Is.EqualTo(260.16))
        Assert.That(spaceAge.onNeptune, Is.EqualTo(1.58))