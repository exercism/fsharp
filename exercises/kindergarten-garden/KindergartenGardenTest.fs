// This file was auto-generated based on version 1.1.1 of the canonical data.

module KindergartenGardenTest

open FsUnit.Xunit
open Xunit

open KindergartenGarden

[<Fact>]
let ``Partial garden - garden with single student`` () =
    let student = "Alice"
    let diagram = "RC\nGG"
    let expected = [Plant.Radishes; Plant.Clover; Plant.Grass; Plant.Grass]
    plants diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Partial garden - different garden with single student`` () =
    let student = "Alice"
    let diagram = "VC\nRC"
    let expected = [Plant.Violets; Plant.Clover; Plant.Radishes; Plant.Clover]
    plants diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Partial garden - garden with two students`` () =
    let student = "Bob"
    let diagram = "VVCG\nVVRC"
    let expected = [Plant.Clover; Plant.Grass; Plant.Radishes; Plant.Clover]
    plants diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Partial garden - multiple students for the same garden with three students - second student's garden`` () =
    let student = "Bob"
    let diagram = "VVCCGG\nVVCCGG"
    let expected = [Plant.Clover; Plant.Clover; Plant.Clover; Plant.Clover]
    plants diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Partial garden - multiple students for the same garden with three students - third student's garden`` () =
    let student = "Charlie"
    let diagram = "VVCCGG\nVVCCGG"
    let expected = [Plant.Grass; Plant.Grass; Plant.Grass; Plant.Grass]
    plants diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Full garden - first student's garden`` () =
    let student = "Alice"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Violets; Plant.Radishes; Plant.Violets; Plant.Radishes]
    plants diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Full garden - second student's garden`` () =
    let student = "Bob"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Clover; Plant.Grass; Plant.Clover; Plant.Clover]
    plants diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Full garden - second to last student's garden`` () =
    let student = "Kincaid"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Grass; Plant.Clover; Plant.Clover; Plant.Grass]
    plants diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Full garden - last student's garden`` () =
    let student = "Larry"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Grass; Plant.Violets; Plant.Clover; Plant.Violets]
    plants diagram student |> should equal expected

