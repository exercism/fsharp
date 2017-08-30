module TwoFerTest

open Xunit
open FsUnit

open TwoFer

[<Test>]
let ``No name given`` () =
    getResponse None |> should equal "One for you, one for me."

[<Test>]
[<Ignore("Remove to run test")>]
let ``A name given`` () =
    getResponse (Some "Alice") |> should equal "One for Alice, one for me."

[<Test>]
[<Ignore("Remove to run test")>]
let ``Another name given`` () =
    getResponse (Some "Bob") |> should equal "One for Bob, one for me."
