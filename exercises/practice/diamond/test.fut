import "diamond"

let split (x: []u8) = x.Split([| '\n' |], StringSplitOptions.None)

let trim (x:string) = x.Trim()

let leading_spaces (x:string) = x.Substring(0, x.IndexOfAny [|'A'..'Z'|])

let trailing_spaces (x:string) = x.Substring(x.LastIndexOfAny [|'A'..'Z'|] + 1)

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
    let first_row_characters = rows |> Seq.head |> trim

    firstRowCharacters |> should equal "A"

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``All rows must have symmetric contour`` (letter:char) =
    let actual = make letter
    let rows = actual |> split
    let symmetric (row:string) = leadingSpaces row = trailingSpaces row

    rows |> Array.iter (fun x -> symmetric x |> should equal true)

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``Top of figure has letters in correct order`` (letter:char) =
    let actual = make letter

    let expected = ['A'..letter]
    let rows = actual |> split
    let first_non_space_letters =
        rows 
        |> Seq.take expected.Length
        |> Seq.map (trim >> Seq.head)
        |> Seq.toList

    expected |> should equal firstNonSpaceLetters

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
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

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``Diamond has square shape`` (letter:char) =
    let actual = make letter

    let rows = actual |> split
    let expected = rows.Length
    let correct_width (x:string) = x.Length = expected

    rows |> Array.iter (fun x -> correctWidth x |> should equal true)

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``All rows except top and bottom have two identical letters`` (letter:char) =
    let actual = make letter

    let rows = 
        actual 
        |> split 
        |> Array.filter (fun x -> not (x.Contains("A")))

    let two_identical_letters (row:string) = 
        let two_characters = row.Replace(" ", "").Length = 2
        let identical_characters = row.Replace(" ", "") |> Seq.distinct |> Seq.length = 1
        twoCharacters && identicalCharacters

    rows |> Array.iter (fun x -> twoIdenticalLetters x |> should equal true)

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
let ``Bottom left corner spaces are triangle`` (letter:char) =
    let actual = make letter

    let rows = actual |> split
    
    let corner_spaces = 
        rows 
        |> Array.rev
        |> Seq.skipWhile (fun x -> not (x.Contains(string letter)))
        |> Seq.map leadingSpaces
        |> Seq.toList

    let space_counts = 
        cornerSpaces 
        |> List.map (fun x -> x.Length)

    let expected = 
        Seq.initInfinite id
        |> Seq.take spaceCounts.Length
        |> Seq.toList

    spaceCounts |> should equal expected