using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TicTacToe
{
    public class Game
    {
        private char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char curPlayer;
        private Random random = new Random();

        public Game()
        {
            
            curPlayer = random.Next(2) == 0 ? 'X' : 'O';
            Console.WriteLine($"Зараз ходить гравець: {(curPlayer == 'X' ? "Ви" : "Комп'ютер")}");
        }

        public void Play()
        {
            int turns = 0;
            char winner = ' ';

            while (winner == ' ' && turns < 9)
            {
                DisplayBoard();

                if (curPlayer == 'X')
                {
                    GetPlayerMove();
                }
                else
                {
                    GetComputerMove();
                }

                turns++;
                winner = CheckWin();
                SwitchPlayer();
            }

            DisplayBoard();

            if (winner != ' ')
            {
                Console.WriteLine($"Переміг гравець: {(winner == 'X' ? "Ви" : "Комп'ютер")}!");
            }
            else
            {
                Console.WriteLine("Нічия!");
            }
        }

        private void DisplayBoard()
        {
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }

        private void GetPlayerMove()
        {
            int choice;
            bool validMove = false;

            while (!validMove)
            {
                Console.Write("Ваш хід (введіть номер клітинки): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    board[choice - 1] = 'X';
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Некоректний хід. Спробуйте ще раз.");
                }
            }
        }

        private void GetComputerMove()
        {
            
            for (int i = 0; i < 9; i++)
            {
                if (board[i] != 'X' && board[i] != 'O')
                {
                    board[i] = 'O';
                    Console.WriteLine("Комп'ютер зробив хід.");
                    return;
                }
            }
        }

        private char CheckWin()
        {
            
            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2])
                {
                    return board[i * 3];
                }
            }

            
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
                {
                    return board[i];
                }
            }

            
            if (board[0] == board[4] && board[4] == board[8])
            {
                return board[0];
            }
            if (board[2] == board[4] && board[4] == board[6])
            {
                return board[2];
            }

            return ' '; 
        }

        private void SwitchPlayer()
        {
            curPlayer = (curPlayer == 'X') ? 'O' : 'X';
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
        }
    }
}