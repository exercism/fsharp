module SqueakyCleanTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open SqueakyClean

[<Fact>]
[<Task(1)>]
let ``Clean_single_letter``() = clean "A" |> should equal "A"

[<Fact>]
[<Task(1)>]
let ``Clean_clean_string``() = clean "àḃç" |> should equal "àḃç"

[<Fact>]
[<Task(1)>]
let ``Clean_string_with_spaces``() = clean "my   Id" |> should equal "my___Id"

[<Fact>]
[<Task(1)>]
let ``Clean_empty_string``() = clean "" |> should equal ""

[<Fact>]
[<Task(2)>]
let ``Convert_kebab_to_camel_case``() = clean "à-ḃç" |> should equal "àḂç"

[<Fact>]
[<Task(3)>]
let ``Clean_string_with_special_characters``() = clean "My😀😀Finder😀" |> should equal "MyFinder"

[<Fact>]
[<Task(3)>]
let ``Clean_string_with_numbers``() = clean "1My2Finder3" |> should equal "MyFinder"

[<Fact>]
[<Task(4)>]
let ``Omit_lower_case_greek_letters``() = clean "MyΟβιεγτFinder" |> should equal "MyΟFinder"

[<Fact>]
[<Task(4)>]
let ``Combine_conversions``() = clean "9 -abcĐ😀ω\0" |> should equal "_AbcĐ"
