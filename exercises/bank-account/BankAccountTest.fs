module BankAccountTest

open NUnit.Framework
open BankAccount

[<Test>]
let ``Returns empty balance after opening`` () =
    let account = mkBankAccount() |> openAccount

    Assert.That(getBalance account, Is.EqualTo(Some 0.0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Check basic balance`` () =
    let account1 = mkBankAccount() |> openAccount
    let openingBalance = account1 |> getBalance 

    let account2 = account1 |> updateBalance 10.0
    let updatedBalance = account2 |> getBalance

    Assert.That(openingBalance, Is.EqualTo(Some 0.0))
    Assert.That(updatedBalance, Is.EqualTo(Some 10.0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Balance can increment or decrement`` () =    
    let account1 = mkBankAccount() |> openAccount
    let openingBalance = account1 |> getBalance 

    let account2 = account1 |> updateBalance 10.0
    let addedBalance = account2 |> getBalance

    let account3 = account2 |> updateBalance -15.0
    let subtractedBalance = account3 |> getBalance

    Assert.That(openingBalance, Is.EqualTo(Some 0.0))
    Assert.That(addedBalance, Is.EqualTo(Some 10.0))
    Assert.That(subtractedBalance, Is.EqualTo(Some -5.0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Account can be closed`` () =
    let account = 
        mkBankAccount()
        |> openAccount
        |> closeAccount

    Assert.That(account |> getBalance, Is.EqualTo(None))