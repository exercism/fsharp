# Recursion

```fsharp
module RobotSimulator

type Direction = North | East | South | West
type Position = int * int

type Robot = Robot of direction: Direction * position: Position

let create (direction: Direction) (position: Position): Robot =
    Robot(direction, position)

let private turnLeft (Robot(direction, position)): Robot =
    match direction with
    | North -> Robot(West,  position)
    | East  -> Robot(North, position)
    | South -> Robot(East,  position)
    | West  -> Robot(South, position)

let private turnRight (Robot(direction, position)): Robot =
    match direction with
    | North -> Robot(East,  position)
    | East  -> Robot(South, position)
    | South -> Robot(West,  position)
    | West  -> Robot(North, position)

let private advance (Robot(direction, (x, y))): Robot =
    match direction with
    | North -> Robot(direction, (x    , y + 1))
    | East  -> Robot(direction, (x + 1, y    ))
    | South -> Robot(direction, (x    , y - 1))
    | West  -> Robot(direction, (x - 1, y    ))

let move (instructions: string) (robot: Robot): Robot =
    let rec applyInstruction (robot: Robot) (instructions: char list): Robot =
        match instructions with
        | [] -> robot
        | 'L' :: remainingInstructions -> applyInstruction (turnLeft robot) remainingInstructions
        | 'R' :: remainingInstructions -> applyInstruction (turnRight robot) remainingInstructions
        | 'A' :: remainingInstructions -> applyInstruction (advance robot) remainingInstructions
        | _   -> failwith "Invalid instruction"

    applyInstruction robot (Seq.toList instructions)
```

## Defining the `Robot` type

The first thing we need to do is to decide how we want to represent a robot.
Obviously, we'll need to keep track of the robot's direction and position (which types are already defined), but there are several options to choose from:

- A [discriminated union][discriminated-unions]
- A [record][records]
- A [tuple][tuples]
- A [class][class]

The class-based approach probably makes the least sense, as you'll likely have mutable state, which isn't the functional-first approach we're aiming for.

The other three are all valid, but let's go with a discriminated union.
It's main advantage of tuples is that you can associate names with its fields, and the advantage over records is that you could easily define different types of robots later on, if needed.

Here is what our type looks like:

```fsharp
type Robot = Robot of direction: Direction * position: Position
```

```exercism/note
Whilst not required, we name the fields of the discriminated union.
It is a good practice to do, as it can really help with readability.
```

## Creating a robot

Creating a robot is nothing more than passing the direction and position values to the `Robot` constructor:

```fsharp
let create (direction: Direction) (position: Position): Robot =
    Robot(direction, position)
```

## Turning

Two of the instructions we need to support turn the robot (left or right).
In both cases, we'll need to return a new robot with a different direction, but with the same position.
We'll use pattern matching on the direction and then call the `Robot` constructor with the updated values:

```fsharp
let private turnLeft (Robot(direction, position)): Robot =
    match direction with
    | North -> Robot(West,  position)
    | East  -> Robot(North, position)
    | South -> Robot(East,  position)
    | West  -> Robot(South, position)

let private turnRight (Robot(direction, position)): Robot =
    match direction with
    | North -> Robot(East,  position)
    | East  -> Robot(South, position)
    | South -> Robot(West,  position)
    | West  -> Robot(North, position)
```

Note that we deconstruct our `Robot` type's fields directly in the function parameter, which is a nice convenience.

## Advancing the robot

Advancing the robot changes its `x` or `y` position, but retains its direction.
Once again, we'll use pattern matching on the direction and then call the `Robot` constructor with the updated values:

```fsharp
let private advance (Robot(direction, (x, y))): Robot =
    match direction with
    | North -> Robot(direction, (x    , y + 1))
    | East  -> Robot(direction, (x + 1, y    ))
    | South -> Robot(direction, (x    , y - 1))
    | West  -> Robot(direction, (x - 1, y    ))
```

In case you missed it, we even deconstructed the nested position tuple directly within the parameter definition!

## Moving the robot

Finally, let's implement the logic to move the robot according to the instructions.
Let's define a recursive `doMove` function that takes a robot and an instruction, and returns an updated robot:

```fsharp
let rec doMove (robot: Robot) (instructions: char list): Robot =
    match instructions with
    | [] -> robot
    | 'L' :: remainingInstructions -> doMove (turnLeft robot)  remainingInstructions
    | 'R' :: remainingInstructions -> doMove (turnRight robot) remainingInstructions
    | 'A' :: remainingInstructions -> doMove (advance robot)   remainingInstructions
    | _   -> failwith "Invalid instruction"
```

We'll define this function within the `move` function (also known as a _nested_ function), but it could just as well have been defined outside the `move` function.

```exercism/note
To allow a function to recursively call itself, the `rec` modified must be added.
In other words: by default, functions cannot call themselves.
```

The first parameter of the `doMove` function is its _accumulator_ parameter: `robot`.
This parameter represents the current robot's state and is updated between the recursive function calls until we're done processing.
The second parameter contains the remaining instructions as a `char list`, which means that we'll be able to pattern match on it.

Within this function, we pattern match on the instructions

```fsharp
match instructions with
```

We first check to see if there are no remaining instructions, which means that we're done and we can return the robot:

```fsharp
| [] -> robot
```

