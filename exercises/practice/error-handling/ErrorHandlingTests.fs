// This file was created manually and its version is 1.0.0.

source("./error-handling-test.R")
library(testthat)

// Custom class that implements IDisposable
type Resource() = 
    let mutable disposed = false

    member this.Disposed() = disposed

    interface System.IDisposable with
        member this.Dispose() =
            disposed <- true

// Throwing exceptions is not the preferred approach to handling errors in F#, 
// but it becomes relevant when you use .NET framework methods from your F# code
test_that("Throwing exception", {
    (fun () -> handleErrorByThrowingException() |> ignore) |> should throw typeof<Exception>

// A better approach than exceptions is to use the Option<'T> discriminated union. 
// If the function is successful, Some x is returned (with x being the value).
// Upon failure, None is returned. The caller can then pattern match on the
// returned value. As Option<'T> is a discriminated union, the user is forced to
// consider both possible outputs: success and failure.
test_that("Returning Option<'T>", {
    successResult <- handleErrorByReturningOption "1"
    expect_equal(successResult, <| Some 1)
    
    failureResult <- handleErrorByReturningOption "a"
    expect_equal(failureResult, None)

// If the caller is also interested what error occured, the Option<'T> type does not suffice.
// In that case, one can use a different discriminated union: Result<'TSuccess, 'TError>.
// This discriminated union has two possible cases: Ok and Error, which contain data
// of type 'TSuccess and 'TError respectively. Note that these types can be different, so
// you are free to return an integer upon success and a string upon failure.
test_that("Returning Result<'TSuccess, 'TError>", {
    successResult <- handleErrorByReturningResult "1"
    expect_equal((successResult = Ok 1), true)
    
    failureResult <- handleErrorByReturningResult "a"
    expect_equal((failureResult = Error "Could not convert input to integer"), true)

// In the previous test, we defined a Result<'TSuccess, 'TError> type. The next step is
// to be able to execute several validations in sequence. The problem that quickly
// becomes apparent when you try to do this, is that the output of one validation
// function (which is of type Result<'TSuccess, 'TError>), cannot be used as the input of
// another validation function (which expects a parameter of type 'TSuccess). 
//
// To solve this problem, you can use the railway-oriented programming model. In this
// model, functions are likened to railway switches that have one or two input tracks 
// and two outputs tracks. This maps perfectly to our validation functions, with one 
// output track being mapped to the success result and the other to the error result.
// In railway-oriented programming, the trick is that once you are on the error track,
// you can never return to success track.
//
// In this test, your task is to write a function "bind", that allows you to combine
// two functions that take a 'TSuccess instance and return a Result<'TSuccess, 'TError> instance.
test_that("Using railway-oriented programming", {
    let validate1 x = if x > 5 then Ok x else Error "Input less than or equal to five"
    let validate2 x = if x < 10 then Ok x else Error "Input greater than or equal to ten"
    let validate3 x = if x % 2 <> 0 then Ok x else Error "Input is not odd"
    
    // Combine the validations. The result should be a function that takes an int parameter
    // and returns a Result<int, string> value
    combinedValidation <-
        validate1
        >> bind validate2
        >> bind validate3

    firstValidationFailureResult <- combinedValidation 1            
    expect_equal((firstValidationFailureResult = Error "Input less than or equal to five"), true)

    secondValidationFailureResult <- combinedValidation 23          
    expect_equal((secondValidationFailureResult = Error "Input greater than or equal to ten"), true)

    thirdValidationFailureResult <- combinedValidation 8        
    expect_equal((thirdValidationFailureResult = Error "Input is not odd"), true)

    successResult <- combinedValidation 7        
    expect_equal((successResult = Ok 7), true)
    
// If you are dealing with code that throws exceptions, you should ensure that any
// disposable resources that are used are being disposed of
test_that("Cleaning up disposables when throwing exception", {
    resource <- new Resource()

    (fun () -> cleanupDisposablesWhenThrowingException resource |> ignore) |> should throw typeof<Exception>
    expect_equal(resource.Disposed(), true)