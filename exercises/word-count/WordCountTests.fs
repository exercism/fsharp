module WordCountTests

open NUnit.Framework
open Phrase

type WordCountTests() =
    
    [<Test>]
    member tests.Count_one_word() =
        let phrase = Phrase("word");
        let counts = Map.ofSeq [("word", 1)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))

    [<Test>]
    [<Ignore>]
    member tests.Count_one_of_each() =
        let phrase = Phrase("one of each");
        let counts = Map.ofSeq [("one",  1);
                                ("of",   1);
                                ("each", 1)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))

    [<Test>]
    [<Ignore>]
    member tests.Count_multiple_occurrences() =
        let phrase = Phrase("one fish two fish red fish blue fish");
        let counts = Map.ofSeq [("one",  1);
                                ("fish", 4);
                                ("two",  1);
                                ("red",  1);
                                ("blue", 1)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))

    [<Test>]
    [<Ignore>]
    member tests.Count_everything_just_once() =
        let phrase = Phrase("all the kings horses and all the kings men");
        let counts = Map.ofSeq [("all",    2);
                                ("the",    2);
                                ("kings",  2);
                                ("horses", 1);
                                ("and",    1);
                                ("men",    1)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))

    [<Test>]
    [<Ignore>]
    member tests.Ignore_punctuation() =
        let phrase = Phrase("car : carpet as java : javascript!!&@$%^&");
        let counts = Map.ofSeq [("car",        1);
                                ("carpet",     1);
                                ("as",         1);
                                ("java",       1);
                                ("javascript", 1)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))

    [<Test>]
    [<Ignore>]
    member tests.Handles_cramped_list() =
        let phrase = Phrase("one,two,three");
        let counts = Map.ofSeq [("one",   1);
                                ("two",   1);
                                ("three", 1)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))

    [<Test>]
    [<Ignore>]
    member tests.Include_numbers() =
        let phrase = Phrase("testing, 1, 2 testing");
        let counts = Map.ofSeq [("testing", 2);
                                ("1",       1);
                                ("2",       1)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))

    [<Test>]
    [<Ignore>]
    member tests.Normalize_case() =
        let phrase = Phrase("go Go GO");
        let counts = Map.ofSeq [("go", 3)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))

    [<Test>]
    [<Ignore>]
    member tests.With_apostrophes() =
        let phrase = Phrase("First: don't laugh. Then: don't cry.");
        let counts = Map.ofSeq [("first", 1);
                                ("don't", 2);
                                ("laugh", 1);
                                ("then",  1);
                                ("cry",   1)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))

    [<Test>]
    [<Ignore>]
    member tests.With_free_standing_apostrophes() =
        let phrase = Phrase("go ' Go '' GO");
        let counts = Map.ofSeq [("go", 3)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))

    [<Test>]
    [<Ignore>]
    member tests.With_apostrophes_as_quotes() =
        let phrase = Phrase("She said, 'let's meet at twelve o'clock'");
        let counts = Map.ofSeq [("she", 1);
                                ("said", 1);
                                ("let's", 1);
                                ("meet", 1);
                                ("at", 1);
                                ("twelve", 1);
                                ("o'clock", 1)]

        Assert.That(phrase.wordCount(), Is.EqualTo(counts))
