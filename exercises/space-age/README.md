# Space Age

Given an age in seconds, calculate how old someone would be on:

   - Earth: orbital period 365.25 Earth days, or 31557600 seconds
   - Mercury: orbital period 0.2408467 Earth years
   - Venus: orbital period 0.61519726 Earth years
   - Mars: orbital period 1.8808158 Earth years
   - Jupiter: orbital period 11.862615 Earth years
   - Saturn: orbital period 29.447498 Earth years
   - Uranus: orbital period 84.016846 Earth years
   - Neptune: orbital period 164.79132 Earth years

So if you were told someone were 1,000,000,000 seconds old, you should
be able to say that they're 31.69 Earth-years old.

If you're wondering why Pluto didn't make the cut, go watch [this
youtube video](http://www.youtube.com/watch?v=Z_2gbGXzFbs).

## Hints
- Try to focus on minimizing the amount of code duplication. If you find yourself doing a lot of copy/paste take a step back and think about how the code can be refactored
- [Pattern matching](https://fsharpforfunandprofit.com/posts/match-expression/) is more idiomatic than using dictionaries to translate values

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

## Further information

For more detailed information about the F# track, including how to get help if
you're having trouble, please visit the exercism.io [F# language page](http://exercism.io/languages/fsharp/resources).

## Source

Partially inspired by Chapter 1 in Chris Pine's online Learn to Program tutorial. [http://pine.fm/LearnToProgram/?Chapter=01](http://pine.fm/LearnToProgram/?Chapter=01)

