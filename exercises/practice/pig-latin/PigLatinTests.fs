source("./pig-latin.R")
library(testthat)

let ``Word beginning with a`` () =
    expect_equal(translate "apple", "appleay")

let ``Word beginning with e`` () =
    expect_equal(translate "ear", "earay")

let ``Word beginning with i`` () =
    expect_equal(translate "igloo", "iglooay")

let ``Word beginning with o`` () =
    expect_equal(translate "object", "objectay")

let ``Word beginning with u`` () =
    expect_equal(translate "under", "underay")

let ``Word beginning with a vowel and followed by a qu`` () =
    expect_equal(translate "equal", "equalay")

let ``Word beginning with p`` () =
    expect_equal(translate "pig", "igpay")

let ``Word beginning with k`` () =
    expect_equal(translate "koala", "oalakay")

let ``Word beginning with x`` () =
    expect_equal(translate "xenon", "enonxay")

let ``Word beginning with q without a following u`` () =
    expect_equal(translate "qat", "atqay")

let ``Word beginning with ch`` () =
    expect_equal(translate "chair", "airchay")

let ``Word beginning with qu`` () =
    expect_equal(translate "queen", "eenquay")

let ``Word beginning with qu and a preceding consonant`` () =
    expect_equal(translate "square", "aresquay")

let ``Word beginning with th`` () =
    expect_equal(translate "therapy", "erapythay")

let ``Word beginning with thr`` () =
    expect_equal(translate "thrush", "ushthray")

let ``Word beginning with sch`` () =
    expect_equal(translate "school", "oolschay")

let ``Word beginning with yt`` () =
    expect_equal(translate "yttria", "yttriaay")

let ``Word beginning with xr`` () =
    expect_equal(translate "xray", "xrayay")

let ``Y is treated like a consonant at the beginning of a word`` () =
    expect_equal(translate "yellow", "ellowyay")

let ``Y is treated like a vowel at the end of a consonant cluster`` () =
    expect_equal(translate "rhythm", "ythmrhay")

let ``Y as second letter in two letter word`` () =
    expect_equal(translate "my", "ymay")

let ``A whole phrase`` () =
    expect_equal(translate "quick fast run", "ickquay astfay unray")

