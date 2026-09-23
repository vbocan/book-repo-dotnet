type MetodaPlata =
    | Numerar
    | Card of numar: string * titular: string
    | TransferBancar of iban: string
    | PortofelDigital of furnizor: string * email: string

let descrieMetoda metoda =
    match metoda with
    | Numerar -> "Plată în numerar"
    | Card(numar, titular) ->
        let ultimeleCifre = numar[numar.Length - 4..]
        $"Card ****{ultimeleCifre} ({titular})"
    | TransferBancar iban -> $"Transfer bancar: {iban}"
    | PortofelDigital(furnizor, email) -> $"{furnizor} ({email})"

let plati =
    [ Numerar
      Card("4111222233334444", "Maria Popescu")
      TransferBancar "RO49AAAA1B31007593840000"
      PortofelDigital("PayPal", "maria@email.com") ]

for p in plati do
    printfn "  %s" (descrieMetoda p)
