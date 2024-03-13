using System;

namespace Lab4CSharp
{
	public class Romb
	{
		private double side;
        private double diagonale1;
        private double diagonale2;
        private string color;

        public Romb(double side,double diagonale, string color)
		{
			this.side = side;
			this.diagonale1 = diagonale;
			this.diagonale2 = Math.Sqrt(4 * side * side - diagonale * diagonale);
            this.color = color;
            Cheak();
		}

        public double Side
        {
            get { return side; }
        }

        public double Diagonale1
        {
            get { return diagonale1; }
        }

        public double Diagonale2
        {
            get { return diagonale2; }
        }

        public string Color
        {
            get { return color; }
        }

        private void Cheak()
		{
			if(double.IsNaN(diagonale2) || side <= 0 || diagonale1 <= 0)
			{
				double a = Math.Sqrt(Math.Pow(diagonale1,2)+Math.Pow(diagonale2,2));
				if (a != side)
				{
					Console.WriteLine("Не iснує, створюється квадрат з стороною 4.");
					this.side = 4;
					this.diagonale1 = side * Math.Sqrt(2);
					this.diagonale2 = diagonale1;
					this.color = "Black";
				}
            }
		}

        public static bool operator true(Romb romb)
        {
            return romb.Is_Square();
        }

        public static bool operator false(Romb romb)
        {
            return !romb.Is_Square();
        }

        public object this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return side;
                    case 1: return diagonale1;
                    case 2: return diagonale2;
                    case 3: return color;            
                    default: throw new ArgumentOutOfRangeException(nameof(index), "Invalid index");
                }
            }
        }

        public static Romb operator ++(Romb romb)
        {
            romb.side++;
            romb.diagonale1++;
            return romb;
        }

        public static Romb operator --(Romb romb)
        {
            romb.side--;
            romb.diagonale1--;
            return romb;
        }

        public static Romb operator *(Romb romb, double scalar)
        {
            romb.side *= scalar;
            romb.diagonale1 *= scalar;
            return romb;
        }

        public double GetDiagonal1()
		{
			return diagonale1;
		}

        public double GetDiagonal2()
        {
            return diagonale2;
        }

         public override string ToString()
        {
        return $"Ромб: сторона={this.side}; Перша дiагональ={this.diagonale1}; Друга дiагональ={this.diagonale2}; Колiр={this.color}";
        }

        public static implicit operator string(Romb romb)
        {
            return $"Ромб: сторона={romb.Side}; Перша дiагональ={romb.Diagonale1}; Друга дiагональ={romb.Diagonale2}; Колiр={romb.Color}";
        }

        public static implicit operator Romb(string s)
        {
            string[] parts = s.Split(';');
            double a = Convert.ToDouble(parts[0].Split('=')[1].Trim());
            double d1 = Convert.ToDouble(parts[1].Split('=')[1].Trim());
            string color = parts[3].Split('=')[1].Trim();
            return new Romb(a, d1, color);
        }

        public int Per(int side)
		{
			int per;
			if (side < 0)  Console.WriteLine("Не iснує");
			per = side * 4;
			return per;
		}

		public double Area(double diagonale)
		{
			return diagonale1 * diagonale2 / 2;
		}

		private bool Is_Square()
		{
            return Math.Round(diagonale1, 4) == Math.Round(diagonale2, 4);
        }
	}
}