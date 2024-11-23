// This file was created manually and its version is 1.0.0.

module HexadecimalTest



# Hexadecimal 1 is decimal 1
    toDecimal "1" |> should equal 1

# Hexadecimal c is decimal 12
    toDecimal "c" |> should equal 12

# Hexadecimal 10 is decimal 16
    toDecimal "10" |> should equal 16

# Hexadecimal af is decimal 175
    toDecimal "af" |> should equal 175

# Hexadecimal 100 is decimal 256
    toDecimal "100" |> should equal 256

# Hexadecimal 19ace is decimal 105166
    toDecimal "19ace" |> should equal 105166

# Hexadecimal 000000 is decimal 0
    toDecimal "000000" |> should equal 0

# Hexadecimal ffffff is decimal 16777215
    toDecimal "ffffff" |> should equal 16777215

# Hexadecimal ffff00 is decimal 16776960
    toDecimal "ffff00" |> should equal 16776960

# Hexadecimal carrot is decimal 0
    toDecimal "carrot" |> should equal 0

