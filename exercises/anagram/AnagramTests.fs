module AnagramTests

open System
open NUnit.Framework
open Anagram

type AnagramTests() =
    [<Test>]
    member tests.No_matches() =
        let detector = new Anagram("diaper")
        let words = ["hello"; "world"; "zombies"; "pants"]
        let results = []
        Assert.That(detector.Match(words), Is.EquivalentTo(results))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Detect_simple_anagram() =
        let detector = new Anagram("ant")
        let words = ["tan"; "stand"; "at"]
        let results = ["tan"]
        Assert.That(detector.Match(words), Is.EquivalentTo(results))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Detect_multiple_anagrams() =
        let detector = new Anagram("master");
        let words = ["stream"; "pigeon"; "maters"];
        let results = ["maters"; "stream"];
        Assert.That(detector.Match(words), Is.EquivalentTo(results));

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Does_not_confuse_different_duplicates() =
        let detector = new Anagram("galea");
        let words = ["eagle"];
        let results = []
        Assert.That(detector.Match(words), Is.EquivalentTo(results));

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Identical_word_is_not_anagram() =
        let detector = new Anagram("corn");
        let words = ["corn"; "dark"; "Corn"; "rank"; "CORN"; "cron"; "park"];
        let results = ["cron"];
        Assert.That(detector.Match(words), Is.EquivalentTo(results));

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Eliminate_anagrams_with_same_checksum() =
        let detector = new Anagram("mass");
        let words = ["last"];
        let results = []
        Assert.That(detector.Match(words), Is.EquivalentTo(results));

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Eliminate_anagram_subsets() =
        let detector = new Anagram("good");
        let words = ["dog"; "goody"];
        let results = []
        Assert.That(detector.Match(words), Is.EquivalentTo(results));

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Detect_anagrams() =
        let detector = new Anagram("allergy");
        let words = ["gallery"; "ballerina"; "regally"; "clergy"; "largely"; "leading"];
        let results = ["gallery"; "largely"; "regally"];
        let enumerable = detector.Match(words);
        Assert.That(enumerable, Is.EquivalentTo(results));

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.Anagrams_are_case_insensitive() =
        let detector = new Anagram("Orchestra");
        let words = ["cashregister"; "Carthorse"; "radishes"];
        let results = ["Carthorse"];
        Assert.That(detector.Match(words), Is.EquivalentTo(results));