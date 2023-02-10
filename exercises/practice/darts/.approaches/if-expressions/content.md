# `if` expressions

```fsharp
module Darts

open System

let score (x: double) (y: double): int =
    let distance = Math.Sqrt(x * x + y * y)

    if   distance <=  1.0 then 10
    elif distance <=  5.0 then  5
    elif distance <= 10.0 then  1
    else 0
```

The first step is to calculate the distance from the center of the board, which we can with the [cartesian coordinates distance formula][distance-formula]

```fsharp
let distance = Math.Sqrt(x * x + y * y)
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
if   distance <= 1.0 then 10
elif distance > 1.0 && distance <=  5.0 then 5
elif distance > 5.0 && distance <= 10.0 then 1
else 0
```

However, due to the order of evaluation, we know in our second condition, `distance > 1.0` must always `true` as otherwise `distance <= 1.0` would have been `true`.
The same reasoning applies to the `distandistance > 5.0` condition.
We can thus shorten our code to:

```fsharp
if   distance <=  1.0 then 10
elif distance <=  5.0 then  5
elif distance <= 10.0 then  1
else 0
```

[distance-formula]: https://www.thoughtco.com/understanding-the-distance-formula-2312242
