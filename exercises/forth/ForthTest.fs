// This file was auto-generated based on version 1.7.0 of the canonical data.

module ForthTest

open FsUnit.Xunit
open Xunit

open Forth

[<Fact>]
let ``Parsing and numbers - numbers just get pushed onto the stack`` () =
    let expected = Some [1; 2; 3; 4; 5]
    evaluate ["1 2 3 4 5"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Addition - can add two numbers`` () =
    let expected = Some [3]
    evaluate ["1 2 +"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Addition - errors if there is nothing on the stack`` () =
    let expected = None
    evaluate ["+"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Addition - errors if there is only one value on the stack`` () =
    let expected = None
    evaluate ["1 +"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Subtraction - can subtract two numbers`` () =
    let expected = Some [-1]
    evaluate ["3 4 -"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Subtraction - errors if there is nothing on the stack`` () =
    let expected = None
    evaluate ["-"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Subtraction - errors if there is only one value on the stack`` () =
    let expected = None
    evaluate ["1 -"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiplication - can multiply two numbers`` () =
    let expected = Some [8]
    evaluate ["2 4 *"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiplication - errors if there is nothing on the stack`` () =
    let expected = None
    evaluate ["*"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiplication - errors if there is only one value on the stack`` () =
    let expected = None
    evaluate ["1 *"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Division - can divide two numbers`` () =
    let expected = Some [4]
    evaluate ["12 3 /"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Division - performs integer division`` () =
    let expected = Some [2]
    evaluate ["8 3 /"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Division - errors if dividing by zero`` () =
    let expected = None
    evaluate ["4 0 /"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Division - errors if there is nothing on the stack`` () =
    let expected = None
    evaluate ["/"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Division - errors if there is only one value on the stack`` () =
    let expected = None
    evaluate ["1 /"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Combined arithmetic - addition and subtraction`` () =
    let expected = Some [-1]
    evaluate ["1 2 + 4 -"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Combined arithmetic - multiplication and division`` () =
    let expected = Some [2]
    evaluate ["2 4 * 3 /"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Dup - copies a value on the stack`` () =
    let expected = Some [1; 1]
    evaluate ["1 dup"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Dup - copies the top value on the stack`` () =
    let expected = Some [1; 2; 2]
    evaluate ["1 2 dup"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Dup - errors if there is nothing on the stack`` () =
    let expected = None
    evaluate ["dup"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Drop - removes the top value on the stack if it is the only one`` () =
    let expected: int list option = Some []
    evaluate ["1 drop"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Drop - removes the top value on the stack if it is not the only one`` () =
    let expected = Some [1]
    evaluate ["1 2 drop"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Drop - errors if there is nothing on the stack`` () =
    let expected = None
    evaluate ["drop"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Swap - swaps the top two values on the stack if they are the only ones`` () =
    let expected = Some [2; 1]
    evaluate ["1 2 swap"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Swap - swaps the top two values on the stack if they are not the only ones`` () =
    let expected = Some [1; 3; 2]
    evaluate ["1 2 3 swap"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Swap - errors if there is nothing on the stack`` () =
    let expected = None
    evaluate ["swap"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Swap - errors if there is only one value on the stack`` () =
    let expected = None
    evaluate ["1 swap"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Over - copies the second element if there are only two`` () =
    let expected = Some [1; 2; 1]
    evaluate ["1 2 over"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Over - copies the second element if there are more than two`` () =
    let expected = Some [1; 2; 3; 2]
    evaluate ["1 2 3 over"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Over - errors if there is nothing on the stack`` () =
    let expected = None
    evaluate ["over"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Over - errors if there is only one value on the stack`` () =
    let expected = None
    evaluate ["1 over"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``User-defined words - can consist of built-in words`` () =
    let expected = Some [1; 1; 1]
    evaluate [": dup-twice dup dup ;"; "1 dup-twice"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``User-defined words - execute in the right order`` () =
    let expected = Some [1; 2; 3]
    evaluate [": countup 1 2 3 ;"; "countup"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``User-defined words - can override other user-defined words`` () =
    let expected = Some [1; 1; 1]
    evaluate [": foo dup ;"; ": foo dup dup ;"; "1 foo"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``User-defined words - can override built-in words`` () =
    let expected = Some [1; 1]
    evaluate [": swap dup ;"; "1 swap"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``User-defined words - can override built-in operators`` () =
    let expected = Some [12]
    evaluate [": + * ;"; "3 4 +"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``User-defined words - can use different words with the same name`` () =
    let expected = Some [5; 6]
    evaluate [": foo 5 ;"; ": bar foo ;"; ": foo 6 ;"; "bar foo"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``User-defined words - can define word that uses word with the same name`` () =
    let expected = Some [11]
    evaluate [": foo 10 ;"; ": foo foo 1 + ;"; "foo"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``User-defined words - cannot redefine numbers`` () =
    let expected = None
    evaluate [": 1 2 ;"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``User-defined words - errors if executing a non-existent word`` () =
    let expected = None
    evaluate ["foo"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Case-insensitivity - DUP is case-insensitive`` () =
    let expected = Some [1; 1; 1; 1]
    evaluate ["1 DUP Dup dup"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Case-insensitivity - DROP is case-insensitive`` () =
    let expected = Some [1]
    evaluate ["1 2 3 4 DROP Drop drop"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Case-insensitivity - SWAP is case-insensitive`` () =
    let expected = Some [2; 3; 4; 1]
    evaluate ["1 2 SWAP 3 Swap 4 swap"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Case-insensitivity - OVER is case-insensitive`` () =
    let expected = Some [1; 2; 1; 2; 1]
    evaluate ["1 2 OVER Over over"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Case-insensitivity - user-defined words are case-insensitive`` () =
    let expected = Some [1; 1; 1; 1]
    evaluate [": foo dup ;"; "1 FOO Foo foo"] |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Case-insensitivity - definitions are case-insensitive`` () =
    let expected = Some [1; 1; 1; 1]
    evaluate [": SWAP DUP Dup dup ;"; "1 swap"] |> should equal expected

