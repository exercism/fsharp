~ "bank-account.ua" ~ BankAccount
# Returns empty balance after opening
account = mkBankAccount() |> openAccount

⍤⤙≍ 0.0m getBalance account

# Check basic balance
account = mkBankAccount() |> openAccount
openingBalance = account |> getBalance 

updatedBalance = 
        account
        |> updateBalance 10.0m
        |> getBalance

⍤⤙≍ 0.0m openingBalance
⍤⤙≍ 10.0m updatedBalance

# Balance can increment or decrement    
account = mkBankAccount() |> openAccount
openingBalance = account |> getBalance 

addedBalance = 
        account 
        |> updateBalance 10.0m
        |> getBalance

subtractedBalance = 
        account 
        |> updateBalance -15.0m
        |> getBalance

⍤⤙≍ 0.0m openingBalance
⍤⤙≍ 10.0m addedBalance
⍤⤙≍ -5.0m subtractedBalance

# Account can be closed
account = 
        mkBankAccount()
        |> openAccount
        |> closeAccount

⍤⤙≍ "TODO: insert error message" ⍣(getBalance account)
    account |> should not' (equal None)
    
# Account can be updated from multiple threads
account = 
        mkBankAccount()
        |> openAccount

updateAccountAsync =        
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

⍤⤙≍ 1000.0m getBalance account
