module PovTest

open NUnit.Framework
open FsUnit

open Pov

let x = "x"
let leaf v = mkGraph v []

let singleton = mkGraph x []
let flat = mkGraph "root" (List.map leaf ["a"; "b"; x; "c"])
let nested = mkGraph "level-0" [mkGraph "level-1" [mkGraph "level-2" [mkGraph "level-3" [mkGraph x []]]]]
let kids = mkGraph "root" [mkGraph x [mkGraph "kid-0" []; mkGraph "kid-1" []]]
let cousins = mkGraph "grandparent" [
                mkGraph "parent" [
                    mkGraph x [leaf "kid-a"; leaf "kid-b"]; 
                    (leaf "sibling-0"); 
                    (leaf "sibling-1")];
                    mkGraph "uncle" [
                        (leaf "cousin-0");
                        (leaf "cousin-1")]]

let singleton' = singleton
let flat' = mkGraph x [mkGraph "root" (List.map leaf ["a"; "b"; "c"])]
let nested' = mkGraph x [mkGraph "level-3" [mkGraph "level-2" [mkGraph "level-1" [mkGraph "level-0" []]]]]
let kids' = mkGraph x [mkGraph "kid-0" []; mkGraph "kid-1" []; mkGraph "root" []]
let cousins' = mkGraph x [
                leaf "kid-a";
                leaf "kid-b";
                mkGraph "parent" [
                    mkGraph "sibling-0" [];
                    mkGraph "sibling-1" [];
                    mkGraph "grandparent" [
                        mkGraph "uncle" [
                            mkGraph "cousin-0" [];
                            mkGraph "cousin-1" []]]]]

[<Test>]
let ``Reparent singleton`` () =
    fromPOV x singleton |> should equal Some singleton'

[<Test>]
[<Ignore("Remove to run test")>]
let ``Reparent flat`` () =
    fromPOV x flat |> should equal Some flat'

[<Test>]
[<Ignore("Remove to run test")>]
let ``Reparent nested`` () =
    fromPOV x nested |> should equal Some nested'

[<Test>]
[<Ignore("Remove to run test")>]
let ``Reparent kids`` () =
    fromPOV x kids |> should equal Some kids'

[<Test>]
[<Ignore("Remove to run test")>]
let ``Reparent cousins`` () =
    fromPOV x cousins |> should equal Some cousins'

[<Test>]
[<Ignore("Remove to run test")>]
let ``Reparent from POV of non-existent node`` () =
    fromPOV x (leaf "foo") |> should equal None

[<Test>]
[<Ignore("Remove to run test")>]
let ``Should not be able to find a missing node`` () =
    let nodes = [singleton; flat; kids; nested; cousins] |> List.map (fromPOV "NOT THERE")
    nodes |> List.forall (should equal None)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Cannot trace between un-connected nodes`` () =
    tracePathBetween x "NOT THERE" cousins |> should equal None

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can trace a path from x to cousin`` () = 
    tracePathBetween x "cousin-1" cousins |> should equal Some ["x"; "parent"; "grandparent"; "uncle"; "cousin-1"]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can trace from a leaf to a leaf`` () =
    tracePathBetween "kid-a" "cousin-0" cousins |> should equal Some ["kid-a"; "x"; "parent"; "grandparent"; "uncle"; "cousin-0"]