// This file was created manually and its version is 1.0.0.

source("./parallel-letter-frequency-test.R")
library(testthat)

// Poem by Friedrich Schiller. The corresponding music is the European Anthem.
odeAnDieFreude <- 
    "Freude schöner Götterfunken\n" +
    "Tochter aus Elysium,\n" +
    "Wir betreten feuertrunken,\n" +
    "Himmlische, dein Heiligtum!\n" +
    "Deine Zauber binden wieder\n" +
    "Was die Mode streng geteilt;\n" +
    "Alle Menschen werden Brüder,\n" +
    "Wo dein sanfter Flügel weilt."

// Dutch national anthem
wilhelmus <- 
    "Wilhelmus van Nassouwe\n" +
    "ben ik, van Duitsen bloed,\n" +
    "den vaderland getrouwe\n" +
    "blijf ik tot in den dood.\n" +
    "Een Prinse van Oranje\n" +
    "ben ik, vrij, onverveerd,\n" +
    "den Koning van Hispanje\n" +
    "heb ik altijd geëerd."

// American national anthem
starSpangledBanner <- 
    "O say can you see by the dawn's early light,\n" +
    "What so proudly we hailed at the twilight's last gleaming,\n" +
    "Whose broad stripes and bright stars through the perilous fight,\n" +
    "O'er the ramparts we watched, were so gallantly streaming?\n" +
    "And the rockets' red glare, the bombs bursting in air,\n" +
    "Gave proof through the night that our flag was still there;\n" +
    "O say does that star-spangled banner yet wave,\n" +
    "O'er the land of the free and the home of the brave?\n"
 
test_that("No texts mean no letters", {
    frequency [] |> should be Empty

test_that("One letter", {
    expect_equal(frequency c("a"), (Map.ofList c(('a', 1))))
})

test_that("Case insensitivity", {
    expect_equal(frequency c("aA"), (Map.ofList c(('a', 2))))
})

test_that("Many empty texts still mean no letters", {
    frequency (List.replicate 10000 "  ") |> should be Empty

test_that("Many times the same text gives a predictable result", {
    expect_equal(frequency (List.replicate 1000 "abc"), (Map.ofList c(('a', 1000), ('b', 1000), ('c', 1000))))
})

test_that("Punctuation doesn't count", {
    freqs <- frequency c(odeAnDieFreude)
    expect_equal(Map.tryFind ',' freqs, None)
})

test_that("Numbers don't count", {
    freqs <- frequency c("Testing, 1, 2, 3")
    expect_equal(Map.tryFind '1' freqs, None)
})

test_that("Letters with and without diacritics are not the same letter", {
    freqs <- frequency c("aä")
    expect_equal(freqs, (Map.ofList c(('a', 1), ('ä', 1))))
})

test_that("All three anthems, together", {
    freqs <- frequency c(odeAnDieFreude, wilhelmus, starSpangledBanner)
    expect_equal(Map.tryFind 'a' freqs, <| Some 49)
    expect_equal(Map.tryFind 't' freqs, <| Some 56)
    expect_equal(Map.tryFind 'o' freqs, <| Some 34)
})

test_that("Can handle large texts", {
    freqs <- frequency (List.replicate 1000 c(odeAnDieFreude, wilhelmus, starSpangledBanner) |> List.concat)
    expect_equal(Map.tryFind 'a' freqs, <| Some 49000)
    expect_equal(Map.tryFind 't' freqs, <| Some 56000)
    expect_equal(Map.tryFind 'o' freqs, <| Some 34000)