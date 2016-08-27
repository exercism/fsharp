module SpaceAgeTest

open NUnit.Framework
open SpaceAge
    
[<Test>]
let ``Age on earth`` () =
    let seconds = 1000000000m
    Assert.That(spaceAge Planet.Earth seconds, Is.EqualTo(31.69m))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Age on mercury`` () =
    let seconds = 2134835688m
    Assert.That(spaceAge Planet.Earth seconds, Is.EqualTo(67.65m))
    Assert.That(spaceAge Planet.Mercury seconds, Is.EqualTo(280.88m))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Age on venus`` () =
    let seconds = 189839836m
    Assert.That(spaceAge Planet.Earth seconds, Is.EqualTo(6.02m))
    Assert.That(spaceAge Planet.Venus seconds, Is.EqualTo(9.78m))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Age on mars`` () =
    let seconds = 2329871239m
    Assert.That(spaceAge Planet.Earth seconds, Is.EqualTo(73.83m))
    Assert.That(spaceAge Planet.Mars seconds, Is.EqualTo(39.25m))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Age on jupiter`` () =
    let seconds = 901876382m
    Assert.That(spaceAge Planet.Earth seconds, Is.EqualTo(28.58m))
    Assert.That(spaceAge Planet.Jupiter seconds, Is.EqualTo(2.41m))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Age on saturn`` () =
    let seconds = 3000000000m
    Assert.That(spaceAge Planet.Earth seconds, Is.EqualTo(95.06m))
    Assert.That(spaceAge Planet.Saturn seconds, Is.EqualTo(3.23m))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Age on uranus`` () =
    let seconds = 3210123456m
    Assert.That(spaceAge Planet.Earth seconds, Is.EqualTo(101.72m))
    Assert.That(spaceAge Planet.Uranus seconds, Is.EqualTo(1.21m))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Age on neptune`` () =
    let seconds = 8210123456m
    Assert.That(spaceAge Planet.Earth seconds, Is.EqualTo(260.16m))
    Assert.That(spaceAge Planet.Neptune seconds, Is.EqualTo(1.58m))