open FSharp.Data

//[<Literal>]
//let cnx = "Data Source=.;Initial Catalog=AdventureWorks2012;Integrated Security=True"

//type TinyIntMappingCLI = SqlEnumProvider<"SELECT * FROM (VALUES(('One'), CAST(1 AS tinyint)), ('Two', CAST(2 AS tinyint))) AS T(Tag, Value)", cnx, Kind = SqlEnumKind.CLI>
//type CurrencyCode = 
//   SqlEnumProvider<"
//       SELECT CurrencyCode
//       FROM Sales.Currency 
//       WHERE CurrencyCode IN ('USD', 'EUR', 'GBP')
//   ", cnx, Kind = SqlEnumKind.UnitsOfMeasure>

//type TinyIntMappingDefault = SqlEnumProvider<"SELECT * FROM (VALUES(('One'), CAST(1 AS tinyint)), ('Two', CAST(2 AS tinyint))) AS T(Tag, Value)", cnx, Kind = SqlEnumKind.Default>
//type SingleColumnSelect = SqlEnumProvider<"SELECT Name FROM Purchasing.ShipMethod", cnx>

type Test = TestGenerativeProvider<"">

[<EntryPoint>]
let main _ =
    let get42 = new SqlCommandProvider<"SELECT 42", "Server=.;Integrated Security=True">("Server=.;Integrated Security=True")
    get42.Execute() |> Seq.toArray |> printfn "%A"
    //printfn "uom: %A" 1m<CurrencyCode.USD>
    //printfn "cli enum: %A" TinyIntMappingCLI.One
    //printfn "default: %A" TinyIntMappingDefault.One
    //printfn "sss: %A" SingleColumnSelect.``CARGO TRANSPORT 5``
    printfn "test: %A" (Test.TryParse("xyz"))
    printfn "test2: %A" (Test.TryParse("xyz", true))
    0