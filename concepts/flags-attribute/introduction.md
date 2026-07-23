# Introduction

A common way to use discriminated union type in F# is to represent a fixed set of named constants -- a structure called an "enum" in other languages.

Normally, in such a discriminated union, each case can only refer to exactly one of those named constants.
However, sometimes it is useful to refer to more than one constant.
To do so, one can annotate the discriminated union with the Flags attribute.

A discriminated union with the Flags attribute can be defined as follows (using binary integer notation 0b):

```fsharp
[<Flags>]
type PhoneFeatures =
| Call = 0b00000001
| Text = 0b00000010
```

A `PhoneFeatures` instance with the value 0b00000011 has both its Call and Text flags set.
