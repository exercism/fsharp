// This file was auto-generated based on version 1.1.0 of the canonical data.

module AtbashCipherTest

open FsUnit.Xunit
open Xunit

open AtbashCipher

[<Fact>]
let ``Encode yes`` () =
    encode "yes" |> should equal "bvh"

[<Fact(Skip = "Remove to run test")>]
let ``Encode no`` () =
    encode "no" |> should equal "ml"

[<Fact(Skip = "Remove to run test")>]
let ``Encode OMG`` () =
    encode "OMG" |> should equal "lnt"

[<Fact(Skip = "Remove to run test")>]
let ``Encode spaces`` () =
    encode "O M G" |> should equal "lnt"

[<Fact(Skip = "Remove to run test")>]
let ``Encode mindblowingly`` () =
    encode "mindblowingly" |> should equal "nrmwy oldrm tob"

[<Fact(Skip = "Remove to run test")>]
let ``Encode numbers`` () =
    encode "Testing,1 2 3, testing." |> should equal "gvhgr mt123 gvhgr mt"

[<Fact(Skip = "Remove to run test")>]
let ``Encode deep thought`` () =
    encode "Truth is fiction." |> should equal "gifgs rhurx grlm"

[<Fact(Skip = "Remove to run test")>]
let ``Encode all the letters`` () =
    encode "The quick brown fox jumps over the lazy dog." |> should equal "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt"

[<Fact(Skip = "Remove to run test")>]
let ``Decode exercism`` () =
    decode "vcvix rhn" |> should equal "exercism"

[<Fact(Skip = "Remove to run test")>]
let ``Decode a sentence`` () =
    decode "zmlyh gzxov rhlug vmzhg vkkrm thglm v" |> should equal "anobstacleisoftenasteppingstone"

[<Fact(Skip = "Remove to run test")>]
let ``Decode numbers`` () =
    decode "gvhgr mt123 gvhgr mt" |> should equal "testing123testing"

[<Fact(Skip = "Remove to run test")>]
let ``Decode all the letters`` () =
    decode "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt" |> should equal "thequickbrownfoxjumpsoverthelazydog"

