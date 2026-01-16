class Program
{
    static void Main(string[] args)
    {
        int[,] puzzle = new int[9, 9]
        {
            {5,3,0, 0,7,0, 0,0,0 },
            {6,0,0, 1,9,5, 0,0,0 },
            {0,9,8, 0,0,0, 0,6,0 },

            {8,0,0, 0,6,0, 0,0,3 },
            {4,0,0, 8,0,3, 0,0,1 },
            {7,0,0, 0,2,0, 0,0,6 },

            {0,6,0, 0,0,0, 2,8,0 },
            {0,0,0, 4,1,9, 0,0,5 },
            {0,0,0, 0,8,0, 0,7,9 }
        };

        var s = new Sodoku(puzzle);

        if (s.solve())
        {
            Console.WriteLine("Van megoldás: ");
            s.Print();
        }
        else
        {
            Console.WriteLine("Erre a mátrixra nincs megoldás! :(");
        }

        Console.ReadKey();
    }
}



public class Sodoku
{
    int[,] tabla;
    const int meret = 9;
    const int ures = 0;

    public Sodoku(int[,] board)
    {
        tabla = new int[meret, meret];
        Array.Copy(board, tabla, board.Length);
    }

    public bool FindEmpty(out int row, out int col)
    {
        for(row = 0; row < meret; row++)
        {
            for(col = 0; col < meret; col++)
            {
                if(tabla[row,col] == ures)
                {
                    return true;
                }
                
            }
        }
        row = -1;
        col = -1;
        return false;
    }

    public bool IsSafe(int row, int col, int num)
    {   
        //sor
        for (int i = 0; i < meret; i++)
        {
            if (tabla[row, i] == num) return false;
        }

        //oszlop
        for (int i = 0; i < meret; i++)
        {
            if (tabla[i, col] == num) return false;
        }

        return true;
    }

    public bool solve()
    {
        if(!FindEmpty(out int row, out int col))
        {
            return true;
        }

        for(int num = 1; num <=9; num++)
        {
            if (IsSafe(row, col, num))
            {
                tabla[row, col] = num;

                if (solve())
                {
                    return true;
                }

                tabla[row, col] = ures;  //visszalépés
            }
        }

        return false;
    }

    public void Print()
    {
        for(int i =0; i < meret; i++)
        {
            for(int j = 0; j < meret; j++)
            {
                Console.Write(tabla[i, j] + " ");
               
            }
            Console.WriteLine();
        }
    }
}
