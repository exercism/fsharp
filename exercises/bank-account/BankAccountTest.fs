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
    let account = mkBankAccount() |> openAccount
    let openingBalance = account |> getBalance 

    let updatedBalance = 
        account
        |> updateBalance 10.0 
        |> getBalance

    Assert.That(openingBalance, Is.EqualTo(Some 0.0))
    Assert.That(updatedBalance, Is.EqualTo(Some 10.0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Balance can increment or decrement`` () =    
    let account = mkBankAccount() |> openAccount
    let openingBalance = account |> getBalance 

    let addedBalance = 
        account 
        |> updateBalance 10.0
        |> getBalance

    let subtractedBalance = 
        account 
        |> updateBalance -15.0
        |> getBalance

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
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Account can be updated from multiple threads`` () =
    let account = 
        mkBankAccount()
        |> openAccount

    let updateAccountAsync =        
        async {                             
            account 
            |> updateBalance 1.0
            |> ignore
        }

    updateAccountAsync
    |> List.replicate 1000
    |> Async.Parallel 
    |> Async.RunSynchronously
    |> ignore

    Assert.That(account |> getBalance, Is.EqualTo(Some 1000.0))