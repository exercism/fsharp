# Instructions

Your task is to create a password checker.
A password checker validates a user's proposed password to ensure that it meets a set of requirements defined by the organization that controls access to the given resource.

For this exercise, the password requirements are:
* Must have 12 or more characters
* Must have at least one uppercase letter
* Must have at least one lowercase letter
* Must have at least one digit
* Must have at least one symbol in the set !@#$%^&*

Your solution must use a `Result` to encapsulate the success or failure status.
For the success case, the `Result` must convey the validated password as a string.
For the failure case, the `Result` must convey the rule that was violated in the failure case.

~~~~exercism/note
For this exercise, the password checker will be simplistic -- it will indicate only when a single rule has been violated.
A subsequent exercise will explore a more realistic password checker that can indicate when multiple rules have been violated at the same time.
~~~~

## 1. Implement the `checkPassword` function

The `checkPassword` function checks the given password against the aforementioned rules.  On failure, it indicates the rule that was violated by encapsulating one of the `PasswordRule` values within the result value.

```fsharp
checkPassword "abcdefghij5#"
// => Error MissingUppercaseLetter
```

## 2. Implement the ``getStatusMessage` function

The `getStatusMessage` function returns a string containing a human-readable message indicating the meaning of the result returned from `checkPassword`.

```fsharp
getStatusMessage (Error MissingDigit)
// => "Error: does not have at least one digit"
```
