module LedgerTest

open NUnit.Framework

open Ledger

[<Test>]
let ``Empty ledger`` () =
    let currency = "USD"
    let locale = "en-US"
    let entries = []
    let expected = 
        "Date       | Description               | Change       "

    Assert.That(formatLedger currency locale entries, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One entry`` () =
    let currency = "USD"
    let locale = "en-US"
    let entries = 
        [
            mkEntry "2015-01-01" "Buy present" -1000
        ]
    let expected = 
        "Date       | Description               | Change       \n" +
        "01/01/2015 | Buy present               |      ($10.00)"

    Assert.That(formatLedger currency locale entries, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Credit and debit`` () =
    let currency = "USD"
    let locale = "en-US"
    let entries = 
        [
            mkEntry "2015-01-02" "Get present"  1000;
            mkEntry "2015-01-01" "Buy present" -1000
        ]
    let expected = 
        "Date       | Description               | Change       \n" +
        "01/01/2015 | Buy present               |      ($10.00)\n" +
        "01/02/2015 | Get present               |       $10.00 "

    Assert.That(formatLedger currency locale entries, Is.EqualTo(expected))
  
[<Test>] 
[<Ignore("Remove to run test")>] 
let ``Multiple entries on same date ordered by description`` () =
    let currency = "USD"
    let locale = "en-US"
    let entries = 
        [
            mkEntry "2015-01-01" "Buy present" -1000;
            mkEntry "2015-01-01" "Get present"  1000
        ]
    let expected = 
        "Date       | Description               | Change       \n" +
        "01/01/2015 | Buy present               |      ($10.00)\n" +
        "01/01/2015 | Get present               |       $10.00 " 

    Assert.That(formatLedger currency locale entries, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Final order tie breaker is change`` () =
    let currency = "USD"
    let locale = "en-US"
    let entries = 
        [
            mkEntry "2015-01-01" "Something" 0;
            mkEntry "2015-01-01" "Something" -1;
            mkEntry "2015-01-01" "Something" 1
        ]
    let expected =
        "Date       | Description               | Change       \n" +
        "01/01/2015 | Something                 |       ($0.01)\n" +
        "01/01/2015 | Something                 |        $0.00 \n" +
        "01/01/2015 | Something                 |        $0.01 "

    Assert.That(formatLedger currency locale entries, Is.EqualTo(expected))
   
[<Test>] 
[<Ignore("Remove to run test")>]
let ``Overlong descriptions`` () =
    let currency = "USD"
    let locale = "en-US"
    let entries = 
        [
            mkEntry "2015-01-01" "Freude schoner Gotterfunken" -123456
        ]
    let expected =
        "Date       | Description               | Change       \n" +
        "01/01/2015 | Freude schoner Gotterf... |   ($1,234.56)"

    Assert.That(formatLedger currency locale entries, Is.EqualTo(expected))
   
[<Test>] 
[<Ignore("Remove to run test")>]
let ``Euros`` () =
    let currency = "EUR"
    let locale = "en-US"
    let entries = 
        [
            mkEntry "2015-01-01" "Buy present" -1000
        ]
    let expected =
        "Date       | Description               | Change       \n" +
        "01/01/2015 | Buy present               |      (€10.00)"

    Assert.That(formatLedger currency locale entries, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Dutch locale`` () =
    let currency = "USD"
    let locale = "nl-NL"
    let entries = 
        [
            mkEntry "2015-03-12" "Buy present" 123456
        ]
    let expected =
        "Datum      | Omschrijving              | Verandering  \n" +
        "12-03-2015 | Buy present               |   $ 1.234,56 "

    Assert.That(formatLedger currency locale entries, Is.EqualTo(expected))
  
[<Test>]  
[<Ignore("Remove to run test")>]
let ``Dutch negative number with 3 digits before decimal point`` () =
    let currency = "USD"
    let locale = "nl-NL"
    let entries = 
        [
            mkEntry "2015-03-12" "Buy present" -12345
        ]
    let expected = 
        "Datum      | Omschrijving              | Verandering  \n" +
        "12-03-2015 | Buy present               |     $ -123,45"

    Assert.That(formatLedger currency locale entries, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``American negative number with 3 digits before decimal point`` () =
    let currency = "USD"
    let locale = "en-US"
    let entries = 
        [
            mkEntry "2015-03-12" "Buy present" -12345
        ]
    let expected = 
        "Date       | Description               | Change       \n" +
        "03/12/2015 | Buy present               |     ($123.45)"

    Assert.That(formatLedger currency locale entries, Is.EqualTo(expected))