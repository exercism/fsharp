module VariableLengthQuantityTest

open NUnit.Framework

open VariableLengthQuantity

[<Test>]
let ``To single byte`` () =
    Assert.That(toBytes [0x00u], Is.EqualTo([0x00uy]))
    Assert.That(toBytes [0x40u], Is.EqualTo([0x40uy]))
    Assert.That(toBytes [0x7fu], Is.EqualTo([0x7fuy]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``To double byte`` () =
    Assert.That(toBytes [0x80u], Is.EqualTo([0x81uy; 0x00uy]))
    Assert.That(toBytes [0x2000u], Is.EqualTo([0xc0uy; 0x00uy]))
    Assert.That(toBytes [0x3fffu], Is.EqualTo([0xffuy; 0x7fuy]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``To triple byte`` () =
    Assert.That(toBytes [0x4000u], Is.EqualTo([0x81uy; 0x80uy; 0x00uy]))
    Assert.That(toBytes [0x100000u], Is.EqualTo([0xc0uy; 0x80uy; 0x00uy]))
    Assert.That(toBytes [0x1fffffu], Is.EqualTo([0xffuy; 0xffuy; 0x7fuy]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``To quadruple byte`` () =
    Assert.That(toBytes [0x200000u], Is.EqualTo([0x81uy; 0x80uy; 0x80uy; 0x00uy]))
    Assert.That(toBytes [0x08000000u], Is.EqualTo([0xc0uy; 0x80uy; 0x80uy; 0x00uy]))
    Assert.That(toBytes [0x0fffffffu], Is.EqualTo([0xffuy; 0xffuy; 0xffuy; 0x7fuy]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``To quintuple byte`` () =
    Assert.That(toBytes [0x10000000u], Is.EqualTo([0x81uy; 0x80uy; 0x80uy; 0x80uy; 0x00uy]))
    Assert.That(toBytes [0xff000000u], Is.EqualTo([0x8fuy; 0xf8uy; 0x80uy; 0x80uy; 0x00uy]))
    Assert.That(toBytes [0xffffffffu], Is.EqualTo([0x8fuy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``From bytes`` () =
    Assert.That(fromBytes [0x7fuy], Is.EqualTo([0x7fu]))
    Assert.That(fromBytes [0xc0uy; 0x00uy], Is.EqualTo([0x2000u]))
    Assert.That(fromBytes [0xffuy; 0xffuy; 0x7fuy], Is.EqualTo([0x1fffffu]))
    Assert.That(fromBytes [0x81uy; 0x80uy; 0x80uy; 0x00uy], Is.EqualTo([0x200000u]))
    Assert.That(fromBytes [0x8fuy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy], Is.EqualTo([0xffffffffu]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``To bytes multiple values`` () =
    Assert.That(toBytes [0x40u; 0x7fu], Is.EqualTo([0x40uy; 0x7fuy]))
    Assert.That(toBytes [0x4000u; 0x123456u], Is.EqualTo([0x81uy; 0x80uy; 0x00uy; 0xc8uy; 0xe8uy; 0x56uy]))
    Assert.That(toBytes [0x2000u; 0x123456u; 0x0fffffffu; 0x00u; 0x3fffu; 0x4000u], Is.EqualTo([0xc0uy; 0x00uy; 0xc8uy; 0xe8uy; 0x56uy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy; 0x00uy; 0xffuy; 0x7fuy; 0x81uy; 0x80uy; 0x00uy]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``From bytes multiple values`` () =
    Assert.That(fromBytes [0xc0uy; 0x00uy; 0xc8uy; 0xe8uy; 0x56uy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy; 0x00uy; 0xffuy; 0x7fuy; 0x81uy; 0x80uy; 0x00uy], Is.EqualTo([0x2000u; 0x123456u; 0x0fffffffu; 0x00u; 0x3fffu; 0x4000u]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Incomplete byte sequence`` () =
    Assert.That((fun () -> fromBytes [0xffuy] |> ignore), Throws.Exception)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Overflow`` () =    
    Assert.That((fun () -> fromBytes [0xffuy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy] |> ignore), Throws.Exception)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Chained execution is identity`` () =
    let test = [0xf2u; 0xf6u; 0x96u; 0x9cu; 0x3bu; 0x39u; 0x2eu; 0x30u; 0xb3u; 0x24u];
    Assert.That(toBytes test |> fromBytes, Is.EqualTo(test))