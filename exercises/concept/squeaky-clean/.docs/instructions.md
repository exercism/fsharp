# Instructions

In this exercise you will implement a partial set of utility routines to help a developer clean up identifier names.

In the 4 tasks you will gradually build up the routine `clean`.
A valid identifier comprises zero or more letters and underscores.

In all cases the input string is guaranteed to be non-null. 
If an empty string is passed to the `clean` function, an empty string should be returned.

## 1. Replace any hyphens encountered with underscores

Implement the `clean` function to replace any hyphens with underscores.

```fsharp
clean "my-Id"  // => "my_Id"
```

## 2. Remove all whitespace

Remove all whitepace characters.
This includes leading and trailing whitespace.

```fsharp
clean " my Id   "  // => "myId"
```

## 3. Convert camelCase to kebab-case

Modify the `clean` function to convert camelCase to kebab-case

```fsharp
clean "àḂç"  // => "à-ḃç"
```

## 4. Omit characters that are digits

Modify the `clean` function to omit any characters that are numeric.

```fsharp
clean "x1😀2😀3😀"  // => "x😀😀😀"
```

## 5. Replace Greek lower case letters with question marks

Modify the `clean` function to replace any Greek letters in the range 'α' to 'ω'.

```fsharp
clean "MyΟβιεγτFinder"  // => "MyΟ?????Finder"
```


## Assembling a string from characters

This topic will be covered in detail later in the syllabus.

For now, it may be useful to know that there is a [higher order function][higher-order-function] called [`String.collect`][string-collect] that converts a collection of `char`s to a string, using a function that you supply.

```fsharp
let transform ch = $"{ch}_"
String.collect transform "abc"  // =>  "a_b_c_"
```


[higher-order-function]: https://exercism.org/tracks/fsharp/concepts/higher-order-functions
[string-collect]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-stringmodule.html#collect