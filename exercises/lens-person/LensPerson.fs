module LensPerson

open Aether
open Aether.Operators
open System

type Address = 
    { street: string
      houseNumber: int
      place: string
      country: string }

type Born = 
    { at: Address
      on: DateTime }

type Name = 
    { name: string
      surName: string }

type Person = 
    { name: Name
      born: Born
      address: Address }