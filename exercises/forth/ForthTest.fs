module ForthTest

open NUnit.Framework

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

[<Test>]
let ``No input, no stack`` () =
    Assert.That(formatStack empty, Is.EqualTo(""))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Numbers just get pushed onto the stack`` () =
    Assert.That(run "1 2 3 4 5", Is.EqualTo(Choice1Of2 "1 2 3 4 5": Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Non-word characters are separators`` () =
    Assert.That(run "1\b2\t3\n4\r5 6\t7", Is.EqualTo(Choice1Of2 "1 2 3 4 5 6 7": Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Basic arithmetic`` () =
    Assert.That(run "1 2 + 4 -", Is.EqualTo(Choice1Of2 "-1": Choice<string,ForthError>))
    Assert.That(run "2 4 * 3 /", Is.EqualTo(Choice1Of2 "2": Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Division by zero`` () =
    Assert.That(run "4 2 2 - /", Is.EqualTo(Choice2Of2 DivisionByZero: Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``dup`` () =
    Assert.That(run "1 DUP", Is.EqualTo(Choice1Of2 "1 1": Choice<string,ForthError>))
    Assert.That(run "1 2 Dup", Is.EqualTo(Choice1Of2 "1 2 2": Choice<string,ForthError>))
    Assert.That(run "dup", Is.EqualTo(Choice2Of2 StackUnderflow: Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``drop`` () =
    Assert.That(run "1 drop", Is.EqualTo(Choice1Of2 "": Choice<string,ForthError>))
    Assert.That(run "1 2 drop", Is.EqualTo(Choice1Of2 "1": Choice<string,ForthError>))
    Assert.That(run "drop", Is.EqualTo(Choice2Of2 StackUnderflow: Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``swap`` () =
    Assert.That(run "1 2 swap", Is.EqualTo(Choice1Of2 "2 1": Choice<string,ForthError>))
    Assert.That(run "1 2 3 swap", Is.EqualTo(Choice1Of2 "1 3 2": Choice<string,ForthError>))
    Assert.That(run "1 swap", Is.EqualTo(Choice2Of2 StackUnderflow: Choice<string,ForthError>))
    Assert.That(run "swap", Is.EqualTo(Choice2Of2 StackUnderflow: Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``over`` () =
    Assert.That(run "1 2 over", Is.EqualTo(Choice1Of2 "1 2 1": Choice<string,ForthError>))
    Assert.That(run "1 2 3 over", Is.EqualTo(Choice1Of2 "1 2 3 2": Choice<string,ForthError>))
    Assert.That(run "1 over", Is.EqualTo(Choice2Of2 StackUnderflow: Choice<string,ForthError>))
    Assert.That(run "over", Is.EqualTo(Choice2Of2 StackUnderflow: Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Defining a new word`` () =
    let actual =
        empty
        |> eval ": dup-twice dup dup ;"  
        |> bind (eval "1 dup-twice")
        |> map formatStack

    Assert.That(actual, Is.EqualTo(Choice1Of2 "1 1 1": Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Redefining an existing word`` () =    
    let actual =
        empty
        |> eval ": foo dup ;"  
        |> bind (eval ": foo dup dup ;")
        |> bind (eval "1 foo")
        |> map formatStack
        
    Assert.That(actual, Is.EqualTo(Choice1Of2 "1 1 1": Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Redefining an existing built-in word`` () =  
    let actual =
        empty
        |> eval ": swap dup ;"  
        |> bind (eval "1 swap")
        |> map formatStack

    Assert.That(actual, Is.EqualTo(Choice1Of2 "1 1": Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Defining words with odd characters`` () =
    Assert.That(run ": € 220371 ; €", Is.EqualTo(Choice1Of2 "220371": Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Defining a number`` () =
    Assert.That(run ": 1 2 ;", Is.EqualTo(Choice2Of2 InvalidWord: Choice<string,ForthError>))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Calling a non-existing word`` () =
    Assert.That(run "1 foo", Is.EqualTo(Choice2Of2 (UnknownWord "foo"): Choice<string,ForthError>))