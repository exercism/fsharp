~ "matching-brackets.ua" ~ MatchingBrackets

# Paired square brackets
    isPaired "[]" |> should equal true

# Empty string
    isPaired "" |> should equal true

# Unpaired brackets
    isPaired "[[" |> should equal false

# Wrong ordered brackets
    isPaired "}{" |> should equal false

# Wrong closing bracket
    isPaired "{]" |> should equal false

# Paired with whitespace
    isPaired "{ }" |> should equal true

# Partially paired brackets
    isPaired "{[])" |> should equal false

# Simple nested brackets
    isPaired "{[]}" |> should equal true

# Several paired brackets
    isPaired "{}[]" |> should equal true

# Paired and nested brackets
    isPaired "([{}({}[])])" |> should equal true

# Unopened closing brackets
    isPaired "{[)][]}" |> should equal false

# Unpaired and nested brackets
    isPaired "([{])" |> should equal false

# Paired and wrong nested brackets
    isPaired "[({]})" |> should equal false

# Paired and wrong nested brackets but innermost are correct
    isPaired "[({}])" |> should equal false

# Paired and incomplete brackets
    isPaired "{}[" |> should equal false

# Too many closing brackets
    isPaired "[]]" |> should equal false

# Early unexpected brackets
    isPaired ")()" |> should equal false

# Early mismatched brackets
    isPaired "{)()" |> should equal false

# Math expression
    isPaired "(((185 + 223.85) * 15) - 543)/2" |> should equal true

# Complex latex expression
    isPaired "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)" |> should equal true

