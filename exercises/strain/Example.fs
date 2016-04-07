module Seq

let keep pred xs = seq { for x in xs do if pred x then yield x }

let discard pred = keep (not << pred)