module AtbastTests

open NUnit.Framework
open Atbash

[<TestFixture>]
type AtbashTests() =
    [<TestCase("no", Result = "ml")>]
    [<TestCase("yes", Result = "bvh", Ignore = true)>]
    [<TestCase("OMG", Result = "lnt", Ignore = true)>]
    [<TestCase("mindblowingly", Result = "nrmwy oldrm tob", Ignore = true)>]
    [<TestCase("Testing, 1 2 3, testing.", Result = "gvhgr mt123 gvhgr mt", Ignore = true)>]
    [<TestCase("Truth is fiction.", Result = "gifgs rhurx grlm", Ignore = true)>]
    [<TestCase("The quick brown fox jumps over the lazy dog.", Result = "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt", Ignore = true)>]
    member tests.Encodes_words_using_atbash_cipher(words) =        
        Atbash().encode(words)