# `if` expressions

```fsharp
module Bob

let response (phrase: string): string =
    let isEmpty = System.String.IsNullOrWhiteSpace(phrase)
    let isYell = phrase <> phrase.ToLower() && phrase = phrase.ToUpper()
    let isQuestion = phrase.TrimEnd().EndsWith("?")

    if isEmpty then "Fine. Be that way!"
    elif isYell && isQuestion then "Calm down, I know what I'm doing!"
    elif isYell then "Whoa, chill out!"
    elif isQuestion then "Sure."
    else "Whatever."
```

## Handling the different responses

We start out with a function named `response` that takes a `string` as its sole parameter and returns a `string`:

```fsharp
let response (phrase: string): string
```

### Response for silence

If the input is an empty string (signifying silence), the response should be `"Fine. Be that way!"`.
To check this, we can use the built-in [`String.IsNullOrWhiteSpace()`][string.isnullorwhitespace] method:

```fsharp
let isEmpty = System.String.IsNullOrWhiteSpace(phrase)
```

~~~~exercism/note
We opted for using `System.String`, but another option would be to open the `System` namespace and then we could omit the `System.` prefix for the `String.IsNullOrWhiteSpace` call:

```fsharp
open System

let isEmpty = String.IsNullOrWhiteSpace(phrase)
```

If you were to use multiple types from the `System` namespace, we'd recommend using the above approach where the namespace is explicitly opened.
~~~~

Now that we can determine whether a phrase is empty, we can return the proper response using an [`if` expression][if-expressions]:

```fsharp
if isEmpty then
    "Fine. Be that way!"
```

Nice! Let's move on to the next type of phrase.

### Response for yell

If the input's letters are all in uppercase, and there is at least one letter, then the phrase is considered to be a yell.
We can check if calling [`ToUpper()`][string.toupper] on the phrase doesn't introduce any changes, which means that every letter was already in uppercase.
However, it could be that there weren't any letters, so to handle that we can use [`ToLower()`][string.tolower], and see if that is not equal to the phrase (which means that there _were_ uppercase letters):

```fsharp
let isYell = phrase <> phrase.ToLower() && phrase = phrase.ToUpper()
```

The correct response can be returned via:

```fsharp
elif isYell then
    "Whoa, chill out!"
```

### Response for question

If the input ends with a question mark, it is considered to be a question.
We can use the [`EndsWith()`][string.endswith] method for that:

```fsharp
let isQuestion = phrase.EndsWith("?")
```

This doesn't pass all the tests though, as we need to ignore any trailing white space.
The fix for that is easy: first remove the trailing white space using [`TrimEnd()`][string.endswith]:

```fsharp
let isQuestion = phrase.TrimEnd().EndsWith("?")
```

The correct response can then be returned via:

```fsharp
elif isQuestion then
    "Sure."
```

### Response for yelled question

Due to the fact that we have separate `isYell` and `isQuestion` bindings, checking for a yelled question is a simple as:

```fsharp
elif isYell && isQuestion then
    "Calm down, I know what I'm doing!"
```

Note that we need to check this _before_ checking of the yell or question responses, as otherwise this will never match.

### Default response

Finally, we'll need to return the default response, which we can do via:

```fsharp
else "Whatever."
```

## Putting it all together

Putting our `if/elif/else` together gives us the following code:

```fsharp
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

### Shortening

We can shorten this code a bit by putting the returned `string` values on the same line as the `if/elif/else` keywords:

```fsharp
if isEmpty then "Fine. Be that way!"
elif isYell && isQuestion then "Calm down, I know what I'm doing!"
elif isYell then "Whoa, chill out!"
elif isQuestion then "Sure."
else "Whatever."
```

### Final code

And with that, we have an implementation of the `response` function that passes all the tests:

```fsharp
let response (phrase: string): string =
    let isEmpty = System.String.IsNullOrWhiteSpace(phrase)
    let isYell = phrase <> phrase.ToLower() && phrase = phrase.ToUpper()
    let isQuestion = phrase.TrimEnd().EndsWith("?")

    if isEmpty then "Fine. Be that way!"
    elif isYell && isQuestion then "Calm down, I know what I'm doing!"
    elif isYell then "Whoa, chill out!"
    elif isQuestion then "Sure."
    else "Whatever."
```

~~~~exercism/note
We've defined the `isEmpty`, `isYell` and `isQuestion` bindings within the `response` function, as they're only used within that function.
~~~~

[if-expressions]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/conditional-expressions-if-then-else
[string.isnullorwhitespace]: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace
[string.tolower]: https://learn.microsoft.com/en-us/dotnet/api/system.string.tolower
[string.toupper]: https://learn.microsoft.com/en-us/dotnet/api/system.string.toupper
[string.trimend]: https://learn.microsoft.com/en-us/dotnet/api/system.string.trimend
[string.endswith]: https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith
