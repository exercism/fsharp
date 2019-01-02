// This file was auto-generated based on version 2.0.0 of the canonical data.

module ScaleGeneratorTest

open FsUnit.Xunit
open Xunit

open ScaleGenerator

[<Fact>]
let ``Chromatic scale with sharps`` () =
    chromatic "C" |> should equal ["C"; "C#"; "D"; "D#"; "E"; "F"; "F#"; "G"; "G#"; "A"; "A#"; "B"]

[<Fact(Skip = "Remove to run test")>]
let ``Chromatic scale with flats`` () =
    chromatic "F" |> should equal ["F"; "Gb"; "G"; "Ab"; "A"; "Bb"; "B"; "C"; "Db"; "D"; "Eb"; "E"]

[<Fact(Skip = "Remove to run test")>]
let ``Simple major scale`` () =
    interval "MMmMMM" "C" |> should equal ["C"; "D"; "E"; "F"; "G"; "A"; "B"]

[<Fact(Skip = "Remove to run test")>]
let ``Major scale with sharps`` () =
    interval "MMmMMM" "G" |> should equal ["G"; "A"; "B"; "C"; "D"; "E"; "F#"]

[<Fact(Skip = "Remove to run test")>]
let ``Major scale with flats`` () =
    interval "MMmMMM" "F" |> should equal ["F"; "G"; "A"; "Bb"; "C"; "D"; "E"]

[<Fact(Skip = "Remove to run test")>]
let ``Minor scale with sharps`` () =
    interval "MmMMmM" "f#" |> should equal ["F#"; "G#"; "A"; "B"; "C#"; "D"; "E"]

[<Fact(Skip = "Remove to run test")>]
let ``Minor scale with flats`` () =
    interval "MmMMmM" "bb" |> should equal ["Bb"; "C"; "Db"; "Eb"; "F"; "Gb"; "Ab"]

[<Fact(Skip = "Remove to run test")>]
let ``Dorian mode`` () =
    interval "MmMMMm" "d" |> should equal ["D"; "E"; "F"; "G"; "A"; "B"; "C"]

[<Fact(Skip = "Remove to run test")>]
let ``Mixolydian mode`` () =
    interval "MMmMMm" "Eb" |> should equal ["Eb"; "F"; "G"; "Ab"; "Bb"; "C"; "Db"]

[<Fact(Skip = "Remove to run test")>]
let ``Lydian mode`` () =
    interval "MMMmMM" "a" |> should equal ["A"; "B"; "C#"; "D#"; "E"; "F#"; "G#"]

[<Fact(Skip = "Remove to run test")>]
let ``Phrygian mode`` () =
    interval "mMMMmM" "e" |> should equal ["E"; "F"; "G"; "A"; "B"; "C"; "D"]

[<Fact(Skip = "Remove to run test")>]
let ``Locrian mode`` () =
    interval "mMMmMM" "g" |> should equal ["G"; "Ab"; "Bb"; "C"; "Db"; "Eb"; "F"]

[<Fact(Skip = "Remove to run test")>]
let ``Harmonic minor`` () =
    interval "MmMMmA" "d" |> should equal ["D"; "E"; "F"; "G"; "A"; "Bb"; "Db"]

[<Fact(Skip = "Remove to run test")>]
let ``Octatonic`` () =
    interval "MmMmMmM" "C" |> should equal ["C"; "D"; "D#"; "F"; "F#"; "G#"; "A"; "B"]

[<Fact(Skip = "Remove to run test")>]
let ``Hexatonic`` () =
    interval "MMMMM" "Db" |> should equal ["Db"; "Eb"; "F"; "G"; "A"; "B"]

[<Fact(Skip = "Remove to run test")>]
let ``Pentatonic`` () =
    interval "MMAM" "A" |> should equal ["A"; "B"; "C#"; "E"; "F#"]

[<Fact(Skip = "Remove to run test")>]
let ``Enigmatic`` () =
    interval "mAMMMm" "G" |> should equal ["G"; "G#"; "B"; "C#"; "D#"; "F"; "F#"]

