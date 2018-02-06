// This file was auto-generated based on version 1.1.0 of the canonical data.

module VariableLengthQuantityTest

open FsUnit.Xunit
open Xunit

open VariableLengthQuantity

[<Fact>]
let ``Zero`` () =
    encode [0x0u] |> should equal [0x0uy]

[<Fact(Skip = "Remove to run test")>]
let ``Arbitrary single byte`` () =
    encode [0x40u] |> should equal [0x40uy]

[<Fact(Skip = "Remove to run test")>]
let ``Largest single byte`` () =
    encode [0x7fu] |> should equal [0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``Smallest double byte`` () =
    encode [0x80u] |> should equal [0x81uy; 0x0uy]

[<Fact(Skip = "Remove to run test")>]
let ``Arbitrary double byte`` () =
    encode [0x2000u] |> should equal [0xc0uy; 0x0uy]

[<Fact(Skip = "Remove to run test")>]
let ``Largest double byte`` () =
    encode [0x3fffu] |> should equal [0xffuy; 0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``Smallest triple byte`` () =
    encode [0x4000u] |> should equal [0x81uy; 0x80uy; 0x0uy]

[<Fact(Skip = "Remove to run test")>]
let ``Arbitrary triple byte`` () =
    encode [0x100000u] |> should equal [0xc0uy; 0x80uy; 0x0uy]

[<Fact(Skip = "Remove to run test")>]
let ``Largest triple byte`` () =
    encode [0x1fffffu] |> should equal [0xffuy; 0xffuy; 0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``Smallest quadruple byte`` () =
    encode [0x200000u] |> should equal [0x81uy; 0x80uy; 0x80uy; 0x0uy]

[<Fact(Skip = "Remove to run test")>]
let ``Arbitrary quadruple byte`` () =
    encode [0x8000000u] |> should equal [0xc0uy; 0x80uy; 0x80uy; 0x0uy]

[<Fact(Skip = "Remove to run test")>]
let ``Largest quadruple byte`` () =
    encode [0xfffffffu] |> should equal [0xffuy; 0xffuy; 0xffuy; 0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``Smallest quintuple byte`` () =
    encode [0x10000000u] |> should equal [0x81uy; 0x80uy; 0x80uy; 0x80uy; 0x0uy]

[<Fact(Skip = "Remove to run test")>]
let ``Arbitrary quintuple byte`` () =
    encode [0xff000000u] |> should equal [0x8fuy; 0xf8uy; 0x80uy; 0x80uy; 0x0uy]

[<Fact(Skip = "Remove to run test")>]
let ``Maximum 32-bit integer input`` () =
    encode [0xffffffffu] |> should equal [0x8fuy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``Two single-byte values`` () =
    encode [0x40u; 0x7fu] |> should equal [0x40uy; 0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``Two multi-byte values`` () =
    encode [0x4000u; 0x123456u] |> should equal [0x81uy; 0x80uy; 0x0uy; 0xc8uy; 0xe8uy; 0x56uy]

[<Fact(Skip = "Remove to run test")>]
let ``Many multi-byte values`` () =
    encode [0x2000u; 0x123456u; 0xfffffffu; 0x0u; 0x3fffu; 0x4000u] |> should equal [0xc0uy; 0x0uy; 0xc8uy; 0xe8uy; 0x56uy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy; 0x0uy; 0xffuy; 0x7fuy; 0x81uy; 0x80uy; 0x0uy]

[<Fact(Skip = "Remove to run test")>]
let ``One byte`` () =
    decode [0x7fuy] |> should equal (Some [0x7fu])

[<Fact(Skip = "Remove to run test")>]
let ``Two bytes`` () =
    decode [0xc0uy; 0x0uy] |> should equal (Some [0x2000u])

[<Fact(Skip = "Remove to run test")>]
let ``Three bytes`` () =
    decode [0xffuy; 0xffuy; 0x7fuy] |> should equal (Some [0x1fffffu])

[<Fact(Skip = "Remove to run test")>]
let ``Four bytes`` () =
    decode [0x81uy; 0x80uy; 0x80uy; 0x0uy] |> should equal (Some [0x200000u])

[<Fact(Skip = "Remove to run test")>]
let ``Maximum 32-bit integer`` () =
    decode [0x8fuy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy] |> should equal (Some [0xffffffffu])

[<Fact(Skip = "Remove to run test")>]
let ``Incomplete sequence causes error`` () =
    decode [0xffuy] |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Incomplete sequence causes error, even if value is zero`` () =
    decode [0x80uy] |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Multiple values`` () =
    decode [0xc0uy; 0x0uy; 0xc8uy; 0xe8uy; 0x56uy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy; 0x0uy; 0xffuy; 0x7fuy; 0x81uy; 0x80uy; 0x0uy] |> should equal (Some [0x2000u; 0x123456u; 0xfffffffu; 0x0u; 0x3fffu; 0x4000u])

