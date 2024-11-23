~ "space-age.ua" ~ SpaceAge

# Age on Earth
    age Earth 1000000000L |> should (equalWithin 0.01) 31.69

# Age on Mercury
    age Mercury 2134835688L |> should (equalWithin 0.01) 280.88

# Age on Venus
    age Venus 189839836L |> should (equalWithin 0.01) 9.78

# Age on Mars
    age Mars 2129871239L |> should (equalWithin 0.01) 35.88

# Age on Jupiter
    age Jupiter 901876382L |> should (equalWithin 0.01) 2.41

# Age on Saturn
    age Saturn 2000000000L |> should (equalWithin 0.01) 2.15

# Age on Uranus
    age Uranus 1210123456L |> should (equalWithin 0.01) 0.46

# Age on Neptune
    age Neptune 1821023456L |> should (equalWithin 0.01) 0.35

