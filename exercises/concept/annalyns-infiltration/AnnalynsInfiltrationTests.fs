module annalynsInfiltrationTests

test_that("Cannot execute fast attack if knight is awake", {
    knightIsAwake <- true
    expect_equal(canFastAttack knightIsAwake, false)

test_that("Can execute fast attack if knight is sleeping", {
    knightIsAwake <- false
    expect_equal(canFastAttack knightIsAwake, true)

test_that("Cannot spy if everyone is sleeping", {
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- false
    expect_equal(canSpy knightIsAwake archerIsAwake prisonerIsAwake, false)

test_that("Can spy if everyone but knight is sleeping", {
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- false
    expect_equal(canSpy knightIsAwake archerIsAwake prisonerIsAwake, true)

test_that("Can spy if everyone but archer is sleeping", {
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- false
    expect_equal(canSpy knightIsAwake archerIsAwake prisonerIsAwake, true)

test_that("Can spy if everyone but prisoner is sleeping", {
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- true
    expect_equal(canSpy knightIsAwake archerIsAwake prisonerIsAwake, true)

test_that("Can spy if only knight is sleeping", {
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- true
    expect_equal(canSpy knightIsAwake archerIsAwake prisonerIsAwake, true)

test_that("Can spy if only archer is sleeping", {
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- true
    expect_equal(canSpy knightIsAwake archerIsAwake prisonerIsAwake, true)

test_that("Can spy if only prisoner is sleeping", {
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- false
    expect_equal(canSpy knightIsAwake archerIsAwake prisonerIsAwake, true)

test_that("Can spy if everyone is awake", {
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- true
    expect_equal(canSpy knightIsAwake archerIsAwake prisonerIsAwake, true)

test_that("Can signal prisoner if archer is sleeping and prisoner is awake", {
    archerIsAwake <- false
    prisonerIsAwake <- true
    expect_equal(canSignalPrisoner archerIsAwake prisonerIsAwake, true)

test_that("Cannot signal prisoner if archer is awake and prisoner is sleeping", {
    archerIsAwake <- true
    prisonerIsAwake <- false
    expect_equal(canSignalPrisoner archerIsAwake prisonerIsAwake, false)

test_that("Cannot signal prisoner if archer and prisoner are both sleeping", {
    archerIsAwake <- false
    prisonerIsAwake <- false
    expect_equal(canSignalPrisoner archerIsAwake prisonerIsAwake, false)

test_that("Cannot signal prisoner if archer and prisoner are both awake", {
    archerIsAwake <- true
    prisonerIsAwake <- true
    expect_equal(canSignalPrisoner archerIsAwake prisonerIsAwake, false)

test_that("Cannot free prisoner if everyone is awake and pet dog is present", {
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- true
    petDogIsPresent <- true
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)

test_that("Cannot free prisoner if everyone is awake and pet dog is absent", {
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- true
    petDogIsPresent <- false
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)

test_that("Can free prisoner if everyone is asleep and pet dog is present", {
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- false
    petDogIsPresent <- true
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, true)

test_that("Cannot free prisoner if everyone is asleep and pet dog is absent", {
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- false
    petDogIsPresent <- false
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)

test_that("Can free prisoner if only prisoner is awake and pet dog is present", {
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- true
    petDogIsPresent <- true
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, true)

test_that("Can free prisoner if only prisoner is awake and pet dog is absent", {
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- true
    petDogIsPresent <- false
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, true)

test_that("Cannot free prisoner if only archer is awake and pet dog is present", {
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- false
    petDogIsPresent <- true
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)

test_that("Cannot free prisoner if only archer is awake and pet dog is absent", {
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- false
    petDogIsPresent <- false
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)

test_that("Can free prisoner if only knight is awake and pet dog is present", {
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- false
    petDogIsPresent <- true
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, true)

test_that("Cannot free prisoner if only knight is awake and pet dog is absent", {
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- false
    petDogIsPresent <- false
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)

test_that("Cannot free prisoner if only knight is asleep and pet dog is present", {
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- true
    petDogIsPresent <- true
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)

test_that("Cannot free prisoner if only knight is asleep and pet dog is absent", {
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- true
    petDogIsPresent <- false
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)

test_that("Can free prisoner if only archer is asleep and pet dog is present", {
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- true
    petDogIsPresent <- true
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, true)

test_that("Cannot free prisoner if only archer is asleep and pet dog is absent", {
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- true
    petDogIsPresent <- false
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)

test_that("Cannot free prisoner if only prisoner is asleep and pet dog is present", {
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- false
    petDogIsPresent <- true
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)

test_that("Cannot free prisoner if only prisoner is asleep and pet dog is absent", {
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- false
    petDogIsPresent <- false
    expect_equal(canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent, false)
