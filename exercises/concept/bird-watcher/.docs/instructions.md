# Instructions

You're an avid bird watcher that keeps track of how many birds have visited your garden in the last seven days.

You have six tasks, all dealing with the numbers of birds that visited your garden.

## 1. Check what the counts were last week

For comparison purposes, you always keep a copy of last week's counts nearby, which were: 0, 2, 5, 3, 7, 8, and 4. Define the `lastWeek` binding that contains last week's counts:

```fsharp
lastWeek
// => [| 0; 2; 5; 3; 7; 8; 4 |]
```

## 2. Check how many birds visited yesterday

Implement the `yesterday` function to return how many birds visited your garden yesterday. The bird counts are ordered by day, with the first element being the count of the oldest day, and the last element being today's count.

```fsharp
yesterday [| 3; 5; 0; 7; 4; 1 |]
// => 4
```

## 3. Calculate the total number of visiting birds

Implement the `total` function to return the total number of birds that have visited your garden:

```fsharp
total [| 3; 5; 0; 7; 4; 1 |]
// => 20
```

## 4. Check if there was a day with no visiting birds

Implement the `dayWithoutBirds` function that returns `true` if there was a day at which zero birds visited the garden; otherwise, return `false`:

```fsharp
dayWithoutBirds [| 3; 5; 0; 7; 4; 1 |]
// => true
```

## 5. Increment today's count

Implement the `incrementTodaysCount` function to increment today's count and return the updated counts:

```fsharp
let birdCount = [| 3; 5; 0; 7; 4; 1 |]
incrementTodaysCount birdCount
// => [| 3; 5; 0; 7; 4; 2 |]
```

## 6. Check for odd week

Over the last year, you've found that some weeks have the same, odd patterns:
- On each even day of the week, there were no birds
- On each even day of the week, exactly 10 birds were spotted
- On each odd day of the week, exactly 5 birds were spotted

Implement the `oddWeek` function that returns `true` if the bird count pattern of this week matches one of the odd patterns:

```fsharp
oddWeek [| 1; 0; 5; 0; 12; 0; 2 |]
// => true

oddWeek [| 5; 0; 5; 12; 5; 3; 5|]
// => true
```
 
