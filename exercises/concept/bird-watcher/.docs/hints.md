# Hints

## General

- The bird counts arrays always contain exactly 7 integers.

## 1. Check what the counts were last week

- There are [several ways to define an array][creating-arrays].

## 2. Check how many birds visited yesterday

- Remember that the counts are ordered by day from oldest to most recent, with the last element representing today.
- Accessing the second last element can be done either by using its (fixed) index (remember to start counting from zero) or by calculating its index using the array's length, either through a [function in the `Array` module][length-function] or by accessing one of the array's [properties][length-property].

## 3. Calculate the total number of visiting birds

- The `Array` module has a [function to sum the values of an array][sum-function].

## 4. Check if there was a day with no visiting birds

- The `Array` module has a [function to check if an array contains a specific value][contains-function].

## 5. Increment today's count

- There are two ways to update a value in an array:
  - The `<-` operator allows a value in an array to be updated.
  - The `Array` module has a [function to update a value in an array][set-function].
- The above function to update a value in an array does not return a value. You should thus manually return the updated array after setting its value.

## 6. Check for unusual week

- Instead of checking all individual values, use [pattern matching][pattern-matching-array].

[creating-arrays]: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/arrays#creating-arrays
[length-function]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#length
[length-property]: https://docs.microsoft.com/en-us/dotnet/api/system.array.length?redirectedfrom=MSDN&view=netcore-3.1#System_Array_Length
[sum-function]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#sum
[contains-function]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#contains
[set-function]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#set
[pattern-matching-array]: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/pattern-matching#array-pattern
