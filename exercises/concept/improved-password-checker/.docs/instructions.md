The goal of this exercise is to improve upon the Password Checker exercise.
Since a given password will likely violate more than one rule at a time, a useful password checker ought to communicate to the user all the rules that are violated, instead of just the first one that happens to be discovered.
The improved password checker should indicate all of the rules being violated by a given password in one go.

The rules for this password checker are the same as in the previous Password Checker exercise:

- Must have 12 or more characters
- Must have at least one uppercase letter
- Must have at least one lowercase letter
- Must have at least one digit
- Must have at least one symbol in the set !@#$%^&\*

Your solution must use a `Result` to encapsulate the success or failure status.
For the success case, the `Result` must convey the validated password as a string.
For the failure case, the `Result` must indicate all of the violated rules.

## 1. Modify the `PasswordError` discriminated union to allow the individual values to be treated as flags

Note that the tests will not compile until this essential step is complete.

## 2. Implement the `checkPassword` function

The `checkPassword` function checks the given password against the aforementioned rules.
The function should return a `Result` value, where `Ok` is returned when the password satisfies all rules, and an `Error` value when it fails one or more rules.
If multiple rules fail, the `PasswordError` value should represent all those failing rules.

```fsharp
checkPassword "abcdefghijk5"
// => Error (PasswordError.MissingUppercaseLetter ||| PasswordError.MissingSymbol)
```

## 3. Implement the ``getStatusPhrases` function

The `getStatusPhrases` function returns a set of strings each containing a human-readable phrase corresponding to one of the erorrs in the result returned from `checkPassword`.

```fsharp
getStatusPhrases (Error PasswordError.MissingDigit ||| PasswordError.LessThan12Characters)
// => Set ["12 characters"; "digit"]
```
