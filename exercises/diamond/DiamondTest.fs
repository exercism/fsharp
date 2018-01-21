// This file was created manually and its version is 1.0.0.

module DiamondTest

open Diamond
open System
open FsUnit.Xunit
open Xunit
open FsCheck
open FsCheck.Xunit

let split (x: string) = x.Split([| '\n' |], StringSplitOptions.None)

let trim (x:string) = x.Trim()

let leadingSpaces (x:string) = x.Substring(0, x.IndexOfAny [|'A'..'Z'|])

let trailingSpaces (x:string) = x.Substring(x.LastIndexOfAny [|'A'..'Z'|] + 1)

type Letters =
    static member Chars () =
        Arb.Default.Char()
        |> Arb.filter (fun c -> 'A' <= c && c <= 'Z')

type DiamondPropertyAttribute () =
    inherit PropertyAttribute(Arbitrary = [| typeof<Letters> |])

[<DiamondProperty>]
let ``First row contains 'A'`` (letter:char) =
    let actual = make letter
    let rows = actual |> split
    let firstRowCharacters = rows |> Seq.head |> trim

    firstRowCharacters |> should equal "A"

[<DiamondProperty(Skip = "Remove to run test")>]
let ``All rows must have symmetric contour`` (letter:char) =
    let actual = make letter
    let rows = actual |> split
    let symmetric (row:string) = leadingSpaces row = trailingSpaces row

    rows |> Array.iter (fun x -> symmetric x |> should equal true)

[<DiamondProperty(Skip = "Remove to run test")>]
let ``Top of figure has letters in correct order`` (letter:char) =
    let actual = make letter

    let expected = ['A'..letter]
    let rows = actual |> split
    let firstNonSpaceLetters =
        rows 
        |> Seq.take expected.Length
        |> Seq.map (trim >> Seq.head)
        |> Seq.toList

    expected |> should equal firstNonSpaceLetters

[<DiamondProperty(Skip = "Remove to run test")>]
let ``Figure is symmetric around the horizontal axis`` (letter:char) =
    let actual = make letter

    let rows = actual |> split
    let top = 
        rows
        |> Seq.takeWhile (fun x -> not (x.Contains(string letter)))
        |> List.ofSeq
    
    let bottom = 
        rows 
        |> Array.rev
        |> Seq.takeWhile (fun x -> not (x.Contains(string letter)))
        |> List.ofSeq

    top |> should equal bottom

[<DiamondProperty(Skip = "Remove to run test")>]
let ``Diamond has square shape`` (letter:char) =
    let actual = make letter

    let rows = actual |> split
    let expected = rows.Length
    let correctWidth (x:string) = x.Length = expected

    rows |> Array.iter (fun x -> correctWidth x |> should equal true)

[<DiamondProperty(Skip = "Remove to run test")>]
let ``All rows except top and bottom have two identical letters`` (letter:char) =
    let actual = make letter

    let rows = 
        actual 
        |> split 
        |> Array.filter (fun x -> not (x.Contains("A")))

    let twoIdenticalLetters (row:string) = 
        let twoCharacters = row.Replace(" ", "").Length = 2
        let identicalCharacters = row.Replace(" ", "") |> Seq.distinct |> Seq.length = 1
        twoCharacters && identicalCharacters

    rows |> Array.iter (fun x -> twoIdenticalLetters x |> should equal true)

[<DiamondProperty(Skip = "Remove to run test")>]
let ``Bottom left corner spaces are triangle`` (letter:char) =
    let actual = make letter

    let rows = actual |> split
    
    let cornerSpaces = 
        rows 
        |> Array.rev
        |> Seq.skipWhile (fun x -> not (x.Contains(string letter)))
        |> Seq.map leadingSpaces
        |> Seq.toList

    let spaceCounts = 
        cornerSpaces 
        |> List.map (fun x -> x.Length)

    let expected = 
        Seq.initInfinite id
        |> Seq.take spaceCounts.Length
        |> Seq.toList

    spaceCounts |> should equal expected