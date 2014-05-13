module SpaceAge

let EARTH_ORBIT_IN_SECONDS = 31557600m

type Planets =
    | Earth
    | Mars
    | Venus
    | Mercury
    | Jupiter
    | Saturn
    | Uranus
    | Neptune

type SpaceAge(seconds: decimal) =
    let periodOfEarthYearToPlanet = 
        [
            Planets.Earth, 1m;
            Planets.Mercury, 0.2408467m;
            Planets.Venus, 0.61519726m;
            Planets.Mars, 1.8808158m;
            Planets.Jupiter, 11.862615m;
            Planets.Saturn, 29.447498m;
            Planets.Neptune, 164.79132m;
            Planets.Uranus, 84.016846m;
        ]
        |> Map.ofList

    let calculateAge(periodInEarthYears: decimal) =
        System.Math.Round(seconds / (EARTH_ORBIT_IN_SECONDS * periodInEarthYears), 2)

    member this.Seconds = seconds

    member this.onEarth() =
        calculateAge(periodOfEarthYearToPlanet.[Planets.Earth])

    member this.onMercury() =
        calculateAge(periodOfEarthYearToPlanet.[Planets.Mercury])

    member this.onVenus() =
        calculateAge(periodOfEarthYearToPlanet.[Planets.Venus])

    member this.onMars() =
        calculateAge(periodOfEarthYearToPlanet.[Planets.Mars])

    member this.onJupiter() =
        calculateAge(periodOfEarthYearToPlanet.[Planets.Jupiter])

    member this.onSaturn() =
        calculateAge(periodOfEarthYearToPlanet.[Planets.Saturn])

    member this.onNeptune() =
        calculateAge(periodOfEarthYearToPlanet.[Planets.Neptune])

    member this.onUranus() =
        calculateAge(periodOfEarthYearToPlanet.[Planets.Uranus])