module BankAccountTest

open NUnit.Framework
open BankAccount

[<TestFixture>]
type BankAccountTest() =
    let account = BankAccount()

    [<Test>]
    member tests.Returns_empty_balance_after_opening() =
        account.openAccount() |> ignore

        Assert.That(account.getBalance(), Is.EqualTo(0.0))

    [<Test>]
    [<Ignore>]
    member tests.Check_basic_balance() =
        account.openAccount() |> ignore

        let openingBalance = account.getBalance()

        account.updateBalance(10.0)

        let updatedBalance = account.getBalance()

        Assert.That(openingBalance, Is.EqualTo(0.0))
        Assert.That(updatedBalance, Is.EqualTo(10.0))

    [<Test>]
    [<Ignore>]
    member tests.Balance_can_increment_or_decrement() =
        account.openAccount() |> ignore

        let openingBalance = account.getBalance()

        account.updateBalance(10.0)

        let addedBalance = account.getBalance()

        account.updateBalance(-15.0)

        let subtractedBalance = account.getBalance()

        Assert.That(openingBalance, Is.EqualTo(0.0))
        Assert.That(addedBalance, Is.EqualTo(10.0))
        Assert.That(subtractedBalance, Is.EqualTo(-5.0))

    [<Test>]
    [<Ignore>]
    member tests.Account_can_be_closed() =
        account.openAccount() |> ignore

        account.closeAccount()

        Assert.That(account.Balance, Is.EqualTo(Option<float>.None))