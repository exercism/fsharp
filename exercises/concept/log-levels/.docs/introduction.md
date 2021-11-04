# Introduction

A `string` in F# is an object that represents immutable text as a sequence of Unicode characters (letters, digits, punctuation, etc.) and is defined as follows:

```fsharp
let fruit = "Apple"
```

Strings are manipulated by either calling the string's methods, or using the `String` module's functions. Once a string has been constructed, its value can never change. Any methods/functions that appear to modify a string will actually return a new string.

Strings can be concatenated or formatted a few different ways.
* You can use the `+` operator for concatenation:
```fsharp
let sentence = "Apple" + " is a type of fruit."
```
* You can use the [sprintf function](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/plaintext-formatting#checking-of-printf-format-strings) for formatting text, where you have placeholders in a format text (`%s` for a `string`) and provide the values as arguments:
```fsharp
let sentence = sprintf "%s is a type of %s." "Apple" "fruit"
```