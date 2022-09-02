using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ProjectLastVersion
{
    class Program
    {
        static void Main(string[] args)
        {



            int moveLimit = 0; //default
            int scoreLimit = 200; //score that should be reached


            var text = @"
 __   __      ___    ___       ____    ____        _______      ___      .___  ___.  _______ 
/_ | /_ |    |__ \  |__ \     |___ \  |___ \      /  _____|    /   \     |   \/   | |   ____|
 | |  | |       ) |    ) |      __) |   __) |    |  |  __     /  ^  \    |  \  /  | |  |__   
 | |  | |      / /    / /      |__ <   |__ <     |  | |_ |   /  /_\  \   |  |\/|  | |   __|  
 | |  | |     / /_   / /_      ___) |  ___) |    |  |__| |  /  _____  \  |  |  |  | |  |____ 
 |_|  |_|    |____| |____|    |____/  |____/      \______| /__/     \__\ |__|  |__| |_______|
                                                                                             
";


            Console.WriteLine(text);

            while (true)
            {

                Console.WriteLine("1-Easy");
                Console.WriteLine("2-Medium");
                Console.WriteLine("3-Hard\n");
                Console.WriteLine("Which mode you would like to play?");

                String input = Console.ReadLine();


                if (input == "1") //easy
                {
                    moveLimit = 20;
                    break;
                }
                else if (input == "2") //medium
                {
                    moveLimit = 15;
                    break;
                }
                else if (input == "3") //hard
                {
                    moveLimit = 10;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                    Console.WriteLine();
                }

            }

            Console.Clear(); //cleaning before printing the table
            Console.SetCursorPosition(13, 1);
            Console.WriteLine("11 22 33 GAME");

            //creating arrays
            int[] arr1 = new int[30];
            int[] arr2 = new int[30];
            int[] arr3 = new int[30];

            int score = 0;


            int RowOfArray1 = 1;
            int RowOfArray2 = 2;
            int RowOfArray3 = 3;

            int arr1YIndex = 4;
            int arr2YIndex = 5;
            int arr3YIndex = 6;

            Random random = new Random();


            //random number creating and placing them
            int eachNumberDetermination = 0;
            while (eachNumberDetermination < 30)
            {
                int number = random.Next(1, 4); // 1 or 2 or 3
                int whichIndex = random.Next(0, 30); //which column
                int whichArray = random.Next(1, 4); //which row

                if (whichArray == RowOfArray1) //for row 1
                {
                    if (arr1[whichIndex] == 0) //checking whether it is empty or not
                    {
                        arr1[whichIndex] = number;
                        eachNumberDetermination++;
                    }
                    else
                    {
                        continue;
                    }

                }

                else if (whichArray == RowOfArray2) //for row 2
                {
                    if (arr2[whichIndex] == 0)
                    {
                        arr2[whichIndex] = number;
                        eachNumberDetermination++;
                    }

                    else
                    {
                        continue;
                    }
                }

                else if (whichArray == RowOfArray3) //for row 3
                {
                    if (arr3[whichIndex] == 0)
                    {
                        arr3[whichIndex] = number;
                        eachNumberDetermination++;
                    }

                    else
                    {
                        continue;
                    }
                }


            }


            //printing the numbers in table

            Console.SetCursorPosition(4, 4); //row 1
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == 0)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(arr1[i]);
                }


            }

            Console.SetCursorPosition(4, 5); //row 2
            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr2[i] == 0)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(arr2[i]);
                }


            }



            Console.SetCursorPosition(4, 6); //row 3
            for (int i = 0; i < arr3.Length; i++)
            {
                if (arr3[i] == 0)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(arr3[i]);
                }

            }





            //printing the table

            Console.SetCursorPosition(3, 3);
            Console.WriteLine("+------------------------------+");

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(3, 3 + i + 1);
                Console.WriteLine("|");
                Console.SetCursorPosition(34, 3 + i + 1);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("+------------------------------+");




            //printing the current score and number of moves left

            Console.SetCursorPosition(50, 5);
            Console.WriteLine("Your score: " + score);
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("Number of moves left: " + moveLimit);




            Thread.Sleep(3000);

            int numberWillBeProduced = 1000;


            while (numberWillBeProduced != 0)
            {

                //checking matching numbers

                numberWillBeProduced = 0;

                for (int i = 0; i < arr1.Length - 1; i++)
                {
                    if (arr1[i] == arr1[i + 1] && arr1[i] != 0)
                    {
                        arr1[i] = 0;
                        arr1[i + 1] = 0;
                        numberWillBeProduced += 2;
                    }
                }

                for (int i = 0; i < arr2.Length - 1; i++)
                {
                    if (arr2[i] == arr2[i + 1] && arr2[i] != 0)
                    {
                        arr2[i] = 0;
                        arr2[i + 1] = 0;
                        numberWillBeProduced += 2;
                    }
                }

                for (int i = 0; i < arr3.Length - 1; i++)
                {
                    if (arr3[i] == arr3[i + 1] && arr3[i] != 0)
                    {
                        arr3[i] = 0;
                        arr3[i + 1] = 0;
                        numberWillBeProduced += 2;
                    }
                }


                score = score + ((numberWillBeProduced / 2) * 10);



                //creating new numbers instead of numbers were matched

                eachNumberDetermination = 0;
                while (eachNumberDetermination < numberWillBeProduced)
                {
                    int number = random.Next(1, 4);
                    int whichIndex = random.Next(0, 30);
                    int whichArray = random.Next(1, 4);

                    if (whichArray == RowOfArray1)
                    {
                        if (arr1[whichIndex] == 0)
                        {
                            arr1[whichIndex] = number;
                            eachNumberDetermination++;
                        }
                        else
                        {
                            continue;
                        }

                    }

                    else if (whichArray == RowOfArray2)
                    {
                        if (arr2[whichIndex] == 0)
                        {
                            arr2[whichIndex] = number;
                            eachNumberDetermination++;
                        }

                        else
                        {
                            continue;
                        }
                    }

                    else if (whichArray == RowOfArray3)
                    {
                        if (arr3[whichIndex] == 0)
                        {
                            arr3[whichIndex] = number;
                            eachNumberDetermination++;
                        }

                        else
                        {
                            continue;
                        }
                    }


                }


                //printing numbers of table again after the matching and re-creating

                Console.SetCursorPosition(4, 4);
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(arr1[i]);
                    }


                }

                Console.SetCursorPosition(4, 5);
                for (int i = 0; i < arr2.Length; i++)
                {
                    if (arr2[i] == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(arr2[i]);
                    }


                }


                Console.SetCursorPosition(4, 6);
                for (int i = 0; i < arr3.Length; i++)
                {
                    if (arr3[i] == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(arr3[i]);
                    }

                }


                //printing the current score and number of moves left
                Console.SetCursorPosition(50, 5);
                Console.WriteLine("Your score: " + score);
                Console.SetCursorPosition(50, 7);
                Console.WriteLine("Number of moves left: " + moveLimit);


                //checking user wins or not

                if (score >= scoreLimit)
                {
                    Console.SetCursorPosition(50, 9);
                    Console.WriteLine("Congratulations, you won!");
                    Thread.Sleep(5000);
                    System.Environment.Exit(0);
                }

                Thread.Sleep(3000);



            }


            int cursorx = 18, cursory = 5;
            ConsoleKeyInfo cki;


            while (true)
            {

                //moving the cursor with arrow keys and moving the numbers with WASD

                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.RightArrow && cursorx < 33)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        cursorx++;
                    }
                    if (cki.Key == ConsoleKey.LeftArrow && cursorx > 4)
                    {
                        Console.SetCursorPosition(cursorx, cursory);

                        cursorx--;
                    }
                    if (cki.Key == ConsoleKey.UpArrow && cursory > 4)
                    {
                        Console.SetCursorPosition(cursorx, cursory);

                        cursory--;
                    }
                    if (cki.Key == ConsoleKey.DownArrow && cursory < 6)
                    {
                        Console.SetCursorPosition(cursorx, cursory);

                        cursory++;
                    }


                    //moving right

                    if (cki.Key == ConsoleKey.D)
                    {
                        if (cursory == arr1YIndex) //moving number which is in first row
                        {

                            for (int i = cursorx - 4 + 1; i < arr1.Length; i++)
                            {
                                if (arr1[i] != 0)
                                {
                                    int temp = arr1[cursorx - 4];

                                    arr1[cursorx - 4] = 0;
                                    arr1[i - 1] = temp;
                                    moveLimit = moveLimit - 1;

                                    break;

                                }

                            }


                        }



                        if (cursory == arr2YIndex) //moving number which is in second row
                        {
                            for (int i = cursorx - 4 + 1; i < arr2.Length; i++)
                            {
                                if (arr2[i] != 0)
                                {
                                    int temp = arr2[cursorx - 4];

                                    arr2[cursorx - 4] = 0;
                                    arr2[i - 1] = temp;
                                    moveLimit = moveLimit - 1;



                                    break;
                                }
                            }




                        }


                        if (cursory == arr3YIndex) //moving number which is in third row
                        {
                            for (int i = cursorx - 4 + 1; i < arr3.Length; i++)
                            {
                                if (arr3[i] != 0)
                                {
                                    int temp = arr3[cursorx - 4];

                                    arr3[cursorx - 4] = 0;
                                    arr3[i - 1] = temp;
                                    moveLimit = moveLimit - 1;


                                    break;
                                }
                            }



                        }

                        numberWillBeProduced = 1000;

                        //matching and determining new number of new numbers
                        while (numberWillBeProduced != 0)
                        {


                            numberWillBeProduced = 0;

                            for (int i = 0; i < arr1.Length - 1; i++)
                            {
                                if (arr1[i] == arr1[i + 1] && arr1[i] != 0)
                                {
                                    arr1[i] = 0;
                                    arr1[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }

                            for (int i = 0; i < arr2.Length - 1; i++)
                            {
                                if (arr2[i] == arr2[i + 1] && arr2[i] != 0)
                                {
                                    arr2[i] = 0;
                                    arr2[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }

                            for (int i = 0; i < arr3.Length - 1; i++)
                            {
                                if (arr3[i] == arr3[i + 1] && arr3[i] != 0)
                                {
                                    arr3[i] = 0;
                                    arr3[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }


                            score = score + ((numberWillBeProduced / 2) * 10);

                            //creating new numbers and placing randomly
                            eachNumberDetermination = 0;
                            while (eachNumberDetermination < numberWillBeProduced)
                            {
                                int number = random.Next(1, 4);
                                int whichIndex = random.Next(0, 30);
                                int whichArray = random.Next(1, 4);

                                if (whichArray == RowOfArray1)
                                {
                                    if (arr1[whichIndex] == 0)
                                    {
                                        arr1[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }

                                else if (whichArray == RowOfArray2)
                                {
                                    if (arr2[whichIndex] == 0)
                                    {
                                        arr2[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }

                                    else
                                    {
                                        continue;
                                    }
                                }

                                else if (whichArray == RowOfArray3)
                                {
                                    if (arr3[whichIndex] == 0)
                                    {
                                        arr3[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }

                                    else
                                    {
                                        continue;
                                    }
                                }


                            }


                            //printing numbers in table

                            Console.SetCursorPosition(4, 4);
                            for (int i = 0; i < arr1.Length; i++)
                            {
                                if (arr1[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr1[i]);
                                }


                            }

                            Console.SetCursorPosition(4, 5);
                            for (int i = 0; i < arr2.Length; i++)
                            {
                                if (arr2[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr2[i]);
                                }


                            }



                            Console.SetCursorPosition(4, 6);
                            for (int i = 0; i < arr3.Length; i++)
                            {
                                if (arr3[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr3[i]);
                                }

                            }

                            //printing the current score and number of moves left
                            Console.SetCursorPosition(50, 5);
                            Console.WriteLine("Your score: " + score);
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine("                                    "); //for clearing the previous printings in this line
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine("Number of moves left: " + moveLimit);

                            if (score >= scoreLimit) //checking winning
                            {
                                Console.SetCursorPosition(50, 9);
                                Console.WriteLine("Congratulations, you won!");
                                Thread.Sleep(5000);
                                System.Environment.Exit(0);
                            }

                            Thread.Sleep(1000);


                        }

                    }



                    //for left movement
                    if (cki.Key == ConsoleKey.A)
                    {
                        if (cursory == arr1YIndex) //for row 1
                        {

                            for (int i = cursorx - 4 - 1; i >= 0; i--)
                            {
                                if (arr1[i] != 0)
                                {
                                    int temp = arr1[cursorx - 4];
                                    arr1[cursorx - 4] = 0;
                                    arr1[i + 1] = temp;
                                    moveLimit = moveLimit - 1;

                                    break;
                                }
                            }



                        }

                        if (cursory == arr2YIndex) //for row 2
                        {
                            for (int i = cursorx - 4 - 1; i >= 0; i--)
                            {
                                if (arr2[i] != 0)
                                {
                                    int temp = arr2[cursorx - 4];
                                    arr2[cursorx - 4] = 0;
                                    arr2[i + 1] = temp;
                                    moveLimit = moveLimit - 1;

                                    break;
                                }
                            }


                        }


                        if (cursory == arr3YIndex) //for row 3
                        {
                            for (int i = cursorx - 4 - 1; i >= 0; i--)
                            {
                                if (arr3[i] != 0)
                                {
                                    int temp = arr3[cursorx - 4];
                                    arr3[cursorx - 4] = 0;
                                    arr3[i + 1] = temp;
                                    moveLimit = moveLimit - 1;

                                    break;
                                }
                            }

                        }

                        numberWillBeProduced = 1000;

                        //determining the number will be produced after the matching
                        while (numberWillBeProduced != 0)
                        {


                            numberWillBeProduced = 0;

                            for (int i = 0; i < arr1.Length - 1; i++)
                            {
                                if (arr1[i] == arr1[i + 1] && arr1[i] != 0)
                                {
                                    arr1[i] = 0;
                                    arr1[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }

                            for (int i = 0; i < arr2.Length - 1; i++)
                            {
                                if (arr2[i] == arr2[i + 1] && arr2[i] != 0)
                                {
                                    arr2[i] = 0;
                                    arr2[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }

                            for (int i = 0; i < arr3.Length - 1; i++)
                            {
                                if (arr3[i] == arr3[i + 1] && arr3[i] != 0)
                                {
                                    arr3[i] = 0;
                                    arr3[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }


                            score = score + ((numberWillBeProduced / 2) * 10);

                            //determining and placing new numbers
                            eachNumberDetermination = 0;
                            while (eachNumberDetermination < numberWillBeProduced)
                            {
                                int number = random.Next(1, 4);
                                int whichIndex = random.Next(0, 30);
                                int whichArray = random.Next(1, 4);

                                if (whichArray == RowOfArray1)
                                {
                                    if (arr1[whichIndex] == 0)
                                    {
                                        arr1[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }

                                else if (whichArray == RowOfArray2)
                                {
                                    if (arr2[whichIndex] == 0)
                                    {
                                        arr2[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }

                                    else
                                    {
                                        continue;
                                    }
                                }

                                else if (whichArray == RowOfArray3)
                                {
                                    if (arr3[whichIndex] == 0)
                                    {
                                        arr3[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }

                                    else
                                    {
                                        continue;
                                    }
                                }


                            }


                            //printing numbers in table

                            Console.SetCursorPosition(4, 4);
                            for (int i = 0; i < arr1.Length; i++)
                            {
                                if (arr1[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr1[i]);
                                }


                            }

                            Console.SetCursorPosition(4, 5);
                            for (int i = 0; i < arr2.Length; i++)
                            {
                                if (arr2[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr2[i]);
                                }


                            }



                            Console.SetCursorPosition(4, 6);
                            for (int i = 0; i < arr3.Length; i++)
                            {
                                if (arr3[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr3[i]);
                                }

                            }


                            //printing score and moves left
                            Console.SetCursorPosition(50, 5);
                            Console.WriteLine("Your score: " + score);
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine("                                    ");
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine("Number of moves left: " + moveLimit);

                            //checking winning
                            if (score >= scoreLimit)
                            {
                                Console.SetCursorPosition(50, 9);
                                Console.WriteLine("Congratulations, you won!");
                                Thread.Sleep(5000);
                                System.Environment.Exit(0);
                            }
                            Thread.Sleep(1000);


                        }

                    }





                    //for up movement
                    if (cki.Key == ConsoleKey.W)
                    {

                        if (cursory == arr2YIndex) //row 2
                        {
                            if (arr1[cursorx - 4] == 0)
                            {
                                arr1[cursorx - 4] = arr2[cursorx - 4];
                                arr2[cursorx - 4] = 0;
                                moveLimit = moveLimit - 1;
                            }



                        }


                        if (cursory == arr3YIndex) //row3
                        {

                            if (arr2[cursorx - 4] == 0)
                            {
                                arr2[cursorx - 4] = arr3[cursorx - 4];
                                arr3[cursorx - 4] = 0;
                                moveLimit = moveLimit - 1;
                            }


                        }


                        numberWillBeProduced = 1000;

                        //determining number will be produced
                        while (numberWillBeProduced != 0)
                        {


                            numberWillBeProduced = 0;

                            for (int i = 0; i < arr1.Length - 1; i++)
                            {
                                if (arr1[i] == arr1[i + 1] && arr1[i] != 0)
                                {
                                    arr1[i] = 0;
                                    arr1[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }

                            for (int i = 0; i < arr2.Length - 1; i++)
                            {
                                if (arr2[i] == arr2[i + 1] && arr2[i] != 0)
                                {
                                    arr2[i] = 0;
                                    arr2[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }

                            for (int i = 0; i < arr3.Length - 1; i++)
                            {
                                if (arr3[i] == arr3[i + 1] && arr3[i] != 0)
                                {
                                    arr3[i] = 0;
                                    arr3[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }


                            score = score + ((numberWillBeProduced / 2) * 10);

                            //creating and placing new numbers after matching
                            eachNumberDetermination = 0;
                            while (eachNumberDetermination < numberWillBeProduced)
                            {
                                int number = random.Next(1, 4);
                                int whichIndex = random.Next(0, 30);
                                int whichArray = random.Next(1, 4);

                                if (whichArray == RowOfArray1)
                                {
                                    if (arr1[whichIndex] == 0)
                                    {
                                        arr1[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }

                                else if (whichArray == RowOfArray2)
                                {
                                    if (arr2[whichIndex] == 0)
                                    {
                                        arr2[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }

                                    else
                                    {
                                        continue;
                                    }
                                }

                                else if (whichArray == RowOfArray3)
                                {
                                    if (arr3[whichIndex] == 0)
                                    {
                                        arr3[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }

                                    else
                                    {
                                        continue;
                                    }
                                }


                            }


                            //printing numbers in table again
                            Console.SetCursorPosition(4, 4);
                            for (int i = 0; i < arr1.Length; i++)
                            {
                                if (arr1[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr1[i]);
                                }


                            }

                            Console.SetCursorPosition(4, 5);
                            for (int i = 0; i < arr2.Length; i++)
                            {
                                if (arr2[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr2[i]);
                                }


                            }



                            Console.SetCursorPosition(4, 6);
                            for (int i = 0; i < arr3.Length; i++)
                            {
                                if (arr3[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr3[i]);
                                }

                            }


                            Console.SetCursorPosition(50, 5);
                            Console.WriteLine("Your score: " + score);
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine("                                    ");
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine("Number of moves left: " + moveLimit);

                            if (score >= scoreLimit)
                            {
                                Console.SetCursorPosition(50, 9);
                                Console.WriteLine("Congratulations, you won!");
                                Thread.Sleep(5000);
                                System.Environment.Exit(0);
                            }
                            Thread.Sleep(1000);


                        }


                    }


                    //down movement
                    if (cki.Key == ConsoleKey.S)
                    {

                        if (cursory == arr1YIndex) // row 1
                        {
                            if (arr2[cursorx - 4] == 0)
                            {
                                arr2[cursorx - 4] = arr1[cursorx - 4];
                                arr1[cursorx - 4] = 0;
                                moveLimit = moveLimit - 1;
                            }


                        }





                        if (cursory == arr2YIndex) //row 2
                        {
                            if (arr3[cursorx - 4] == 0)
                            {
                                arr3[cursorx - 4] = arr2[cursorx - 4];
                                arr2[cursorx - 4] = 0;
                                moveLimit = moveLimit - 1;
                            }


                        }


                        numberWillBeProduced = 1000;

                        //determining number will be produced according to the matching

                        while (numberWillBeProduced != 0)
                        {


                            numberWillBeProduced = 0;

                            for (int i = 0; i < arr1.Length - 1; i++)
                            {
                                if (arr1[i] == arr1[i + 1] && arr1[i] != 0)
                                {
                                    arr1[i] = 0;
                                    arr1[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }

                            for (int i = 0; i < arr2.Length - 1; i++)
                            {
                                if (arr2[i] == arr2[i + 1] && arr2[i] != 0)
                                {
                                    arr2[i] = 0;
                                    arr2[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }

                            for (int i = 0; i < arr3.Length - 1; i++)
                            {
                                if (arr3[i] == arr3[i + 1] && arr3[i] != 0)
                                {
                                    arr3[i] = 0;
                                    arr3[i + 1] = 0;
                                    numberWillBeProduced += 2;
                                }
                            }


                            score = score + ((numberWillBeProduced / 2) * 10);

                            //creating and placing new numbers
                            eachNumberDetermination = 0;
                            while (eachNumberDetermination < numberWillBeProduced)
                            {
                                int number = random.Next(1, 4);
                                int whichIndex = random.Next(0, 30);
                                int whichArray = random.Next(1, 4);

                                if (whichArray == RowOfArray1)
                                {
                                    if (arr1[whichIndex] == 0)
                                    {
                                        arr1[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }

                                else if (whichArray == RowOfArray2)
                                {
                                    if (arr2[whichIndex] == 0)
                                    {
                                        arr2[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }

                                    else
                                    {
                                        continue;
                                    }
                                }

                                else if (whichArray == RowOfArray3)
                                {
                                    if (arr3[whichIndex] == 0)
                                    {
                                        arr3[whichIndex] = number;
                                        eachNumberDetermination++;
                                    }

                                    else
                                    {
                                        continue;
                                    }
                                }


                            }


                            //printing numbers in table again
                            Console.SetCursorPosition(4, 4);
                            for (int i = 0; i < arr1.Length; i++)
                            {
                                if (arr1[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr1[i]);
                                }


                            }

                            Console.SetCursorPosition(4, 5);
                            for (int i = 0; i < arr2.Length; i++)
                            {
                                if (arr2[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr2[i]);
                                }


                            }



                            Console.SetCursorPosition(4, 6);
                            for (int i = 0; i < arr3.Length; i++)
                            {
                                if (arr3[i] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    Console.Write(arr3[i]);
                                }

                            }


                            Console.SetCursorPosition(50, 5);
                            Console.WriteLine("Your score: " + score);
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine("                                    ");
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine("Number of moves left: " + moveLimit);


                            if (score >= scoreLimit)
                            {
                                Console.SetCursorPosition(50, 9);
                                Console.WriteLine("Congratulations, you won!");
                                Thread.Sleep(5000);
                                System.Environment.Exit(0);
                            }
                            Thread.Sleep(1000);



                        }


                    }


                }


                Console.SetCursorPosition(cursorx, cursory);    // refresh X (current position)

                //checking moves left and score
                if (moveLimit <= 0 && score < scoreLimit)
                {
                    Console.SetCursorPosition(50, 9);
                    Console.WriteLine("Game Over!");
                    Thread.Sleep(5000);
                    break;
                }

            }



        }
    }
}
