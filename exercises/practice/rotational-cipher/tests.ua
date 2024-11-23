~ "rotational-cipher.ua" ~ RotationalCipher

let ``Rotate a by 0, same output as input`` () =
    rotate 0 "a" |> should equal "a"

let ``Rotate a by 1`` () =
    rotate 1 "a" |> should equal "b"

let ``Rotate a by 26, same output as input`` () =
    rotate 26 "a" |> should equal "a"

let ``Rotate m by 13`` () =
    rotate 13 "m" |> should equal "z"

let ``Rotate n by 13 with wrap around alphabet`` () =
    rotate 13 "n" |> should equal "a"

let ``Rotate capital letters`` () =
    rotate 5 "OMG" |> should equal "TRL"

let ``Rotate spaces`` () =
    rotate 5 "O M G" |> should equal "T R L"

let ``Rotate numbers`` () =
    rotate 4 "Testing 1 2 3 testing" |> should equal "Xiwxmrk 1 2 3 xiwxmrk"

let ``Rotate punctuation`` () =
    rotate 21 "Let's eat, Grandma!" |> should equal "Gzo'n zvo, Bmviyhv!"

let ``Rotate all letters`` () =
    rotate 13 "The quick brown fox jumps over the lazy dog." |> should equal "Gur dhvpx oebja sbk whzcf bire gur ynml qbt."

