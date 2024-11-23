~ "matching-brackets.ua" ~ MatchingBrackets

let ``Paired square brackets`` () =
    isPaired "[]" |> should equal true

let ``Empty string`` () =
    isPaired "" |> should equal true

let ``Unpaired brackets`` () =
    isPaired "[[" |> should equal false

let ``Wrong ordered brackets`` () =
    isPaired "}{" |> should equal false

let ``Wrong closing bracket`` () =
    isPaired "{]" |> should equal false

let ``Paired with whitespace`` () =
    isPaired "{ }" |> should equal true

let ``Partially paired brackets`` () =
    isPaired "{[])" |> should equal false

let ``Simple nested brackets`` () =
    isPaired "{[]}" |> should equal true

let ``Several paired brackets`` () =
    isPaired "{}[]" |> should equal true

let ``Paired and nested brackets`` () =
    isPaired "([{}({}[])])" |> should equal true

let ``Unopened closing brackets`` () =
    isPaired "{[)][]}" |> should equal false

let ``Unpaired and nested brackets`` () =
    isPaired "([{])" |> should equal false

let ``Paired and wrong nested brackets`` () =
    isPaired "[({]})" |> should equal false

let ``Paired and wrong nested brackets but innermost are correct`` () =
    isPaired "[({}])" |> should equal false

let ``Paired and incomplete brackets`` () =
    isPaired "{}[" |> should equal false

let ``Too many closing brackets`` () =
    isPaired "[]]" |> should equal false

let ``Early unexpected brackets`` () =
    isPaired ")()" |> should equal false

let ``Early mismatched brackets`` () =
    isPaired "{)()" |> should equal false

let ``Math expression`` () =
    isPaired "(((185 + 223.85) * 15) - 543)/2" |> should equal true

let ``Complex latex expression`` () =
    isPaired "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)" |> should equal true

