# Introduction

The Flags attribute allows the values defined in a discriminated union to be represented as bit positions (i.e. flags).
As flags, such values can be combined, making it possible for multiple boolean conditions to be represented in a single value.

```fsharp
[<Flags>]
type PhoneFeatures =
| Call = 1
| Text = 2
```

```fsharp
[<Flags>]
type PhoneFeaturesBinary =
| Call = 0b00000001
| Text = 0b00000010
```

Setting a flag can be done with the bitwise OR operator (`|||`); unsetting a flag can be done with a combination of the bitwise AND operator (`&&&`) and the bitwise negation operator (`~~~`).
While checking flag's state can be done with the bitwise AND operator, one can also use the HasFlag() method.

```fsharp
let features = PhoneFeatures.Call

// Set the Text flag
let moreFeatures = features ||| PhoneFeatures.Text

moreFeatures.HasFlag(PhoneFeatures.Call) // => true
moreFeatures.HasFlag(PhoneFeatures.Text) // => true

// Unset the Call flag
let lessFeatures = features &&& ~~~PhoneFeatures.Call

lessFeatures.HasFlag(PhoneFeatures.Call) // => false
lessFeatures.HasFlag(PhoneFeatures.Text) // => true
```

See [Summary of Bitwise Operators][bitwise-operators] for a complete list of the bitwise operators available in the F# language.

[bitwise-operators]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/bitwise-operators#summary-of-bitwise-operators
