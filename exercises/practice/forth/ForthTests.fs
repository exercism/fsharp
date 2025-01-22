source("./forth.R")
library(testthat)

let ``Parsing and numbers - numbers just get pushed onto the stack`` () =
    expected <- Some [1; 2; 3; 4; 5]
    expect_equal(evaluate ["1 2 3 4 5"], expected)

let ``Parsing and numbers - pushes negative numbers onto the stack`` () =
    expected <- Some [-1; -2; -3; -4; -5]
    expect_equal(evaluate ["-1 -2 -3 -4 -5"], expected)

let ``Addition - can add two numbers`` () =
    expected <- Some [3]
    expect_equal(evaluate ["1 2 +"], expected)

let ``Addition - errors if there is nothing on the stack`` () =
    expected <- None
    expect_equal(evaluate ["+"], expected)

let ``Addition - errors if there is only one value on the stack`` () =
    expected <- None
    expect_equal(evaluate ["1 +"], expected)

let ``Subtraction - can subtract two numbers`` () =
    expected <- Some [-1]
    expect_equal(evaluate ["3 4 -"], expected)

let ``Subtraction - errors if there is nothing on the stack`` () =
    expected <- None
    expect_equal(evaluate ["-"], expected)

let ``Subtraction - errors if there is only one value on the stack`` () =
    expected <- None
    expect_equal(evaluate ["1 -"], expected)

let ``Multiplication - can multiply two numbers`` () =
    expected <- Some [8]
    expect_equal(evaluate ["2 4 *"], expected)

let ``Multiplication - errors if there is nothing on the stack`` () =
    expected <- None
    expect_equal(evaluate ["*"], expected)

let ``Multiplication - errors if there is only one value on the stack`` () =
    expected <- None
    expect_equal(evaluate ["1 *"], expected)

let ``Division - can divide two numbers`` () =
    expected <- Some [4]
    expect_equal(evaluate ["12 3 /"], expected)

let ``Division - performs integer division`` () =
    expected <- Some [2]
    expect_equal(evaluate ["8 3 /"], expected)

let ``Division - errors if dividing by zero`` () =
    expected <- None
    expect_equal(evaluate ["4 0 /"], expected)

let ``Division - errors if there is nothing on the stack`` () =
    expected <- None
    expect_equal(evaluate ["/"], expected)

let ``Division - errors if there is only one value on the stack`` () =
    expected <- None
    expect_equal(evaluate ["1 /"], expected)

let ``Combined arithmetic - addition and subtraction`` () =
    expected <- Some [-1]
    expect_equal(evaluate ["1 2 + 4 -"], expected)

let ``Combined arithmetic - multiplication and division`` () =
    expected <- Some [2]
    expect_equal(evaluate ["2 4 * 3 /"], expected)

let ``Dup - copies a value on the stack`` () =
    expected <- Some [1; 1]
    expect_equal(evaluate ["1 dup"], expected)

let ``Dup - copies the top value on the stack`` () =
    expected <- Some [1; 2; 2]
    expect_equal(evaluate ["1 2 dup"], expected)

let ``Dup - errors if there is nothing on the stack`` () =
    expected <- None
    expect_equal(evaluate ["dup"], expected)

let ``Drop - removes the top value on the stack if it is the only one`` () =
    let expected: int list option = Some []
    expect_equal(evaluate ["1 drop"], expected)

let ``Drop - removes the top value on the stack if it is not the only one`` () =
    expected <- Some [1]
    expect_equal(evaluate ["1 2 drop"], expected)

let ``Drop - errors if there is nothing on the stack`` () =
    expected <- None
    expect_equal(evaluate ["drop"], expected)

let ``Swap - swaps the top two values on the stack if they are the only ones`` () =
    expected <- Some [2; 1]
    expect_equal(evaluate ["1 2 swap"], expected)

let ``Swap - swaps the top two values on the stack if they are not the only ones`` () =
    expected <- Some [1; 3; 2]
    expect_equal(evaluate ["1 2 3 swap"], expected)

