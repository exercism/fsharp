# About

The `Result` type makes it possible for a function to return a single value indicating all of the following things:
- Whether the operation succeeded or failed
- On success, the resulting value of the operation
- On failure, the reason for the failure

With other programming languages that don't support something like a `Result` type, it is common to find the following patterns to accomplish the aforementioned goals:
- A function returning a numeric code indicating success or the reason for the failure and requiring an output parameter to accept the value on success.
- A function returning the value on success or NULL on error, and then a different function to get the error code indicating the reason for the failure.

Another common error-handling mechanism is the exception, which abruptly breaks out of the current function and
transfers control to the first handler in the call stack when a failure occurs.  
If no handler "catches" the exception, then the program aborts.

## Benefits of using the `Result` type

* __Compile-time safety__: By making the success or failure of a function call explicit in the type system, the compiler can ensure that calling code handles all of the failure cases, preventing a large category of bugs that could occur with nulls.

* __Run-time safety__: Instead of using `null`, the `Result` type uses `Error` represent a failure, making it impossible for a `NullReferenceException` to occur.

* __Explicit error handling__: Code that calls a function returning a `Result` must acknowledge that the
call can fail; calling code must handle such failures intentionally.  There are oo silent failures and no surprise exceptions.

* __Predictable control flow__: A `Result` is returned just like any other value; it does not jump out of the call stack like an exception.  You always know where errors originate and how they propagate.

* __Improved readability and maintainability__: By returning a `Result`, a function's signature clearly indicates the expected behavior on success and failure.

## Usage

The `Result` type is a generic type containing two underlying types:
- The type of the resultant value on a successful operation
- The type representing the reason for the failure on a failure

The `Result` type is also a [discriminated union][discriminated-union] with the following possible cases:
* `Ok <value>` representing a successful result
* `Error <reason>` representing a failure

The following function demonstrates how to create a `Result` value:

```fsharp
let validateName (name: string) : Result<string, string> = 
    match name with
    | null -> Error "Name not found."
    | "" -> Error "Name is empty."
    | _ -> Ok name
```

In this example, the `Ok` value is a string (the given name), and the `Error` value is also a string (the cause of the error, in human-readable form).

## Reading the content of a `Result` value

Consider the following type definition and function signature:

```
type FileOpenError = 
| NotFound
| AccessDenied
| FileLocked

let openFile (filename: string) : Result<int, FileOpenError> =
```

Code that calls the `openFile` function can use pattern matching to handle the success and failure cases, as in the following example:

```fsharp
match openFile(filename) with
| Ok handle -> doSomethingWithFile(handle)
| Error NotFound -> printfn $"Error: file {filename} was not found."
| Error AccessDenied -> printfn $"Error: you do not have permission to open the file {filename}."
| Error FileLocked -> printfn $"Error: file {filename} is already in use."
```

[discriminated-union]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions
