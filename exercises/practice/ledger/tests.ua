// This file was created manually and its version is 1.0.0.

module LedgerTest



# Empty ledger
    let currency = "USD"
    let locale = "en-US"
    let entries = []
    let expected =
        "Date       | Description               | Change       "

    formatLedger currency locale entries |> should equal expected

# One entry
    let currency = "USD"
    let locale = "en-US"
    let entries =
        [
            mkEntry "2015-01-01" "Buy present" -1000
        ]
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      ($10.00)"

    formatLedger currency locale entries |> should equal expected

# Credit and debit
    let currency = "USD"
    let locale = "en-US"
    let entries =
        [
            mkEntry "2015-01-02" "Get present"  1000;
            mkEntry "2015-01-01" "Buy present" -1000
        ]
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      ($10.00)" + System.Environment.NewLine +
        "01/02/2015 | Get present               |       $10.00 "

    formatLedger currency locale entries |> should equal expected
 
# Multiple entries on same date ordered by description
    let currency = "USD"
    let locale = "en-US"
    let entries =
        [
            mkEntry "2015-01-01" "Buy present" -1000;
            mkEntry "2015-01-01" "Get present"  1000
        ]
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      ($10.00)" + System.Environment.NewLine +
        "01/01/2015 | Get present               |       $10.00 "

    formatLedger currency locale entries |> should equal expected
   
# Final order tie breaker is change
    let currency = "USD"
    let locale = "en-US"
    let entries =
        [
            mkEntry "2015-01-01" "Something" 0;
            mkEntry "2015-01-01" "Something" -1;
            mkEntry "2015-01-01" "Something" 1
        ]
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Something                 |       ($0.01)" + System.Environment.NewLine +
        "01/01/2015 | Something                 |        $0.00 " + System.Environment.NewLine +
        "01/01/2015 | Something                 |        $0.01 "

    formatLedger currency locale entries |> should equal expected
  
# Overlong descriptions
    let currency = "USD"
    let locale = "en-US"
    let entries =
        [
            mkEntry "2015-01-01" "Freude schoner Gotterfunken" -123456
        ]
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Freude schoner Gotterf... |   ($1,234.56)"

    formatLedger currency locale entries |> should equal expected
  
# Euros
    let currency = "EUR"
    let locale = "en-US"
    let entries =
        [
            mkEntry "2015-01-01" "Buy present" -1000
        ]
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "01/01/2015 | Buy present               |      (€10.00)"

    formatLedger currency locale entries |> should equal expected
   
# Dutch locale
    let currency = "USD"
    let locale = "nl-NL"
    let entries =
        [
            mkEntry "2015-03-12" "Buy present" 123456
        ]
    let expected =
        "Datum      | Omschrijving              | Verandering  " + System.Environment.NewLine +
        "12-03-2015 | Buy present               |   $ 1.234,56 "

    formatLedger currency locale entries |> should equal expected
 
# Dutch negative number with 3 digits before decimal point
    let currency = "USD"
    let locale = "nl-NL"
    let entries =
        [
            mkEntry "2015-03-12" "Buy present" -12345
        ]
    let expected =
        "Datum      | Omschrijving              | Verandering  " + System.Environment.NewLine +
        "12-03-2015 | Buy present               |     $ -123,45"

    formatLedger currency locale entries |> should equal expected
   
# American negative number with 3 digits before decimal point
    let currency = "USD"
    let locale = "en-US"
    let entries =
        [
            mkEntry "2015-03-12" "Buy present" -12345
        ]
    let expected =
        "Date       | Description               | Change       " + System.Environment.NewLine +
        "03/12/2015 | Buy present               |     ($123.45)"

    formatLedger currency locale entries |> should equal expected