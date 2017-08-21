module LeapYear

let isLeapYear (year: int) = year % 4 = 0 && (year % 400 = 0 || year % 100 <> 0)