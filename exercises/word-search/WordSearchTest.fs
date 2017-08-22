module WordSearchTest

open NUnit.Framework
open FsUnit

open WordSearch

let puzzle = 
    ["jefblpepre";
     "camdcimgtc";
     "oivokprjsm";
     "pbwasqroua";
     "rixilelhrs";
     "wolcqlirpc";
     "screeaumgr";
     "alxhpburyi";
     "jalaycalmp";
     "clojurermt"]

[<Test>]
let ``Should find horizontal words written left-to-right`` () =
    let actual = find puzzle "clojure"
    actual |> should equal Some ((1, 10), (7, 10))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should find horizontal words written right-to-left`` () =
    let actual = find puzzle "elixir"
    actual |> should equal Some ((6, 5), (1, 5))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should find vertical words written top-to-bottom`` () =
    let actual = find puzzle "ecmascript"
    actual |> should equal Some ((10, 1), (10, 10))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should find vertical words written bottom-to-top`` () =
    let actual = find puzzle "rust"
    actual |> should equal Some ((9, 5), (9, 2))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should find diagonal words written top-left-to-bottom-right`` () =
    let actual = find puzzle "java"
    actual |> should equal Some ((1, 1), (4, 4))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should find diagonal upper written bottom-right-to-top-left`` () =
    let actual = find puzzle "lua"
    actual |> should equal Some ((8, 9), (6, 7))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should find diagonal upper written bottom-left-to-top-right`` () =
    let actual = find puzzle "lisp"
    actual |> should equal Some ((3, 6), (6, 3))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should find diagonal upper written top-right-to-bottom-left`` () =
    let actual = find puzzle "ruby"    
    actual |> should equal Some ((8, 6), (5, 9))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should not find words that are not in the puzzle`` () =
    let actual = find puzzle "haskell"
    actual |> should equal None

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should be able to search differently-sized puzzles`` () =
    let differentSizePuzzle =
        ["qwertyuiopz";
         "luamsicrexe";
         "abcdefghijk"]

    let actual = find differentSizePuzzle "exercism"    
    actual |> should equal Some ((11, 2), (4, 2))