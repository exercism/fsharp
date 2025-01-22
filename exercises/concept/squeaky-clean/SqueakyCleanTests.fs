source("./squeaky-clean.R")
library(testthat)

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open SqueakyClean

[<Task(1)>]
let ``Clean_single_letter``() = transform 'a' |> should equal "a"

[<Task(1)>]
let ``Clean_hyphen``() = transform '-' |> should equal "_"

[<Task(2)>]
let ``Remove_whitespace``() = transform ' ' |> should equal ""

[<Task(3)>]
let ``Convert_camel_to_kebab_case``() = transform 'Γ' |> should equal "-γ"

[<Task(4)>]
let ``Remove_digits``() = transform '4' |> should equal ""

[<Task(5)>]
let ``Replace_lower_case_greek_letters``() = transform 'ω' |> should equal "?"

[<Task(6)>]
let ``Clean_empty_string``() = clean "" |> should equal ""

[<Task(6)>]
let ``Clean_clean_string``() = clean "àḃç" |> should equal "àḃç"

[<Task(6)>]
let ``Clean_string_with_spaces``() = clean "my   id" |> should equal "myid"

[<Task(6)>]
let ``Clean_string_with_leading_and_trailing_spaces``() = clean "   my   id  " |> should equal "myid"

[<Task(6)>]
let ``Combine_conversions``() = clean "9 cAbcĐ😀ω" |> should equal "c-abc-đ😀?"
