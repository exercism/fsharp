source("./word-count.R")
library(testthat)

let ``Count one word`` () =
    expected <- [("word", 1)] |> Map.ofList
    countWords "word" |> should equal expected

let ``Count one of each word`` () =
    expected <- 
        [ ("one", 1);
          ("of", 1);
          ("each", 1) ]
        |> Map.ofList
    countWords "one of each" |> should equal expected

let ``Multiple occurrences of a word`` () =
    expected <- 
        [ ("one", 1);
          ("fish", 4);
          ("two", 1);
          ("red", 1);
          ("blue", 1) ]
        |> Map.ofList
    countWords "one fish two fish red fish blue fish" |> should equal expected

let ``Handles cramped lists`` () =
    expected <- 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
    countWords "one,two,three" |> should equal expected

let ``Handles expanded lists`` () =
    expected <- 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
    countWords "one,\ntwo,\nthree" |> should equal expected

let ``Ignore punctuation`` () =
    expected <- 
        [ ("car", 1);
          ("carpet", 1);
          ("as", 1);
          ("java", 1);
          ("javascript", 1) ]
        |> Map.ofList
    countWords "car: carpet as java: javascript!!&@$%^&" |> should equal expected

let ``Include numbers`` () =
    expected <- 
        [ ("testing", 2);
          ("1", 1);
          ("2", 1) ]
        |> Map.ofList
    countWords "testing, 1, 2 testing" |> should equal expected

let ``Normalize case`` () =
    expected <- 
        [ ("go", 3);
          ("stop", 2) ]
        |> Map.ofList
    countWords "go Go GO Stop stop" |> should equal expected

let ``With apostrophes`` () =
    expected <- 
        [ ("first", 1);
          ("don't", 2);
          ("laugh", 1);
          ("then", 1);
          ("cry", 1);
          ("you're", 1);
          ("getting", 1);
          ("it", 1) ]
        |> Map.ofList
    countWords "'First: don't laugh. Then: don't cry. You're getting it.'" |> should equal expected

let ``With quotations`` () =
    expected <- 
        [ ("joe", 1);
          ("can't", 1);
          ("tell", 1);
          ("between", 1);
          ("large", 2);
          ("and", 1) ]
        |> Map.ofList
    countWords "Joe can't tell between 'large' and large." |> should equal expected

let ``Substrings from the beginning`` () =
    expected <- 
        [ ("joe", 1);
          ("can't", 1);
          ("tell", 1);
          ("between", 1);
          ("app", 1);
          ("apple", 1);
          ("and", 1);
          ("a", 1) ]
        |> Map.ofList
    countWords "Joe can't tell between app, apple and a." |> should equal expected

let ``Multiple spaces not detected as a word`` () =
    expected <- 
        [ ("multiple", 1);
          ("whitespaces", 1) ]
        |> Map.ofList
    countWords " multiple   whitespaces" |> should equal expected

let ``Alternating word separators not detected as a word`` () =
    expected <- 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
    countWords ",\n,one,\n ,two \n 'three'" |> should equal expected

let ``Quotation for word with apostrophe`` () =
    expected <- 
        [ ("can", 1);
          ("can't", 2) ]
        |> Map.ofList
    countWords "can, can't, 'can't'" |> should equal expected

