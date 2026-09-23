# 🟣 Programare .NET — exemple de cod

![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Partea_A-178600?logo=csharp&logoColor=white)
![F#](https://img.shields.io/badge/F%23-Partea_B-378BBA?logo=fsharp&logoColor=white)
![Licență](https://img.shields.io/badge/licen%C8%9B%C4%83-MIT-2F855A)
![CI](https://img.shields.io/badge/build-GitHub_Actions-2088FF?logo=githubactions&logoColor=white)

Cod însoțitor pentru manualul **_Programare .NET_** de Valer Bocan (Editura Politehnica
Timișoara). Fiecare exemplu este extras din carte și **verificat că se compilează și
rulează** cu .NET 10, astfel încât să îl puteți clona și rula pe măsură ce citiți.
Depozitul conține și **soluțiile de referință** ale exercițiilor din secțiunile „Aplicație
practică", la căile indicate în carte. Încercați fiecare exercițiu înainte de a consulta
soluția.

```bash
git clone https://github.com/vbocan/book-repo-dotnet.git
```

## 📦 Structură

| | |
|---|---|
| 🟦 [`csharp/`](csharp/) | Exemple C# — Partea A (capitolele 1–8), fiecare un proiect consolă |
| 🟫 [`fsharp/`](fsharp/) | Exemple F# — Partea B (capitolele 9–15), fiecare un script `.fsx` |

## 🚀 Rularea unui exemplu

**C#** (necesită .NET 10 SDK):
```bash
dotnet run --project csharp/<capitol>/<exemplu>
```

**F#** (script, rulat cu F# Interactive):
```bash
dotnet fsi fsharp/<capitol>/<exemplu>.fsx
```

## 📚 Harta capitolelor

| Cap. | Subiect | Exemple C# | Exemple F# |
|----:|---------|:----------:|:----------:|
| 01 | introducere platforma dotnet | 1 | 1 |
| 02 | tipuri variabile operatori | 45 | — |
| 03 | structuri control metode | 47 | — |
| 04 | programare orientata obiecte | 26 | — |
| 05 | mostenire interfete polimorfism | 17 | — |
| 06 | colectii lambda linq | 37 | — |
| 07 | gestionarea erorilor | 11 | — |
| 08 | prelucrarea datelor linq | 9 | — |
| 09 | introducere fsharp | 1 | 34 |
| 10 | functii pattern matching | — | 31 |
| 11 | tipuri algebrice fsharp | — | 22 |
| 12 | colectii prelucrarea datelor fsharp | — | 39 |
| 13 | gestionarea erorilor functional | — | 16 |
| 14 | prelucrarea fisierelor fsharp | — | 5 |
| 15 | interoperabilitate csharp fsharp | — | 11 |

## ⚖️ Licență

Codul sursă din acest depozit este publicat sub [licența MIT](LICENSE). Textul cărții este
© Valer Bocan și **nu** este acoperit de această licență.
