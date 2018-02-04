// This file was auto-generated based on version 1.1.0 of the canonical data.

module RailFenceCipherTest

open FsUnit.Xunit
open Xunit

open RailFenceCipher

[<Fact>]
let ``Encode with two rails`` () =
    let rails = 2
    let msg = "XOXOXOXOXOXOXOXOXO"
    let expected = "XXXXXXXXXOOOOOOOOO"
    encode rails msg |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Encode with three rails`` () =
    let rails = 3
    let msg = "WEAREDISCOVEREDFLEEATONCE"
    let expected = "WECRLTEERDSOEEFEAOCAIVDEN"
    encode rails msg |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Encode with ending in the middle`` () =
    let rails = 4
    let msg = "EXERCISES"
    let expected = "ESXIEECSR"
    encode rails msg |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Decode with three rails`` () =
    let rails = 3
    let msg = "TEITELHDVLSNHDTISEIIEA"
    let expected = "THEDEVILISINTHEDETAILS"
    decode rails msg |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Decode with five rails`` () =
    let rails = 5
    let msg = "EIEXMSMESAORIWSCE"
    let expected = "EXERCISMISAWESOME"
    decode rails msg |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Decode with six rails`` () =
    let rails = 6
    let msg = "133714114238148966225439541018335470986172518171757571896261"
    let expected = "112358132134558914423337761098715972584418167651094617711286"
    decode rails msg |> should equal expected

