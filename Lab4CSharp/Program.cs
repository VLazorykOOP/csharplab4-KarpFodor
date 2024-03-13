// See https://aka.ms/new-console-template for more information

using Lab4CSharp;

Console.WriteLine("Lab_4 C#");

while (true) 
{
    Console.WriteLine("Оберiть завдання(1-3):");
    int n = int.Parse(Console.ReadLine());

    switch (n)
    {
        case 1:
            Romb romb = new Romb(4, 4 * Math.Sqrt(2), "Red");

            Console.WriteLine(romb[0]);
            Console.WriteLine(romb[1]);
            Console.WriteLine(romb[2]);

            // Перевантаження true i false
            Console.WriteLine(romb ? "Квадрат" : "Не квадрат");

            Console.WriteLine($"Пiсля операцiї ++: {romb}");

            Console.WriteLine($"Пiсля операцiї --: {romb}");

            // Перевантаження оператору *
            romb = romb * 2;
            Console.WriteLine($"Пiсля операцiї * 2: {romb}");

            // Перетворення типу Romb в string i навпаки
            string rombString = romb;
            Console.WriteLine($"Romb в string: {rombString}");

            Romb newRomb = rombString;
            Console.WriteLine($"String в Romb: {newRomb}");
            Console.ReadLine();
            break;

        case 2:
            VectorUshort vector1 = new VectorUshort(5);
            VectorUshort vector2 = new VectorUshort(5);

            Console.WriteLine("Ввод з клавiатури");
            vector2.Fill();
            vector2.Print();

            Console.WriteLine("Заповнення скаляром(2)");
            vector2.Enter(2);
            vector2.Print();

            Console.WriteLine(vector2.Num);

            vector2.CodeError = 0;
            Console.WriteLine(vector2.CodeError);

            Console.WriteLine("Вiрний " + vector2[1] + " Не Вiрний " + vector2[10]);

            Console.WriteLine(vector2.CodeError);

            Console.WriteLine("Операцiя ++");
            vector2++;
            vector2.Print();

            Console.WriteLine("Операцiя --");
            vector2--;
            vector2--;
            vector2.Print();

            vector2.Fill();
            vector1.Enter(1);
            Console.WriteLine("Операцiя True/False");
            if (vector2) Console.WriteLine("Не дорiвнює нулю");
            else Console.WriteLine("Розмiрнiсть вектора або один з елементiв дорiвнює 0 ");

            VectorUshort vectorNot = new VectorUshort(2);
            VectorUshort vector = new VectorUshort(vector1.Num);
            ushort scalar = 2;
            Console.WriteLine("Перевантаження +");
            vector = vector1 + vector2;
            vector.Print();
 
            vector = vector2 + scalar;
            vector.Print();

            Console.WriteLine("Перевантаження -");
            vector = vector2 - vector1;
            vector.Print();
            
            vector = vector2 - scalar;
            vector.Print();

            Console.WriteLine("Перевантаження *");
            vector = vector1 * vector2;
            vector.Print();
            vector = vector2 * scalar;
            vector.Print();

            Console.WriteLine("Перевантаження /");
            vector = vector2 / vector1;
            vector.Print();
            vector = vector2 / scalar;
            vector.Print();

            Console.WriteLine("Перевантаження %");
            vector = vector2 % vector1;
            vector.Print();
            vector = vector2 % scalar;
            vector.Print();

            Console.WriteLine("Перевантаження |");
            vector = vector2 | vector1;
            vector.Print();
            vector = vector2 | scalar;
            vector.Print();

            Console.WriteLine("Перевантаження >>");
            vector = vector2 >> scalar;
            vector.Print();

            Console.WriteLine("Перевантаження <<");
            vector = vector2 << scalar;
            vector.Print();

            Console.WriteLine("Перевантаження ==");
            Console.WriteLine(vector1 == vector);
            vector1 = vector2;
            Console.WriteLine(vector1 == vector2);

            Console.WriteLine("Перевантаження !=");
            Console.WriteLine(vector1 != vector);

            Console.WriteLine("Перевантаження >");
            Console.WriteLine(vector1 > vector);

            Console.WriteLine("Перевантаження <");
            Console.WriteLine(vector1 < vector);

            Console.WriteLine("Перевантаження >=");
            Console.WriteLine(vector1 >= vector);

            Console.WriteLine("Перевантаження <=");
            Console.WriteLine(vector1 <= vector);
            break;

        case 3:
            MatrixUshort matrix1 = new MatrixUshort(2, 2);
            MatrixUshort matrix2 = new MatrixUshort(2, 2);

            matrix1.Print();

            Console.WriteLine("Ввод з клавiатури");
            matrix1.Fill();
            matrix1.Print();

            Console.WriteLine("Операцiя Заповнення скаляром(3)");
            matrix2.Enter(3);
            matrix2.Print();

            matrix2.CodeError = 0;
            Console.WriteLine(matrix2.CodeError);

            Console.WriteLine("Вiрний " + matrix1[0, 1] + " Не Вiрний " + matrix2[4, 5]);
            Console.WriteLine("Через iндекс k - " + matrix1[3]);
            Console.WriteLine(matrix2.CodeError);

            Console.WriteLine("Операцiя ++");
            matrix1++;
            matrix1.Print();

            Console.WriteLine("Операцiя --");
            matrix2--;
            matrix2.Print();

            matrix2.Fill();
            Console.WriteLine("Операцiя True/False");
            if (matrix2) Console.WriteLine("Не дорiвнює нулю");
            else Console.WriteLine("Розмiрнiсть матрицi або один з елементiв дорiвнює 0 ");

            MatrixUshort matrix = new MatrixUshort(2, 2);
            ushort scalar1 = 2;
            Console.WriteLine("Перевантаження +");
            matrix = matrix1 + matrix2;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix1 + scalar1;
            matrix.Print();

            Console.WriteLine("Перевантаження -");
            matrix = matrix2 - matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 - scalar1;
            matrix.Print();

            Console.WriteLine("Перевантаження *");
            matrix = matrix1 * matrix2;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 * scalar1;
            matrix.Print();

            Console.WriteLine("Перевантаження /");
            matrix = matrix2 / matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 / scalar1;
            matrix.Print();

            Console.WriteLine("Перевантаження %");
            matrix = matrix2 % matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 % scalar1;
            matrix.Print();

            Console.WriteLine("Перевантаження |");
            matrix = matrix2 | matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 | scalar1;
            matrix.Print();

            Console.WriteLine("Перевантаження >>");
            matrix = matrix2 >> scalar1;
            matrix.Print();

            Console.WriteLine("Перевантаження <<");
            matrix = matrix2 << scalar1;
            matrix.Print();

            Console.WriteLine("Перевантаження ==");
            Console.WriteLine(matrix1 == matrix);
            matrix1 = matrix2;
            Console.WriteLine(matrix1 == matrix2);

            Console.WriteLine("Перевантаження !=");
            Console.WriteLine(matrix1 != matrix);

            Console.WriteLine("Перевантаження >");
            Console.WriteLine(matrix1 > matrix);

            Console.WriteLine("Перевантаження <");
            Console.WriteLine(matrix1 < matrix);

            Console.WriteLine("Перевантаження >=");
            Console.WriteLine(matrix1 >= matrix);

            Console.WriteLine("Перевантаження <=");
            Console.WriteLine(matrix1 <= matrix);
            break;

        default:

            Console.WriteLine("Невiдомий вибiр.");
            break;
    }
}
