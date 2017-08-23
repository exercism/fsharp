module DiffieHellmanTest

open System.Numerics

open NUnit.Framework
open FsUnit

open DiffieHellman

[<Test>]
let ``Private key in range`` () =   
    let primeP = 23I
    let privateKeys = [for _ in 0 .. 10 -> privateKey primeP]
    privateKeys |> List.iter (fun x -> x |> should be (greaterThanOrEqualTo 1I))
    privateKeys |> List.iter (fun x -> x |> should be (lessThanOrEqualTo (primeP - 1I)))

// Note: due to the nature of randomness, there is always a chance that this test fails
// Be sure to check the actual generated values
[<Test>]
[<Ignore("Remove to run test")>]
let ``Private key randomly generated`` () =   
    let primeP = 7919I
    let privateKeys = [for _ in 0 .. 5 -> privateKey primeP]
    privateKeys.Length |> should equal <| List.length (List.distinct privateKeys) 
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Public key correctly calculated`` () =
    let primeP = 23I
    let primeG = 5I
    let privateKey = 6I

    let actual = publicKey primeP primeG privateKey    
    actual |> should equal 8I

[<Test>]
[<Ignore("Remove to run test")>]
let ``Secret key correctly calculated`` () =
    let primeP = 23I
    let publicKey = 19I
    let privateKey = 6I

    let actual = secret primeP publicKey privateKey
    actual |> should equal 2I

[<Test>]
[<Ignore("Remove to run test")>]
let ``Secret key correctly calculated when using large primes`` () =
    let primeP = 120227323036150778550155526710966921740030662694578947298423549235265759593711587341037426347114541533006628856300552706996143592240453345642869233562886752930249953227657883929905072620233073626594386072962776144691433658814261874113232461749035425712805067202910389407991986070558964461330091797026762932543I
    let publicKey = 75205441154357919442925546169208711235485855904969178206313309299205868312399046149367516336607966149689640419216591714331722664409474612463910928128055994157922930443733535659848264364106037925315974095321112757711756912144137705613776063541350548911512715512539186192176020596861210448363099541947258202188I
    let privateKey = 2483479393625932939911081304356888505153797135447327501792696199190469015215177630758617902200417377685436170904594686456961202706692908603181062371925882I
    let expected = 70900735223964890815905879227737819348808518698920446491346508980461201746567735331455825644429877946556431095820785835497384849778344216981228226252639932672153547963980483673419756271345828771971984887453014488572245819864454136618980914729839523581263886740821363010486083940557620831348661126601106717071I
    let actual = secret primeP publicKey privateKey
    actual |> should equal expected

[<Test>]
[<Ignore("Remove to run test")>]
let ``Test exchange`` () =
    let primeP = 23I
    let primeG = 5I

    let privateKeyA = privateKey primeP
    let privateKeyB = privateKey primeP
    
    let publicKeyA = publicKey primeP primeG privateKeyA
    let publicKeyB = publicKey primeP primeG privateKeyB
    
    let secretA = secret primeP publicKeyB privateKeyA
    let secretB = secret primeP publicKeyA privateKeyB

    secretA |> should equal secretB