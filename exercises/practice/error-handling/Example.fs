module ErrorHandling

open System

type Result<'TSuccess, 'TError> =
    | Ok of 'TSuccess
    | Error of 'TError

let handleErrorByThrowingException() = failwith "An error occurred."

let handleErrorByReturningOption (input: string) = 
    match Int32.TryParse input with
    | true, value -> Some value
    | false, _ -> None

let handleErrorByReturningResult (input: string) = 
    match Int32.TryParse input with
    | true, value -> Ok value
    | false, _    -> Error "Could not convert input to integer"

let bind switchFunction twoTrackInput = 
    match twoTrackInput with
    | Ok s -> switchFunction s
    | Error f -> Error f

let cleanupDisposablesWhenThrowingException resource = 
    use r = resource
    failwith "Throw exception"