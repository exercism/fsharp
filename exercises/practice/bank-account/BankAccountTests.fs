// This file was created manually and its version is 2.0.0.

source("./bank-account-test.R")
library(testthat)

let ``Returns empty balance after opening`` () =
    account <- mkBankAccount() |> openAccount

    getBalance account |> should equal (Some 0.0m)

let ``Check basic balance`` () =
    account <- mkBankAccount() |> openAccount
    openingBalance <- account |> getBalance 

    updatedBalance <- 
        account
        |> updateBalance 10.0m
        |> getBalance

    openingBalance |> should equal (Some 0.0m)
    updatedBalance |> should equal (Some 10.0m)

let ``Balance can increment or decrement`` () =    
    account <- mkBankAccount() |> openAccount
    openingBalance <- account |> getBalance 

    addedBalance <- 
        account 
        |> updateBalance 10.0m
        |> getBalance

    subtractedBalance <- 
        account 
        |> updateBalance -15.0m
        |> getBalance

    openingBalance |> should equal (Some 0.0m)
    addedBalance |> should equal (Some 10.0m)
    subtractedBalance |> should equal (Some -5.0m)

let ``Account can be closed`` () =
    account <- 
        mkBankAccount()
        |> openAccount
        |> closeAccount

    getBalance account |> should equal None
    account |> should not' (equal None)
    
let ``Account can be updated from multiple threads`` () =
    account <- 
        mkBankAccount()
        |> openAccount

    updateAccountAsync <-        
        async {                             
            account 
            |> updateBalance 1.0m
            |> ignore
        }

    updateAccountAsync
    |> List.replicate 1000
    |> Async.Parallel 
    |> Async.RunSynchronously
    |> ignore

    getBalance account |> should equal (Some 1000.0m)
