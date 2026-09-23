let imparteSecurizat x y : Result<float, string> =
    if y = 0.0 then Error "Împărțire la zero"
    else Ok (x / y)

printfn "%A" (imparteSecurizat 10.0 3.0)
printfn "%A" (imparteSecurizat 10.0 0.0)
