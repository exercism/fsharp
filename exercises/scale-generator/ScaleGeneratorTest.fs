// This file was auto-generated based on version 1.0.0 of the canonical data.

module ScaleGeneratorTest

open FsUnit.Xunit
open Xunit

open ScaleGenerator

[<Fact>]
let ``Chromatic scale with sharps`` () =
    pitches "C" None |> should equal ["C"; "C#"; "D"; "D#"; "E"; "F"; "F#"; "G"; "G#"; "A"; "A#"; "B"]

[<Fact(Skip = "Remove to run test")>]
let ``Chromatic scale with flats`` () =
    pitches "F" None |> should equal ["F"; "Gb"; "G"; "Ab"; "A"; "Bb"; "B"; "C"; "Db"; "D"; "Eb"; "E"]

[<Fact(Skip = "Remove to run test")>]
let ``Simple major scale`` () =
    pitches "C" (Some "MMmMMMm") |> should equal ["C"; "D"; "E"; "F"; "G"; "A"; "B"]

[<Fact(Skip = "Remove to run test")>]
let ``Major scale with sharps`` () =
    pitches "G" (Some "MMmMMMm") |> should equal ["G"; "A"; "B"; "C"; "D"; "E"; "F#"]

[<Fact(Skip = "Remove to run test")>]
let ``Major scale with flats`` () =
    pitches "F" (Some "MMmMMMm") |> should equal ["F"; "G"; "A"; "Bb"; "C"; "D"; "E"]

[<Fact(Skip = "Remove to run test")>]
let ``Minor scale with sharps`` () =
    pitches "f#" (Some "MmMMmMM") |> should equal ["F#"; "G#"; "A"; "B"; "C#"; "D"; "E"]

[<Fact(Skip = "Remove to run test")>]
let ``Minor scale with flats`` () =
    pitches "bb" (Some "MmMMmMM") |> should equal ["Bb"; "C"; "Db"; "Eb"; "F"; "Gb"; "Ab"]

[<Fact(Skip = "Remove to run test")>]
let ``Dorian mode`` () =
    pitches "d" (Some "MmMMMmM") |> should equal ["D"; "E"; "F"; "G"; "A"; "B"; "C"]

[<Fact(Skip = "Remove to run test")>]
let ``Mixolydian mode`` () =
    pitches "Eb" (Some "MMmMMmM") |> should equal ["Eb"; "F"; "G"; "Ab"; "Bb"; "C"; "Db"]

[<Fact(Skip = "Remove to run test")>]
let ``Lydian mode`` () =
    pitches "a" (Some "MMMmMMm") |> should equal ["A"; "B"; "C#"; "D#"; "E"; "F#"; "G#"]

[<Fact(Skip = "Remove to run test")>]
let ``Phrygian mode`` () =
    pitches "e" (Some "mMMMmMM") |> should equal ["E"; "F"; "G"; "A"; "B"; "C"; "D"]

[<Fact(Skip = "Remove to run test")>]
let ``Locrian mode`` () =
    pitches "g" (Some "mMMmMMM") |> should equal ["G"; "Ab"; "Bb"; "C"; "Db"; "Eb"; "F"]

[<Fact(Skip = "Remove to run test")>]
let ``Harmonic minor`` () =
    pitches "d" (Some "MmMMmAm") |> should equal ["D"; "E"; "F"; "G"; "A"; "Bb"; "Db"]

[<Fact(Skip = "Remove to run test")>]
let ``Octatonic`` () =
    pitches "C" (Some "MmMmMmMm") |> should equal ["C"; "D"; "D#"; "F"; "F#"; "G#"; "A"; "B"]

[<Fact(Skip = "Remove to run test")>]
let ``Hexatonic`` () =
    pitches "Db" (Some "MMMMMM") |> should equal ["Db"; "Eb"; "F"; "G"; "A"; "B"]

[<Fact(Skip = "Remove to run test")>]
let ``Pentatonic`` () =
    pitches "A" (Some "MMAMA") |> should equal ["A"; "B"; "C#"; "E"; "F#"]

[<Fact(Skip = "Remove to run test")>]
let ``Enigmatic`` () =
    pitches "G" (Some "mAMMMmm") |> should equal ["G"; "G#"; "B"; "C#"; "D#"; "F"; "F#"]

