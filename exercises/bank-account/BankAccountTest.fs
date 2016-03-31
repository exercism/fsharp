module BankAccountTest

open NUnit.Framework
open BankAccount

[<Test>]
let ``Returns empty balance after opening`` () =
    let account = BankAccount()

    account.openAccount() |> ignore

    Assert.That(account.getBalance(), Is.EqualTo(0.0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Check basic balance`` () =
    let account = BankAccount()

    account.openAccount() |> ignore

    let openingBalance = account.getBalance()

    account.updateBalance(10.0)

    let updatedBalance = account.getBalance()

    Assert.That(openingBalance, Is.EqualTo(0.0))
    Assert.That(updatedBalance, Is.EqualTo(10.0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Balance can increment or decrement`` () =
    let account = BankAccount()

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
[<Ignore("Remove to run test")>]
let ``Account can be closed`` () =
    let account = BankAccount()

    account.openAccount() |> ignore

    account.closeAccount()

    Assert.That(account.Balance, Is.EqualTo(Option<float>.None))