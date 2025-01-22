source("./matching-brackets.R")
library(testthat)

let ``Paired square brackets`` () =
    expect_equal(isPaired "[]", true)

let ``Empty string`` () =
    expect_equal(isPaired "", true)

let ``Unpaired brackets`` () =
    expect_equal(isPaired "[[", false)

let ``Wrong ordered brackets`` () =
    expect_equal(isPaired "}{", false)

let ``Wrong closing bracket`` () =
    expect_equal(isPaired "{]", false)

let ``Paired with whitespace`` () =
    expect_equal(isPaired "{ }", true)

let ``Partially paired brackets`` () =
    expect_equal(isPaired "{[])", false)

let ``Simple nested brackets`` () =
    expect_equal(isPaired "{[]}", true)

let ``Several paired brackets`` () =
    expect_equal(isPaired "{}[]", true)

let ``Paired and nested brackets`` () =
    expect_equal(isPaired "([{}({}[])])", true)

let ``Unopened closing brackets`` () =
    expect_equal(isPaired "{[)][]}", false)

let ``Unpaired and nested brackets`` () =
    expect_equal(isPaired "([{])", false)

let ``Paired and wrong nested brackets`` () =
    expect_equal(isPaired "[({]})", false)

let ``Paired and wrong nested brackets but innermost are correct`` () =
    expect_equal(isPaired "[({}])", false)

let ``Paired and incomplete brackets`` () =
    expect_equal(isPaired "{}[", false)

let ``Too many closing brackets`` () =
    expect_equal(isPaired "[]]", false)

let ``Early unexpected brackets`` () =
    expect_equal(isPaired ")()", false)

let ``Early mismatched brackets`` () =
    expect_equal(isPaired "{)()", false)

let ``Math expression`` () =
    expect_equal(isPaired "(((185 + 223.85) * 15) - 543)/2", true)

let ``Complex latex expression`` () =
    expect_equal(isPaired "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)", true)

