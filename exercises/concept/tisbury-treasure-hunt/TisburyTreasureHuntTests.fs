source("./tisbury-treasure-hunt.R")
library(testthat)

test_that("Get coordinate for Scrimshaw Whale's Tooth", {
    expect_equal(getCoordinate ("Scrimshaw Whale's Tooth", "2A"), "2A")

test_that("Get coordinate for Brass Spyglass", {
    expect_equal(getCoordinate ("Brass Spyglass", "4B"), "4B")

test_that("Get coordinate for Robot Parrot", {
    expect_equal(getCoordinate ("Robot Parrot", "1C"), "1C")

test_that("Get coordinate for Glass Starfish", {
    expect_equal(getCoordinate ("Glass Starfish", "6D"), "6D")

test_that("Get coordinate for Crystal Crab", {
    expect_equal(getCoordinate ("Crystal Crab", "6A"), "6A")

test_that("Get coordinate for Angry Monkey Figurine", {
    expect_equal(getCoordinate ("Angry Monkey Figurine", "5B"), "5B")

test_that("Convert coordinate for 2A", {
    expect_equal(convertCoordinate "2A", (2, 'A'))

test_that("Convert coordinate for 4B", {
    expect_equal(convertCoordinate "4B", (4, 'B'))

test_that("Convert coordinate for 6A", {
    expect_equal(convertCoordinate "6A", (6, 'A'))

test_that("Compare records for first matched records returns true", {
    azarasData <- ("Scrimshaw Whale's Tooth", "2A")
    ruisData <- ("Deserted Docks", (2, 'A'), "Blue")   
    expect_true(compareRecords azarasData ruisData)

test_that("Compare records for second matched records returns true", {
    azarasData <- ("Glass Starfish", "6D")
    ruisData <- ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    expect_true(compareRecords azarasData ruisData)

test_that("Compare records for third matched records returns true", {
    azarasData <- ("Vintage Pirate Hat", "7E")
    ruisData <- ("Quiet Inlet (Island of Mystery)", (7, 'E'), "Orange")
    expect_true(compareRecords azarasData ruisData)

test_that("Compare records for forth matched records returns true", {
    azarasData <- ("Glass Starfish", "6D")
    ruisData <- ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    expect_true(compareRecords azarasData ruisData)

test_that("Compare records for first unmatched records returns true", {
    azarasData <- ("Angry Monkey Figurine", "5B")
    ruisData <- ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    expect_false(compareRecords azarasData ruisData)

test_that("Compare records for second unmatched records returns true", {
    azarasData <- ("Brass Spyglass", "4B")
    ruisData <- ("Spiky Rocks", (3, 'D'), "Yellow")
    expect_false(compareRecords azarasData ruisData)

test_that("Compare records for third unmatched records returns true", {
    azarasData <- ("Angry Monkey Figurine", "5B")
    ruisData <- ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    expect_false(compareRecords azarasData ruisData)

test_that("Create Record for first matched records returns correct tuple", {
    azarasData <- ("Scrimshaw Whale's Tooth", "2A")
    ruisData <- ("Deserted Docks", (2, 'A'), "Blue")
    expected <- ("2A", "Deserted Docks", "Blue", "Scrimshaw Whale's Tooth")
    expect_equal(createRecord(azarasData, ruisData), expected)

test_that("Compare records for second matched records returns correct tuple", {
    azarasData <- ("Glass Starfish", "6D")
    ruisData <- ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    expected <- ("6D", "Tangled Seaweed Patch", "Orange", "Glass Starfish")
    expect_equal(createRecord(azarasData, ruisData), expected)

test_that("Compare records for third matched records returns correct tuple", {
    azarasData <- ("Vintage Pirate Hat", "7E")
    ruisData <- ("Quiet Inlet (Island of Mystery)", (7, 'E'), "Orange")
    expected <- ("7E", "Quiet Inlet (Island of Mystery)", "Orange", "Vintage Pirate Hat")
    expect_equal(createRecord(azarasData, ruisData), expected)

test_that("Compare records for forth matched records returns correct tuple", {
    azarasData <- ("Glass Starfish", "6D")
    ruisData <- ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    expected <- ("6D", "Tangled Seaweed Patch", "Orange", "Glass Starfish")
    expect_equal(createRecord(azarasData, ruisData), expected)

test_that("Compare records for first unmatched records returns correct empty tuple", {
    azarasData <- ("Angry Monkey Figurine", "5B")
    ruisData <- ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    expected <- ("", "", "", "")
    expect_equal(createRecord(azarasData, ruisData), expected)

test_that("Compare records for second unmatched records returns correct empty tuple", {
    azarasData <- ("Brass Spyglass", "4B")
    ruisData <- ("Spiky Rocks", (3, 'D'), "Yellow")
    expected <- ("", "", "", "")
    expect_equal(createRecord(azarasData, ruisData), expected)

test_that("Compare records for third unmatched records returns correct empty tuple", {
    azarasData <- ("Angry Monkey Figurine", "5B")
    ruisData <- ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    expected <- ("", "", "", "")
    expect_equal(createRecord(azarasData, ruisData), expected)
