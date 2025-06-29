import "matching_brackets"

-- Paired square brackets
-- ==
-- input { "[]" }
-- output { true }

-- Empty string
-- ==
-- input { "" }
-- output { true }

-- Unpaired brackets
-- ==
-- input { "[[" }
-- output { false }

-- Wrong ordered brackets
-- ==
-- input { "}{" }
-- output { false }

-- Wrong closing bracket
-- ==
-- input { "{]" }
-- output { false }

-- Paired with whitespace
-- ==
-- input { "{ }" }
-- output { true }

-- Partially paired brackets
-- ==
-- input { "{[])" }
-- output { false }

-- Simple nested brackets
-- ==
-- input { "{[]}" }
-- output { true }

-- Several paired brackets
-- ==
-- input { "{}[]" }
-- output { true }

-- Paired and nested brackets
-- ==
-- input { "([{}({}[])])" }
-- output { true }

-- Unopened closing brackets
-- ==
-- input { "{[)][]}" }
-- output { false }

-- Unpaired and nested brackets
-- ==
-- input { "([{])" }
-- output { false }

-- Paired and wrong nested brackets
-- ==
-- input { "[({]})" }
-- output { false }

-- Paired and wrong nested brackets but innermost are correct
-- ==
-- input { "[({}])" }
-- output { false }

-- Paired and incomplete brackets
-- ==
-- input { "{}[" }
-- output { false }

-- Too many closing brackets
-- ==
-- input { "[]]" }
-- output { false }

-- Early unexpected brackets
-- ==
-- input { ")()" }
-- output { false }

-- Early mismatched brackets
-- ==
-- input { "{)()" }
-- output { false }

-- Math expression
-- ==
-- input { "(((185 + 223.85) * 15) - 543)/2" }
-- output { true }

-- Complex latex expression
-- ==
-- input { "\left(\begin{array}{cc} \frac{1}{3} & x\\ \mathrm{e}^{x} &... x^2 \end{array}\right)" }
-- output { true }

