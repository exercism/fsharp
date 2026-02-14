# Introduction

The `Result` type makes it possible for a function to return a single value indicating all of the following things:
- Whether the operation succeeded or failed
- On success, the resulting value of the operation
- On failure, the reason for the failure

## Usage

The `Result` type is a generic type containing two underlying types:
- The type of the resultant value on a successful operation
- The type of error on a failure

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