let ``Swap - errors if there is nothing on the stack`` () =
    expected <- None
    expect_equal(evaluate ["swap"], expected)

let ``Swap - errors if there is only one value on the stack`` () =
    expected <- None
    expect_equal(evaluate ["1 swap"], expected)

let ``Over - copies the second element if there are only two`` () =
    expected <- Some [1; 2; 1]
    expect_equal(evaluate ["1 2 over"], expected)

let ``Over - copies the second element if there are more than two`` () =
    expected <- Some [1; 2; 3; 2]
    expect_equal(evaluate ["1 2 3 over"], expected)

let ``Over - errors if there is nothing on the stack`` () =
    expected <- None
    expect_equal(evaluate ["over"], expected)

let ``Over - errors if there is only one value on the stack`` () =
    expected <- None
    expect_equal(evaluate ["1 over"], expected)

let ``User-defined words - can consist of built-in words`` () =
    expected <- Some [1; 1; 1]
    expect_equal(evaluate [": dup-twice dup dup ;"; "1 dup-twice"], expected)

let ``User-defined words - execute in the right order`` () =
    expected <- Some [1; 2; 3]
    expect_equal(evaluate [": countup 1 2 3 ;"; "countup"], expected)

let ``User-defined words - can override other user-defined words`` () =
    expected <- Some [1; 1; 1]
    expect_equal(evaluate [": foo dup ;"; ": foo dup dup ;"; "1 foo"], expected)

let ``User-defined words - can override built-in words`` () =
    expected <- Some [1; 1]
    expect_equal(evaluate [": swap dup ;"; "1 swap"], expected)

let ``User-defined words - can override built-in operators`` () =
    expected <- Some [12]
    expect_equal(evaluate [": + * ;"; "3 4 +"], expected)

let ``User-defined words - can use different words with the same name`` () =
    expected <- Some [5; 6]
    expect_equal(evaluate [": foo 5 ;"; ": bar foo ;"; ": foo 6 ;"; "bar foo"], expected)

let ``User-defined words - can define word that uses word with the same name`` () =
    expected <- Some [11]
    expect_equal(evaluate [": foo 10 ;"; ": foo foo 1 + ;"; "foo"], expected)

let ``User-defined words - cannot redefine non-negative numbers`` () =
    expected <- None
    expect_equal(evaluate [": 1 2 ;"], expected)

let ``User-defined words - cannot redefine negative numbers`` () =
    expected <- None
    expect_equal(evaluate [": -1 2 ;"], expected)

let ``User-defined words - errors if executing a non-existent word`` () =
    expected <- None
    expect_equal(evaluate ["foo"], expected)

let ``User-defined words - only defines locally`` () =
    expect_equal(evaluate [": + - ;"; "1 1 +"], (Some [0]))
    expect_equal(evaluate ["1 1 +"], (Some [2]))

let ``Case-insensitivity - DUP is case-insensitive`` () =
    expected <- Some [1; 1; 1; 1]
    expect_equal(evaluate ["1 DUP Dup dup"], expected)

let ``Case-insensitivity - DROP is case-insensitive`` () =
    expected <- Some [1]
    expect_equal(evaluate ["1 2 3 4 DROP Drop drop"], expected)

let ``Case-insensitivity - SWAP is case-insensitive`` () =
    expected <- Some [2; 3; 4; 1]
    expect_equal(evaluate ["1 2 SWAP 3 Swap 4 swap"], expected)

let ``Case-insensitivity - OVER is case-insensitive`` () =
    expected <- Some [1; 2; 1; 2; 1]
    expect_equal(evaluate ["1 2 OVER Over over"], expected)

let ``Case-insensitivity - user-defined words are case-insensitive`` () =
    expected <- Some [1; 1; 1; 1]
    expect_equal(evaluate [": foo dup ;"; "1 FOO Foo foo"], expected)

let ``Case-insensitivity - definitions are case-insensitive`` () =
    expected <- Some [1; 1; 1; 1]
    expect_equal(evaluate [": SWAP DUP Dup dup ;"; "1 swap"], expected)

