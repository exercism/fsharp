~ "ledger.ua" ~ Ledger

# Empty ledger
currency = "USD"
locale = "en-US"
entries = []
expected =
        "Date       | Description               | Change       "

⍤⤙≍ expected formatLedger currency locale entries

# One entry
currency = "USD"
locale = "en-US"
entries =
        [
            mkEntry "2015-01-01" "Buy present" -1000
        ]
expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      ($10.00)"

⍤⤙≍ expected formatLedger currency locale entries

# Credit and debit
currency = "USD"
locale = "en-US"
entries =
        [
            mkEntry "2015-01-02" "Get present"  1000;
            mkEntry "2015-01-01" "Buy present" -1000
        ]
expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      ($10.00)" + System.Environment.NewLine +
        "01/02/2015 | Get present               |       $10.00 "

⍤⤙≍ expected formatLedger currency locale entries
 
# Multiple entries on same date ordered by description
currency = "USD"
locale = "en-US"
entries =
        [
            mkEntry "2015-01-01" "Buy present" -1000;
            mkEntry "2015-01-01" "Get present"  1000
        ]
expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      ($10.00)" + System.Environment.NewLine +
        "01/01/2015 | Get present               |       $10.00 "

⍤⤙≍ expected formatLedger currency locale entries
   
# Final order tie breaker is change
currency = "USD"
locale = "en-US"
entries =
        [
            mkEntry "2015-01-01" "Something" 0;
            mkEntry "2015-01-01" "Something" -1;
            mkEntry "2015-01-01" "Something" 1
        ]
expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Something                 |       ($0.01)" + System.Environment.NewLine +
        "01/01/2015 | Something                 |        $0.00 " + System.Environment.NewLine +
        "01/01/2015 | Something                 |        $0.01 "

⍤⤙≍ expected formatLedger currency locale entries
  
# Overlong descriptions
currency = "USD"
locale = "en-US"
entries =
        [
            mkEntry "2015-01-01" "Freude schoner Gotterfunken" -123456
        ]
expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Freude schoner Gotterf... |   ($1,234.56)"

⍤⤙≍ expected formatLedger currency locale entries
  
# Euros
currency = "EUR"
locale = "en-US"
entries =
        [
            mkEntry "2015-01-01" "Buy present" -1000
        ]
expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      (€10.00)"

⍤⤙≍ expected formatLedger currency locale entries
   
# Dutch locale
currency = "USD"
locale = "nl-NL"
entries =
        [
            mkEntry "2015-03-12" "Buy present" 123456
        ]
expected =
        "Datum      | Omschrijving              | Verandering  " + System.Environment.NewLine +
        "12-03-2015 | Buy present               |   $ 1.234,56 "

⍤⤙≍ expected formatLedger currency locale entries
 
# Dutch negative number with 3 digits before decimal point
currency = "USD"
locale = "nl-NL"
entries =
        [
            mkEntry "2015-03-12" "Buy present" -12345
        ]
expected =
        "Datum      | Omschrijving              | Verandering  " + System.Environment.NewLine +
        "12-03-2015 | Buy present               |     $ -123,45"

⍤⤙≍ expected formatLedger currency locale entries
   
# American negative number with 3 digits before decimal point
currency = "USD"
locale = "en-US"
entries =
        [
            mkEntry "2015-03-12" "Buy present" -12345
        ]
expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "03/12/2015 | Buy present               |     ($123.45)"

⍤⤙≍ expected formatLedger currency locale entries