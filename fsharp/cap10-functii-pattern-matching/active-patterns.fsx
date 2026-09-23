let (|Par|Impar|) n =
    if n % 2 = 0 then Par else Impar

let descrie n =
    match n with
    | Par -> $"{n} este par"
    | Impar -> $"{n} este impar"

for i in 1..6 do
    printfn "%s" (descrie i)
