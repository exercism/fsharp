module SqueakyCleanTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open SqueakyClean

[<Fact>]
[<Task(1)>]
let ``Clean_empty_string``() = clean "" |> should equal ""

[<Fact>]
[<Task(1)>]
let ``Clean_single_letter``() = clean "a" |> should equal "a"

[<Fact>]
[<Task(1)>]
let ``Clean_clean_string``() = clean "àḃç" |> should equal "àḃç"

[<Fact>]
[<Task(1)>]
let ``Clean_string_with_hyphens``() = clean "à-ḃ-ç" |> should equal "à_ḃ_ç"

[<Fact>]
[<Task(2)>]
let ``Clean_string_with_spaces``() = clean "my   id" |> should equal "myid"

[<Fact>]
[<Task(2)>]
let ``Clean_string_with_leading_and_trailing_spaces``() = clean "   my   id  " |> should equal "myid"

[<Fact>]
[<Task(3)>]
let ``Convert_camel_to_kebab_case``() = clean "àḂç" |> should equal "à-ḃç"

[<Fact>]
[<Task(4)>]
let ``Clean_string_with_numbers``() = clean "1my2😀finder3" |> should equal "my😀finder"

[<Fact>]
[<Task(5)>]
let ``Replace_lower_case_greek_letters``() = clean "myβιεγτfinder" |> should equal "my?????finder"

[<Fact>]
[<Task(5)>]
let ``Combine_conversions``() = clean "9 cAbcĐ😀ω" |> should equal "c-abc-đ😀ω"
