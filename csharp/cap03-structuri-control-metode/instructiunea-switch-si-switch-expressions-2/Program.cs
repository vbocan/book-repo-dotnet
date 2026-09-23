Console.Write("Introduceți ziua săptămânii (1-7): ");
int ziua = int.Parse(Console.ReadLine()!);

string numeZi = ziua switch
{
    1 => "Luni",
    2 => "Marți",
    3 => "Miercuri",
    4 => "Joi",
    5 => "Vineri",
    6 => "Sâmbătă",
    7 => "Duminică",
    _ => "Necunoscut"
};

Console.WriteLine($"Ziua selectată: {numeZi}");
