module AtbastTests

open NUnit.Framework
open Atbash

[<TestFixture>]
type AtbashTests() =
    [<TestCase("no", ExpectedResult = "ml")>]
    [<TestCase("yes", ExpectedResult = "bvh", Ignore = true)>]
    [<TestCase("OMG", ExpectedResult = "lnt", Ignore = true)>]
    [<TestCase("mindblowingly", ExpectedResult = "nrmwy oldrm tob", Ignore = true)>]
    [<TestCase("Testing, 1 2 3, testing.", ExpectedResult = "gvhgr mt123 gvhgr mt", Ignore = true)>]
    [<TestCase("Truth is fiction.", ExpectedResult = "gifgs rhurx grlm", Ignore = true)>]
    [<TestCase("The quick brown fox jumps over the lazy dog.", ExpectedResult = "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt", Ignore = true)>]
    member tests.Encodes_words_using_atbash_cipher(words) =        
        Atbash().encode(words)