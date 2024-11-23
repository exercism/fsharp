~ "matching-brackets.ua" ~ MatchingBrackets

# Paired square brackets
⍤⤙≍ true isPaired "[]"

# Empty string
⍤⤙≍ true isPaired ""

# Unpaired brackets
⍤⤙≍ false isPaired "[["

# Wrong ordered brackets
⍤⤙≍ false isPaired "}{"

# Wrong closing bracket
⍤⤙≍ false isPaired "{]"

# Paired with whitespace
⍤⤙≍ true isPaired "{ }"

# Partially paired brackets
⍤⤙≍ false isPaired "{[])"

# Simple nested brackets
⍤⤙≍ true isPaired "{[]}"

# Several paired brackets
⍤⤙≍ true isPaired "{}[]"

# Paired and nested brackets
⍤⤙≍ true isPaired "([{}({}[])])"

# Unopened closing brackets
⍤⤙≍ false isPaired "{[)][]}"

# Unpaired and nested brackets
⍤⤙≍ false isPaired "([{])"

# Paired and wrong nested brackets
⍤⤙≍ false isPaired "[({]})"

# Paired and wrong nested brackets but innermost are correct
⍤⤙≍ false isPaired "[({}])"

# Paired and incomplete brackets
⍤⤙≍ false isPaired "{}["

# Too many closing brackets
⍤⤙≍ false isPaired "[]]"

# Early unexpected brackets
⍤⤙≍ false isPaired ")()"

# Early mismatched brackets
⍤⤙≍ false isPaired "{)()"

# Math expression
⍤⤙≍ true isPaired "(((185 + 223.85) * 15) - 543)/2"

# Complex latex expression
⍤⤙≍ true isPaired "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)"