The next three patterns map to the three instructions (left/right/advance):

```fsharp
| 'L' :: remainingInstructions -> doMove (turnLeft robot)  remainingInstructions
| 'R' :: remainingInstructions -> doMove (turnRight robot) remainingInstructions
| 'A' :: remainingInstructions -> doMove (advance robot)   remainingInstructions
```

We check to see if the first element in the list is an `'L'`, `'R'` or `'A'` character.
If it is, we recursively call `doMove`, but with a correctly updated robot (e.g. `(turnLeft robot)`) and the remaining instructions.
This will recursively apply the instructions, all whilst updating the robot.

Finally, we'll need to handle the case where we get an instruction that we don't support, in which case we'll just throw an exception:

```fsharp
| _ -> failwith "Invalid instruction"
```

## Putting it all together

The final step is to call our recursive helper function.
We'll use [`Seq.toList`][seq.tolist] to convert the string to `char list`, and pass in the `robot` parameter as its initial value:

```fsharp
doMove robot (Seq.toList instructions)
```

which gives us:

```fsharp
let move (instructions: string) (robot: Robot): Robot =
    let rec doMove (robot: Robot) (instructions: char list): Robot =
        match instructions with
        | [] -> robot
        | 'L' :: remainingInstructions -> doMove (turnLeft robot) remainingInstructions
        | 'R' :: remainingInstructions -> doMove (turnRight robot) remainingInstructions
        | 'A' :: remainingInstructions -> doMove (advance robot) remainingInstructions
        | _   -> failwith "Invalid instruction"

    doMove robot (Seq.toList instructions)
```

And with that, we can move our robot according to the specified instructions!

### Step-by-step execution

In case you're wondering how this recursive implementation works, consider the following example:

```fsharp
let robot = create Direction.North (0, 0)
move "RARA" robot
```

The robot starts facing north and is at position (0, 0).
These are the values of the `doMove` calls:

| Instructions           | Robot           | Returns         |
| ---------------------- | --------------- | --------------- |
| `['R'; 'A'; 'R'; 'A']` | `North, (0, 0)` | `East, (0, 0)`  |
| `['A'; 'R'; 'A']`      | `East, (0, 0)`  | `East, (1, 0)`  |
| `['R'; 'A']`           | `East, (1, 0)`  | `South, (1, 0)` |
| `['A']`                | `South, (1, 0)` | `South, (1, 1)` |
| `[]`                   | `South, (1, 1)` | `South, (1, 1)` |

## Alternative: using a tuple

If you'd like to be _really_ minimal, [tuples][tuples] could be used.
For convenience and readability, let's define a [type abbreviation][type-abbreviations]:

```fsharp
type Robot = Direction * Position
```

Then all we need to do is remove the `Robot()` wrappers:

```fsharp
let create (direction: Direction) (position: Position): Robot =
    (direction, position)

let private turnLeft (direction, position): Robot =
    match direction with
    | North -> (West,  position)
    | East  -> (North, position)
    | South -> (East,  position)
    | West  -> (South, position)

let private turnRight (direction, position): Robot =
    match direction with
    | North -> (East,  position)
    | East  -> (South, position)
    | South -> (West,  position)
    | West  -> (North, position)

let private advance (direction, (x, y)): Robot =
    match direction with
    | North -> (direction, (x    , y + 1))
    | East  -> (direction, (x + 1, y    ))
    | South -> (direction, (x    , y - 1))
    | West  -> (direction, (x - 1, y    ))
```

The rest of the code can be left unchanged.

## Alternative: using a record

Instead of using a discriminated union, one could also use a [record][records]:

```fsharp
type Robot = { direction: Direction; position: Position }
```

The `create` function then uses a [_record expression_][record-expressions] to create the record:

```fsharp
let create (direction: Direction) (position: Position): Robot =
    { direction = direction; position = position }
```

Like a discriminated union, records are immutable, which means that we'll need to return a new record each time we want to make a change.
For that, we'll use the [_copy and update record expressions_][record-expressions], which use the `with` keyword to make a copy of a record but with certain changes:

```fsharp
let private turnLeft (robot: Robot): Robot =
    match robot.direction with
    | North -> { robot with direction = West }
    | East  -> { robot with direction = North }
    | South -> { robot with direction = East }
    | West  -> { robot with direction = South }
```

We apply the same logic to the `turnRight` function:

```fsharp
let private turnRight (robot: Robot): Robot =
    match robot.direction with
    | North -> { robot with direction = East }
    | East  -> { robot with direction = South }
    | South -> { robot with direction = West }
    | West  -> { robot with direction = North }
```

And the last function to update is the `advance` function:

```fsharp
let private advance (robot: Robot): Robot =
    let x, y = robot.position

    match robot.direction with
    | North -> { robot with position = (x    , y + 1) }
    | East  -> { robot with position = (x + 1, y    ) }
    | South -> { robot with position = (x    , y - 1) }
    | West  -> { robot with position = (x - 1, y    ) }
```

The rest of the code can be left unchanged.

[records]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/records
[record-expressions]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/records#creating-records-by-using-record-expressions
[type-abbreviations]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/type-abbreviations
[discriminated-unions]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions
[classes]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/classes
[tuples]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples
[seq.fold]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#fold
