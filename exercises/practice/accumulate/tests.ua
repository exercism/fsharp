// This file was created manually and its version is 2.0.0

~ "accumulate.ua" ~ Accumulate
reverse (str:string) = new string(str.ToCharArray() |> Array.rev)

# Empty accumulation produces empty accumulation
⍤⤙≍ [] accumulate (fun x -> x + 1) List.empty

# Identity accumulation returns unmodified list
⍤⤙≍ [1 2 3] accumulate id [1 2 3]

# Accumulate squares
⍤⤙≍ [1 4 9] accumulate (fun x -> x * x) [1 2 3]

# Accumulate upcases
    accumulate (fun (x:string) -> x.ToUpper()) ["hello" "world"]
⍤⤙≍ ["HELLO" "WORLD"]  

# Accumulate reversed strings
    accumulate reverse (List.ofArray ("the quick brown fox etc".Split(' ')))
⍤⤙≍ (List.ofArray("eht kciuq nworb xof cte".Split(' ')))  

# Accumulate within accumulate
    accumulate (fun (x:string) -> String.concat " " (accumulate (fun y -> x + y) ["1" "2" "3"])) ["a" "b" "c"]
⍤⤙≍ ["a1 a2 a3" "b1 b2 b3" "c1 c2 c3"]  

# Accumulate large data set without stack overflow
    accumulate id [1..100000]
⍤⤙≍ [1..100000]  
