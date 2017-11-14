module ReverseString

open System

let reverse (input:string) = input |> Seq.rev |> Seq.toArray |> String