module LuhnTest

open NUnit.Framework
open Luhn
  
[<Test>]
let ``Check digit is the rightmost digit`` () =
    Assert.That(checkDigit 34567L, Is.EqualTo 7)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Addends doubles every other number from the right`` () =
    Assert.That(addends 12121L, Is.EqualTo [1; 4; 1; 4; 1])

[<Test>]
[<Ignore("Remove to run test")>]
let ``Addends subtracts 9 when doubled number is more than 9`` () =
    Assert.That(addends 8631L, Is.EqualTo [7; 6; 6; 1])

[<TestCase(4913, ExpectedResult = 2)>]
[<TestCase(201773, ExpectedResult = 1)>]
let ``Checksum adds addends together`` (number) =
    checksum number

[<TestCase(738, ExpectedResult = false)>]
[<TestCase(8739567, ExpectedResult = true)>]
let ``Number is valid when checksum mod 10 is zero`` (number) =
    valid number

[<Test>]
[<Ignore("Remove to run test")>]
let ``Luhn can create simple numbers with valid check digit`` () =
    Assert.That(create 123L, Is.EqualTo(1230))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Luhn can create larger numbers with valid check digit`` () =
    Assert.That(create 873956L, Is.EqualTo(8739567))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Luhn can create huge numbers with valid check digit`` () =
    Assert.That(create 837263756L, Is.EqualTo(8372637564L))