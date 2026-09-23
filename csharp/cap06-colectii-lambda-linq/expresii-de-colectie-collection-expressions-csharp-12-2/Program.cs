int[] prima = [1, 2, 3];
int[] aDoua = [4, 5, 6];
int[] aTreia = [7, 8, 9];

int[] toate = [..prima, ..aDoua, ..aTreia];
Console.WriteLine($"Concatenate: {string.Join(", ", toate)}");

// Combinare cu elemente individuale
int[] cuExtra = [0, ..prima, 100];
Console.WriteLine($"Cu extra: {string.Join(", ", cuExtra)}");
