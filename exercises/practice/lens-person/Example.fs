module LensPerson

open Aether
open Aether.Operators
open System

type Address = 
    { street: string
      houseNumber: int
      place: string
      country: string }

    static member street_ =
        (fun a -> a.street), (fun b a -> { a with street = b })

type Born = 
    { at: Address
      on: DateTime }

    static member at_ =
        (fun a -> a.at), (fun b a -> { a with at = b })

    static member on_ =
        (fun a -> a.on), (fun b a -> { a with on = b })

    static member birthMonth_ =
        (fun a -> a.on.Month), (fun b a -> { a with on = DateTime(a.on.Year, b, a.on.Day) })

type Name = 
    { name: string
      surName: string }

type Person = 
    { name: Name
      born: Born
      address: Address }

    static member born_ =
        (fun a -> a.born), (fun b a -> { a with born = b })

    static member address_ =
        (fun a -> a.address), (fun b a -> { a with address = b })
        
let bornAtStreet = Person.born_ >-> Born.at_ >-> Address.street_

let bornOn = Person.born_ >-> Born.on_
        
let currentStreet = Person.address_ >-> Address.street_

let birthMonth = Person.born_ >-> Born.birthMonth_