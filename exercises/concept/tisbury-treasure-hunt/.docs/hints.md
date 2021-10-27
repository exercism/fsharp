# Hints

## General

- [Tuples](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples) are immutable grouping of unnamed but ordered values, possibly of different types.
- Elements within tuples can be [obtained](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples#obtaining-individual-values) via pattern matching, tuple deconstruction or using helper functions.

## 1. Extract coordinates

- Remember: tuples allow access using helper functions or deconstruction.
- Check [parsing](https://docs.microsoft.com/en-us/dotnet/api/system.int32.parse?view=net-5.0) in order to get number from string.

## 2. Format coordinates

- Check [examples](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples#examples) for more details on tuples creation.
- Check [string slicing](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/strings#string-indexing-and-slicing) for more details on strings.

## 3. Match coordinates

- What operators could be used here for for [testing membership](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/strings#string-indexing-and-slicing)?
- Could you re-use your `convertCoordinate()` function?

## 4. Combine matched records

- Remember that tuples support [pattern matching](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples#obtaining-individual-values).
- Could you re-use your `compareRecords()` function here?
