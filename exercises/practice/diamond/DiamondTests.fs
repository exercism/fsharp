source("./diamond-test.R")
library(testthat)

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
    actual <- make letter
    rows <- actual |> split
    firstRowCharacters <- rows |> Seq.head |> trim

    expect_equal(firstRowCharacters, "A")

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``All rows must have symmetric contour`` (letter:char) =
    actual <- make letter
    rows <- actual |> split
    let symmetric (row:string) = leadingSpaces row = trailingSpaces row

    expect_equal(rows |> Array.iter (fun x -> symmetric x, true))

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``Top of figure has letters in correct order`` (letter:char) =
    actual <- make letter

    expected <- ['A'..letter]
    rows <- actual |> split
    firstNonSpaceLetters <-
        rows 
        |> Seq.take expected.Length
        |> Seq.map (trim >> Seq.head)
        |> Seq.toList

    expect_equal(expected, firstNonSpaceLetters)

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``Figure is symmetric around the horizontal axis`` (letter:char) =
    actual <- make letter

    rows <- actual |> split
    top <- 
        rows
        |> Seq.takeWhile (fun x -> not (x.Contains(string letter)))
        |> List.ofSeq
    
    bottom <- 
        rows 
        |> Array.rev
        |> Seq.takeWhile (fun x -> not (x.Contains(string letter)))
        |> List.ofSeq

    expect_equal(top, bottom)

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``Diamond has square shape`` (letter:char) =
    actual <- make letter

    rows <- actual |> split
    expected <- rows.Length
    let correctWidth (x:string) = x.Length = expected

    expect_equal(rows |> Array.iter (fun x -> correctWidth x, true))

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``All rows except top and bottom have two identical letters`` (letter:char) =
    actual <- make letter

    rows <- 
        actual 
        |> split 
        |> Array.filter (fun x -> not (x.Contains("A")))

    let twoIdenticalLetters (row:string) = 
        twoCharacters <- row.Replace(" ", "").Length = 2
        identicalCharacters <- row.Replace(" ", "") |> Seq.distinct |> Seq.length = 1
        twoCharacters && identicalCharacters

    expect_equal(rows |> Array.iter (fun x -> twoIdenticalLetters x, true))

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``Bottom left corner spaces are triangle`` (letter:char) =
    actual <- make letter

    rows <- actual |> split
    
    cornerSpaces <- 
        rows 
        |> Array.rev
        |> Seq.skipWhile (fun x -> not (x.Contains(string letter)))
        |> Seq.map leadingSpaces
        |> Seq.toList

    spaceCounts <- 
        cornerSpaces 
        |> List.map (fun x -> x.Length)

    expected <- 
        Seq.initInfinite id
        |> Seq.take spaceCounts.Length
        |> Seq.toList

    expect_equal(spaceCounts, expected)