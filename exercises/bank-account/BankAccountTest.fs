module BankAccountTest

open NUnit.Framework
open FsUnit
open BankAccount

[<Test>]
let ``Returns empty balance after opening`` () =
    let account = mkBankAccount() |> openAccount

    getBalance account |> should equal Some 0.0

[<Test>]
[<Ignore("Remove to run test")>]
let ``Check basic balance`` () =
    let account = mkBankAccount() |> openAccount
    let openingBalance = account |> getBalance 

    let updatedBalance = 
        account
        |> updateBalance 10.0 
        |> getBalance

    openingBalance |> should equal Some 0.0
    updatedBalance |> should equal Some 10.0

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

    openingBalance |> should equal Some 0.0
    addedBalance |> should equal Some 10.0
    subtractedBalance |> should equal Some -5.0

[<Test>]
[<Ignore("Remove to run test")>]
let ``Account can be closed`` () =
    let account = 
        mkBankAccount()
        |> openAccount
        |> closeAccount

    account |> getBalance |> should equal None
    
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

    account |> getBalance |> should equal Some 1000.0