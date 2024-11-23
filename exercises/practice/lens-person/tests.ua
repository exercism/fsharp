// This file was created manually and its version is 1.0.0.

module LensPersonTest


let testPerson =
    { name = 
        { name = "Jane Joanna"
          surName = "Doe" }
      born = 
        { at = 
            { street = "Longway"
              houseNumber = 1024
              place = "Springfield"
              country = "United States" }
          on = DateTime(1984, 4, 12) }
      address = 
        { street = "Shortlane"
          houseNumber = 2
          place = "Fallmeadow"
          country = "Canada" } }

# Set born at street
    Optic.get bornAtStreet testPerson |> should equal "Longway"

# Set current street
    Optic.set currentStreet "Middleroad" testPerson |> Optic.get currentStreet |> should equal "Middleroad"

# Upper case born at street
    Optic.map bornAtStreet (fun x -> x.ToUpper()) testPerson |> Optic.get bornAtStreet |> should equal "LONGWAY"

# Set birth month
    Optic.set birthMonth 9 testPerson |> Optic.get bornOn |> should equal <| DateTime(1984, 9, 12)