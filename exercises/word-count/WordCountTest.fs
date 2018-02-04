// This file was auto-generated based on version 1.2.0 of the canonical data.

module WordCountTest

open FsUnit.Xunit
open Xunit

open WordCount

[<Fact>]
let ``Count one word`` () =
    let expected = [("word", 1)] |> Map.ofList
    countWords "word" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Count one of each word`` () =
    let expected = 
        [ ("one", 1);
          ("of", 1);
          ("each", 1) ]
        |> Map.ofList
    countWords "one of each" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiple occurrences of a word`` () =
    let expected = 
        [ ("one", 1);
          ("fish", 4);
          ("two", 1);
          ("red", 1);
          ("blue", 1) ]
        |> Map.ofList
    countWords "one fish two fish red fish blue fish" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Handles cramped lists`` () =
    let expected = 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
    countWords "one,two,three" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Handles expanded lists`` () =
    let expected = 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
    countWords "one,\ntwo,\nthree" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Ignore punctuation`` () =
    let expected = 
        [ ("car", 1);
          ("carpet", 1);
          ("as", 1);
          ("java", 1);
          ("javascript", 1) ]
        |> Map.ofList
    countWords "car: carpet as java: javascript!!&@$%^&" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Include numbers`` () =
    let expected = 
        [ ("testing", 2);
          ("1", 1);
          ("2", 1) ]
        |> Map.ofList
    countWords "testing, 1, 2 testing" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Normalize case`` () =
    let expected = 
        [ ("go", 3);
          ("stop", 2) ]
        |> Map.ofList
    countWords "go Go GO Stop stop" |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``With apostrophes`` () =
    let expected = 
        [ ("first", 1);
          ("don't", 2);
          ("laugh", 1);
          ("then", 1);
          ("cry", 1) ]
        |> Map.ofList
    countWords "First: don't laugh. Then: don't cry." |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``With quotations`` () =
    let expected = 
        [ ("joe", 1);
          ("can't", 1);
          ("tell", 1);
          ("between", 1);
          ("large", 2);
          ("and", 1) ]
        |> Map.ofList
    countWords "Joe can't tell between 'large' and large." |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiple spaces not detected as a word`` () =
    let expected = 
        [ ("multiple", 1);
          ("whitespaces", 1) ]
        |> Map.ofList
    countWords " multiple   whitespaces" |> should equal expected

