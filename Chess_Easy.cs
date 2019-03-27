using System;

namespace ChessEasy
{
    public class Position
    {
        public int posX
        {
            get;
        }
        public int posY
        {
            get;
        }
        public Position(char x, char y)
        {
            posX = x - 'a';
            posY = y - '1';
        }
    };

    class Program
    {
        public static void Main(string[] args)
        {
            char chessman = Console.ReadLine().ToCharArray()[0];

            string positions = Console.ReadLine();
            Position start = new Position(positions[0], positions[1]);
            Position finish = new Position(positions[3], positions[4]);

            int result = 0;
            switch (chessman)
            {
                case 'R':
                    result = RookMove(start, finish);
                    break;
                case 'B':
                    result = BishopMove(start, finish);
                    break;
                case 'Q':
                    result = QueenMove(start, finish);
                    break;
                case 'N':
                    result = KnightMove(start, finish);
                    break;
            }

            Console.WriteLine(result);
        }
        static int RookMove(Position start, Position finish)
        {
            if (start.posX == finish.posX)
            {
                return 0;
            }

            if (start.posX == finish.posX || start.posY == finish.posY)
            {
                return 1;
            }

            return 2;
        }

        static int BishopMove(Position start, Position finish)
        {
            if (start.posX == finish.posX)
            {
                return 0;
            }

            if ((start.posX + start.posY) % 2 - (finish.posX + finish.posY) % 2 != 0)
            {
                return -1;
            }

            if (start.posX - start.posY - finish.posX + finish.posY == 0 ||
                start.posX - start.posY + finish.posY - finish.posX == 0)
            {
                return 1;
            }

            return 2;
        }

        static int QueenMove(Position start, Position finish)
        {
            if (start.posX == finish.posX)
            {
                return 0;
            }

            if (start.posX == finish.posX || 
                start.posY == finish.posY ||
                start.posX - start.posY - finish.posX + finish.posY == 0 ||
                start.posX - start.posY + finish.posY - finish.posX == 0)
            {
                return 1;
            }

            return 2;
        }

        static int KnightMove(Position start, Position finish)
        {
            return 0;
        }
    }
}
