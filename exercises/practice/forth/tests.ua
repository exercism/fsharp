~ "forth.ua" ~ Forth

# Parsing and numbers - numbers just get pushed onto the stack
expected ← [1 2 3 4 5]
⍤⤙≍ expected evaluate ["1 2 3 4 5"]

# Parsing and numbers - pushes negative numbers onto the stack
expected ← [-1 -2 -3 -4 -5]
⍤⤙≍ expected evaluate ["-1 -2 -3 -4 -5"]

# Addition - can add two numbers
expected ← [3]
⍤⤙≍ expected evaluate ["1 2 +"]

# Addition - errors if there is nothing on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["+"])

# Addition - errors if there is only one value on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["1 +"])

# Subtraction - can subtract two numbers
expected ← [-1]
⍤⤙≍ expected evaluate ["3 4 -"]

# Subtraction - errors if there is nothing on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["-"])

# Subtraction - errors if there is only one value on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["1 -"])

# Multiplication - can multiply two numbers
expected ← [8]
⍤⤙≍ expected evaluate ["2 4 *"]

# Multiplication - errors if there is nothing on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["*"])

# Multiplication - errors if there is only one value on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["1 *"])

# Division - can divide two numbers
expected ← [4]
⍤⤙≍ expected evaluate ["12 3 /"]

# Division - performs integer division
expected ← [2]
⍤⤙≍ expected evaluate ["8 3 /"]

# Division - errors if dividing by zero
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["4 0 /"])

# Division - errors if there is nothing on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["/"])

# Division - errors if there is only one value on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["1 /"])

# Combined arithmetic - addition and subtraction
expected ← [-1]
⍤⤙≍ expected evaluate ["1 2 + 4 -"]

# Combined arithmetic - multiplication and division
expected ← [2]
⍤⤙≍ expected evaluate ["2 4 * 3 /"]

# Dup - copies a value on the stack
expected ← [1 1]
⍤⤙≍ expected evaluate ["1 dup"]

# Dup - copies the top value on the stack
expected ← [1 2 2]
⍤⤙≍ expected evaluate ["1 2 dup"]

# Dup - errors if there is nothing on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["dup"])

# Drop - removes the top value on the stack if it is the only one
expected: int list option = []
⍤⤙≍ expected evaluate ["1 drop"]

# Drop - removes the top value on the stack if it is not the only one
expected ← [1]
⍤⤙≍ expected evaluate ["1 2 drop"]

# Drop - errors if there is nothing on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["drop"])

# Swap - swaps the top two values on the stack if they are the only ones
expected ← [2 1]
⍤⤙≍ expected evaluate ["1 2 swap"]

# Swap - swaps the top two values on the stack if they are not the only ones
expected ← [1 3 2]
⍤⤙≍ expected evaluate ["1 2 3 swap"]

# Swap - errors if there is nothing on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["swap"])

# Swap - errors if there is only one value on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["1 swap"])

# Over - copies the second element if there are only two
expected ← [1 2 1]
⍤⤙≍ expected evaluate ["1 2 over"]

# Over - copies the second element if there are more than two
expected ← [1 2 3 2]
⍤⤙≍ expected evaluate ["1 2 3 over"]

# Over - errors if there is nothing on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["over"])

# Over - errors if there is only one value on the stack
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["1 over"])

# User-defined words - can consist of built-in words
expected ← [1 1 1]
⍤⤙≍ expected evaluate [": dup-twice dup dup ;" "1 dup-twice"]

# User-defined words - execute in the right order
expected ← [1 2 3]
⍤⤙≍ expected evaluate [": countup 1 2 3 ;" "countup"]

# User-defined words - can override other user-defined words
expected ← [1 1 1]
⍤⤙≍ expected evaluate [": foo dup ;" ": foo dup dup ;" "1 foo"]

# User-defined words - can override built-in words
expected ← [1 1]
⍤⤙≍ expected evaluate [": swap dup ;" "1 swap"]

# User-defined words - can override built-in operators
expected ← [12]
⍤⤙≍ expected evaluate [": + * ;" "3 4 +"]

# User-defined words - can use different words with the same name
expected ← [5 6]
⍤⤙≍ expected evaluate [": foo 5 ;" ": bar foo ;" ": foo 6 ;" "bar foo"]

# User-defined words - can define word that uses word with the same name
expected ← [11]
⍤⤙≍ expected evaluate [": foo 10 ;" ": foo foo 1 + ;" "foo"]

# User-defined words - cannot redefine non-negative numbers
⍤⤙≍ "TODO: insert error message" ⍣(evaluate [": 1 2 ;"])

# User-defined words - cannot redefine negative numbers
⍤⤙≍ "TODO: insert error message" ⍣(evaluate [": -1 2 ;"])

# User-defined words - errors if executing a non-existent word
⍤⤙≍ "TODO: insert error message" ⍣(evaluate ["foo"])

# User-defined words - only defines locally
⍤⤙≍ [0] evaluate [": + - ;" "1 1 +"]
⍤⤙≍ [2] evaluate ["1 1 +"]

# Case-insensitivity - DUP is case-insensitive
expected ← [1 1 1 1]
⍤⤙≍ expected evaluate ["1 DUP Dup dup"]

# Case-insensitivity - DROP is case-insensitive
expected ← [1]
⍤⤙≍ expected evaluate ["1 2 3 4 DROP Drop drop"]

# Case-insensitivity - SWAP is case-insensitive
expected ← [2 3 4 1]
⍤⤙≍ expected evaluate ["1 2 SWAP 3 Swap 4 swap"]

# Case-insensitivity - OVER is case-insensitive
expected ← [1 2 1 2 1]
⍤⤙≍ expected evaluate ["1 2 OVER Over over"]

# Case-insensitivity - user-defined words are case-insensitive
expected ← [1 1 1 1]
⍤⤙≍ expected evaluate [": foo dup ;" "1 FOO Foo foo"]

# Case-insensitivity - definitions are case-insensitive
expected ← [1 1 1 1]
⍤⤙≍ expected evaluate [": SWAP DUP Dup dup ;" "1 swap"]
