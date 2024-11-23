~ "SOLUTION" ~ LensPerson
testPerson =
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
⍤⤙≍ "Longway" Optic.get bornAtStreet testPerson

# Set current street
⍤⤙≍ "Middleroad" Optic.set currentStreet "Middleroad" testPerson |> Optic.get currentStreet

# Upper case born at street
⍤⤙≍ "LONGWAY" Optic.map bornAtStreet (fun x -> x.ToUpper()) testPerson |> Optic.get bornAtStreet

# Set birth month
⍤⤙≍ <| DateTime(1984, 9, 12) Optic.set birthMonth 9 testPerson |> Optic.get bornOn