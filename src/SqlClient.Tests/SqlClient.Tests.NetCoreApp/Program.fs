open FSharp.Data

[<Literal>]
let cnx = "Data Source=.;Initial Catalog=AdventureWorks2012;Integrated Security=True"

type TinyIntMapping = SqlEnumProvider<"SELECT * FROM (VALUES(('One'), CAST(1 AS tinyint)), ('Two', CAST(2 AS tinyint))) AS T(Tag, Value)", cnx>

[<EntryPoint>]
let main _ =
    let get42 = new SqlCommandProvider<"SELECT 42", "Server=.;Integrated Security=True">("Server=.;Integrated Security=True")
    get42.Execute() |> Seq.toArray |> printfn "%A"
    printfn "generative type: %A" TinyIntMapping.Items
    0