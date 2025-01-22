source("./tracks-on-tracks-on-tracks.R")
library(testthat)

[<Task(1)>]
let ``New list``() =
    let expected: string list = []
    newList |> should equal expected

[<Task(2)>]
let ``Existing list``() = existingList |> should equal [ "F#"; "Clojure"; "Haskell" ]

[<Task(3)>]
let ``Add language to new list``() = addLanguage "Scala" newList |> should equal [ "Scala" ]

[<Task(3)>]
let ``Add language to existing list``() =
    addLanguage "Common Lisp" existingList |> should equal [ "Common Lisp"; "F#"; "Clojure"; "Haskell" ]

[<Task(3)>]
let ``Add language to custom list``() = addLanguage "Racket" [ "Scheme" ] |> should equal [ "Racket"; "Scheme" ]

[<Task(4)>]
let ``Count languages on new list``() = countLanguages newList |> should equal 0

[<Task(4)>]
let ``Count languages on existing list``() = countLanguages existingList |> should equal 3

[<Task(4)>]
let ``Count languages on custom list``() = countLanguages [ "Python"; "JavaScript" ] |> should equal 2

[<Task(5)>]
let ``Reverse order of new list``() =
    let expected: string list = []
    reverseList newList |> should equal expected

[<Task(5)>]
let ``Reverse order of existing list``() = reverseList existingList |> should equal [ "Haskell"; "Clojure"; "F#" ]

[<Task(5)>]
let ``Reverse order of custom list``() =
    reverseList [ "Kotlin"; "Java"; "Scala"; "Clojure" ] |> should equal [ "Clojure"; "Scala"; "Java"; "Kotlin" ]

[<Task(6)>]
let ``Empty list is not exciting``() = excitingList [] |> should equal false

[<Task(6)>]
let ``Singleton list with F# is exciting``() = excitingList [ "F#" ] |> should equal true

[<Task(6)>]
let ``Singleton list without fsharp is not exciting``() = excitingList [ "C#" ] |> should equal false

[<Task(6)>]
let ``Two-item list with F# as first item is exciting``() = excitingList [ "F#"; "Clojure" ] |> should equal true

[<Task(6)>]
let ``Two-item list with F# as second item is exciting``() = excitingList [ "Nim"; "F#" ] |> should equal true

[<Task(6)>]
let ``Two-item list without F# is not exciting``() = excitingList [ "Python"; "Go" ] |> should equal false

[<Task(6)>]
let ``Three-item list with F# as first item is exciting``() =
    excitingList [ "F#"; "Lisp"; "Clojure" ] |> should equal true

[<Task(6)>]
let ``Three-item list with F# as second item is exciting``() =
    excitingList [ "Java"; "F#"; "C#" ] |> should equal true

[<Task(6)>]
let ``Three-item list with F# as third item is not exciting``() =
    excitingList [ "Julia"; "Assembly"; "F#" ] |> should equal false

[<Task(6)>]
let ``Four-item list with F# as first item is exciting``() =
    excitingList [ "F#"; "C"; "C++"; "C#" ] |> should equal true

[<Task(6)>]
let ``Four-item list with F# as second item is not exciting``() =
    excitingList [ "Elm"; "F#"; "C#"; "Scheme" ] |> should equal false

[<Task(6)>]
let ``Four-item list with F# as third item is not exciting``() =
    excitingList [ "Delphi"; "D"; "F#"; "Prolog" ] |> should equal false

[<Task(6)>]
let ``Four-item list with F# as fourth item is not exciting``() =
    excitingList [ "Julia"; "Assembly"; "Crystal"; "F#" ] |> should equal false
