module WordSearchTests

open FsUnit.Xunit
open Xunit

open WordSearch

[<Fact>]
let ``Should accept an initial game grid and a target search word`` () =
    let grid = ["jefblpepre"]
    let wordsToSearchFor = ["clojure"]
    let expected = [("clojure", Option<((int * int) * (int * int))>.None)] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate one word written left to right`` () =
    let grid = ["clojurermt"]
    let wordsToSearchFor = ["clojure"]
    let expected = [("clojure", Some ((1, 1), (7, 1)))] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate the same word written left to right in a different position`` () =
    let grid = ["mtclojurer"]
    let wordsToSearchFor = ["clojure"]
    let expected = [("clojure", Some ((3, 1), (9, 1)))] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate a different left to right word`` () =
    let grid = ["coffeelplx"]
    let wordsToSearchFor = ["coffee"]
    let expected = [("coffee", Some ((1, 1), (6, 1)))] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate that different left to right word in a different position`` () =
    let grid = ["xcoffeezlp"]
    let wordsToSearchFor = ["coffee"]
    let expected = [("coffee", Some ((2, 1), (7, 1)))] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate a left to right word in two line grid`` () =
    let grid = 
        [ "jefblpepre";
          "tclojurerm" ]
    let wordsToSearchFor = ["clojure"]
    let expected = [("clojure", Some ((2, 2), (8, 2)))] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate a left to right word in three line grid`` () =
    let grid = 
        [ "camdcimgtc";
          "jefblpepre";
          "clojurermt" ]
    let wordsToSearchFor = ["clojure"]
    let expected = [("clojure", Some ((1, 3), (7, 3)))] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate a left to right word in ten line grid`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    let wordsToSearchFor = ["clojure"]
    let expected = [("clojure", Some ((1, 10), (7, 10)))] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate that left to right word in a different position in a ten line grid`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "clojurermt";
          "jalaycalmp" ]
    let wordsToSearchFor = ["clojure"]
    let expected = [("clojure", Some ((1, 9), (7, 9)))] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate a different left to right word in a ten line grid`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "fortranftw";
          "alxhpburyi";
          "clojurermt";
          "jalaycalmp" ]
    let wordsToSearchFor = ["fortran"]
    let expected = [("fortran", Some ((1, 7), (7, 7)))] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate multiple words`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "fortranftw";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    let wordsToSearchFor = ["fortran"; "clojure"]
    let expected = 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("fortran", Some ((1, 7), (7, 7))) ]
        |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate a single word written right to left`` () =
    let grid = ["rixilelhrs"]
    let wordsToSearchFor = ["elixir"]
    let expected = [("elixir", Some ((6, 1), (1, 1)))] |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate multiple words written in different horizontal directions`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    let wordsToSearchFor = ["elixir"; "clojure"]
    let expected = 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5))) ]
        |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate words written top to bottom`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    let wordsToSearchFor = ["clojure"; "elixir"; "ecmascript"]
    let expected = 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10))) ]
        |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate words written bottom to top`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    let wordsToSearchFor = ["clojure"; "elixir"; "ecmascript"; "rust"]
    let expected = 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2))) ]
        |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate words written top left to bottom right`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    let wordsToSearchFor = ["clojure"; "elixir"; "ecmascript"; "rust"; "java"]
    let expected = 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4))) ]
        |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate words written bottom right to top left`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    let wordsToSearchFor = ["clojure"; "elixir"; "ecmascript"; "rust"; "java"; "lua"]
    let expected = 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7))) ]
        |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate words written bottom left to top right`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    let wordsToSearchFor = ["clojure"; "elixir"; "ecmascript"; "rust"; "java"; "lua"; "lisp"]
    let expected = 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7)));
          ("lisp", Some ((3, 6), (6, 3))) ]
        |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should locate words written top right to bottom left`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    let wordsToSearchFor = ["clojure"; "elixir"; "ecmascript"; "rust"; "java"; "lua"; "lisp"; "ruby"]
    let expected = 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7)));
          ("lisp", Some ((3, 6), (6, 3)));
          ("ruby", Some ((8, 6), (5, 9))) ]
        |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Should fail to locate a word that is not in the puzzle`` () =
    let grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
    let wordsToSearchFor = ["clojure"; "elixir"; "ecmascript"; "rust"; "java"; "lua"; "lisp"; "ruby"; "haskell"]
    let expected = 
        [ ("clojure", Some ((1, 10), (7, 10)));
          ("elixir", Some ((6, 5), (1, 5)));
          ("ecmascript", Some ((10, 1), (10, 10)));
          ("rust", Some ((9, 5), (9, 2)));
          ("java", Some ((1, 1), (4, 4)));
          ("lua", Some ((8, 9), (6, 7)));
          ("lisp", Some ((3, 6), (6, 3)));
          ("ruby", Some ((8, 6), (5, 9)));
          ("haskell", Option<((int * int) * (int * int))>.None) ]
        |> Map.ofList
    search grid wordsToSearchFor |> should equal expected

