using System;


namespace TicTacToe
{
    public enum Cell { X, O, Empty} ; // new objects

    public class TicTacToeGame
    {
        private readonly Cell[,] _board = new Cell[3,3] ;
        private int _moves=9;

        public TicTacToeGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i, j] = Cell.Empty;
                }
            }
        }


        public void ShowBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("-------------");
                Console.Write("|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + PrintableCell(_board[i, j]) + " ") ;
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------");
        }

        public bool MakeMove(int x, int y , Cell symbol)
        {
            bool isEmptyCell = !IsFullCell(x,y);
            bool isLegalSymbol = (symbol == Cell.X || symbol == Cell.O);

            if (!isEmptyCell || !isLegalSymbol) return false;
            _board[x, y] = symbol;
            _moves--;
            return true;
            
        }


        private string PrintableCell(Cell cell)
        {
            string x="E"; // error = E
            switch (cell)
            {
                case Cell.Empty:
                       x = " ";
                        break;
                case Cell.O:
                        x = "O";
                        break;
                case Cell.X:
                        x =  "X";
                        break;
            }
            return x;
        }

        public bool IsFullBoard()
        {
            return _moves == 0;
        }

        public bool IsFullCell(int i, int j)
        {
            return _board[i, j] != Cell.Empty;
        }

        public bool CheckBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, i] == Cell.Empty) continue;

                var tempCell = _board[i, i];
                var tempIndex = i;
                var counter = 0;

                if (tempIndex == 1)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_board[j, j] == tempCell) counter++;
                        else break;
                    }
                    if (counter == 3) return true;
                    counter = 0;
                    for (int j = 2; j > 0; j--)
                    {
                        if (_board[j, j] == tempCell) counter++;
                        else break;
                    }
                    if (counter == 3) return true;
                    counter = 0;
                }

                for (int j = 0; j < 3; j++)
                {
                    if (_board[tempIndex, j] == tempCell) counter++;
                    else break;
                }

                if (counter == 3) return true;
                counter = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (_board[j, tempIndex] == tempCell) counter++;
                    else break;
                }

                if (counter == 3) return true;
            }

            return false;
        }
    }
    class Program
    {
        static void Main()
        {
            TicTacToeGame game1 = new TicTacToeGame();
            Cell playetMove = Cell.X;
            while (!game1.CheckBoard() && !game1.IsFullBoard())
            {
                int row, colum;

                Console.Clear();
                game1.ShowBoard();

                Console.WriteLine("Player {0} , your turn." , (playetMove == Cell.X) ? 1 : 2 );
                bool fullCell = false;

                do
                {
                    Console.Clear();
                    game1.ShowBoard();

                    Console.WriteLine("Player {0} , your turn.", (playetMove == Cell.X) ? 1 : 2);
                    if (fullCell) Console.WriteLine("This cell is Full!!! Choose other cell.");
                    Console.WriteLine("Enter your row move :");
                    var convertToInt = int.TryParse(Console.ReadLine(), out row);
                    while (!convertToInt || row > 3 || row < 1)
                    {
                        Console.WriteLine("You can enter just 1-3 number.");
                        convertToInt = int.TryParse(Console.ReadLine(), out row);
                    }
                    Console.WriteLine("Enter your colum move :");
                    convertToInt = int.TryParse(Console.ReadLine(), out colum);
                    while (!convertToInt || colum > 3 || colum < 0)
                    {
                        Console.WriteLine("You can enter just 1-3 number.");
                        convertToInt = int.TryParse(Console.ReadLine(), out colum);
                    }

                    fullCell = game1.IsFullCell(row - 1, colum - 1);

                } while (fullCell); 

                game1.MakeMove(row - 1, colum - 1, playetMove);

                playetMove = (playetMove == Cell.X) ? Cell.O : Cell.X;
            }

            if (game1.IsFullBoard())
            {
                Console.Clear();
                game1.ShowBoard();
                Console.WriteLine("Its a Tie !");
            }
            else
            {
                Console.Clear();
                game1.ShowBoard();
                Console.WriteLine("Player {0} , You Are the Winner !!!", (playetMove == Cell.X) ? 1 : 2);
            }
            
        }
    }
}
