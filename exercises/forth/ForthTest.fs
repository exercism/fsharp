module ForthTest

open Xunit
open FsUnit.Xunit

open Forth

let bind f m = 
    match m with
    | Choice1Of2 x -> f x
    | Choice2Of2 x -> Choice2Of2 x

let map f =
    function
    | Choice1Of2 x -> f x |> Choice1Of2
    | Choice2Of2 x -> Choice2Of2 x

let run text = eval text empty |> map formatStack
    
// Note: we use the Choice<'T1, 'T2> type to represent a possible outcome of
// evaluating input. When the evaluating is succesful, the result is 
// contained in a Choice1Of2. If an error occured, that error is contained
// in a Choice2Of2.

[<Fact>]
let ``No input, no stack`` () =
    formatStack empty |> should equal ""

[<Fact(Skip = "Remove to run test")>]
let ``Numbers just get pushed onto the stack`` () =
    run "1 2 3 4 5" |> should equal (Choice1Of2 "1 2 3 4 5": Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``Non-word characters are separators`` () =
    run "1\b2\t3\n4\r5 6\t7" |> should equal (Choice1Of2 "1 2 3 4 5 6 7": Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``Basic arithmetic`` () =
    run "1 2 + 4 -" |> should equal (Choice1Of2 "-1": Choice<string,ForthError>)
    run "2 4 * 3 /" |> should equal (Choice1Of2 "2": Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``Division by zero`` () =
    run "4 2 2 - /" |> should equal (Choice2Of2 DivisionByZero: Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``dup`` () =
    run "1 DUP" |> should equal (Choice1Of2 "1 1": Choice<string,ForthError>)
    run "1 2 Dup" |> should equal (Choice1Of2 "1 2 2": Choice<string,ForthError>)
    run "dup" |> should equal (Choice2Of2 StackUnderflow: Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``drop`` () =
    run "1 drop" |> should equal (Choice1Of2 "": Choice<string,ForthError>)
    run "1 2 drop" |> should equal (Choice1Of2 "1": Choice<string,ForthError>)
    run "drop" |> should equal (Choice2Of2 StackUnderflow: Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``swap`` () =
    run "1 2 swap" |> should equal (Choice1Of2 "2 1": Choice<string,ForthError>)
    run "1 2 3 swap" |> should equal (Choice1Of2 "1 3 2": Choice<string,ForthError>)
    run "1 swap" |> should equal (Choice2Of2 StackUnderflow: Choice<string,ForthError>)
    run "swap" |> should equal (Choice2Of2 StackUnderflow: Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``over`` () =
    run "1 2 over" |> should equal (Choice1Of2 "1 2 1": Choice<string,ForthError>)
    run "1 2 3 over" |> should equal (Choice1Of2 "1 2 3 2": Choice<string,ForthError>)
    run "1 over" |> should equal (Choice2Of2 StackUnderflow: Choice<string,ForthError>)
    run "over" |> should equal (Choice2Of2 StackUnderflow: Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``Defining a new word`` () =
    let actual =
        empty
        |> eval ": dup-twice dup dup ;"  
        |> bind (eval "1 dup-twice")
        |> map formatStack

    actual |> should equal (Choice1Of2 "1 1 1": Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``Redefining an existing word`` () =    
    let actual =
        empty
        |> eval ": foo dup ;"  
        |> bind (eval ": foo dup dup ;")
        |> bind (eval "1 foo")
        |> map formatStack
        
    actual |> should equal (Choice1Of2 "1 1 1": Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``Redefining an existing built-in word`` () =  
    let actual =
        empty
        |> eval ": swap dup ;"  
        |> bind (eval "1 swap")
        |> map formatStack

    actual |> should equal (Choice1Of2 "1 1": Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``Defining words with odd characters`` () =
    run ": € 220371 ; €" |> should equal (Choice1Of2 "220371": Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``Defining a number`` () =
    run ": 1 2 ;" |> should equal (Choice2Of2 InvalidWord: Choice<string,ForthError>)

[<Fact(Skip = "Remove to run test")>]
let ``Calling a non-existing word`` () =
    run "1 foo" |> should equal (Choice2Of2 (UnknownWord "foo"): Choice<string,ForthError>)