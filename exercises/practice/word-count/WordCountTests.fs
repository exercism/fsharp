source("./word-count.R")
library(testthat)

let ``Count one word`` () =
    expected <- [("word", 1)] |> Map.ofList
    expect_equal(countWords "word", expected)

let ``Count one of each word`` () =
    expected <- 
        [ ("one", 1);
          ("of", 1);
          ("each", 1) ]
        |> Map.ofList
    expect_equal(countWords "one of each", expected)

let ``Multiple occurrences of a word`` () =
    expected <- 
        [ ("one", 1);
          ("fish", 4);
          ("two", 1);
          ("red", 1);
          ("blue", 1) ]
        |> Map.ofList
    expect_equal(countWords "one fish two fish red fish blue fish", expected)

let ``Handles cramped lists`` () =
    expected <- 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
    expect_equal(countWords "one,two,three", expected)

let ``Handles expanded lists`` () =
    expected <- 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
    expect_equal(countWords "one,\ntwo,\nthree", expected)

let ``Ignore punctuation`` () =
    expected <- 
        [ ("car", 1);
          ("carpet", 1);
          ("as", 1);
          ("java", 1);
          ("javascript", 1) ]
        |> Map.ofList
    expect_equal(countWords "car: carpet as java: javascript!!&@$%^&", expected)

let ``Include numbers`` () =
    expected <- 
        [ ("testing", 2);
          ("1", 1);
          ("2", 1) ]
        |> Map.ofList
    expect_equal(countWords "testing, 1, 2 testing", expected)

let ``Normalize case`` () =
    expected <- 
        [ ("go", 3);
          ("stop", 2) ]
        |> Map.ofList
    expect_equal(countWords "go Go GO Stop stop", expected)

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
    expect_equal(countWords "'First: don't laugh. Then: don't cry. You're getting it.'", expected)

let ``With quotations`` () =
    expected <- 
        [ ("joe", 1);
          ("can't", 1);
          ("tell", 1);
          ("between", 1);
          ("large", 2);
          ("and", 1) ]
        |> Map.ofList
    expect_equal(countWords "Joe can't tell between 'large' and large.", expected)

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
    expect_equal(countWords "Joe can't tell between app, apple and a.", expected)

let ``Multiple spaces not detected as a word`` () =
    expected <- 
        [ ("multiple", 1);
          ("whitespaces", 1) ]
        |> Map.ofList
    expect_equal(countWords " multiple   whitespaces", expected)

let ``Alternating word separators not detected as a word`` () =
    expected <- 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
    expect_equal(countWords ",\n,one,\n ,two \n 'three'", expected)

let ``Quotation for word with apostrophe`` () =
    expected <- 
        [ ("can", 1);
          ("can't", 2) ]
        |> Map.ofList
    expect_equal(countWords "can, can't, 'can't'", expected)

