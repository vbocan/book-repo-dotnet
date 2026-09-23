let (|Intreg|_|) (s: string) =
    match System.Int32.TryParse(s) with (true, v) -> Some v | _ -> None

type Operatie = Adunare | Scadere | Inmultire | Impartire

let parseazaOp = function
    | "+" -> Some Adunare | "-" -> Some Scadere
    | "*" -> Some Inmultire | "/" -> Some Impartire | _ -> None

let evalueaza a op b =
    match op with
    | Adunare -> a + b | Scadere -> a - b
    | Inmultire -> a * b
    | Impartire -> if b = 0 then failwith "Împărțire la zero" else a / b

let calculeaza (expr: string) =
    match expr.Trim().Split(' ') with
    | [| Intreg a; op; Intreg b |] ->
        match parseazaOp op with
        | Some operatie -> $"{expr} = {evalueaza a operatie b}"
        | None -> $"Operator necunoscut: '{op}'"
    | _ -> $"Format invalid: '{expr}'"

["3 + 5"; "10 - 3"; "4 * 7"; "20 / 4"] |> List.iter (fun e -> printfn "  %s" (calculeaza e))
