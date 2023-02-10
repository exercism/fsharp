# Pattern matching

```fsharp
module Darts

open System

let score (x: double) (y: double): int =
    match Math.Sqrt(x * x + y * y) with
    | distance when distance <=  1.0 -> 10
    | distance when distance <=  5.0 ->  5
    | distance when distance <= 10.0 ->  1
    | _ -> 0
```

The first step is to calculate the distance from the center of the board, which we can with the [cartesian coordinates distance formula][distance-formula]:

```fsharp
Math.Sqrt(x * x + y * y)
```

```exercism/note
We open the `System` namespace to allows us to use `Math.Sqrt` instead of `System.Math.Sqrt`.
```

Before we'll look at the score calculation, let's re-iterate the games rules:

| Lands         | Distance                  | Points |
| ------------- | ------------------------- | ------ |
| Outside       | > 10 units                | 0      |
| Outer circle  | > 5 units and <= 10 units | 1      |
| Middle circle | > 1 unit and <= 5 units   | 5      |
| Inner circle  | <= 1 unit                 | 10     |

Directly translating this to code gives us:

```fsharp
match Math.Sqrt(x * x + y * y) with
| distance when distance <=  1.0 -> 10
| distance when distance > 1.0 && distance <= 5.0 ->  5
| distance when distance > 5.0 && <= 10.0 -> 1
| _ -> 0
```

However, due to the order of evaluation, we know in our second condition, `distance > 1.0` must always `true` as otherwise `distance <= 1.0` would have been `true`.
The same reasoning applies to the `distandistance > 5.0` condition.
We can thus shorten our code to:

```fsharp
match Math.Sqrt(x * x + y * y) with
| distance when distance <=  1.0 -> 10
| distance when distance <=  5.0 ->  5
| distance when distance <= 10.0 ->  1
| _ -> 0
```

[distance-formula]: https://www.thoughtco.com/understanding-the-distance-formula-2312242
