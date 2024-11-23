~ "SOLUTION" ~ Isogram

let ``Empty string`` () =
    isIsogram "" |> should equal true

let ``Isogram with only lower case characters`` () =
    isIsogram "isogram" |> should equal true

let ``Word with one duplicated character`` () =
    isIsogram "eleven" |> should equal false

let ``Word with one duplicated character from the end of the alphabet`` () =
    isIsogram "zzyzx" |> should equal false

let ``Longest reported english isogram`` () =
    isIsogram "subdermatoglyphic" |> should equal true

let ``Word with duplicated character in mixed case`` () =
    isIsogram "Alphabet" |> should equal false

let ``Word with duplicated character in mixed case, lowercase first`` () =
    isIsogram "alphAbet" |> should equal false

let ``Hypothetical isogrammic word with hyphen`` () =
    isIsogram "thumbscrew-japingly" |> should equal true

let ``Hypothetical word with duplicated character following hyphen`` () =
    isIsogram "thumbscrew-jappingly" |> should equal false

let ``Isogram with duplicated hyphen`` () =
    isIsogram "six-year-old" |> should equal true

let ``Made-up name that is an isogram`` () =
    isIsogram "Emily Jung Schwartzkopf" |> should equal true

let ``Duplicated character in the middle`` () =
    isIsogram "accentor" |> should equal false

let ``Same first and last characters`` () =
    isIsogram "angola" |> should equal false

let ``Word with duplicated character and with two hyphens`` () =
    isIsogram "up-to-date" |> should equal false

