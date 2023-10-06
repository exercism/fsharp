# Active Patterns

```fsharp
module Bob

let (|Silence|_|) (phrase: string): unit option =
    if System.String.IsNullOrWhiteSpace(phrase) then Some () else None

let (|Yell|_|) (phrase: string): unit option =
    if phrase <> phrase.ToLower() && phrase = phrase.ToUpper() then Some () else None

let (|Question|_|) (phrase: string): unit option =
    if phrase.TrimEnd().EndsWith("?") then Some () else None

let response (phrase: string): string =
    match phrase with
    | Silence         -> "Fine. Be that way!"
    | Yell & Question -> "Calm down, I know what I'm doing!"
    | Yell            -> "Whoa, chill out!"
    | Question        -> "Sure."
    | _               -> "Whatever."
```

## What are Active Patterns?

[Active patterns][active-patterns] are used in pattern matching and can be used to categorize input and/or extract data from input.

There are two types of active patterns:

- Regular active patterns: these patterns will match any input
- Partial active patterns: these pattern will match some inputs, but not all

If we apply this to the exercise, we see that we have three patterns:

- The phrase is a question
- The phrase is a yell
- The phrase is silence

All three of these patterns must be partial, because they only match on some inputs, not all.

## Handling the different responses

We start out with a function named `response` that takes a `string` as its sole parameter and returns a `string`:

```fsharp
let response (phrase: string): string
```

### Response for silence

If the input is an empty string (signifying silence), the response should be `"Fine. Be that way!"`.
Let's define a `Silence` partial active pattern that takes the phrase as its parameter:

```fsharp
let (|Silence|_|) (phrase: string): unit option =
```

We are returning an `unit option` type, which signifies two things:

- The `option` part indicates if the input matched the pattern (`Some` means it did, `None` means it didn't)
- Te `unit` part indicates that the pattern does extract/return any information from the input; think of this pattern as being a boolean pattern (either is matches, or it doesn't)

We then need to determine if the input phrase is an empty string and return `Some ()` if it is, and `None` if it isn't.
We can check for an empty string via the built-in [`String.IsNullOrWhiteSpace()`][string.isnullorwhitespace] method:

```fsharp
if System.String.IsNullOrWhiteSpace(phrase) then Some () else None
```

~~~~exercism/note
We opted for using `System.String`, but another option would be to open the `System` namespace and then we could omit the `System.` prefix for the `String.IsNullOrWhiteSpace` call:

```fsharp
open System

let isEmpty = String.IsNullOrWhiteSpace(phrase)
```

If you were to use multiple types from the `System` namespace, we'd recommend using the above approach where the namespace is explicitly opened.
~~~~

Now that we can determine whether a phrase is empty, we can use this pattern in the `response` function:

```fsharp
match phrase with
| Silence -> "Fine. Be that way!"
```

Nice! Let's move on to the next type of phrase.

### Response for yell

If the input's letters are all in uppercase, and there is at least one letter, then the phrase is considered to be a yell.
We can check if calling [`ToUpper()`][string.toupper] on the phrase doesn't introduce any changes, which means that every letter was already in uppercase.
However, it could be that there weren't any letters, so to handle that we can use [`ToLower()`][string.tolower], and see if that is not equal to the phrase (which means that there _were_ uppercase letters).

The active pattern looks like this:

```fsharp
let (|Yell|_|) (phrase: string): unit option =
    if phrase <> phrase.ToLower() && phrase = phrase.ToUpper() then Some () else None
```

The correct response can be returned via:

```fsharp
match phrase with
| Yell -> "Whoa, chill out!"
```

### Response for question

If the input ends with a question mark, it is considered to be a question.
Let's define a `Question` active pattern and use the [`EndsWith()`][string.endswith] method to check for ending with a question mark:

```fsharp
let (|Question|_|) (phrase: string): unit option =
    if phrase.EndsWith("?") then Some () else None
```

This doesn't pass all the tests though, as we need to ignore any trailing white space.
The fix for that is easy: first remove the trailing white space using [`TrimEnd()`][string.endswith]:

```fsharp
if phrase.TrimEnd().EndsWith("?") then Some () else None
```

The correct response can then be returned via:

```fsharp
match phrase with
| Question -> "Sure."
```

### Response for yelled question

Due to the fact that we have defined patterns for a yell (`Yell`) and question (`Question`), we can use the `&` keyword to check for two patterns matching at the same time:

```fsharp
match phrase with
| Yell & Question -> "Calm down, I know what I'm doing!"

```

Note that we need to check this _before_ checking of the yell or question responses, as otherwise this will never run.

### Default response

Finally, we'll need to return the default response, which we can do via:

```fsharp
match phrase with
| _ -> "Whatever."
```

## Putting it all together

Putting our active patterns together gives us the following code:

```fsharp
match phrase with
| Silence -> "Fine. Be that way!"
| Yell & Question -> "Calm down, I know what I'm doing!"
| Yell -> "Whoa, chill out!"
| Question-> "Sure."
| _  -> "Whatever."
```

### Alignment

While definitely not needed, aligning the code vertically could help with readability:

```fsharp
match phrase with
| Silence         -> "Fine. Be that way!"
| Yell & Question -> "Calm down, I know what I'm doing!"
| Yell            -> "Whoa, chill out!"
| Question        -> "Sure."
| _               -> "Whatever."
```

~~~~exercism/note
A downside of vertical alignment is that changes to the code require more work, as you'll need to ensure everything is still aligned.
For this particular case, it isn't really an issue, as the spec is fixed and the code is thus unlikely to change.
~~~~

### Final code

And with that, we have an implementation of the `response` function that passes all the tests:

```fsharp
let response (phrase: string): string =
    match phrase with
    | Silence         -> "Fine. Be that way!"
    | Yell & Question -> "Calm down, I know what I'm doing!"
    | Yell            -> "Whoa, chill out!"
    | Question        -> "Sure."
    | _               -> "Whatever."
```

[active-patterns]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns
[string.isnullorwhitespace]: https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace
[string.tolower]: https://learn.microsoft.com/en-us/dotnet/api/system.string.tolower
[string.toupper]: https://learn.microsoft.com/en-us/dotnet/api/system.string.toupper
[string.trimend]: https://learn.microsoft.com/en-us/dotnet/api/system.string.trimend
[string.endswith]: https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith
