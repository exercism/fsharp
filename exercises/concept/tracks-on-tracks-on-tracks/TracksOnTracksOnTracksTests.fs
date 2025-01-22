source("./tracks-on-tracks-on-tracks.R")
library(testthat)

[<Task(1)>]
let ``New list``() =
    let expected: string list = []
    expect_equal(newList, expected)

[<Task(2)>]
    expect_equal(let ``Existing list``() = existingList, [ "F#"; "Clojure"; "Haskell" ])

[<Task(3)>]
    expect_equal(let ``Add language to new list``() = addLanguage "Scala" newList, [ "Scala" ])

[<Task(3)>]
let ``Add language to existing list``() =
    expect_equal(addLanguage "Common Lisp" existingList, [ "Common Lisp"; "F#"; "Clojure"; "Haskell" ])

[<Task(3)>]
    expect_equal(let ``Add language to custom list``() = addLanguage "Racket" [ "Scheme" ], [ "Racket"; "Scheme" ])

[<Task(4)>]
    expect_equal(let ``Count languages on new list``() = countLanguages newList, 0)

[<Task(4)>]
    expect_equal(let ``Count languages on existing list``() = countLanguages existingList, 3)

[<Task(4)>]
    expect_equal(let ``Count languages on custom list``() = countLanguages [ "Python"; "JavaScript" ], 2)

[<Task(5)>]
let ``Reverse order of new list``() =
    let expected: string list = []
    expect_equal(reverseList newList, expected)

[<Task(5)>]
    expect_equal(let ``Reverse order of existing list``() = reverseList existingList, [ "Haskell"; "Clojure"; "F#" ])

[<Task(5)>]
let ``Reverse order of custom list``() =
    expect_equal(reverseList [ "Kotlin"; "Java"; "Scala"; "Clojure" ], [ "Clojure"; "Scala"; "Java"; "Kotlin" ])

[<Task(6)>]
    expect_equal(let ``Empty list is not exciting``() = excitingList [], false)

[<Task(6)>]
    expect_equal(let ``Singleton list with F# is exciting``() = excitingList [ "F#" ], true)

[<Task(6)>]
    expect_equal(let ``Singleton list without fsharp is not exciting``() = excitingList [ "C#" ], false)

[<Task(6)>]
    expect_equal(let ``Two-item list with F# as first item is exciting``() = excitingList [ "F#"; "Clojure" ], true)

[<Task(6)>]
    expect_equal(let ``Two-item list with F# as second item is exciting``() = excitingList [ "Nim"; "F#" ], true)

[<Task(6)>]
    expect_equal(let ``Two-item list without F# is not exciting``() = excitingList [ "Python"; "Go" ], false)

[<Task(6)>]
let ``Three-item list with F# as first item is exciting``() =
    expect_equal(excitingList [ "F#"; "Lisp"; "Clojure" ], true)

[<Task(6)>]
let ``Three-item list with F# as second item is exciting``() =
    expect_equal(excitingList [ "Java"; "F#"; "C#" ], true)

[<Task(6)>]
let ``Three-item list with F# as third item is not exciting``() =
    expect_equal(excitingList [ "Julia"; "Assembly"; "F#" ], false)

[<Task(6)>]
let ``Four-item list with F# as first item is exciting``() =
    expect_equal(excitingList [ "F#"; "C"; "C++"; "C#" ], true)

[<Task(6)>]
let ``Four-item list with F# as second item is not exciting``() =
    expect_equal(excitingList [ "Elm"; "F#"; "C#"; "Scheme" ], false)

[<Task(6)>]
let ``Four-item list with F# as third item is not exciting``() =
    expect_equal(excitingList [ "Delphi"; "D"; "F#"; "Prolog" ], false)

[<Task(6)>]
let ``Four-item list with F# as fourth item is not exciting``() =
    expect_equal(excitingList [ "Julia"; "Assembly"; "Crystal"; "F#" ], false)
