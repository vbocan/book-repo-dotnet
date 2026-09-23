open System

type Masurare = { Data: DateTime; Temperatura: float; Precipitatii: float; Vant: int }

let csvMeteo = [|
    "Data,Temperatura,Precipitatii,Vant"
    "2026-01-05,-3.2,0.0,12"; "2026-01-12,-1.5,5.2,18"
    "2026-01-20,1.0,2.1,8";   "2026-01-28,-4.8,0.0,22"
    "2026-02-03,0.5,3.0,15";  "2026-02-14,2.8,8.4,10"
    "2026-02-22,5.1,1.2,7";   "2026-03-01,8.3,4.5,12"
    "2026-03-10,12.0,0.0,6";  "2026-03-18,10.5,2.3,9"
|]

let masurari =
    csvMeteo
    |> Array.skip 1
    |> Array.map (fun linie ->
        let p = linie.Split(',')
        { Data = DateTime.Parse(p.[0]); Temperatura = float p.[1]
          Precipitatii = float p.[2]; Vant = int p.[3] })

printfn "=== Statistici lunare ==="
masurari
|> Array.groupBy (fun m -> m.Data.Month)
|> Array.sortBy fst
|> Array.iter (fun (luna, date) ->
    let temp = date |> Array.map (fun m -> m.Temperatura)
    let precip = date |> Array.sumBy (fun m -> m.Precipitatii)
    let numeLuna =
        Globalization.CultureInfo("ro-RO").DateTimeFormat.GetMonthName(luna)
    printfn "  %s:" (numeLuna.Substring(0, 1).ToUpper() + numeLuna.Substring(1))
    printfn "    Temperatură: medie %.1f°C, min %.1f°C, max %.1f°C"
        (Array.average temp) (Array.min temp) (Array.max temp)
    printfn "    Precipitații totale: %.1f mm, măsurări: %d" precip date.Length)

let ceaMaiCalda = masurari |> Array.maxBy (fun m -> m.Temperatura)
let ceaMaiRece = masurari |> Array.minBy (fun m -> m.Temperatura)
printfn "\n=== Extreme ==="
printfn "  Cea mai caldă zi: %s (%.1f°C)"
    (ceaMaiCalda.Data.ToString("yyyy-MM-dd")) ceaMaiCalda.Temperatura
printfn "  Cea mai rece zi: %s (%.1f°C)"
    (ceaMaiRece.Data.ToString("yyyy-MM-dd")) ceaMaiRece.Temperatura
