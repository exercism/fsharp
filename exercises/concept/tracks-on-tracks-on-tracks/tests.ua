~ "SOLUTION" ~ TracksOnTracksOnTracks

let ``New list``() =
    let expected: string list = []
    newList |> should equal expected

let ``Existing list``() = existingList |> should equal [ "F#"; "Clojure"; "Haskell" ]

let ``Add language to new list``() = addLanguage "Scala" newList |> should equal [ "Scala" ]

let ``Add language to existing list``() =
    addLanguage "Common Lisp" existingList |> should equal [ "Common Lisp"; "F#"; "Clojure"; "Haskell" ]

let ``Add language to custom list``() = addLanguage "Racket" [ "Scheme" ] |> should equal [ "Racket"; "Scheme" ]

let ``Count languages on new list``() = countLanguages newList |> should equal 0

let ``Count languages on existing list``() = countLanguages existingList |> should equal 3

let ``Count languages on custom list``() = countLanguages [ "Python"; "JavaScript" ] |> should equal 2

let ``Reverse order of new list``() =
    let expected: string list = []
    reverseList newList |> should equal expected

let ``Reverse order of existing list``() = reverseList existingList |> should equal [ "Haskell"; "Clojure"; "F#" ]

let ``Reverse order of custom list``() =
    reverseList [ "Kotlin"; "Java"; "Scala"; "Clojure" ] |> should equal [ "Clojure"; "Scala"; "Java"; "Kotlin" ]

let ``Empty list is not exciting``() = excitingList [] |> should equal false

let ``Singleton list with F# is exciting``() = excitingList [ "F#" ] |> should equal true

let ``Singleton list without fsharp is not exciting``() = excitingList [ "C#" ] |> should equal false

let ``Two-item list with F# as first item is exciting``() = excitingList [ "F#"; "Clojure" ] |> should equal true

let ``Two-item list with F# as second item is exciting``() = excitingList [ "Nim"; "F#" ] |> should equal true

let ``Two-item list without F# is not exciting``() = excitingList [ "Python"; "Go" ] |> should equal false

let ``Three-item list with F# as first item is exciting``() =
    excitingList [ "F#"; "Lisp"; "Clojure" ] |> should equal true

let ``Three-item list with F# as second item is exciting``() =
    excitingList [ "Java"; "F#"; "C#" ] |> should equal true

let ``Three-item list with F# as third item is not exciting``() =
    excitingList [ "Julia"; "Assembly"; "F#" ] |> should equal false

let ``Four-item list with F# as first item is exciting``() =
    excitingList [ "F#"; "C"; "C++"; "C#" ] |> should equal true

let ``Four-item list with F# as second item is not exciting``() =
    excitingList [ "Elm"; "F#"; "C#"; "Scheme" ] |> should equal false

let ``Four-item list with F# as third item is not exciting``() =
    excitingList [ "Delphi"; "D"; "F#"; "Prolog" ] |> should equal false

let ``Four-item list with F# as fourth item is not exciting``() =
    excitingList [ "Julia"; "Assembly"; "Crystal"; "F#" ] |> should equal false
