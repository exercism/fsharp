source("./scale-generator.R")
library(testthat)

test_that("Chromatic scale with sharps", {
    chromatic "C" |> should equal ["C"; "C#"; "D"; "D#"; "E"; "F"; "F#"; "G"; "G#"; "A"; "A#"; "B"]
})

test_that("Chromatic scale with flats", {
    chromatic "F" |> should equal ["F"; "Gb"; "G"; "Ab"; "A"; "Bb"; "B"; "C"; "Db"; "D"; "Eb"; "E"]
})

test_that("Simple major scale", {
    interval "MMmMMMm" "C" |> should equal ["C"; "D"; "E"; "F"; "G"; "A"; "B"; "C"]
})

test_that("Major scale with sharps", {
    interval "MMmMMMm" "G" |> should equal ["G"; "A"; "B"; "C"; "D"; "E"; "F#"; "G"]
})

test_that("Major scale with flats", {
    interval "MMmMMMm" "F" |> should equal ["F"; "G"; "A"; "Bb"; "C"; "D"; "E"; "F"]
})

test_that("Minor scale with sharps", {
    interval "MmMMmMM" "f#" |> should equal ["F#"; "G#"; "A"; "B"; "C#"; "D"; "E"; "F#"]
})

test_that("Minor scale with flats", {
    interval "MmMMmMM" "bb" |> should equal ["Bb"; "C"; "Db"; "Eb"; "F"; "Gb"; "Ab"; "Bb"]
})

test_that("Dorian mode", {
    interval "MmMMMmM" "d" |> should equal ["D"; "E"; "F"; "G"; "A"; "B"; "C"; "D"]
})

test_that("Mixolydian mode", {
    interval "MMmMMmM" "Eb" |> should equal ["Eb"; "F"; "G"; "Ab"; "Bb"; "C"; "Db"; "Eb"]
})

test_that("Lydian mode", {
    interval "MMMmMMm" "a" |> should equal ["A"; "B"; "C#"; "D#"; "E"; "F#"; "G#"; "A"]
})

test_that("Phrygian mode", {
    interval "mMMMmMM" "e" |> should equal ["E"; "F"; "G"; "A"; "B"; "C"; "D"; "E"]
})

test_that("Locrian mode", {
    interval "mMMmMMM" "g" |> should equal ["G"; "Ab"; "Bb"; "C"; "Db"; "Eb"; "F"; "G"]
})

test_that("Harmonic minor", {
    interval "MmMMmAm" "d" |> should equal ["D"; "E"; "F"; "G"; "A"; "Bb"; "Db"; "D"]
})

test_that("Octatonic", {
    interval "MmMmMmMm" "C" |> should equal ["C"; "D"; "D#"; "F"; "F#"; "G#"; "A"; "B"; "C"]
})

test_that("Hexatonic", {
    interval "MMMMMM" "Db" |> should equal ["Db"; "Eb"; "F"; "G"; "A"; "B"; "Db"]
})

test_that("Pentatonic", {
    interval "MMAMA" "A" |> should equal ["A"; "B"; "C#"; "E"; "F#"; "A"]
})

test_that("Enigmatic", {
    interval "mAMMMmm" "G" |> should equal ["G"; "G#"; "B"; "C#"; "D#"; "F"; "F#"; "G"]

