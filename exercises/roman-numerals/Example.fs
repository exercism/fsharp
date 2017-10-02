module RomanNumerals

let numeralThresholds = [(1000, "M");
                            (900,  "CM");
                            (500,  "D");
                            (400,  "CD");
                            (100,  "C");
                            (90,   "XC");
                            (50,   "L");
                            (40,   "XL");
                            (10,   "X");
                            (9,    "IX");
                            (5,    "V");
                            (4,    "IV");
                            (1,    "I")]

let rec toRomanLoop remainder acc thresholds =         
    match thresholds with
        | [] -> acc
        | (threshold, numeral)::xs ->
            if threshold <= remainder then toRomanLoop (remainder - threshold) (acc + numeral) thresholds
            else toRomanLoop remainder acc xs

let roman (arabicNumeral: int) = toRomanLoop arabicNumeral "" numeralThresholds
