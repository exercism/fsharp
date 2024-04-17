# Hints

## 1. Replace any spaces encountered with underscores

- [Reference documentation][char-docs] for `char`s is here.
- You can retrieve `char`s from a string in the same way as elements from an array, though in this exercise it may be better to convert to a list or array first.
- Using a [`StringBuilder`][string-builder] to build the output string is in general preferred, but [`String.Concat`][string-concat] is entirely adequate for these short strings.
- See [this method][iswhitespace] for detecting spaces.
- `char` literals are enclosed in single quotes.

## 2. Convert kebab-case to camel-case

- See [this method][toupper] to convert a character to upper case.

## 4. Omit Greek lower case letters

- `char`s support the default equality and comparison operators.

[char-docs]: https://learn.microsoft.com/en-us/dotnet/api/system.char
[chars-tutorial]: https://csharp.net-tutorials.com/data-types/the-char-type/
[string-builder]: https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder
[string-concat]: https://learn.microsoft.com/en-us/dotnet/api/system.string.concat
[iswhitespace]: https://docs.microsoft.com/en-us/dotnet/api/system.char.iswhitespace
[iscontrol]: https://docs.microsoft.com/en-us/dotnet/api/system.char.iscontrol
[toupper]: https://docs.microsoft.com/en-us/dotnet/api/system.char.toupper
[equality]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators
[comparison]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/comparison-operators
