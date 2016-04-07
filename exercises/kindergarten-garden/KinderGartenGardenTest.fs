module KinderGartenGardenTest

open NUnit.Framework
open KinderGartenGarden

[<Test>]
let ``Missing child`` () =
    let garden = defaultGarden "RC\nGG"
    let actual = lookupPlants "Potter" garden
    Assert.That(actual, Is.Empty)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Alice`` () =
    Assert.That(defaultGarden "RC\nGG" |> lookupPlants "Alice", Is.EqualTo([Plant.Radishes; Plant.Clover; Plant.Grass; Plant.Grass]))
    Assert.That(defaultGarden "VC\nRC" |> lookupPlants "Alice", Is.EqualTo([Plant.Violets; Plant.Clover; Plant.Radishes; Plant.Clover]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Small garden`` () =
    let garden = defaultGarden "VVCG\nVVRC"
    Assert.That(lookupPlants "Bob" garden, Is.EqualTo([Plant.Clover; Plant.Grass; Plant.Radishes; Plant.Clover]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Medium garden`` () =
    let garden = defaultGarden "VVCCGG\nVVCCGG"
    Assert.That(lookupPlants "Bob" garden, Is.EqualTo([Plant.Clover; Plant.Clover; Plant.Clover; Plant.Clover]))
    Assert.That(lookupPlants "Charlie" garden, Is.EqualTo([Plant.Grass; Plant.Grass; Plant.Grass; Plant.Grass]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Full garden`` () =
    let garden = defaultGarden "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    Assert.That(lookupPlants "Alice" garden, Is.EqualTo([Plant.Violets; Plant.Radishes; Plant.Violets; Plant.Radishes]))
    Assert.That(lookupPlants "Alice" garden, Is.EqualTo([Plant.Violets; Plant.Radishes; Plant.Violets; Plant.Radishes]))
    Assert.That(lookupPlants "Bob" garden, Is.EqualTo([Plant.Clover; Plant.Grass; Plant.Clover; Plant.Clover]))
    Assert.That(lookupPlants "David" garden, Is.EqualTo([Plant.Radishes; Plant.Violets; Plant.Clover; Plant.Radishes]))
    Assert.That(lookupPlants "Eve" garden, Is.EqualTo([Plant.Clover; Plant.Grass; Plant.Radishes; Plant.Grass]))
    Assert.That(lookupPlants "Fred" garden, Is.EqualTo([Plant.Grass; Plant.Clover; Plant.Violets; Plant.Clover]))
    Assert.That(lookupPlants "Ginny" garden, Is.EqualTo([Plant.Clover; Plant.Grass; Plant.Grass; Plant.Clover]))
    Assert.That(lookupPlants "Harriet" garden, Is.EqualTo([Plant.Violets; Plant.Radishes; Plant.Radishes; Plant.Violets]))
    Assert.That(lookupPlants "Ileana" garden, Is.EqualTo([Plant.Grass; Plant.Clover; Plant.Violets; Plant.Clover]))
    Assert.That(lookupPlants "Joseph" garden, Is.EqualTo([Plant.Violets; Plant.Clover; Plant.Violets; Plant.Grass]))
    Assert.That(lookupPlants "Kincaid" garden, Is.EqualTo([Plant.Grass; Plant.Clover; Plant.Clover; Plant.Grass]))
    Assert.That(lookupPlants "Larry" garden, Is.EqualTo([Plant.Grass; Plant.Violets; Plant.Clover; Plant.Violets]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Surprise garden`` () =
    let garden = garden ["Samantha"; "Patricia"; "Xander"; "Roger"] "VCRRGVRG\nRVGCCGCV"
    Assert.That(lookupPlants "Patricia" garden, Is.EqualTo([Plant.Violets; Plant.Clover; Plant.Radishes; Plant.Violets]))
    Assert.That(lookupPlants "Roger" garden, Is.EqualTo([Plant.Radishes; Plant.Radishes; Plant.Grass; Plant.Clover]))
    Assert.That(lookupPlants "Samantha" garden, Is.EqualTo([Plant.Grass; Plant.Violets; Plant.Clover; Plant.Grass]))
    Assert.That(lookupPlants "Xander" garden, Is.EqualTo([Plant.Radishes; Plant.Grass; Plant.Clover; Plant.Violets]))