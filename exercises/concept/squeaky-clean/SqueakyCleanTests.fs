source("./squeaky-clean.R")
library(testthat)

[<Task(1)>]
    expect_equal(let ``Clean_single_letter``() = transform 'a', "a")

[<Task(1)>]
    expect_equal(let ``Clean_hyphen``() = transform '-', "_")

[<Task(2)>]
    expect_equal(let ``Remove_whitespace``() = transform ' ', "")

[<Task(3)>]
    expect_equal(let ``Convert_camel_to_kebab_case``() = transform 'Γ', "-γ")

[<Task(4)>]
    expect_equal(let ``Remove_digits``() = transform '4', "")

[<Task(5)>]
    expect_equal(let ``Replace_lower_case_greek_letters``() = transform 'ω', "?")

[<Task(6)>]
    expect_equal(let ``Clean_empty_string``() = clean "", "")

[<Task(6)>]
    expect_equal(let ``Clean_clean_string``() = clean "àḃç", "àḃç")

[<Task(6)>]
    expect_equal(let ``Clean_string_with_spaces``() = clean "my   id", "myid")

[<Task(6)>]
    expect_equal(let ``Clean_string_with_leading_and_trailing_spaces``() = clean "   my   id  ", "myid")

[<Task(6)>]
    expect_equal(let ``Combine_conversions``() = clean "9 cAbcĐ😀ω", "c-abc-đ😀?")
