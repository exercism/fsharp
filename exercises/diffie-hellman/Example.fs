module DiffieHellman

open System
open System.Numerics

let random = new Random()

let privateKey (primeP: bigint) = random.Next(1, (int primeP) - 1) |> bigint

let publicKey (primeP: bigint) (primeG: bigint) (privateKey: bigint) = BigInteger.ModPow(primeG, privateKey, primeP)

let secret (primeP: bigint) (publicKey: bigint) (privateKey: bigint) = BigInteger.ModPow(publicKey, privateKey, primeP)