# Hints

## 1. Introduce yourself

The `introduce` function must "unwrap" the value contained in `player.Name`.
Consider using the [`Options.defaultValue` function][defaultvalue] to convert `player.Name` to its "wrapped" value when it is `Some` or the required default value when it is `None`.

## 2. Implement the revive mechanic

The `revive` function must return either `Some <player>` or `None`, where `<player>` is a `Player` record possibly with some modified fields.

## 3. Implement the spell casting mechanic

Consider using a match expression to cover both the `Some` and `None` cases, as in the following example:

```fsharp
let exists (x: Option<int>) =
    match x with
    | Some n -> true
    | None -> false
```

[defaultvalue]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/options#converting-options-with-default-values
