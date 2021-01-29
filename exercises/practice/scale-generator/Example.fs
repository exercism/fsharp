module ScaleGenerator

open System

let chromaticScale = ["C"; "C#"; "D"; "D#"; "E"; "F"; "F#"; "G"; "G#"; "A"; "A#"; "B"]
let flatChromaticScale = ["C"; "Db"; "D"; "Eb"; "E"; "F"; "Gb"; "G"; "Ab"; "A"; "Bb"; "B"]
let flatKeys = ["F"; "Bb"; "Eb"; "Ab"; "Db"; "Gb"; "d"; "g"; "c"; "f"; "bb"; "eb"]

let shift index list = List.skip index list @ List.take index list
let intervals = [('m', 1); ('M', 2); ('A', 3)] |> Map.ofList

let skipInterval interval scale = List.skip (Map.find interval intervals) scale 

let interval intervals tonic =
    let scale = if List.contains tonic flatKeys then flatChromaticScale else chromaticScale
    let index = List.findIndex (fun pitch -> String.Equals(pitch, tonic, StringComparison.InvariantCultureIgnoreCase)) scale
    let shiftedScale = shift index scale

    intervals
    |> List.ofSeq
    |> List.fold (fun (acc, remainder) item -> (List.head remainder :: acc, skipInterval item remainder)) ([], shiftedScale)
    |> fst
    |> List.rev

let chromatic tonic = interval "mmmmmmmmmmmm" tonic