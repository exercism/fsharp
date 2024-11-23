~ "matching-brackets.ua" ~ MatchingBrackets

# Paired square brackets
⍤⤙≍ 1 isPaired "[]"

# Empty string
⍤⤙≍ 1 isPaired ""

# Unpaired brackets
⍤⤙≍ 0 isPaired "[["

# Wrong ordered brackets
⍤⤙≍ 0 isPaired "}{"

# Wrong closing bracket
⍤⤙≍ 0 isPaired "{]"

# Paired with whitespace
⍤⤙≍ 1 isPaired "{ }"

# Partially paired brackets
⍤⤙≍ 0 isPaired "{[])"

# Simple nested brackets
⍤⤙≍ 1 isPaired "{[]}"

# Several paired brackets
⍤⤙≍ 1 isPaired "{}[]"

# Paired and nested brackets
⍤⤙≍ 1 isPaired "([{}({}[])])"

# Unopened closing brackets
⍤⤙≍ 0 isPaired "{[)][]}"

# Unpaired and nested brackets
⍤⤙≍ 0 isPaired "([{])"

# Paired and wrong nested brackets
⍤⤙≍ 0 isPaired "[({]})"

# Paired and wrong nested brackets but innermost are correct
⍤⤙≍ 0 isPaired "[({}])"

# Paired and incomplete brackets
⍤⤙≍ 0 isPaired "{}["

# Too many closing brackets
⍤⤙≍ 0 isPaired "[]]"

# Early unexpected brackets
⍤⤙≍ 0 isPaired ")()"

# Early mismatched brackets
⍤⤙≍ 0 isPaired "{)()"

# Math expression
⍤⤙≍ 1 isPaired "(((185 + 223.85) * 15) - 543)/2"

# Complex latex expression
⍤⤙≍ 1 isPaired "\\left(\\begin{array}{cc} \\frac{1}{3} & x\\ \\mathrm{e}^{x} &... x^2 \\end{array}\\right)"
