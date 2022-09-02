using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Project3LastFinalVersion
{
    class Program
    {


        static void Main(string[] args)
        {

            startScreen(); //this is the function that is used for starting screen which contains name-text of game
            char[,] tableArray = generateBoard(8, 8); //generateBoard function is for printing table boundaries and creating default 2d-array
            print(tableArray); //it is used for printing the icons inside the array


            int cursorx = 7, cursory = 7; //default cursor locations
            ConsoleKeyInfo cki;
            ConsoleKeyInfo cki2;
            ConsoleKeyInfo cki3;

            bool turn = false; //this is the boolean value that helps us to determine turn(computer or human)
            int round = 1;//default round number

            while (true)
            {

                //win method returns 1 if the human wins, returns 2 if the computer wins, and returns 0 if nobody wins


                winCheck(tableArray);


                if (!turn) //turn--> false means that it is the turn of human
                {
                    Console.SetCursorPosition(20, 5);
                    Console.WriteLine("Turn: X");
                    Console.SetCursorPosition(20, 6);
                    Console.Write("Round: " + round);
                    round++;
                    turn = true; //turn is now for computer
                }

                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);

                    int[] arr = arrowCursorMovement(cki, cursorx, cursory); //What is done in this function is repeated in different parts of the program, so we have included it in a method.
                    //it returns an array, the first index in array contains cursorx info, and the seconds index contains cursory info
                    cursorx = arr[0];
                    cursory = arr[1];

                    Console.SetCursorPosition(cursorx, cursory);


                    if (cki.Key == ConsoleKey.Z) //if human press z then it means that we will keep this X piece to move.
                    {
                        int selectedNodeX = cursorx - 4; //selectedNodeX means y coordinate of the piece that we would like to move, column
                        int selectedNodeY = cursory - 4; //selectedNodeY means x coordinate of the piece that we would like to move, row

                        char selectedPlayerIcon = tableArray[selectedNodeY, selectedNodeX];

                        if (selectedPlayerIcon != 'X') //if it is point or O then the loop will continue from beginning. and then we will make another selection.
                        {
                            continue;

                        }


                        bool placed = false; //the bool value that helps us to determine whether human object placed or not successfully
                        bool successive = false;//this is for succesive jump

                        while (!placed)
                        {

                            if (Console.KeyAvailable)
                            {
                                cki2 = Console.ReadKey(true);


                                arr = arrowCursorMovement(cki2, cursorx, cursory); //the arrow function is used here again to allow cursor movement

                                cursorx = arr[0];
                                cursory = arr[1];


                                if (cki2.Key == ConsoleKey.X)
                                {



                                    if ((tableArray[cursory - 4, cursorx - 4] != 'X') && (tableArray[cursory - 4, cursorx - 4] != 'O')) // or "." if equals
                                    {


                                        //this if block is for jumping
                                        //there are some conditions to jump
                                        //For example, in order to jump up, above must be X or O.
                                        if (((selectedNodeX + 2 == cursorx - 4) && (selectedNodeY == cursory - 4) && ((tableArray[selectedNodeY, selectedNodeX + 1] == 'X') || (tableArray[selectedNodeY, selectedNodeX + 1] == 'O'))) || //right jump
                                           ((selectedNodeX - 2 == cursorx - 4) && (selectedNodeY == cursory - 4) && ((tableArray[selectedNodeY, selectedNodeX - 1] == 'X') || (tableArray[selectedNodeY, selectedNodeX - 1] == 'O'))) || //left jump
                                           ((selectedNodeX == cursorx - 4) && (selectedNodeY + 2 == cursory - 4) && ((tableArray[selectedNodeY + 1, selectedNodeX] == 'X') || (tableArray[selectedNodeY + 1, selectedNodeX] == 'O'))) || //down jump
                                           ((selectedNodeX == cursorx - 4) && (selectedNodeY - 2 == cursory - 4) && ((tableArray[selectedNodeY - 1, selectedNodeX] == 'X') || (tableArray[selectedNodeY - 1, selectedNodeX] == 'O')))) //up jump
                                        {

                                            tableArray[selectedNodeY, selectedNodeX] = '.'; //if condition satisfied then we need to make point that index in array
                                            int newYcoordinate = cursory - 4;
                                            int newXcoordinate = cursorx - 4;
                                            tableArray[newYcoordinate, newXcoordinate] = selectedPlayerIcon; //cursorx-4 and cursory-4 are new coordinates of our object.

                                            print(tableArray);//printing new table 

                                            //succesive jump operations

                                            Console.SetCursorPosition(0, 15);
                                            Console.WriteLine("Please press C if you done your move");

                                            cki3 = Console.ReadKey(true);

                                            Console.SetCursorPosition(0, 15);
                                            Console.WriteLine("                                     ");

                                            //If the expected key is c, then placed true will be done.


                                            if (cki3.Key == ConsoleKey.C)
                                            {
                                                placed = true;
                                            }

                                            //so the turn will be able to switch to the computer. If anything other than C is pressed then the loop will be started again with the new coordinates.

                                            else
                                            {
                                                selectedNodeX = cursorx - 4;
                                                selectedNodeY = cursory - 4;
                                                successive = true;
                                            }

                                        }


                                        //step operation for human
                                        else if ((((selectedNodeX + 1 == cursorx - 4) && (selectedNodeY == cursory - 4)) || //right step
                                            ((selectedNodeX - 1 == cursorx - 4) && (selectedNodeY == cursory - 4)) || //left step
                                            ((selectedNodeX == cursorx - 4) && (selectedNodeY + 1 == cursory - 4)) || //down step
                                            ((selectedNodeX == cursorx - 4) && (selectedNodeY - 1 == cursory - 4))) && !successive)//up step
                                        {


                                            tableArray[selectedNodeY, selectedNodeX] = '.';
                                            tableArray[cursory - 4, cursorx - 4] = selectedPlayerIcon;
                                            print(tableArray);
                                            placed = true;

                                        }

                                        if (placed) //if placed true then game can continue with computer
                                        {


                                            if (turn) //turn was made true above
                                            {
                                                Console.SetCursorPosition(20, 5);
                                                Console.WriteLine("Turn: O");
                                                Console.SetCursorPosition(20, 6);
                                                Console.Write("Round: " + round);
                                                Thread.Sleep(500);
                                                round++;
                                                turn = false;
                                            }

                                            //computer movements

                                            bool computerPlaced = false;

                                            while (computerPlaced == false)
                                            {

                                                computerPlaced = computerMove(tableArray);

                                            }
                                        }

                                    }
                                    else //if the place we want to put is not empty
                                    {
                                        break;
                                    }

                                }

                            }

                            Console.SetCursorPosition(cursorx, cursory);
                        }
                    }
                }
                Console.SetCursorPosition(cursorx, cursory);    // refresh current position
            }
        }


        public static void print(char[,] tableArray) //this function is for printing the elements in 2d array
        {
            Console.SetCursorPosition(4, 4);
            int row = 1;
            for (int i = 0; i <= tableArray.GetUpperBound(0); i++)
            {

                for (int j = 0; j <= tableArray.GetUpperBound(1); j++)
                {

                    Console.Write(tableArray[i, j]);
                }
                Console.WriteLine();
                Console.SetCursorPosition(4, 4 + row);
                row++;
            }
        }



        public static int[,] findO(char[,] tableArray) //this function is the function that gives the places of O symbols dynamically.
                                                       //it returns an array and this array(2d) contains the coordinates
        {
            int[,] arr = new int[9, 2];
            int index = 0;

            for (int i = 0; i <= tableArray.GetUpperBound(0); i++)
            {

                for (int j = 0; j <= tableArray.GetUpperBound(1); j++)
                {

                    if (tableArray[i, j] == 'O')
                    {
                        arr[index, 0] = i;
                        arr[index, 1] = j;
                        index++;

                    }


                }


            }
            return arr;
        }


        public static int[] arrowCursorMovement(ConsoleKeyInfo cki, int cursorx, int cursory) //this is the function for cursor movements, returns and int array which contains cursorx and cursory
        {
            int[] arr = new int[2];

            int rightBound = 11;
            int leftBound = 4;
            int upBound = 4;
            int downBound = 11;


            if (cki.Key == ConsoleKey.RightArrow && cursorx < rightBound)
            {
                cursorx++;
            }
            if (cki.Key == ConsoleKey.LeftArrow && cursorx > leftBound)
            {
                cursorx--;
            }
            if (cki.Key == ConsoleKey.UpArrow && cursory > upBound)
            {
                cursory--;
            }
            if (cki.Key == ConsoleKey.DownArrow && cursory < downBound)
            {
                cursory++;
            }

            arr[0] = cursorx;
            arr[1] = cursory;

            return arr;

        }


        public static void startScreen()
        {


            Console.WriteLine(" ██████╗███████╗███╗   ██╗ ██████╗      ██████╗██╗  ██╗███████╗ ██████╗██╗  ██╗███████╗██████╗ ███████╗");
            Console.WriteLine("██╔════╝██╔════╝████╗  ██║██╔════╝     ██╔════╝██║  ██║██╔════╝██╔════╝██║ ██╔╝██╔════╝██╔══██╗██╔════╝");
            Console.WriteLine("██║     █████╗  ██╔██╗ ██║██║  ███╗    ██║     ███████║█████╗  ██║     █████╔╝ █████╗  ██████╔╝███████╗");
            Console.WriteLine("██║     ██╔══╝  ██║╚██╗██║██║   ██║    ██║     ██╔══██║██╔══╝  ██║     ██╔═██╗ ██╔══╝  ██╔══██╗╚════██║");
            Console.WriteLine("╚██████╗███████╗██║ ╚████║╚██████╔╝    ╚██████╗██║  ██║███████╗╚██████╗██║  ██╗███████╗██║  ██║███████║");
            Console.WriteLine(" ╚═════╝╚══════╝╚═╝  ╚═══╝ ╚═════╝      ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚══════╝");
            Console.WriteLine();
            Console.WriteLine("Ahmet BAŞBUĞ     Ramazan FİDAN     Mert Emin TEZCAN");
            Console.WriteLine();
            Console.WriteLine("Press any key to start...");

            Console.ReadKey();
            Console.Clear();
        }

        public static void printTable(int row, int col) //prints the table according to the row and column number, it will be used below in generateBoard function
        {
            Console.SetCursorPosition(3, 3);
            Console.Write("+");
            for (int i = 0; i < col; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");

            for (int i = 0; i < row; i++)
            {
                Console.SetCursorPosition(3, 4 + i);
                Console.WriteLine("|");
                Console.SetCursorPosition(4 + col, 4 + i);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(3, row + 4);
            Console.Write("+");
            for (int i = 0; i < col; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");

        }


        public static char[,] generateBoard(int row, int col)
        {
            char[,] tableArray = new char[row, col];

            int placesOfO1 = 0;
            int placesOfO2 = 1;
            int placesOfO3 = 2;


            int placesOfX1 = col - 1;
            int placesOfX2 = col - 2;
            int placesOfX3 = col - 3;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (((i == placesOfO1 || i == placesOfO2 || i == placesOfO3) && ((j == placesOfO1 || j == placesOfO2 || j == placesOfO3))))
                    {

                        tableArray[i, j] = 'O';
                    }

                    if (((i == placesOfX3 || i == placesOfX2 || i == placesOfX1) && ((j == placesOfX3 || j == placesOfX2 || j == placesOfX1))))
                    {
                        tableArray[i, j] = 'X';
                    }

                    if ((tableArray[i, j] != 'X') && (tableArray[i, j] != 'O'))
                    {
                        tableArray[i, j] = '.';
                    }

                }
            }
            printTable(row, col);
            return tableArray;
        }




        public static bool downMove(int rowIndex, int columnIndex, char[,] tableArray)
        {
            bool computerPlaced = false;

            if (!(rowIndex + 1 >= 8)) //should not cross borders
            {

                if (tableArray[rowIndex + 1, columnIndex] == '.') //checking whether the place is empty
                {
                    tableArray[rowIndex, columnIndex] = '.'; //if empty updating array
                    tableArray[rowIndex + 1, columnIndex] = 'O';
                    computerPlaced = true;
                    print(tableArray);//printing new array

                }
            }
            return computerPlaced; //it returns bool variable which indicates whether the computer icon placed or not

        }


        public static bool downMoveJump(int rowIndex, int columnIndex, char[,] tableArray)
        {
            bool computerPlaced = false;

            if (!(rowIndex + 2 >= 8))
            {
                if ((tableArray[rowIndex + 2, columnIndex] == '.') && ((tableArray[rowIndex + 1, columnIndex] == 'X') || (tableArray[rowIndex + 1, columnIndex] == 'O')))
                {
                    tableArray[rowIndex, columnIndex] = '.';
                    tableArray[rowIndex + 2, columnIndex] = 'O';
                    computerPlaced = true;
                    print(tableArray);

                }
            }
            return computerPlaced;
        }




        public static bool rightMove(int rowIndex, int columnIndex, char[,] tableArray)
        {
            bool computerPlaced = false;
            if (!(columnIndex + 1 >= 8))
            {
                if (tableArray[rowIndex, columnIndex + 1] == '.')
                {
                    tableArray[rowIndex, columnIndex] = '.';
                    tableArray[rowIndex, columnIndex + 1] = 'O';
                    computerPlaced = true;
                    print(tableArray);
                }
            }
            return computerPlaced;

        }


        public static bool rightMoveJump(int rowIndex, int columnIndex, char[,] tableArray)
        {
            bool computerPlaced = false;

            if (!(columnIndex + 2 >= 8))
            {
                if ((tableArray[rowIndex, columnIndex + 2] == '.') && ((tableArray[rowIndex, columnIndex + 1] == 'X') || (tableArray[rowIndex, columnIndex + 1] == 'O')))
                {
                    tableArray[rowIndex, columnIndex] = '.';
                    tableArray[rowIndex, columnIndex + 2] = 'O';
                    computerPlaced = true;
                    print(tableArray);
                }
            }
            return computerPlaced;
        }


        public static bool leftMove(int rowIndex, int columnIndex, char[,] tableArray)
        {
            bool computerPlaced = false;
            if (!(columnIndex - 1 < 0))
            {

                if (tableArray[rowIndex, columnIndex - 1] == '.')
                {
                    tableArray[rowIndex, columnIndex] = '.';
                    tableArray[rowIndex, columnIndex - 1] = 'O';
                    computerPlaced = true;
                    print(tableArray);
                }

            }
            return computerPlaced;
        }

        public static bool leftMoveJump(int rowIndex, int columnIndex, char[,] tableArray)
        {
            bool computerPlaced = false;
            if (!(columnIndex - 2 < 0))
            {

                if ((tableArray[rowIndex, columnIndex - 2] == '.') && ((tableArray[rowIndex, columnIndex - 1] == 'X') || (tableArray[rowIndex, columnIndex - 1] == 'O')))
                {
                    tableArray[rowIndex, columnIndex] = '.';
                    tableArray[rowIndex, columnIndex - 2] = 'O';
                    computerPlaced = true;
                    print(tableArray);
                }

            }
            return computerPlaced;
        }

        public static bool upMove(int rowIndex, int columnIndex, char[,] tableArray)
        {

            bool computerPlaced = false;

            if (!(rowIndex - 1 < 0))
            {
                if (tableArray[rowIndex - 1, columnIndex] == '.')
                {
                    tableArray[rowIndex, columnIndex] = '.';
                    tableArray[rowIndex - 1, columnIndex] = 'O';
                    computerPlaced = true;
                    print(tableArray);

                }

            }
            return computerPlaced;
        }



        public static bool upMoveJump(int rowIndex, int columnIndex, char[,] tableArray)
        {
            bool computerPlaced = false;

            if (!(rowIndex - 2 < 0))
            {
                if ((tableArray[rowIndex - 2, columnIndex] == '.') && ((tableArray[rowIndex - 1, columnIndex] == 'X') || (tableArray[rowIndex - 1, columnIndex] == 'O')))
                {
                    tableArray[rowIndex, columnIndex] = '.';
                    tableArray[rowIndex - 2, columnIndex] = 'O';
                    computerPlaced = true;
                    print(tableArray);

                }

            }
            return computerPlaced;
        }



        public static void winCheck(char[,] tableArray)
        {
            bool winCheck = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tableArray[i, j] != 'X')
                    {
                        winCheck = false;
                        break;
                    }
                }
            }
            if (winCheck)
            {
                Console.SetCursorPosition(20, 7);
                Console.WriteLine("Player X won! Congratulations, press any key to exit");
                Console.ReadKey();
                Console.Clear();
                Environment.Exit(0);
            }
            for (int i = tableArray.GetUpperBound(0) - 3; i < tableArray.GetUpperBound(0); i++)
            {
                for (int j = tableArray.GetUpperBound(1) - 3; j < tableArray.GetUpperBound(1); j++)
                {
                    if (tableArray[i, j] != 'O')
                    {
                        winCheck = false;
                        break;
                    }
                }
            }
            if (winCheck)
            {
                Console.SetCursorPosition(20, 7);
                Console.WriteLine("Computer 'O' won! Good luck for the next time, press any key to exit");
                Console.ReadKey();
                Console.Clear();
                Environment.Exit(0);
            }
        }



        public static bool computerMove(char[,] tableArray)//this can be thought of as a gain function.
                                                           //The aim of the game is to move the computer's pieces to the right and down.

        {

            //priority order
            //1)right jump-down jump
            //2)right step-down step 
            //3)left step-up step
            //4)left jump-up jump
            //especially since the last two moves take us away from where we need to go, this is less of a priority.


            //ALGORITHM THAT IS USED HERE, works like followinbg

            //1)First, an o is selected randomly, and then a random move to the right or down is assigned for this.
            //2)Let's say that there is a random jump to the right, but the right side is full, then jumping down is checked.
            //3)If it fails again, the above process is repeated for all O icons in the table. 
            //4)If it fails again then a random O symbol is chosen and a step down or right step operation is attempted.
            //5)If it fails again, the same procedure is applied for the other O symbols in the table.
            //6)In case of failure, an attempt is made to step up or to the left for random O icon.
            //7)If the computer movement cannot be achieved again, then the other O's in the table are checked, and the left-up step is attempted.
            //8)Now the last resort would be to jump up or to the left.This is attempted on a randomly selected computer piece.
            //9)Again, in case of not being placed, jumping up or left is tried for other pieces, but this is often not necessary.




            bool computerPlaced = false;

            Random random = new Random();
            int[,] placesOfComputerIcons = findO(tableArray); //will give us places of O
            int randomO = random.Next(0, 9);
            int rowIndex = placesOfComputerIcons[randomO, 0];
            int columnIndex = placesOfComputerIcons[randomO, 1];

            bool successive = false;

            int randomDirectionForJumpAndStep = random.Next(1, 3); //if 1 ==> right, 2 ==> down

            if (randomDirectionForJumpAndStep == 1)//if randomly comes right jump movement
            {
                computerPlaced = rightMoveJump(rowIndex, columnIndex, tableArray);//trying jump right

                if (computerPlaced)//if it can be placed then checking double jump for computer
                {
                    columnIndex += 2;//since it is jumped right before we need to update its columnIndex number by 2.

                    Thread.Sleep(300);//to show double jump

                    successive = rightMoveJump(rowIndex, columnIndex, tableArray); //first trying right jump as succesive 

                    if (!successive) //if it cannot then trying down move jump as successive
                    {
                        Thread.Sleep(300);
                        successive = downMoveJump(rowIndex, columnIndex, tableArray);
                    }


                    //OR
                    //In the success jump, we could also randomly determine the right or down movement.
                    //However, we did not do this because it would both complicate the code and because it is not a very common combination(probility of right and down jump in same time).
                    //Still, we wanted to show it as a comment line.

                    //Apart from that, we did not include the left and up jump movement here because that would be unreasonable(as succesive jump).
                    //For example, jumping to the left again while jumping to the right would not change anything and would put it in a vicious circle.


                    /*int randomDownOrRightJump = random.Next(1, 2);

                    if (randomDownOrRightJump == 1)
                    {

                        successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                        if (!successive)
                        {
                            Thread.Sleep(200);
                            successive = downMoveJump(rowIndex, columnIndex, tableArray);
                        }

                    }
                    else if (randomDownOrRightJump == 2)
                    {
                        successive = downMoveJump(rowIndex, columnIndex, tableArray);

                        if (!successive)
                        {
                            Thread.Sleep(200);
                            successive = rightMoveJump(rowIndex, columnIndex, tableArray);
                        }

                    }*/

                }


                if (!computerPlaced) //Although there is a random jump to the right above, we still look to see if it can perform the operation of jumping down without going to other alternatives.
                                     //If we do not do this, then something like this may happen. For example, it came randomly right.
                                     //However, it is not possible to jump to the right, but the program, for example, performs step operation to the right, although it can be jumped down.
                {
                    computerPlaced = downMoveJump(rowIndex, columnIndex, tableArray);//trying down jump

                    if (computerPlaced)//if it is successfull, then checking succesive jump
                    {
                        rowIndex += 2;//we need to increment rowIndex number by 2 because we jumped down before

                        Thread.Sleep(300);
                        successive = rightMoveJump(rowIndex, columnIndex, tableArray); //checking right jump first

                        if (!successive)
                        {
                            Thread.Sleep(300);
                            successive = downMoveJump(rowIndex, columnIndex, tableArray); //checking down jump
                        }

                    }

                }
            }

            else if (randomDirectionForJumpAndStep == 2)//if it randomly jumps down at the top
            {
                computerPlaced = downMoveJump(rowIndex, columnIndex, tableArray);

                if (computerPlaced)
                {
                    rowIndex += 2;

                    Thread.Sleep(500);
                    successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                    if (!successive)
                    {
                        Thread.Sleep(500);
                        successive = downMoveJump(rowIndex, columnIndex, tableArray);
                    }


                }

                if (!computerPlaced)
                {
                    computerPlaced = rightMoveJump(rowIndex, columnIndex, tableArray);

                    if (computerPlaced)
                    {
                        columnIndex += 2;

                        Thread.Sleep(500);
                        successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                        if (!successive)
                        {
                            Thread.Sleep(500);
                            successive = downMoveJump(rowIndex, columnIndex, tableArray);
                        }


                    }
                }

            }

            if (!computerPlaced) //the above process is repeated for all O icons in the table. 
            {

                placesOfComputerIcons = findO(tableArray);

                for (int i = 0; i < placesOfComputerIcons.Length / 2; i++)
                {

                    rowIndex = placesOfComputerIcons[i, 0];
                    columnIndex = placesOfComputerIcons[i, 1];


                    randomDirectionForJumpAndStep = random.Next(1, 3); //if 1 ==> right, 2 ==> down

                    if (randomDirectionForJumpAndStep == 1)//right jump
                    {

                        computerPlaced = rightMoveJump(rowIndex, columnIndex, tableArray);


                        if (computerPlaced)
                        {
                            columnIndex += 2;

                            Thread.Sleep(500);
                            successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                            if (!successive)
                            {
                                Thread.Sleep(500);
                                successive = downMoveJump(rowIndex, columnIndex, tableArray);
                            }


                        }




                        if (!computerPlaced) //down jump
                        {
                            computerPlaced = downMoveJump(rowIndex, columnIndex, tableArray);


                            if (computerPlaced)
                            {
                                rowIndex += 2;
                                Thread.Sleep(500);
                                successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                                if (!successive)
                                {
                                    Thread.Sleep(500);
                                    successive = downMoveJump(rowIndex, columnIndex, tableArray);
                                }


                            }

                            if (computerPlaced)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }



                    }

                    else if (randomDirectionForJumpAndStep == 2) //down jump
                    {


                        computerPlaced = downMoveJump(rowIndex, columnIndex, tableArray);



                        if (computerPlaced)
                        {
                            rowIndex += 2;

                            Thread.Sleep(500);
                            successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                            if (!successive)
                            {
                                Thread.Sleep(500);
                                successive = downMoveJump(rowIndex, columnIndex, tableArray);
                            }


                        }


                        if (!computerPlaced) //right jump
                        {
                            computerPlaced = rightMoveJump(rowIndex, columnIndex, tableArray);


                            if (computerPlaced)
                            {
                                columnIndex += 2;
                                Thread.Sleep(500);
                                successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                                if (!successive)
                                {
                                    Thread.Sleep(500);
                                    successive = downMoveJump(rowIndex, columnIndex, tableArray);
                                }


                            }

                            if (computerPlaced)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }

                    }


                }

            }

            if (!computerPlaced)//If above fails then a random O symbol is chosen and a step down or right step operation is attempted.
            {

                placesOfComputerIcons = findO(tableArray);

                randomO = random.Next(0, 9);

                rowIndex = placesOfComputerIcons[randomO, 0];
                columnIndex = placesOfComputerIcons[randomO, 1];


                randomDirectionForJumpAndStep = random.Next(1, 3);

                if (randomDirectionForJumpAndStep == 1)
                {

                    computerPlaced = rightMove(rowIndex, columnIndex, tableArray);

                    if (!computerPlaced)
                    {
                        computerPlaced = downMove(rowIndex, columnIndex, tableArray);
                    }


                }
                else if (randomDirectionForJumpAndStep == 2)
                {
                    computerPlaced = downMove(rowIndex, columnIndex, tableArray);

                    if (!computerPlaced)
                    {
                        computerPlaced = rightMove(rowIndex, columnIndex, tableArray);
                    }

                }

            }

            if (!computerPlaced) //If above fails again, the same procedure is applied for the other O symbols in the table.
            {

                placesOfComputerIcons = findO(tableArray);

                for (int i = 0; i < placesOfComputerIcons.Length / 2; i++)
                {

                    rowIndex = placesOfComputerIcons[i, 0];
                    columnIndex = placesOfComputerIcons[i, 1];


                    randomDirectionForJumpAndStep = random.Next(1, 3); //if 1 ==> right, 2 ==> down

                    if (randomDirectionForJumpAndStep == 1)//right step
                    {

                        computerPlaced = rightMove(rowIndex, columnIndex, tableArray);

                        if (!computerPlaced) //down step
                        {
                            computerPlaced = downMove(rowIndex, columnIndex, tableArray);
                            if (computerPlaced)//if computer placed after down move, in order not to run the loop for nothing, if the placing is successful, we break the loop.
                            {
                                break;
                            }
                        }
                        else//if computer placed after right move, in order not to run the loop for nothing, if the placing is successful, we break the loop.
                        {
                            break;
                        }




                    }
                    else if (randomDirectionForJumpAndStep == 2) //down step
                    {


                        computerPlaced = downMove(rowIndex, columnIndex, tableArray);

                        if (!computerPlaced) //down
                        {
                            computerPlaced = rightMove(rowIndex, columnIndex, tableArray);
                            if (computerPlaced)//if computer placed after right move, in order not to run the loop for nothing, if the placing is successful, we break the loop.
                            {
                                break;
                            }
                        }
                        else //if computer placed after down move, in order not to run the loop for nothing, if the placing is successful, we break the loop.
                        {
                            break;
                        }

                    }


                }

            }



            if (!computerPlaced) //In case of failure, an attempt is made to step up or to the left for random O icon
            {

                placesOfComputerIcons = findO(tableArray);

                randomO = random.Next(0, 9);

                rowIndex = placesOfComputerIcons[randomO, 0];
                columnIndex = placesOfComputerIcons[randomO, 1];


                randomDirectionForJumpAndStep = random.Next(1, 3);

                if (randomDirectionForJumpAndStep == 1) //left step
                {

                    computerPlaced = leftMove(rowIndex, columnIndex, tableArray);

                    if (!computerPlaced)
                    {
                        computerPlaced = upMove(rowIndex, columnIndex, tableArray);
                    }


                }
                else if (randomDirectionForJumpAndStep == 2) //up step
                {
                    computerPlaced = upMove(rowIndex, columnIndex, tableArray);

                    if (!computerPlaced)
                    {
                        computerPlaced = leftMove(rowIndex, columnIndex, tableArray);
                    }

                }

            }

            if (!computerPlaced)//If the computer movement cannot be achieved again, then the other O's in the table are checked, and the left-up step is attempted.
            {

                placesOfComputerIcons = findO(tableArray);

                for (int i = 0; i < placesOfComputerIcons.Length / 2; i++)
                {

                    rowIndex = placesOfComputerIcons[i, 0];
                    columnIndex = placesOfComputerIcons[i, 1];


                    randomDirectionForJumpAndStep = random.Next(1, 3); //if 1 ==> left, 2 ==> up

                    if (randomDirectionForJumpAndStep == 1)//left step
                    {

                        computerPlaced = leftMove(rowIndex, columnIndex, tableArray);

                        if (!computerPlaced) //up step
                        {
                            computerPlaced = upMove(rowIndex, columnIndex, tableArray);
                            if (computerPlaced)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }



                    }
                    else if (randomDirectionForJumpAndStep == 2) //up step
                    {


                        computerPlaced = upMove(rowIndex, columnIndex, tableArray);

                        if (!computerPlaced) //left step
                        {
                            computerPlaced = leftMove(rowIndex, columnIndex, tableArray);
                            if (computerPlaced)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }

                    }


                }

                if (!computerPlaced)//Now the last resort would be to jump up or to the left.This is attempted on a randomly selected computer piece.
                {

                    placesOfComputerIcons = findO(tableArray);

                    randomO = random.Next(0, 9);

                    rowIndex = placesOfComputerIcons[randomO, 0];
                    columnIndex = placesOfComputerIcons[randomO, 1];


                    randomDirectionForJumpAndStep = random.Next(1, 3);

                    if (randomDirectionForJumpAndStep == 1) //left jump
                    {

                        computerPlaced = leftMoveJump(rowIndex, columnIndex, tableArray);


                        /*                            if (computerPlaced)
                                                    {
                                                        columnIndex -= 2;

                                                        Thread.Sleep(200);
                                                        successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                                                        if (!successive)
                                                        {
                                                            Thread.Sleep(200);
                                                            successive = downMoveJump(rowIndex, columnIndex, tableArray);
                                                        }


                                                    }*/


                        if (!computerPlaced)//up jump
                        {
                            computerPlaced = upMoveJump(rowIndex, columnIndex, tableArray);

                            /*                                if (computerPlaced)
                                                            {
                                                                rowIndex -= 2;

                                                                Thread.Sleep(200);
                                                                successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                                                                if (!successive)
                                                                {
                                                                    Thread.Sleep(200);
                                                                    successive = downMoveJump(rowIndex, columnIndex, tableArray);
                                                                }


                                                            }*/
                        }


                    }
                    else if (randomDirectionForJumpAndStep == 2) //up jump
                    {
                        computerPlaced = upMoveJump(rowIndex, columnIndex, tableArray);

                        /*  if (computerPlaced)
                            {
                                rowIndex -= 2;

                                Thread.Sleep(200);
                                successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                                if (!successive)
                                {
                                    Thread.Sleep(200);
                                    successive = downMoveJump(rowIndex, columnIndex, tableArray);
                                }


                            }*/



                        if (!computerPlaced)//left jump
                        {
                            computerPlaced = leftMoveJump(rowIndex, columnIndex, tableArray);

                            /*                                if (computerPlaced)
                                                            {
                                                                columnIndex -= 2;

                                                                Thread.Sleep(200);
                                                                successive = rightMoveJump(rowIndex, columnIndex, tableArray);

                                                                if (!successive)
                                                                {
                                                                    Thread.Sleep(200);
                                                                    successive = downMoveJump(rowIndex, columnIndex, tableArray);
                                                                }


                                                            }*/
                        }

                    }

                }

                if (!computerPlaced)//If the computer movement cannot be achieved again, then the other O's in the table are checked, and the left-up step is attempted.
                {

                    placesOfComputerIcons = findO(tableArray);

                    for (int i = 0; i < placesOfComputerIcons.Length / 2; i++)
                    {

                        rowIndex = placesOfComputerIcons[i, 0];
                        columnIndex = placesOfComputerIcons[i, 1];


                        randomDirectionForJumpAndStep = random.Next(1, 3); //if 1 ==> left, 2 ==> up

                        if (randomDirectionForJumpAndStep == 1)//left step
                        {

                            computerPlaced = leftMove(rowIndex, columnIndex, tableArray);

                            if (!computerPlaced) //up step
                            {
                                computerPlaced = upMove(rowIndex, columnIndex, tableArray);
                                if (computerPlaced)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }



                        }
                        else if (randomDirectionForJumpAndStep == 2) //up step
                        {


                            computerPlaced = upMove(rowIndex, columnIndex, tableArray);

                            if (!computerPlaced) //left step
                            {
                                computerPlaced = leftMove(rowIndex, columnIndex, tableArray);
                                if (computerPlaced)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }

                        }


                    }

                }


            }

            return computerPlaced;
        }

    }
}




