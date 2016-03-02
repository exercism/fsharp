module LuhnTests

open NUnit.Framework
open Luhn

type LuhnTests() =    
    [<Test>]
    member tests.Check_digit_is_the_rightmost_digit() =
        Assert.That(Luhn(34567L).checkDigit, Is.EqualTo(7))

    [<Test>]
    [<Ignore>]
    member tests.Addends_doubles_every_other_number_from_the_right() =
        Assert.That(Luhn(12121L).addends, Is.EqualTo([1; 4; 1; 4; 1]))

    [<Test>]
    [<Ignore>]
    member tests.Addends_subtracts_9_when_doubled_number_is_more_than_9() =
        Assert.That(Luhn(8631L).addends, Is.EqualTo([7; 6; 6; 1]))

    [<TestCase(4913, ExpectedResult = 2, Ignore = true)>]
    [<TestCase(201773, ExpectedResult = 1, Ignore = true)>]
    member tests.Checksum_adds_addends_together(number) =
        Luhn(number).checksum

    [<TestCase(738, ExpectedResult = false, Ignore = true)>]
    [<TestCase(8739567, ExpectedResult = true, Ignore = true)>]
    member tests.Number_is_valid_when_checksum_mod_10_is_zero(number) =
        Luhn(number).valid

    [<Test>]
    [<Ignore>]
    member tests.Luhn_can_create_simple_numbers_with_valid_check_digit() =
        Assert.That(Luhn.create(123L), Is.EqualTo(1230))

    [<Test>]
    [<Ignore>]
    member tests.Luhn_can_create_larger_numbers_with_valid_check_digit() =
        Assert.That(Luhn.create(873956L), Is.EqualTo(8739567))

    [<Test>]
    [<Ignore>]
    member tests.Luhn_can_create_huge_numbers_with_valid_check_digit() =
        Assert.That(Luhn.create(837263756L), Is.EqualTo(8372637564L))