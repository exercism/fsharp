// This file was created manually and its version is 2.0.0.

module BankAccountTest


# Returns empty balance after opening
    let account = mkBankAccount() |> openAccount

⍤⤙≍ (Some 0.0m) getBalance account

# Check basic balance
    let account = mkBankAccount() |> openAccount
    let openingBalance = account |> getBalance 

    let updatedBalance = 
        account
        |> updateBalance 10.0m
        |> getBalance

⍤⤙≍ (Some 0.0m) openingBalance
⍤⤙≍ (Some 10.0m) updatedBalance

# Balance can increment or decrement    
    let account = mkBankAccount() |> openAccount
    let openingBalance = account |> getBalance 

    let addedBalance = 
        account 
        |> updateBalance 10.0m
        |> getBalance

    let subtractedBalance = 
        account 
        |> updateBalance -15.0m
        |> getBalance

⍤⤙≍ (Some 0.0m) openingBalance
⍤⤙≍ (Some 10.0m) addedBalance
⍤⤙≍ (Some -5.0m) subtractedBalance

# Account can be closed
    let account = 
        mkBankAccount()
        |> openAccount
        |> closeAccount

⍤⤙≍ None getBalance account
    account |> should not' (equal None)
    
# Account can be updated from multiple threads
    let account = 
        mkBankAccount()
        |> openAccount

    let updateAccountAsync =        
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

⍤⤙≍ (Some 1000.0m) getBalance account
