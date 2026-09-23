Console.Write("Introduceți ziua săptămânii (1-7): ");
int ziua = int.Parse(Console.ReadLine()!);
string numeZi;

switch (ziua)
{
    case 1:
        numeZi = "Luni";
        break;
    case 2:
        numeZi = "Marți";
        break;
    case 3:
        numeZi = "Miercuri";
        break;
    case 4:
        numeZi = "Joi";
        break;
    case 5:
        numeZi = "Vineri";
        break;
    case 6:
        numeZi = "Sâmbătă";
        break;
    case 7:
        numeZi = "Duminică";
        break;
    default:
        numeZi = "Necunoscut";
        break;
}

Console.WriteLine($"Ziua selectată: {numeZi}");
