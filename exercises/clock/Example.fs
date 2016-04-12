module Clock

open System

type Clock(hours, minutes) =

    let modulo x y = (int)(((x % y) + y) % y)

    new(hours) = Clock(hours, 0)
        
    member private this.totalMinutes = hours * 60 + minutes
    member private this.normalizedHours = modulo ((double)this.totalMinutes / 60.0) 24.0
    member private this.normalizedMinutes = modulo ((double)minutes) 60.0
    
    member this.add minutes = new Clock(this.normalizedHours, this.normalizedMinutes + minutes)
    member this.subtract minutes = new Clock(this.normalizedHours, this.normalizedMinutes - minutes)

    override this.ToString() = sprintf "%02i:%02i" this.normalizedHours this.normalizedMinutes

    override this.Equals(other) =
        match other with
        | :? Clock as y -> this.normalizedHours = y.normalizedHours && this.normalizedMinutes = y.normalizedMinutes
        | _ -> false
 
    override this.GetHashCode() = hash this.totalMinutes

    interface System.IComparable with
      member this.CompareTo other =
          match other with
          | :? Clock as y -> 
            let hoursCompared = compare this.normalizedHours y.normalizedHours
            if hoursCompared = 0 then compare this.normalizedMinutes y.normalizedMinutes 
            else hoursCompared
          | _ -> invalidArg "other" "Cannot compare objects of different types"