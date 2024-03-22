using System;
using Lab4CSharp;
using System.Numerics;

public class MatrixUshort
{
    private ushort[,] ShortIntArray;
    int n, m;
    int codeError;
    static int num_m;
    public MatrixUshort()
    {
        this.n = 1;
        this.m = 0;
        this.codeError = 0;
        this.ShortIntArray = new ushort[n, m];
        ShortIntArray[n, m] = 0;
        num_m++;
    }

    public MatrixUshort(int rows, int columns)
    {
        this.n = rows;
        this.m = columns;
        this.codeError = 0;
        this.ShortIntArray = new ushort[n, m];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                ShortIntArray[i, j] = 0;
            }
        }
        num_m++;
    }

    public MatrixUshort(int rows, int columns, ushort value)
    {
        this.n = rows;
        this.m = columns;
        this.codeError = 0;
        this.ShortIntArray = new ushort[n, m];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                ShortIntArray[i, j] = value;
            }
        }
        num_m++;
    }

    ~MatrixUshort()
    {
        Console.WriteLine("MatrixUshort object is being destroyed.");
    }
    public void Fill()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortIntArray[i, j] = ushort.Parse(Console.ReadLine());
            }
        }
    }

    public void Print()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(this.ShortIntArray[i, j] + " ");
            }
            Console.WriteLine();
        };
    }

    static void Count()
    {
        Console.WriteLine(num_m);
    }

    public void Enter(ushort value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortIntArray[i, j] = value;
            }
        }
    }

    public int N
    {
        get { return N; }
    }

    public int M
    {
        get { return M; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    public int this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = 1;
                return 0;
            }

            codeError = 0;
            return ShortIntArray[i, j];
        }
        set
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = 1;
                return;
            }

            ShortIntArray[i, j] = (ushort)value;
            codeError = 0;
        }
    }

    // iндексатор з одним iндексом
    public int this[int k]
    {
        get
        {
            int i = k / m;
            int j = k % m;

            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = 1;
                return 0;
            }

            codeError = 0;
            return ShortIntArray[i, j];
        }
        set
        {
            int i = k / m;
            int j = k % m;

            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
                return;
            }

            ShortIntArray[i, j] = (ushort)value;
            codeError = 0;
        }
    }
    public static MatrixUshort operator ++(MatrixUshort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortIntArray[i, j]++;
            }
        };
        return matrix;
    }

    public static MatrixUshort operator --(MatrixUshort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortIntArray[i, j]--;
            }
        };
        return matrix;
    }

    static public bool HasZeroElement(MatrixUshort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                if (matrix.ShortIntArray[i, j] == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static bool operator true(MatrixUshort matrix)
    {
        bool hasZero = HasZeroElement(matrix);
        return matrix.n != 0 && matrix.m != 0 && !hasZero;
    }

    public static bool operator false(MatrixUshort matrix)
    {
        bool hasZero = HasZeroElement(matrix);
        return matrix.n == 0 || matrix.m == 0 || hasZero;
    }

    public static bool operator !(MatrixUshort matrix)
    {
        return matrix.n != 0 && matrix.m != 0;
    }

    public override string ToString()
    {
        return $"{this.n}";
    }

    public static MatrixUshort operator ~(MatrixUshort matrix)
    {
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)~matrix.ShortIntArray[i, j]++;
            }
        };
        return result;
    }

    public static MatrixUshort operator +(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException("Вхiднi матрицi не можуть бути нульовими.");
        }
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Розмiрностi матриць повиннi бути однаковими.");
        }
        MatrixUshort result = new MatrixUshort(matrix1.n, matrix1.m);

        // Додавання вiдповiдних елементiв
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                // Перевiрка на переповнення для кожного елемента
                if (matrix1.ShortIntArray[i, j] > ushort.MaxValue - matrix2.ShortIntArray[i, j])
                {
                    throw new OverflowException("При додаваннi елементiв виникло переповнення.");
                }
                result.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] + matrix2.ShortIntArray[i, j]);

            }
        };
        return result;

    }

    // Перевантаження бiнарної операцiї додавання для вектора i скаляра ushort
    public static MatrixUshort operator +(MatrixUshort matrix1, ushort scalar)
    {
        MatrixUshort matrix = new MatrixUshort(matrix1.n, matrix1.m);
        if (matrix1 == null)
        {
            throw new ArgumentNullException("Вхiднi вектори не можуть бути нульовими.");
        }
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {

                matrix.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] + scalar);

            }
        };

        return matrix;
    }

    // Перевантаження бiнарної операцiї вiднiмання для двох векторiв
    public static MatrixUshort operator -(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException("Вхiднi вектори не можуть бути нульовими.");
        }
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Розмiрностi матриць повиннi бути однаковими.");
        }
        MatrixUshort result = new MatrixUshort(matrix1.n, matrix1.m);

        // Додавання вiдповiдних елементiв
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                // Перевiрка на переповнення для кожного елемента
                if (matrix1.ShortIntArray[i, j] < matrix2.ShortIntArray[i, j])
                {
                    //throw new InvalidOperationException("Вiднiмання може призвести до вiд'ємного результату.");
                    Console.WriteLine("Вiдємне значення виходить");
                    result.ShortIntArray[i, j] = 0;
                    continue;
                }
                result.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] - matrix2.ShortIntArray[i, j]);

            }
        };
        return result;
    }

    // Перевантаження бiнарної операцiї вiднiмання для вектора i скаляра ushort
    public static MatrixUshort operator -(MatrixUshort matrix1, ushort scalar)
    {
        MatrixUshort matrix = new MatrixUshort(matrix1.n, matrix1.m);
        if (matrix1 == null)
        {
            throw new ArgumentNullException("Вхiднi вектори не можуть бути нульовими.");
        }
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix1.ShortIntArray[i, j] < scalar)
                {
                    //throw new InvalidOperationException("Вiднiмання може призвести до вiд'ємного результату.");
                    Console.WriteLine("Вiдємне значення виходить");
                    matrix.ShortIntArray[i, j] = 0;
                    continue;
                }
                matrix.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] - scalar);
            }
        };

        return matrix;
    }

    // Перевантаження бiнарної операцiї множення для двох векторiв
    public static MatrixUshort operator *(MatrixUshort left, MatrixUshort right)
    {
        if (left == null || right == null)
        {
            throw new ArgumentNullException("Вхiднi матрицi не можуть бути нульовими.");
        }
        if (left.n != right.n)
        {
            throw new ArgumentException("Розмiрностi матриць повиннi бути однаковими.");

        }
        // Перевiрка на валiднiсть вхiдних параметрiв 
        MatrixUshort result = new MatrixUshort(left.n, left.m);

        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] > ushort.MaxValue / right.ShortIntArray[i, j])
                {
                    throw new OverflowException("При множеннi елементiв виникло переповнення.");
                }
                result.ShortIntArray[i, j] = (ushort)(left.ShortIntArray[i, j] * right.ShortIntArray[i, j]);
            }
        };


        return result;
    }

    // Перевантаження бiнарної операцiї множення для вектора i скаляра ushort
    public static MatrixUshort operator *(MatrixUshort matrix1, ushort scalar)
    {
        MatrixUshort matrix = new MatrixUshort(matrix1.n, matrix1.m);
        if (matrix1 == null)
        {
            throw new ArgumentNullException("Вхiднi вектори не можуть бути нульовими.");
        }
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                matrix.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] * scalar);
            }
        };

        return matrix;
    }

    // Перевантаження бiнарної операцiї дiлення для двох векторiв
    public static MatrixUshort operator /(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException("Вхiднi вектори не можуть бути нульовими.");
        }
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Розмiрностi матриць повиннi бути однаковими.");
        }
        MatrixUshort result = new MatrixUshort(matrix1.n, matrix1.m);

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix2.ShortIntArray[i, j] == 0)
                {
                    throw new InvalidOperationException("Є нульовi елементи");
                }

                result.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] / matrix2.ShortIntArray[i, j]);
            }
        };
        return result;
    }

    // Перевантаження бiнарної операцiї дiлення для вектора i скаляра ushort
    public static MatrixUshort operator /(MatrixUshort matrix1, ushort scalar)
    {
        MatrixUshort matrix = new MatrixUshort(matrix1.n, matrix1.m);
        if (matrix1 == null)
        {
            throw new ArgumentNullException("Вхiднi матрицi не можуть бути нульовими.");
        }
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (scalar == 0)
                {
                    throw new InvalidOperationException("Не допустиме дiлення на 0");
                }

                matrix.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] / scalar);
            }
        };

        return matrix;
    }

    // Перевантаження бiнарної операцiї остачi вiд дiлення для двох векторiв
    public static MatrixUshort operator %(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException("Вхiднi вектори не можуть бути нульовими.");
        }
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Розмiрностi матриць повиннi бути однаковими.");
        }
        MatrixUshort result = new MatrixUshort(matrix1.n, matrix1.m);

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix2.ShortIntArray[i, j] == 0)
                {
                    throw new InvalidOperationException("Є нульовi елементи");
                }

                result.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] % matrix2.ShortIntArray[i, j]);
            }
        };
        return result;
    }

    // Перевантаження бiнарної операцiї остачi вiд дiлення для вектора i скаляра ushort
    public static MatrixUshort operator %(MatrixUshort matrix1, ushort scalar)
    {
        MatrixUshort matrix = new MatrixUshort(matrix1.n, matrix1.m);
        if (matrix1 == null)
        {
            throw new ArgumentNullException("Вхiднi матрицi не можуть бути нульовими.");
        }
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                matrix.ShortIntArray[i, j] = (ushort)(matrix1.ShortIntArray[i, j] % scalar);
            }
        };

        return matrix;
    }
    public static MatrixUshort operator |(MatrixUshort left, MatrixUshort right)
    {
        MatrixUshort result = new MatrixUshort(left.n, right.m);
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(left.ShortIntArray[i, j] | right.ShortIntArray[i, j]);
            }
        };
        return result;
    }
    public static MatrixUshort operator |(MatrixUshort matrix, ushort scalar)
    {
        // Перевiрка на валiднiсть вхiдних параметрiв 
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(matrix.ShortIntArray[i, j] | scalar);
            }
        };

        return result;
    }
    public static MatrixUshort operator ^(MatrixUshort left, MatrixUshort right)
    {
        MatrixUshort result = new MatrixUshort(left.n, left.m);

        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(left.ShortIntArray[i, j] ^ right.ShortIntArray[i, j]);
            }
        };

        return result;
    }

    public static MatrixUshort operator ^(MatrixUshort matrix, ushort scalar)
    {
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(matrix.ShortIntArray[i, j] ^ scalar);
            }
        };

        return result;
    }

    public static MatrixUshort operator &(MatrixUshort left, MatrixUshort right)
    {
        MatrixUshort result = new MatrixUshort(left.n, left.m);

        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(left.ShortIntArray[i, j] & right.ShortIntArray[i, j]);
            }
        };

        return result;
    }

    public static MatrixUshort operator &(MatrixUshort matrix, ushort scalar)
    {
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(matrix.ShortIntArray[i, j] & scalar);
            }
        };

        return result;
    }
    public static MatrixUshort operator >>(MatrixUshort matrix, int shift)
    {
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(matrix.ShortIntArray[i, j] >> shift);
            }
        };


        return result;
    }
    public static MatrixUshort operator <<(MatrixUshort matrix, int shift)
    {
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortIntArray[i, j] = (ushort)(matrix.ShortIntArray[i, j] << shift);
            }
        };
        return result;
    }
    public static bool operator ==(MatrixUshort left, MatrixUshort right)
    {
        if (ReferenceEquals(left, right))
            return true;

        if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            return false;

        if (left.n != right.n || left.m != right.m)
            return false;
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] != right.ShortIntArray[i, j])
                    return false;
            }
        };
        return true;
    }
    public static bool operator !=(MatrixUshort left, MatrixUshort right)
    {
        return !(left == right);
    }
    public static bool operator >(MatrixUshort left, MatrixUshort right)
    {
        if (left.n != right.n || left.m != right.m)
            throw new ArgumentException("matrixs must have the same length for comparison.");
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] <= right.ShortIntArray[i, j])
                    return false;
            }
        };
        return true;
    }

    public static bool operator <(MatrixUshort left, MatrixUshort right)
    {
        if (left.n != right.n || left.m != right.m)
            throw new ArgumentException("matrixs must have the same length for comparison.");
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] >= right.ShortIntArray[i, j])
                    return false;
            }
        };
        return true;
    }

    public static bool operator >=(MatrixUshort left, MatrixUshort right)
    {
        if (left.n != right.n || left.m != right.m)
            throw new ArgumentException("matrixs must have the same length for comparison.");
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] < right.ShortIntArray[i, j])
                    return false;
            }
        };
        return true;
    }

    public static bool operator <=(MatrixUshort left, MatrixUshort right)
    {
        if (left.n != right.n || left.m != right.m)
            throw new ArgumentException("matrixs must have the same length for comparison.");
        for (int i = 0; i < left.n; i++)
        {
            for (int j = 0; j < left.m; j++)
            {
                if (left.ShortIntArray[i, j] > right.ShortIntArray[i, j])
                    return false;
            }
        };
        return true;
    }
}