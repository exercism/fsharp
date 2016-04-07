module Gigasecond

open System

let gigasecond (beginDate: DateTime) = 
    let gigaSecondDateTime = beginDate.AddSeconds(1000000000.0) 
    gigaSecondDateTime.Date