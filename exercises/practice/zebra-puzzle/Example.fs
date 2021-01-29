module ZebraPuzzle

type Color = Red | Green | Ivory | Yellow | Blue 
type Nationality = Englishman | Spaniard | Ukranian | Japanese | Norwegian
type Pet = Dog | Snails | Fox | Horse | Zebra
type Drink = Coffee | Tea | Milk | OrangeJuice | Water
type Smoke = OldGold | Kools | Chesterfields | LuckyStrike | Parliaments

type Solution = { colors: Color list; nationalities: Nationality list; pets: Pet list; drinks: Drink list; smokes: Smoke list }

let rec insertions x = function
    | []             -> [[x]]
    | (y :: ys) as l -> (x::l)::(List.map (fun x -> y::x) (insertions x ys))

let rec permutations = function
    | []      -> seq [ [] ]
    | x :: xs -> Seq.collect (insertions x) (permutations xs)

let index value = List.findIndex ((=) value)

let (==>) (values1, value1) (values2, value2) = List.item (index value1 values1) values2 = value2

let (<==>) (values1, value1) (values2, value2) =
    let index' = index value1 values1
    List.tryItem (index' - 1) values2 = Some value2 || 
    List.tryItem (index' + 1) values2 = Some value2

let colors = [Red; Green; Ivory; Yellow; Blue]
let nationalities = [Englishman; Spaniard; Ukranian; Japanese; Norwegian]
let pets = [Dog; Snails; Fox; Horse; Zebra]
let drinks = [Coffee; Tea; Milk; OrangeJuice; Water]
let smokes = [OldGold; Kools; Chesterfields; LuckyStrike; Parliaments]

let matchesColorRules colors = 
    let greenRightOfIvoryHouse = index Ivory colors = index Green colors - 1 // #6
    greenRightOfIvoryHouse

let matchesNationalityRules colors nationalities = 
    let englishManInRedHouse = (nationalities, Englishman) ==> (colors, Red) // #2
    let norwegianInFirstHouse = List.head nationalities = Norwegian // #10
    let norwegianLivesNextToBlueHouse = (nationalities, Norwegian) <==> (colors, Blue) // #15

    englishManInRedHouse && norwegianInFirstHouse && norwegianLivesNextToBlueHouse

let matchesPetRules nationalities pets  = 
    let spaniardOwnsDog = (nationalities, Spaniard) ==> (pets, Dog) // #3
    spaniardOwnsDog

let matchesDrinkRules colors nationalities drinks  = 
    let coffeeDrunkInGreenHouse = (colors, Green) ==> (drinks, Coffee) // #4
    let ukranianDrinksTee = (nationalities, Ukranian) ==>  (drinks, Tea) // #5
    let milkDrunkInMiddleHouse = List.item 2 drinks = Milk // #9

    coffeeDrunkInGreenHouse && ukranianDrinksTee && milkDrunkInMiddleHouse

let matchesSmokeRules colors nationalities drinks pets smokes = 
    let oldGoldSmokesOwnsSnails = (smokes, OldGold) ==> (pets, Snails) // #7
    let koolsSmokedInYellowHouse = (colors, Yellow) ==> (smokes, Kools) // #8
    let chesterfieldsSmokedNextToHouseWithFox = (smokes, Chesterfields) <==> (pets, Fox) // #11
    let koolsSmokedNextToHouseWithHorse = (smokes, Kools) <==> (pets, Horse) // #12

    let luckyStrikeSmokerDrinksOrangeJuice = (smokes, LuckyStrike) ==> (drinks, OrangeJuice) // #13
    let japaneseSmokesParliaments = (nationalities, Japanese) ==> (smokes, Parliaments) // #14

    oldGoldSmokesOwnsSnails && koolsSmokedInYellowHouse && chesterfieldsSmokedNextToHouseWithFox &&
    koolsSmokedNextToHouseWithHorse && luckyStrikeSmokerDrinksOrangeJuice && japaneseSmokesParliaments

let solutions = seq {
        for validColors        in colors        |> permutations |> Seq.filter matchesColorRules do
        for validNationalities in nationalities |> permutations |> Seq.filter (matchesNationalityRules validColors) do
        for validPets          in pets          |> permutations |> Seq.filter (matchesPetRules validNationalities) do
        for validDrinks        in drinks        |> permutations |> Seq.filter (matchesDrinkRules validColors validNationalities) do
        for validSmokes        in smokes        |> permutations |> Seq.filter (matchesSmokeRules validColors validNationalities validDrinks validPets) do
            yield { colors = validColors; nationalities = validNationalities; pets = validPets; drinks = validDrinks; smokes = validSmokes }
    }

let solution = Seq.head solutions

let drinksWater = List.item (index Water solution.drinks) solution.nationalities
let ownsZebra = List.item (index Zebra solution.pets) solution.nationalities