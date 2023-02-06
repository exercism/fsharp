# Introduction

The key to this exercise is to decide how to represent a robot and then to update it.

## General guidance

- The idiomatic way to represent the robot is to use immutable data
- A `string` can be treated as a `char seq`

## Approach: fold

```fsharp
type Robot = Robot of direction: Direction * position: Position

let create (direction: Direction) (position: Position): Robot =
    Robot(direction, position)

let move (instructions: string) (robot: Robot): Robot =
    let doMove (robot: Robot) (instruction: char): Robot =
        match instruction with
        | 'L' -> turnLeft robot
        | 'R' -> turnRight robot
        | 'A' -> advance robot
        | _   -> failwith "Invalid instruction"

    Seq.fold doMove robot instructions
```

This approach uses [`Seq.fold`][seq.fold] to simulate the robot's movements.
For more information, check the [fold approach][approach-fold].

## Approach: recursion

```fsharp
type Robot = Robot of direction: Direction * position: Position

let create (direction: Direction) (position: Position): Robot =
    Robot(direction, position)

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

This approach uses recursion to simulate the robot's movements.
For more information, check the [recursion approach][approach-recursion].

## Which approach to use?

Both approaches are valid, but it is more idiomatic to use the [fold approach][approach-fold].

[approach-recursion]: https://exercism.org/tracks/fsharp/exercises/robot-simulator/approaches/recursion
[approach-fold]: https://exercism.org/tracks/fsharp/exercises/robot-simulator/approaches/fold
[seq.fold]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#fold
