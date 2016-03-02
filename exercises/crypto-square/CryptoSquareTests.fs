module CryptoSquareTests

open NUnit.Framework
open CryptoSquare

type CryptoSquareTests() =

    [<Test>]
    member tests.Strange_characters_are_stripped_during_normalization() =
        let crypto = new CryptoSquare("s#$%^&plunk")
        Assert.That<string>(crypto.normalizePlaintext, Is.EqualTo("splunk"))

    [<Test>]
    [<Ignore>]
    member tests.Letters_are_lowercased_during_normalization() =
        let crypto = new CryptoSquare("WHOA HEY!")
        Assert.That<string>(crypto.normalizePlaintext, Is.EqualTo("whoahey"))

    [<Test>]
    [<Ignore>]
    member tests.Numbers_are_kept_during_normalization() =
        let crypto = new CryptoSquare("1, 2, 3, GO!")
        Assert.That<string>(crypto.normalizePlaintext, Is.EqualTo("123go"))

    [<Test>]
    [<Ignore>]
    member tests.Smallest_square_size_is_2() =
        let crypto = new CryptoSquare("1234")
        Assert.That<int>(crypto.size, Is.EqualTo(2))

    [<Test>]
    [<Ignore>]
    member tests.Size_of_text_whose_length_is_a_perfect_square_is_its_square_root() =
        let crypto = new CryptoSquare("123456789")
        Assert.That<int>(crypto.size, Is.EqualTo(3))

    [<Test>]
    [<Ignore>]
    member tests.Size_of_text_whose_length_is_not_a_perfect_square_is_next_biggest_square_root() =
        let crypto = new CryptoSquare("123456789abc")
        Assert.That<int>(crypto.size, Is.EqualTo(4))

    [<Test>]
    [<Ignore>]
    member tests.Size_is_determined_by_normalized_text() =
        let crypto = new CryptoSquare("Oh hey, this is nuts!")
        Assert.That<int>(crypto.size, Is.EqualTo(4))

    [<Test>]
    [<Ignore>]
    member tests.Segments_are_split_by_square_size() =
        let crypto = new CryptoSquare("Never vex thine heart with idle woes")
        Assert.That(crypto.plaintextSegments(), Is.EqualTo(["neverv"; "exthin"; "eheart"; "withid"; "lewoes"]))

    [<Test>]
    [<Ignore>]
    member tests.Segments_are_split_by_square_size_until_text_runs_out() =
        let crypto = new CryptoSquare("ZOMG! ZOMBIES!!!")
        Assert.That(crypto.plaintextSegments(), Is.EqualTo(["zomg"; "zomb"; "ies"]))

    [<Test>]
    [<Ignore>]
    member tests.Ciphertext_combines_text_by_column() =
        let crypto = new CryptoSquare("First, solve the problem. Then, write the code.")
        Assert.That(crypto.ciphertext(), Is.EqualTo("foeewhilpmrervrticseohtottbeedshlnte"))

    [<Test>]
    [<Ignore>]
    member tests.Ciphertext_skips_cells_with_no_text() =
        let crypto = new CryptoSquare("Time is an illusion. Lunchtime doubly so.")
        Assert.That(crypto.ciphertext(), Is.EqualTo("tasneyinicdsmiohooelntuillibsuuml"))

    [<Test>]
    [<Ignore>]
    member tests.Normalized_ciphertext_is_split_by_5() =
        let crypto = new CryptoSquare("Vampires are people too!")
        Assert.That(crypto.normalizeCiphertext(), Is.EqualTo("vrel aepe mset paoo irpo"))

    [<Test>]
    [<Ignore>]
    member tests.Normalized_ciphertext_not_exactly_divisible_by_5_spills_into_a_smaller_segment() =
        let crypto = new CryptoSquare("Madness, and then illumination.")
        Assert.That(crypto.normalizeCiphertext(), Is.EqualTo("msemo aanin dnin ndla etlt shui"))