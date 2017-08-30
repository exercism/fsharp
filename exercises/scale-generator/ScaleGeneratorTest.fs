module ScaleGeneratorTest

open Xunit
open FsUnit

open ScaleGenerator

[Fact]
let ``Major scale`` () =
    let major = pitches "C" "MMmMMMm"
    let expected = ["C"; "D"; "E"; "F"; "G"; "A"; "B"]
    major |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Another major scale`` () =
    let major = pitches "G" "MMmMMMm"
    let expected = ["G"; "A"; "B"; "C"; "D"; "E"; "F#"]
    major |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Minor scale`` () =
    let minor = pitches "f#" "MmMMmMM"
    let expected = ["F#"; "G#"; "A"; "B"; "C#"; "D"; "E"]
    minor |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Another minor scale`` () =
    let minor = pitches "bb" "MmMMmMM"
    let expected = ["Bb"; "C"; "Db"; "Eb"; "F"; "Gb"; "Ab"]
    minor |> should equal expected
    
[Fact(Skip = "Remove to run test")]
let ``Dorian mode`` () =
    let dorian = pitches "d" "MmMMMmM"
    let expected = ["D"; "E"; "F"; "G"; "A"; "B"; "C"]
    dorian |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Mixolydian mode`` () =
    let mixolydian = pitches "Eb" "MMmMMmM"
    let expected = ["Eb"; "F"; "G"; "Ab"; "Bb"; "C"; "Db"]
    mixolydian |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Lydian mode`` () =
    let lydian = pitches "a" "MMMmMMm"
    let expected = ["A"; "B"; "C#"; "D#"; "E"; "F#"; "G#"]
    lydian |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Phrygian mode`` () =
    let phrygian = pitches "e" "mMMMmMM"
    let expected = ["E"; "F"; "G"; "A"; "B"; "C"; "D"]
    phrygian |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Locrian mode`` () =
    let locrian = pitches "g" "mMMmMMM"
    let expected = ["G"; "Ab"; "Bb"; "C"; "Db"; "Eb"; "F"]
    locrian |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Harmonic minor`` () =
    let harmonicMinor = pitches "d" "MmMMmAm"
    let expected = ["D"; "E"; "F"; "G"; "A"; "Bb"; "Db"]
    harmonicMinor |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Octatonic`` () =
    let octatonic = pitches "C" "MmMmMmMm"
    let expected = ["C"; "D"; "D#"; "F"; "F#"; "G#"; "A"; "B"]
    octatonic |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Hexatonic`` () =
    let hexatonic = pitches "Db" "MMMMMM"
    let expected = ["Db"; "Eb"; "F"; "G"; "A"; "B"]
    hexatonic |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Pentatonic`` () =
    let pentatonic = pitches "A" "MMAMA"
    let expected = ["A"; "B"; "C#"; "E"; "F#"]
    pentatonic |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Enigmatic`` () =
    let enigmatic = pitches "G" "mAMMMmm"
    let expected = ["G"; "G#"; "B"; "C#"; "D#"; "F"; "F#"]
    enigmatic |> should equal expected