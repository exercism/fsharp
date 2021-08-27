# Introduction

The most common way to conditionally execute code in F# is by using an `if/elif/else` expression:

```fsharp
if x = 5 then
    // Expression to evaluate when x equals 5
elif x > 7 then
    // Expression to evaluate when x greater than 7
else
    // Expression to evaluate in all other cases
```

The condition(s) used in an `if/elif/else` expression must be of type `bool`. F# has no concept of _truthy_ values.
