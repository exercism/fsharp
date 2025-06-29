import "bank_account"
let ``Returns empty balance after opening`` () =
    let account = mkBankAccount() |> openAccount

    getBalance account |> should equal 0.0

let ``Check basic balance`` () =
    let account = mkBankAccount() |> openAccount
    let openingBalance = account |> getBalance 

    let updatedBalance = 
        account
        |> updateBalance 10.0
        |> getBalance

    openingBalance |> should equal 0.0
    updatedBalance |> should equal 10.0

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

    openingBalance |> should equal 0.0
    addedBalance |> should equal 10.0
    subtractedBalance |> should equal -5.0

let ``Account can be closed`` () =
    let account = 
        mkBankAccount()
        |> openAccount
        |> closeAccount

    getBalance account |> should equal None
    account |> should not' (equal None)
    
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

    getBalance account |> should equal 1000.0
