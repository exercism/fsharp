source("./scale-generator.R")
library(testthat)

test_that("Chromatic scale with sharps", {
    expect_equal(chromatic "C", ["C"; "C#"; "D"; "D#"; "E"; "F"; "F#"; "G"; "G#"; "A"; "A#"; "B"])
})

test_that("Chromatic scale with flats", {
    expect_equal(chromatic "F", ["F"; "Gb"; "G"; "Ab"; "A"; "Bb"; "B"; "C"; "Db"; "D"; "Eb"; "E"])
})

test_that("Simple major scale", {
    expect_equal(interval "MMmMMMm" "C", ["C"; "D"; "E"; "F"; "G"; "A"; "B"; "C"])
})

test_that("Major scale with sharps", {
    expect_equal(interval "MMmMMMm" "G", ["G"; "A"; "B"; "C"; "D"; "E"; "F#"; "G"])
})

test_that("Major scale with flats", {
    expect_equal(interval "MMmMMMm" "F", ["F"; "G"; "A"; "Bb"; "C"; "D"; "E"; "F"])
})

test_that("Minor scale with sharps", {
    expect_equal(interval "MmMMmMM" "f#", ["F#"; "G#"; "A"; "B"; "C#"; "D"; "E"; "F#"])
})

test_that("Minor scale with flats", {
    expect_equal(interval "MmMMmMM" "bb", ["Bb"; "C"; "Db"; "Eb"; "F"; "Gb"; "Ab"; "Bb"])
})

test_that("Dorian mode", {
    expect_equal(interval "MmMMMmM" "d", ["D"; "E"; "F"; "G"; "A"; "B"; "C"; "D"])
})

test_that("Mixolydian mode", {
    expect_equal(interval "MMmMMmM" "Eb", ["Eb"; "F"; "G"; "Ab"; "Bb"; "C"; "Db"; "Eb"])
})

test_that("Lydian mode", {
    expect_equal(interval "MMMmMMm" "a", ["A"; "B"; "C#"; "D#"; "E"; "F#"; "G#"; "A"])
})

test_that("Phrygian mode", {
    expect_equal(interval "mMMMmMM" "e", ["E"; "F"; "G"; "A"; "B"; "C"; "D"; "E"])
})

test_that("Locrian mode", {
    expect_equal(interval "mMMmMMM" "g", ["G"; "Ab"; "Bb"; "C"; "Db"; "Eb"; "F"; "G"])
})

test_that("Harmonic minor", {
    expect_equal(interval "MmMMmAm" "d", ["D"; "E"; "F"; "G"; "A"; "Bb"; "Db"; "D"])
})

test_that("Octatonic", {
    expect_equal(interval "MmMmMmMm" "C", ["C"; "D"; "D#"; "F"; "F#"; "G#"; "A"; "B"; "C"])
})

test_that("Hexatonic", {
    expect_equal(interval "MMMMMM" "Db", ["Db"; "Eb"; "F"; "G"; "A"; "B"; "Db"])
})

test_that("Pentatonic", {
    expect_equal(interval "MMAMA" "A", ["A"; "B"; "C#"; "E"; "F#"; "A"])
})

test_that("Enigmatic", {
    expect_equal(interval "mAMMMmm" "G", ["G"; "G#"; "B"; "C#"; "D#"; "F"; "F#"; "G"])
})
