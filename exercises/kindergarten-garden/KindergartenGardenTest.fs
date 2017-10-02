// This file was auto-generated based on version 1.0.0 of the canonical data.

module KindergartenGardenTest

open FsUnit.Xunit
open Xunit

open KindergartenGarden

[<Fact>]
let ``Partial garden - garden with single student`` () =
    let student = "Alice"
    let diagram = "RC\nGG"
    let expected = [Plant.Radishes; Plant.Clover; Plant.Grass; Plant.Grass]
    plantsForDefaultStudents diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Partial garden - different garden with single student`` () =
    let student = "Alice"
    let diagram = "VC\nRC"
    let expected = [Plant.Violets; Plant.Clover; Plant.Radishes; Plant.Clover]
    plantsForDefaultStudents diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Partial garden - garden with two students`` () =
    let student = "Bob"
    let diagram = "VVCG\nVVRC"
    let expected = [Plant.Clover; Plant.Grass; Plant.Radishes; Plant.Clover]
    plantsForDefaultStudents diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Partial garden - multiple students for the same garden with three students - second student's garden`` () =
    let student = "Bob"
    let diagram = "VVCCGG\nVVCCGG"
    let expected = [Plant.Clover; Plant.Clover; Plant.Clover; Plant.Clover]
    plantsForDefaultStudents diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Partial garden - multiple students for the same garden with three students - third student's garden`` () =
    let student = "Charlie"
    let diagram = "VVCCGG\nVVCCGG"
    let expected = [Plant.Grass; Plant.Grass; Plant.Grass; Plant.Grass]
    plantsForDefaultStudents diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Full garden - first student's garden`` () =
    let student = "Alice"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Violets; Plant.Radishes; Plant.Violets; Plant.Radishes]
    plantsForDefaultStudents diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Full garden - second student's garden`` () =
    let student = "Bob"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Clover; Plant.Grass; Plant.Clover; Plant.Clover]
    plantsForDefaultStudents diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Full garden - second to last student's garden`` () =
    let student = "Kincaid"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Grass; Plant.Clover; Plant.Clover; Plant.Grass]
    plantsForDefaultStudents diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Full garden - last student's garden`` () =
    let student = "Larry"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Grass; Plant.Violets; Plant.Clover; Plant.Violets]
    plantsForDefaultStudents diagram student |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Non-alphabetical student list - first student's garden`` () =
    let student = "Patricia"
    let students = ["Samantha"; "Patricia"; "Xander"; "Roger"]
    let diagram = "VCRRGVRG\nRVGCCGCV"
    let expected = [Plant.Violets; Plant.Clover; Plant.Radishes; Plant.Violets]
    plantsForCustomStudents diagram student students |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Non-alphabetical student list - second student's garden`` () =
    let student = "Roger"
    let students = ["Samantha"; "Patricia"; "Xander"; "Roger"]
    let diagram = "VCRRGVRG\nRVGCCGCV"
    let expected = [Plant.Radishes; Plant.Radishes; Plant.Grass; Plant.Clover]
    plantsForCustomStudents diagram student students |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Non-alphabetical student list - third student's garden`` () =
    let student = "Samantha"
    let students = ["Samantha"; "Patricia"; "Xander"; "Roger"]
    let diagram = "VCRRGVRG\nRVGCCGCV"
    let expected = [Plant.Grass; Plant.Violets; Plant.Clover; Plant.Grass]
    plantsForCustomStudents diagram student students |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Non-alphabetical student list - fourth (last) student's garden`` () =
    let student = "Xander"
    let students = ["Samantha"; "Patricia"; "Xander"; "Roger"]
    let diagram = "VCRRGVRG\nRVGCCGCV"
    let expected = [Plant.Radishes; Plant.Grass; Plant.Clover; Plant.Violets]
    plantsForCustomStudents diagram student students |> should equal expected

