source("./scale-generator.R")
library(testthat)

let ``Chromatic scale with sharps`` () =
    chromatic "C" |> should equal ["C"; "C#"; "D"; "D#"; "E"; "F"; "F#"; "G"; "G#"; "A"; "A#"; "B"]

let ``Chromatic scale with flats`` () =
    chromatic "F" |> should equal ["F"; "Gb"; "G"; "Ab"; "A"; "Bb"; "B"; "C"; "Db"; "D"; "Eb"; "E"]

let ``Simple major scale`` () =
    interval "MMmMMMm" "C" |> should equal ["C"; "D"; "E"; "F"; "G"; "A"; "B"; "C"]

let ``Major scale with sharps`` () =
    interval "MMmMMMm" "G" |> should equal ["G"; "A"; "B"; "C"; "D"; "E"; "F#"; "G"]

let ``Major scale with flats`` () =
    interval "MMmMMMm" "F" |> should equal ["F"; "G"; "A"; "Bb"; "C"; "D"; "E"; "F"]

let ``Minor scale with sharps`` () =
    interval "MmMMmMM" "f#" |> should equal ["F#"; "G#"; "A"; "B"; "C#"; "D"; "E"; "F#"]

let ``Minor scale with flats`` () =
    interval "MmMMmMM" "bb" |> should equal ["Bb"; "C"; "Db"; "Eb"; "F"; "Gb"; "Ab"; "Bb"]

let ``Dorian mode`` () =
    interval "MmMMMmM" "d" |> should equal ["D"; "E"; "F"; "G"; "A"; "B"; "C"; "D"]

let ``Mixolydian mode`` () =
    interval "MMmMMmM" "Eb" |> should equal ["Eb"; "F"; "G"; "Ab"; "Bb"; "C"; "Db"; "Eb"]

let ``Lydian mode`` () =
    interval "MMMmMMm" "a" |> should equal ["A"; "B"; "C#"; "D#"; "E"; "F#"; "G#"; "A"]

let ``Phrygian mode`` () =
    interval "mMMMmMM" "e" |> should equal ["E"; "F"; "G"; "A"; "B"; "C"; "D"; "E"]

let ``Locrian mode`` () =
    interval "mMMmMMM" "g" |> should equal ["G"; "Ab"; "Bb"; "C"; "Db"; "Eb"; "F"; "G"]

let ``Harmonic minor`` () =
    interval "MmMMmAm" "d" |> should equal ["D"; "E"; "F"; "G"; "A"; "Bb"; "Db"; "D"]

let ``Octatonic`` () =
    interval "MmMmMmMm" "C" |> should equal ["C"; "D"; "D#"; "F"; "F#"; "G#"; "A"; "B"; "C"]

let ``Hexatonic`` () =
    interval "MMMMMM" "Db" |> should equal ["Db"; "Eb"; "F"; "G"; "A"; "B"; "Db"]

let ``Pentatonic`` () =
    interval "MMAMA" "A" |> should equal ["A"; "B"; "C#"; "E"; "F#"; "A"]

let ``Enigmatic`` () =
    interval "mAMMMmm" "G" |> should equal ["G"; "G#"; "B"; "C#"; "D#"; "F"; "F#"; "G"]

