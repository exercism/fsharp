// This file was created manually and its version is 1.0.0.

module StrainTest


# Empty keep
⍤⤙≍ [] [] |> Seq.keep (fun x -> x < 10)

[<Fact(Skip = "Remove this Skip property to run this test")>]  
# Keep everything
⍤⤙≍ <| [1 2 3] set [1 2 3] |> Seq.keep (fun x -> x < 10) |> Seq.toList

[<Fact(Skip = "Remove this Skip property to run this test")>] 
# Keep first and last
⍤⤙≍ [1 3] [1 2 3 ] |> Seq.keep (fun x -> x % 2 <> 0) |> Seq.toList

# Keep neither first nor last
⍤⤙≍ [2 4] [1 2 3 4 5] |> Seq.keep (fun x -> x % 2 = 0) |> Seq.toList

# Keep strings
words = "apple zebra banana zombies cherimoya zelot".Split(' ');
⍤⤙≍ <| List.ofArray("zebra zombies zelot".Split(' ')) words |> Seq.keep (fun (x:string) -> x.StartsWith("z")) |> Seq.toList

# Keep arrays
actual =  [
                     [1 2 3 ];
                     [5 5 5 ];
                     [5 1 2 ];
                     [2 1 2 ];
                     [1 5 2 ];
                     [2 2 1 ];
                     [1 2 5 ]
                     ]
expected = [  [5 5 5 ]  [5 1 2 ]  [1 5 2 ]  [1 2 5 ] ]
⍤⤙≍ expected actual |> Seq.keep (Array.exists ((=) 5)) |> Seq.toList

# Empty discard
⍤⤙≍ [] [] |> Seq.discard (fun x -> x < 10)

# Discard nothing
⍤⤙≍ <| [1 2 3] set [1 2 3] |> Seq.discard (fun x -> x > 10) |> Seq.toList

# Discard first and last
⍤⤙≍ [2] [1 2 3 ] |> Seq.discard (fun x -> x % 2 <> 0) |> Seq.toList

# Discard neither first nor last
⍤⤙≍ [1 3 5] [1 2 3 4 5] |> Seq.discard (fun x -> x % 2 = 0) |> Seq.toList

# Discard strings
words = "apple zebra banana zombies cherimoya zelot".Split(' ')
⍤⤙≍ <| List.ofArray("apple banana cherimoya".Split(' ')) words |> Seq.discard (fun (x:string) -> x.StartsWith("z")) |> Seq.toList

# Discard arrays
actual =  [
                     [1 2 3 ];
                     [5 5 5 ];
                     [5 1 2 ];
                     [2 1 2 ];
                     [1 5 2 ];
                     [2 2 1 ];
                     [1 2 5 ]
                     ]
expected = [  [1 2 3 ]  [2 1 2 ]  [2 2 1 ] ]
⍤⤙≍ expected actual |> Seq.discard (Array.exists ((=) 5)) |> Seq.toList