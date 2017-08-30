module PhoneNumberTest

open Xunit
open FsUnit

open PhoneNumber

[<Fact>]
let ``Cleans phone number`` () =
    parsePhoneNumber "(123) 456-7890" |> should equal <| Some "1234567890"

[<Fact(Skip = "Remove to run test")>]
let ``Cleans phone number with dots`` () =
    parsePhoneNumber "123.456.7890" |> should equal <| Some "1234567890"

[<Fact(Skip = "Remove to run test")>]
let ``Valid when 11 digits and first is 1`` () =
    parsePhoneNumber "11234567890" |> should equal <| Some "1234567890"

[<Fact(Skip = "Remove to run test")>]
let ``Invalid when 11 digits`` () =
    parsePhoneNumber "21234567890" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Invalid when 9 digits`` () =
    parsePhoneNumber "123456789" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Invalid when 12 digits`` () =
    parsePhoneNumber "123456789012" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Invalid when empty`` () =
    parsePhoneNumber "" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Invalid when no digits present`` () =
    parsePhoneNumber " (-) " |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Valid with leading characters`` () =
    parsePhoneNumber "my parsePhoneNumber is 123 456 7890" |> should equal <| Some "1234567890"

[<Fact(Skip = "Remove to run test")>]
let ``Valid with trailing characters`` () =
    parsePhoneNumber "123 456 7890 - bob" |> should equal <| Some "1234567890"