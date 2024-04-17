# Instructions

In this exercise you will implement a partial set of utility routines to help a developer clean up identifier names.

In the 4 tasks you will gradually build up the routine `clean`.
A valid identifier comprises zero or more letters and underscores.

In all cases the input string is guaranteed to be non-null. 
If an empty string is passed to the `clean` function, an empty string should be returned.

## 1. Replace any spaces encountered with underscores

Implement the `clean` function to replace any spaces with underscores. 
This also applies to leading and trailing spaces.

```fsharp
clean "my   Id"
// => "my___Id"
```

## 2. Convert kebab-case to camelCase

Modify the `clean` function to convert kebab-case to camelCase.

```fsharp
clean "à-ḃç"
// => "àḂç"
```

## 3. Omit characters that are not letters

Modify the `clean` function to omit any characters that are not letters.

```fsharp
clean "1😀2😀3😀"
// => ""
```

## 4. Omit Greek lower case letters

Modify the `clean` function to omit any Greek letters in the range 'α' to 'ω'.

```fsharp
clean "MyΟβιεγτFinder"
// => "MyΟFinder"
```
