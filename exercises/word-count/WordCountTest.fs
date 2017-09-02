module WordCountTest

open Xunit
open FsUnit.Xunit
open Phrase

[<Fact>]
let ``Count one word`` () =
    let phrase = "word"
    let counts = Map.ofSeq [("word", 1)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``Count one of each`` () =
    let phrase = "one of each"
    let counts = Map.ofSeq [("one",  1);
                            ("of",   1);
                            ("each", 1)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``Count multiple occurrences`` () =
    let phrase = "one fish two fish red fish blue fish"
    let counts = Map.ofSeq [("one",  1);
                            ("fish", 4);
                            ("two",  1);
                            ("red",  1);
                            ("blue", 1)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``Count everything just once`` () =
    let phrase = "all the kings horses and all the kings men"
    let counts = Map.ofSeq [("all",    2);
                            ("the",    2);
                            ("kings",  2);
                            ("horses", 1);
                            ("and",    1);
                            ("men",    1)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``Ignore punctuation`` () =
    let phrase = "car : carpet as java : javascript!!&@$%^&"
    let counts = Map.ofSeq [("car",        1);
                            ("carpet",     1);
                            ("as",         1);
                            ("java",       1);
                            ("javascript", 1)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``Handles cramped list`` () =
    let phrase = "one,two,three"
    let counts = Map.ofSeq [("one",   1);
                            ("two",   1);
                            ("three", 1)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``Include numbers`` () =
    let phrase = "testing, 1, 2 testing"
    let counts = Map.ofSeq [("testing", 2);
                            ("1",       1);
                            ("2",       1)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``Normalize case`` () =
    let phrase = "go Go GO"
    let counts = Map.ofSeq [("go", 3)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``With apostrophes`` () =
    let phrase = "First: don't laugh. Then: don't cry."
    let counts = Map.ofSeq [("first", 1);
                            ("don't", 2);
                            ("laugh", 1);
                            ("then",  1);
                            ("cry",   1)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``With free standing apostrophes`` () =
    let phrase = "go ' Go '' GO"
    let counts = Map.ofSeq [("go", 3)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``With apostrophes as quotes`` () =
    let phrase = "She said, 'let's meet at twelve o'clock'"
    let counts = Map.ofSeq [("she",     1);
                            ("said",    1);
                            ("let's",   1);
                            ("meet",    1);
                            ("at",      1);
                            ("twelve",  1);
                            ("o'clock", 1)]

    wordCount phrase |> should equal counts

[<Fact(Skip = "Remove to run test")>]
let ``With multiple lines`` () =
    let phrase = "Your time will come. You will face the same Evil, and you will defeat it."
    let counts = Map.ofSeq [("and",    1);
                            ("come",   1);
                            ("defeat", 1);
                            ("evil",   1);
                            ("face",   1);
                            ("it",     1);
                            ("same",   1);
                            ("the",    1);
                            ("time",   1);
                            ("will",   3);
                            ("you",    2);
                            ("your",   1)]

    wordCount phrase |> should equal counts