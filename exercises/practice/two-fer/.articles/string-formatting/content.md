# String formatting

There are various ways in which you can format the return string.

## Option 1: string interpolation

[String interpolation][string-interpolation] was introduced in F# 5.0 and is the most idiomatic way to build up a string with one more variable parts.

```fsharp
$"One for {name}, one for me.";
```

````exercism/note
It is possible to used typed interpolations, prefixing an interpolation with its type:

```fsharp
$"One for %s{name}, one for me.";
```

This allows the compiler to check at compile time if the passed-in value has the correct type.
````

## Option 2: string concatenation

As there are few variable parts in the returned string (just one), regular [string concatentation][string-concatenation] works well too:

```fsharp
"One for " + name + ", one for me.";
```

It is slightly more verbose than string interpolation, but still completely reasonable.

## Option 3: using `sprintf`

Before string interpolation was introduced in C# 5, [`sprintf`][sprintf] was the go-to option for dynamically formatting strings.

```fsharp
sprintf "One for %s, one for me.", name
```

```exercism/note
Unlike most other languages, a `sprintf` call in F# is type-checked at compile time, meaning you'll get a compile time error if you're passing in an incorrect value.
```

String interpolation is often preferred over `sprintf` for its conciseness, but `sprintf` does have the benefit of it being a function, for example enabling partial application.

## Conclusion

String interpolation is the preferred and idiomatic way to format strings, which used to be `sprintf` formatting.
String concatentation is absolutely a viable option too, as there is only one variable part.

[string-interpolation]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/interpolated-strings
[sprintf]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/plaintext-formatting
[string-concatenation]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/strings#string-operators
