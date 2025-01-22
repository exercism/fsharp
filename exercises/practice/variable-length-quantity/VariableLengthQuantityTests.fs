source("./variable-length-quantity.R")
library(testthat)

let ``Zero`` () =
    expect_equal(encode [0x0u], [0x0uy])

let ``Arbitrary single byte`` () =
    expect_equal(encode [0x40u], [0x40uy])

let ``Largest single byte`` () =
    expect_equal(encode [0x7fu], [0x7fuy])

let ``Smallest double byte`` () =
    expect_equal(encode [0x80u], [0x81uy; 0x0uy])

let ``Arbitrary double byte`` () =
    expect_equal(encode [0x2000u], [0xc0uy; 0x0uy])

let ``Largest double byte`` () =
    expect_equal(encode [0x3fffu], [0xffuy; 0x7fuy])

let ``Smallest triple byte`` () =
    expect_equal(encode [0x4000u], [0x81uy; 0x80uy; 0x0uy])

let ``Arbitrary triple byte`` () =
    expect_equal(encode [0x100000u], [0xc0uy; 0x80uy; 0x0uy])

let ``Largest triple byte`` () =
    expect_equal(encode [0x1fffffu], [0xffuy; 0xffuy; 0x7fuy])

let ``Smallest quadruple byte`` () =
    expect_equal(encode [0x200000u], [0x81uy; 0x80uy; 0x80uy; 0x0uy])

let ``Arbitrary quadruple byte`` () =
    expect_equal(encode [0x8000000u], [0xc0uy; 0x80uy; 0x80uy; 0x0uy])

let ``Largest quadruple byte`` () =
    expect_equal(encode [0xfffffffu], [0xffuy; 0xffuy; 0xffuy; 0x7fuy])

let ``Smallest quintuple byte`` () =
    expect_equal(encode [0x10000000u], [0x81uy; 0x80uy; 0x80uy; 0x80uy; 0x0uy])

let ``Arbitrary quintuple byte`` () =
    expect_equal(encode [0xff000000u], [0x8fuy; 0xf8uy; 0x80uy; 0x80uy; 0x0uy])

let ``Maximum 32-bit integer input`` () =
    expect_equal(encode [0xffffffffu], [0x8fuy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy])

let ``Two single-byte values`` () =
    expect_equal(encode [0x40u; 0x7fu], [0x40uy; 0x7fuy])

let ``Two multi-byte values`` () =
    expect_equal(encode [0x4000u; 0x123456u], [0x81uy; 0x80uy; 0x0uy; 0xc8uy; 0xe8uy; 0x56uy])

let ``Many multi-byte values`` () =
    expect_equal(encode [0x2000u; 0x123456u; 0xfffffffu; 0x0u; 0x3fffu; 0x4000u], [0xc0uy; 0x0uy; 0xc8uy; 0xe8uy; 0x56uy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy; 0x0uy; 0xffuy; 0x7fuy; 0x81uy; 0x80uy; 0x0uy])

let ``One byte`` () =
    expect_equal(decode [0x7fuy], (Some [0x7fu]))

let ``Two bytes`` () =
    expect_equal(decode [0xc0uy; 0x0uy], (Some [0x2000u]))

let ``Three bytes`` () =
    expect_equal(decode [0xffuy; 0xffuy; 0x7fuy], (Some [0x1fffffu]))

let ``Four bytes`` () =
    expect_equal(decode [0x81uy; 0x80uy; 0x80uy; 0x0uy], (Some [0x200000u]))

let ``Maximum 32-bit integer`` () =
    expect_equal(decode [0x8fuy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy], (Some [0xffffffffu]))

let ``Incomplete sequence causes error`` () =
    expect_equal(decode [0xffuy], None)

let ``Incomplete sequence causes error, even if value is zero`` () =
    expect_equal(decode [0x80uy], None)

let ``Multiple values`` () =
    expect_equal(decode [0xc0uy; 0x0uy; 0xc8uy; 0xe8uy; 0x56uy; 0xffuy; 0xffuy; 0xffuy; 0x7fuy; 0x0uy; 0xffuy; 0x7fuy; 0x81uy; 0x80uy; 0x0uy], (Some [0x2000u; 0x123456u; 0xfffffffu; 0x0u; 0x3fffu; 0x4000u]))

