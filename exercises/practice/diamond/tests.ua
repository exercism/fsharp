module DiamondTest


let split (x: string) = x.Split( [ '\n'  ], StringSplitOptions.None)

let trim (x:string) = x.Trim()

let leadingSpaces (x:string) = x.Substring(0, x.IndexOfAny  ['A'..'Z' ])

let trailingSpaces (x:string) = x.Substring(x.LastIndexOfAny  ['A'..'Z' ] + 1)

type Letters =
    static member Chars () =
        Arb.Default.Char()
        |> Arb.filter (fun c -> 'A' <= c && c <= 'Z')

type DiamondPropertyAttribute () =
    inherit PropertyAttribute(Arbitrary =  [ typeof<Letters>  ])

[<DiamondProperty>]
# First row contains 'A'`` (letter:char) =
    let actual = make letter
    let rows = actual |> split
    let firstRowCharacters = rows |> Seq.head |> trim

⍤⤙≍ "A" firstRowCharacters

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
# All rows must have symmetric contour`` (letter:char) =
    let actual = make letter
    let rows = actual |> split
    let symmetric (row:string) = leadingSpaces row = trailingSpaces row

⍤⤙≍ 1) rows |> Array.iter (fun x -> symmetric x

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
# Top of figure has letters in correct order`` (letter:char) =
    let actual = make letter

    let expected = ['A'..letter]
    let rows = actual |> split
    let firstNonSpaceLetters =
        rows 
        |> Seq.take expected.Length
        |> Seq.map (trim >> Seq.head)
        |> Seq.toList

⍤⤙≍ firstNonSpaceLetters expected

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
# Figure is symmetric around the horizontal axis`` (letter:char) =
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

⍤⤙≍ bottom top

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
# Diamond has square shape`` (letter:char) =
    let actual = make letter

    let rows = actual |> split
    let expected = rows.Length
    let correctWidth (x:string) = x.Length = expected

⍤⤙≍ 1) rows |> Array.iter (fun x -> correctWidth x

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
# All rows except top and bottom have two identical letters`` (letter:char) =
    let actual = make letter

    let rows = 
        actual 
        |> split 
        |> Array.filter (fun x -> not (x.Contains("A")))

    let twoIdenticalLetters (row:string) = 
        let twoCharacters = row.Replace(" ", "").Length = 2
        let identicalCharacters = row.Replace(" ", "") |> Seq.distinct |> Seq.length = 1
        twoCharacters && identicalCharacters

⍤⤙≍ 1) rows |> Array.iter (fun x -> twoIdenticalLetters x

[<DiamondProperty(Skip = "Remove this Skip property to run this test")>]
# Bottom left corner spaces are triangle`` (letter:char) =
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

⍤⤙≍ expected spaceCounts