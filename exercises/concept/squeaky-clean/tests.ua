

let ``Clean_single_letter``() = transform 'a' |> should equal "a"

let ``Clean_hyphen``() = transform '-' |> should equal "_"

let ``Remove_whitespace``() = transform ' ' |> should equal ""

let ``Convert_camel_to_kebab_case``() = transform 'Γ' |> should equal "-γ"

let ``Remove_digits``() = transform '4' |> should equal ""

let ``Replace_lower_case_greek_letters``() = transform 'ω' |> should equal "?"

let ``Clean_empty_string``() = clean "" |> should equal ""

let ``Clean_clean_string``() = clean "àḃç" |> should equal "àḃç"

let ``Clean_string_with_spaces``() = clean "my   id" |> should equal "myid"

let ``Clean_string_with_leading_and_trailing_spaces``() = clean "   my   id  " |> should equal "myid"

let ``Combine_conversions``() = clean "9 cAbcĐ😀ω" |> should equal "c-abc-đ😀?"
