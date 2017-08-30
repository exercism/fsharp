module KinderGartenGardenTest

open Xunit
open FsUnit.Xunit
open KinderGartenGarden

[<Fact>]
let ``Missing child`` () =
    let garden = defaultGarden "RC\nGG"
    let actual = lookupPlants "Potter" garden
    actual |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Alice`` () =
    defaultGarden "RC\nGG" |> lookupPlants "Alice" |> should equal [Plant.Radishes; Plant.Clover; Plant.Grass; Plant.Grass]
    defaultGarden "VC\nRC" |> lookupPlants "Alice" |> should equal [Plant.Violets; Plant.Clover; Plant.Radishes; Plant.Clover]
    
[<Fact(Skip = "Remove to run test")>]
let ``Small garden`` () =
    let garden = defaultGarden "VVCG\nVVRC"
    lookupPlants "Bob" garden |> should equal [Plant.Clover; Plant.Grass; Plant.Radishes; Plant.Clover]

[<Fact(Skip = "Remove to run test")>]
let ``Medium garden`` () =
    let garden = defaultGarden "VVCCGG\nVVCCGG"
    lookupPlants "Bob" garden |> should equal [Plant.Clover; Plant.Clover; Plant.Clover; Plant.Clover]
    lookupPlants "Charlie" garden |> should equal [Plant.Grass; Plant.Grass; Plant.Grass; Plant.Grass]

[<Fact(Skip = "Remove to run test")>]
let ``Full garden`` () =
    let garden = defaultGarden "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    lookupPlants "Alice" garden |> should equal [Plant.Violets; Plant.Radishes; Plant.Violets; Plant.Radishes]
    lookupPlants "Alice" garden |> should equal [Plant.Violets; Plant.Radishes; Plant.Violets; Plant.Radishes]
    lookupPlants "Bob" garden |> should equal [Plant.Clover; Plant.Grass; Plant.Clover; Plant.Clover]
    lookupPlants "David" garden |> should equal [Plant.Radishes; Plant.Violets; Plant.Clover; Plant.Radishes]
    lookupPlants "Eve" garden |> should equal [Plant.Clover; Plant.Grass; Plant.Radishes; Plant.Grass]
    lookupPlants "Fred" garden |> should equal [Plant.Grass; Plant.Clover; Plant.Violets; Plant.Clover]
    lookupPlants "Ginny" garden |> should equal [Plant.Clover; Plant.Grass; Plant.Grass; Plant.Clover]
    lookupPlants "Harriet" garden |> should equal [Plant.Violets; Plant.Radishes; Plant.Radishes; Plant.Violets]
    lookupPlants "Ileana" garden |> should equal [Plant.Grass; Plant.Clover; Plant.Violets; Plant.Clover]
    lookupPlants "Joseph" garden |> should equal [Plant.Violets; Plant.Clover; Plant.Violets; Plant.Grass]
    lookupPlants "Kincaid" garden |> should equal [Plant.Grass; Plant.Clover; Plant.Clover; Plant.Grass]
    lookupPlants "Larry" garden |> should equal [Plant.Grass; Plant.Violets; Plant.Clover; Plant.Violets]
    
[<Fact(Skip = "Remove to run test")>]
let ``Surprise garden`` () =
    let garden = garden ["Samantha"; "Patricia"; "Xander"; "Roger"] "VCRRGVRG\nRVGCCGCV"
    lookupPlants "Patricia" garden |> should equal [Plant.Violets; Plant.Clover; Plant.Radishes; Plant.Violets]
    lookupPlants "Roger" garden |> should equal [Plant.Radishes; Plant.Radishes; Plant.Grass; Plant.Clover]
    lookupPlants "Samantha" garden |> should equal [Plant.Grass; Plant.Violets; Plant.Clover; Plant.Grass]
    lookupPlants "Xander" garden |> should equal [Plant.Radishes; Plant.Grass; Plant.Clover; Plant.Violets]