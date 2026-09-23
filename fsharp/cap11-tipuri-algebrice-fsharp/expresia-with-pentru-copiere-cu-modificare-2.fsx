type Configuratie =
    { Server: string
      Port: int
      Timeout: int
      Verbose: bool }

let configImplicita =
    { Server = "localhost"
      Port = 8080
      Timeout = 30
      Verbose = false }

let productie = { configImplicita with Server = "api.exemplu.ro"; Port = 443 }
let debug = { configImplicita with Verbose = true; Timeout = 120 }

printfn "Implicit:  %s:%d (timeout=%ds, verbose=%b)" configImplicita.Server configImplicita.Port configImplicita.Timeout configImplicita.Verbose
printfn "Producție: %s:%d (timeout=%ds, verbose=%b)" productie.Server productie.Port productie.Timeout productie.Verbose
printfn "Debug:     %s:%d (timeout=%ds, verbose=%b)" debug.Server debug.Port debug.Timeout debug.Verbose
