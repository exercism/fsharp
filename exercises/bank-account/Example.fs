module BankAccount

open System

type BankAccount() = 
    member val Lock = new Object()
    member val Balance: decimal option = None with get,set

let mkBankAccount() = BankAccount()

let openAccount (account: BankAccount) = 
    lock account.Lock (fun () ->
        account.Balance <- Some 0.0m
        account
    )

let closeAccount (account: BankAccount) = 
    lock account.Lock (fun () ->
        account.Balance <- None    
        account
    )

let getBalance (account: BankAccount) = account.Balance

let updateBalance change (account: BankAccount) = 
    lock account.Lock (fun () ->
        account.Balance <- Option.map ((+) change) account.Balance    
        account
    )