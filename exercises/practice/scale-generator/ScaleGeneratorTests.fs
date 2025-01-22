source("./scale-generator.R")
library(testthat)

let ``Chromatic scale with sharps`` () =
    expect_equal(chromatic "C", ["C"; "C#"; "D"; "D#"; "E"; "F"; "F#"; "G"; "G#"; "A"; "A#"; "B"])

let ``Chromatic scale with flats`` () =
    expect_equal(chromatic "F", ["F"; "Gb"; "G"; "Ab"; "A"; "Bb"; "B"; "C"; "Db"; "D"; "Eb"; "E"])

let ``Simple major scale`` () =
    expect_equal(interval "MMmMMMm" "C", ["C"; "D"; "E"; "F"; "G"; "A"; "B"; "C"])

let ``Major scale with sharps`` () =
    expect_equal(interval "MMmMMMm" "G", ["G"; "A"; "B"; "C"; "D"; "E"; "F#"; "G"])

let ``Major scale with flats`` () =
    expect_equal(interval "MMmMMMm" "F", ["F"; "G"; "A"; "Bb"; "C"; "D"; "E"; "F"])

let ``Minor scale with sharps`` () =
    expect_equal(interval "MmMMmMM" "f#", ["F#"; "G#"; "A"; "B"; "C#"; "D"; "E"; "F#"])

let ``Minor scale with flats`` () =
    expect_equal(interval "MmMMmMM" "bb", ["Bb"; "C"; "Db"; "Eb"; "F"; "Gb"; "Ab"; "Bb"])

let ``Dorian mode`` () =
    expect_equal(interval "MmMMMmM" "d", ["D"; "E"; "F"; "G"; "A"; "B"; "C"; "D"])

let ``Mixolydian mode`` () =
    expect_equal(interval "MMmMMmM" "Eb", ["Eb"; "F"; "G"; "Ab"; "Bb"; "C"; "Db"; "Eb"])

let ``Lydian mode`` () =
    expect_equal(interval "MMMmMMm" "a", ["A"; "B"; "C#"; "D#"; "E"; "F#"; "G#"; "A"])

let ``Phrygian mode`` () =
    expect_equal(interval "mMMMmMM" "e", ["E"; "F"; "G"; "A"; "B"; "C"; "D"; "E"])

let ``Locrian mode`` () =
    expect_equal(interval "mMMmMMM" "g", ["G"; "Ab"; "Bb"; "C"; "Db"; "Eb"; "F"; "G"])

let ``Harmonic minor`` () =
    expect_equal(interval "MmMMmAm" "d", ["D"; "E"; "F"; "G"; "A"; "Bb"; "Db"; "D"])

let ``Octatonic`` () =
    expect_equal(interval "MmMmMmMm" "C", ["C"; "D"; "D#"; "F"; "F#"; "G#"; "A"; "B"; "C"])

let ``Hexatonic`` () =
    expect_equal(interval "MMMMMM" "Db", ["Db"; "Eb"; "F"; "G"; "A"; "B"; "Db"])

let ``Pentatonic`` () =
    expect_equal(interval "MMAMA" "A", ["A"; "B"; "C#"; "E"; "F#"; "A"])

let ``Enigmatic`` () =
    expect_equal(interval "mAMMMmm" "G", ["G"; "G#"; "B"; "C#"; "D#"; "F"; "F#"; "G"])

