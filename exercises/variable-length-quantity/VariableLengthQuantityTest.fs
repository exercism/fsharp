module VariableLengthQuantityTest

open Xunit
open FsUnit
open System

open VariableLengthQuantity

[<Fact>]
let ``To single byte`` () =
    toBytes [0x00u] |> should equal [0x00uy]
    toBytes [0x40u] |> should equal [0x40uy]
    toBytes [0x7fu] |> should equal [0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``To double byte`` () =
    toBytes [0x80u] |> should equal [0x81uy; 0x00uy]
    toBytes [0x2000u] |> should equal [0xc0uy; 0x00uy]
    toBytes [0x3fffu] |> should equal [0xffuy; 0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``To triple byte`` () =
    toBytes [0x4000u] |> should equal [0x81uy; 0x80uy; 0x00uy]
    toBytes [0x100000u] |> should equal [0xc0uy; 0x80uy; 0x00uy]
    toBytes [0x1fffffu] |> should equal [0xffuy; 0xffuy; 0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``To quadruple byte`` () =
    toBytes [0x200000u] |> should equal [0x81uy; 0x80uy; 0x80uy; 0x00uy]
    toBytes [0x08000000u] |> should equal [0xc0uy; 0x80uy; 0x80uy; 0x00uy]
    toBytes [0x0fffffffu] |> should equal [0xffuy; 0xffuy; 0xffuy; 0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``To quintuple byte`` () =
    toBytes [0x10000000u] |> should equal [0x81uy; 0x80uy; 0x80uy; 0x80uy; 0x00uy]
    toBytes [0xff000000u] |> should equal [0x8fuy; 0xf8uy; 0x80uy; 0x80uy; 0x00uy]
    toBytes [0xffffffffu] |> should equal [0x8fuy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy]

[<Fact(Skip = "Remove to run test")>]
let ``From bytes`` () =
    fromBytes [0x7fuy] |> should equal [0x7fu]
    fromBytes [0xc0uy; 0x00uy] |> should equal [0x2000u]
    fromBytes [0xffuy; 0xffuy; 0x7fuy] |> should equal [0x1fffffu]
    fromBytes [0x81uy; 0x80uy; 0x80uy; 0x00uy] |> should equal [0x200000u]
    fromBytes [0x8fuy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy] |> should equal [0xffffffffu]

[<Fact(Skip = "Remove to run test")>]
let ``To bytes multiple values`` () =
    toBytes [0x40u; 0x7fu] |> should equal [0x40uy; 0x7fuy]
    toBytes [0x4000u; 0x123456u] |> should equal [0x81uy; 0x80uy; 0x00uy; 0xc8uy; 0xe8uy; 0x56uy]
    toBytes [0x2000u; 0x123456u; 0x0fffffffu; 0x00u; 0x3fffu; 0x4000u] |> should equal [0xc0uy; 0x00uy; 0xc8uy; 0xe8uy; 0x56uy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy; 0x00uy; 0xffuy; 0x7fuy; 0x81uy; 0x80uy; 0x00uy]

[<Fact(Skip = "Remove to run test")>]
let ``From bytes multiple values`` () =
    fromBytes [0xc0uy; 0x00uy; 0xc8uy; 0xe8uy; 0x56uy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy; 0x00uy; 0xffuy; 0x7fuy; 0x81uy; 0x80uy; 0x00uy] |> should equal [0x2000u; 0x123456u; 0x0fffffffu; 0x00u; 0x3fffu; 0x4000u]

[<Fact(Skip = "Remove to run test")>]
let ``Incomplete byte sequence`` () =
    (fun () -> fromBytes [0xffuy] |> ignore) |> should throw typeof<Exception>

[<Fact(Skip = "Remove to run test")>]
let ``Overflow`` () =    
    (fun () -> fromBytes [0xffuy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy] |> ignore) |> should throw typeof<Exception>

[<Fact(Skip = "Remove to run test")>]
let ``Chained execution is identity`` () =
    let test = [0xf2u; 0xf6u; 0x96u; 0x9cu; 0x3bu; 0x39u; 0x2eu; 0x30u; 0xb3u; 0x24u];
    toBytes test |> fromBytes |> should equal test