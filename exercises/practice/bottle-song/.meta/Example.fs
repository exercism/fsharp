module BottleSong

let private counts =
    [| "no"
       "one"
       "two"
       "three"
       "four"
       "five"
       "six"
       "seven"
       "eight"
       "nine"
       "ten" |]

let private capitalize (s: string) =  $"{System.Char.ToUpper(s[0])}{s[1..]}"

let private bottles n = if n = 1 then "bottle" else "bottles"

let private verse bottleCount =
    [ $"{counts[bottleCount] |> capitalize} green {bottles bottleCount} hanging on the wall,"
      $"{counts[bottleCount] |> capitalize} green {bottles bottleCount} hanging on the wall,"
      $"And if one green {bottles 1} should accidentally fall,"
      $"There'll be {counts[bottleCount - 1]} green {bottles (bottleCount - 1)} hanging on the wall." ]

let recite startBottles takeDown =
    [ startBottles .. -1 .. (startBottles - takeDown + 1) ]
    |> List.map verse
    |> List.reduce (fun x y -> x @ "" :: y)
