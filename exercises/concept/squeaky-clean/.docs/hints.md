# Hints

## 1. Replace any spaces encountered with underscores

- [Reference documentation][char-docs] for `char`s is here.
- You can retrieve `char`s from a string in the same way as elements from an array, though in this exercise it may be better to use a higher order function such as `String.collect`.
- `char` literals are enclosed in single quotes.

## 2. Remove all whitespace

- See [this method][iswhitespace] for detecting spaces and [this method][isnumber] for digits.

## 3. Convert camel-case to kebab-case

- See [this method][tolower] to convert a character to lower case.

## 5. Omit Greek lower case letters

- `char`s support the default equality and comparison operators.

[char-docs]: https://learn.microsoft.com/en-us/dotnet/api/system.char
[iswhitespace]: https://docs.microsoft.com/en-us/dotnet/api/system.char.iswhitespace
[isnumber]: https://docs.microsoft.com/en-us/dotnet/api/system.char.isnumber
[tolower]: https://docs.microsoft.com/en-us/dotnet/api/system.char.tolower
