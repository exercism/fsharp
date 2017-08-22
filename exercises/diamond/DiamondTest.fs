module DiamondTest

open Diamond
open System
open NUnit.Framework
open FsUnit

type DiamondTest() =
    let split (x: string) = x.Split([| '\n' |], StringSplitOptions.None)

    let trim (x:string) = x.Trim()

    let leadingSpaces (x:string) = x.Substring(0, x.IndexOfAny [|'A'..'Z'|])

    let trailingSpaces (x:string) = x.Substring(x.LastIndexOfAny [|'A'..'Z'|] + 1)

    [<TestCaseSource("Letters")>]
    member this.``First row contains 'A'`` (letter:char) =
        let actual = make letter
        let rows = actual |> split
        let firstRowCharacters = rows |> Seq.head |> trim
    
        firstRowCharacters |> should equal "A"

    [<TestCaseSource("Letters")>]
    [<Ignore("Remove to run test")>]
    member this.``All rows must have symmetric contour`` (letter:char) =
        let actual = make letter
        let rows = actual |> split
        let symmetric (row:string) = leadingSpaces row = trailingSpaces row

        rows |> Array.forall (should be symmetric)

    [<TestCaseSource("Letters")>]
    [<Ignore("Remove to run test")>]
    member this.``Top of figure has letters in correct order`` (letter:char) =
        let actual = make letter

        let expected = ['A'..letter]
        let rows = actual |> split
        let firstNonSpaceLetters =
            rows 
            |> Seq.take expected.Length
            |> Seq.map trim
            |> Seq.map Seq.head
            |> Seq.toList

        expected |> should equal firstNonSpaceLetters

    [<TestCaseSource("Letters")>]
    [<Ignore("Remove to run test")>]
    member this.``Figure is symmetric around the horizontal axis`` (letter:char) =
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
    
    [<TestCaseSource("Letters")>]
    [<Ignore("Remove to run test")>]
    member this.``Diamond has square shape`` (letter:char) =
        let actual = make letter

        let rows = actual |> split
        let expected = rows.Length
        let correctWidth (x:string) = x.Length = expected

        rows |> Array.forall (should be correctWidth)

    [<TestCaseSource("Letters")>]
    [<Ignore("Remove to run test")>]
    member this.``All rows except top and bottom have two identical letters`` (letter:char) =
        let actual = make letter

        let rows = 
            actual 
            |> split 
            |> Array.filter (fun x -> not (x.Contains("A")))

        let twoIdenticalLetters (row:string) = 
            let twoCharacters = row.Replace(" ", "").Length = 2
            let identicalCharacters = row.Replace(" ", "") |> Seq.distinct |> Seq.length = 1
            twoCharacters && identicalCharacters

        rows |> Array.forall (should be twoIdenticalLetters)

    [<TestCaseSource("Letters")>]    
    [<Ignore("Remove to run test")>]
    member this.``Bottom left corner spaces are triangle`` (letter:char) =
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

    static member Letters = [| 'A' .. 'Z' |]