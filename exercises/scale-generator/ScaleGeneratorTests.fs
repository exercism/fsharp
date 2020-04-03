// This file was auto-generated based on version 2.0.0 of the canonical data.

module ScaleGeneratorTests

open FsUnit.Xunit
open Xunit

open ScaleGenerator

[<Fact>]
let ``Chromatic scale with sharps`` () =
    chromatic "C" |> should equal ["C"; "C#"; "D"; "D#"; "E"; "F"; "F#"; "G"; "G#"; "A"; "A#"; "B"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Chromatic scale with flats`` () =
    chromatic "F" |> should equal ["F"; "Gb"; "G"; "Ab"; "A"; "Bb"; "B"; "C"; "Db"; "D"; "Eb"; "E"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Simple major scale`` () =
    interval "MMmMMMm" "C" |> should equal ["C"; "D"; "E"; "F"; "G"; "A"; "B"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Major scale with sharps`` () =
    interval "MMmMMMm" "G" |> should equal ["G"; "A"; "B"; "C"; "D"; "E"; "F#"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Major scale with flats`` () =
    interval "MMmMMMm" "F" |> should equal ["F"; "G"; "A"; "Bb"; "C"; "D"; "E"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Minor scale with sharps`` () =
    interval "MmMMmMM" "f#" |> should equal ["F#"; "G#"; "A"; "B"; "C#"; "D"; "E"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Minor scale with flats`` () =
    interval "MmMMmMM" "bb" |> should equal ["Bb"; "C"; "Db"; "Eb"; "F"; "Gb"; "Ab"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Dorian mode`` () =
    interval "MmMMMmM" "d" |> should equal ["D"; "E"; "F"; "G"; "A"; "B"; "C"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Mixolydian mode`` () =
    interval "MMmMMmM" "Eb" |> should equal ["Eb"; "F"; "G"; "Ab"; "Bb"; "C"; "Db"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Lydian mode`` () =
    interval "MMMmMMm" "a" |> should equal ["A"; "B"; "C#"; "D#"; "E"; "F#"; "G#"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Phrygian mode`` () =
    interval "mMMMmMM" "e" |> should equal ["E"; "F"; "G"; "A"; "B"; "C"; "D"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Locrian mode`` () =
    interval "mMMmMMM" "g" |> should equal ["G"; "Ab"; "Bb"; "C"; "Db"; "Eb"; "F"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Harmonic minor`` () =
    interval "MmMMmAm" "d" |> should equal ["D"; "E"; "F"; "G"; "A"; "Bb"; "Db"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Octatonic`` () =
    interval "MmMmMmMm" "C" |> should equal ["C"; "D"; "D#"; "F"; "F#"; "G#"; "A"; "B"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Hexatonic`` () =
    interval "MMMMMM" "Db" |> should equal ["Db"; "Eb"; "F"; "G"; "A"; "B"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Pentatonic`` () =
    interval "MMAMA" "A" |> should equal ["A"; "B"; "C#"; "E"; "F#"]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Enigmatic`` () =
    interval "mAMMMmm" "G" |> should equal ["G"; "G#"; "B"; "C#"; "D#"; "F"; "F#"]

