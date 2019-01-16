module RestApi

open Newtonsoft.Json
open System.Collections.Generic
open Newtonsoft.Json.Linq

type User(name : string, owes : SortedDictionary<string,decimal>, owed_by : SortedDictionary<string,decimal>) =
    member this.name = name
    member this.owes = owes
    member this.owed_by = owed_by

    member this.lend(name: string, amount: decimal) =
        let remaining = 
            match owes.TryGetValue(name) with
                | (true,value) when value - amount > 0m -> 
                    owes.[name] <- (value - amount)
                    0m
                | (true,value) -> 
                    owes.Remove(name) |> ignore
                    amount - value 
                | (false,_) ->
                    amount

        match owed_by.TryGetValue(name) with
        | (true,value) when remaining > 0m -> 
            owed_by.[name] <- value + remaining
        | (false,_) when remaining > 0m  -> 
            owed_by.Add(name, remaining)
        | _ -> ()

    member this.borrow(name: string, amount: decimal) =
        let remaining = 
            match owed_by.TryGetValue(name) with
                | (true,value) when value - amount > 0m -> 
                    owed_by.[name] <- value - amount 
                    0m
                | (true,value) -> 
                    owed_by.Remove(name) |> ignore
                    amount - value 
                | (false,_) ->
                    amount

        match owes.TryGetValue(name) with
            | (true,value) when remaining > 0m -> 
                owes.[name] <- value + remaining
            | (false,_) when remaining > 0m -> 
                owes.Add(name, remaining)
            | _ -> ()

    member this.balance =
        match (owes,owed_by) with
        | (null,null) -> 0m
        | (_,null) -> - (owes |> Seq.map (fun p -> p.Value) |> Seq.sum)
        | (null,_) ->  (owed_by |> Seq.map (fun p -> p.Value) |> Seq.sum)
        | (_,_) -> -(owes |> Seq.map (fun p -> p.Value) |> Seq.sum) + (owed_by |> Seq.map (fun p -> p.Value) |> Seq.sum)

type Database(users : User[]) =
    member this.users = users

type IOU(lender: string, borrower: string, amount : decimal) =
    member this.lender = lender
    member this.borrower = borrower
    member this.amount = amount


type RestApi(database : string) =
    let Source = JsonConvert.DeserializeObject<Database>(database)   

    member this.Get(url: string) =
        JsonConvert.SerializeObject(Source)

    member this.Get(url: string, payload: string) =
        let jt = JToken.Parse(payload)
        let toGet = JsonConvert.DeserializeObject<string[]>(jt.SelectToken("users").ToString())
        let users = Source.users |> Seq.filter (fun p -> Seq.contains p.name toGet) |> Seq.toArray
        JsonConvert.SerializeObject(Database(users))

    member this.Post(url: string, payload: string)  =
        match url with
        | "/add" -> 
            let userName = JToken.Parse(payload).SelectToken("user").ToString()
            let user = User(userName,SortedDictionary<string,decimal>(),SortedDictionary<string,decimal>())
            JsonConvert.SerializeObject(user)
        | "/iou" ->
            let iou = JsonConvert.DeserializeObject<IOU>(payload)

            let lender = Source.users |> Seq.find (fun p -> p.name.Equals(iou.lender))
            lender.lend(iou.borrower,iou.amount)

            let borrower = Source.users |> Seq.find (fun p -> p.name.Equals(iou.borrower))
            borrower.borrow(iou.lender,iou.amount)

            let newSource = [|lender ; borrower|] |> Seq.sortBy (fun p -> p.name) |> Seq.toArray

            JsonConvert.SerializeObject(Database(newSource))

        | _ -> failwith "unsupported url"
