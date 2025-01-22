// This file was created manually and its version is 2.0.0.

source("./bank-account-test.R")
library(testthat)

let ``Returns empty balance after opening`` () =
    account <- mkBankAccount() |> openAccount

    expect_equal(getBalance account, (Some 0.0m))

let ``Check basic balance`` () =
    account <- mkBankAccount() |> openAccount
    openingBalance <- account |> getBalance 

    updatedBalance <- 
        account
        |> updateBalance 10.0m
        |> getBalance

    expect_equal(openingBalance, (Some 0.0m))
    expect_equal(updatedBalance, (Some 10.0m))

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

    expect_equal(openingBalance, (Some 0.0m))
    expect_equal(addedBalance, (Some 10.0m))
    expect_equal(subtractedBalance, (Some -5.0m))

let ``Account can be closed`` () =
    account <- 
        mkBankAccount()
        |> openAccount
        |> closeAccount

    expect_equal(getBalance account, None)
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

    expect_equal(getBalance account, (Some 1000.0m))
