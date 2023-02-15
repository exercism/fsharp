# `if` expressions

```fsharp
module Bob

let response (phrase: string): string =
    let isEmpty = System.String.IsNullOrWhiteSpace phrase
    let isYell = phrase <> phrase.ToLower() && phrase = phrase.ToUpper()
    let isQuestion = phrase.Trim().EndsWith "?"

    if isEmpty then
        "Fine. Be that way!"
    elif isYell && isQuestion then
        "Calm down, I know what I'm doing!"
    elif isYell then
        "Whoa, chill out!"
    elif isQuestion then
        "Sure."
    else
        "Whatever."
```

We start out with a function named `response` that takes a `string` as its sole parameter and returns a `string`:

```fsharp
let response (phrase: string): string
```

## Response for silence

If the input is an empty string (signifying silence), the response should be `"Fine. Be that way!"`.
To check this, we can use the built-in [`String.IsNullOrWhiteSpace()`][string.isnullorwhitespace] method:

```fsharp
let isEmpty = System.String.IsNullOrWhiteSpace phrase
```

````exercism/note
We opted for using `System.String`, but another option would be to open the `System` namespace and then we could omit the `System.` prefix for the `String.IsNullOrWhiteSpace` call:

```fsharp
open System

let isEmpty = String.IsNullOrWhiteSpace phrase
```

If you were to use multiple types from the `System` namespace, we'd recommend using the above approach where the namespace is explicitly opened.
````

Now that we can determine whether a phrase is empty, we can return the proper response using an [`if` expression][if-expressions]:

```fsharp
if isEmpty then
    "Fine. Be that way!"
```

Nice! Let's move on to the next type of phrase.

## Response for yell

If the input's letters are all in uppercase (and there is at least one letter), then the phrase is considered to be a yell.
We can check if calling `ToUpper()` on the phrase doesn't introduce any changes, which means that every letter was already in uppercase.
However, it could be that there weren't any letters, so to handle that we can use `ToLower()`, and see if that is not equal to the phrase:

```fsharp
let isYell = phrase <> phrase.ToLower() && phrase = phrase.ToUpper()
```

The correct response can be returned via:

```fsharp
elif isYell then
    "Whoa, chill out!"
```

## Response for question

TODO

## Response for yelled question

Due to the fact that we have separate `isYell` and `isQuestion` bindings, checking for a yelled question is a simple as:

```fsharp
elif isYell && isQuestion then
    "Calm down, I know what I'm doing!"
```

```exercism/note
TODO: explain why our separate `isYell` and `isQuestion` bindings are helpful here
```

## Default response

TODO

## Putting it all together

With that, we now have a working version of our Bob implementation using an `if/elif/else` expression:

```fsharp
let response (phrase: string): string =
    let isEmpty = System.String.IsNullOrWhiteSpace phrase
    let isYell = phrase <> phrase.ToLower() && phrase = phrase.ToUpper()
    let isQuestion = phrase.Trim().EndsWith "?"

    if isEmpty then
        "Fine. Be that way!"
    elif isYell && isQuestion then
        "Calm down, I know what I'm doing!"
    elif isYell then
        "Whoa, chill out!"
    elif isQuestion then
        "Sure."
    else
        "Whatever."
```

[if-expressions]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/conditional-expressions-if-then-else
[string.isnullorwhitespace]: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace
