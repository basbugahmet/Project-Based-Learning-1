using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleBattleshipProjectWithoutLoop
{
    class Program
    {
        static void Main(string[] args)
        {

            string empty_string = "                                                          ";
            Random random = new Random();
            int randomX = random.Next(1, 33);
            int randomY = random.Next(1, 13);




            Console.WriteLine();
            Console.WriteLine("                MENU");
            Console.WriteLine("PLEASE SELECT FROM THE OPTIONS BELOW:");
            Console.WriteLine("1 – Enter ship location ");
            Console.WriteLine("2 – Ship info ");
            Console.WriteLine("3 – Shoot at the ship ");
            Console.WriteLine("4 – Show high score table");
            Console.WriteLine("5 – Exit");
            Console.WriteLine();
            Console.Write("Your selection: ");


            string selection = Console.ReadLine();

            if (selection == "1")
            {


                Console.Write("Please enter x-coordinate of A vertice: ");
                int x1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter y-coordinate of A vertice: ");
                int y1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter x-coordinate of B vertice: ");
                int x2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter y-coordinate of B vertice: ");
                int y2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter x-coordinate of C vertice: ");
                int x3 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter y-coordinate of C vertice: ");
                int y3 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                if ((x1 > 30) || (x1 < 0) || (x2 > 30) || (x2 < 0) || (x3 > 30) || (x3 < 0) || (y1 > 12) || (y1 < 0) || (y2 > 12) || (y2 < 0) || (y3 > 12) || (y3 < 0))
                {
                    Console.WriteLine("Coordinates for x should be between 0 and 32 ; for y should be between 0 and 12");
                    Console.WriteLine();
                    Console.WriteLine("Program is being terminated...");
                    Thread.Sleep(1500);
                    Environment.Exit(0);
                }


                double area = 0.5 * Math.Abs((x1 * y2 + x2 * y3 + x3 * y1) - (x2 * y1 + x3 * y2 + x1 * y3));

                if (area == 0)
                {
                    Console.WriteLine("This is not a triangle!, enter coordinates again.");
                    Console.WriteLine();
                    Console.WriteLine("Program is being terminated...");
                    Thread.Sleep(1500);
                    Environment.Exit(0);


                }
                else
                {

                    Console.Clear();


                    Console.WriteLine("12|");
                    Console.WriteLine("11|");
                    Console.WriteLine("10|");
                    Console.WriteLine(" 9|");
                    Console.WriteLine(" 8|");
                    Console.WriteLine(" 7|");
                    Console.WriteLine(" 6|");
                    Console.WriteLine(" 5|");
                    Console.WriteLine(" 4|");
                    Console.WriteLine(" 3|");
                    Console.WriteLine(" 2|");
                    Console.WriteLine(" 1|");
                    Console.WriteLine("  +------------------------------");
                    Console.WriteLine("   123456789012345678901234567890");

                    Console.SetCursorPosition(x1 + 2, 12 - y1);
                    Console.WriteLine("A");
                    Console.SetCursorPosition(x2 + 2, 12 - y2);
                    Console.WriteLine("B");
                    Console.SetCursorPosition(x3 + 2, 12 - y3);
                    Console.WriteLine("C");

                    Console.SetCursorPosition(0, 15);

                    Console.WriteLine("A:(" + x1 + "," + y1 + ") B:(" + x2 + "," + y2 + ") C:(" + x3 + "," + y3 + ")");

                    double a = Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2));
                    double b = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
                    double c = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

                    double perimeter = a + b + c;

                    double cosA = (Math.Pow(a, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) / (-2 * b * c);
                    double angleA = Math.Acos(cosA) * (180 / Math.PI);
                    double cosB = (Math.Pow(b, 2) - Math.Pow(a, 2) - Math.Pow(c, 2)) / (-2 * a * c);
                    double angleB = Math.Acos(cosB) * (180 / Math.PI);
                    double cosC = (Math.Pow(c, 2) - Math.Pow(a, 2) - Math.Pow(b, 2)) / (-2 * a * b);
                    double angleC = Math.Acos(cosC) * (180 / Math.PI);


                    double medianAxCoordinate = (x2 + x3) / 2;
                    double medianAyCoordinate = (y2 + y3) / 2;
                    double medianBxCoordinate = (x1 + x3) / 2;
                    double medianByCoordinate = (y1 + y3) / 2;
                    double medianCxCoordinate = (x1 + x2) / 2;
                    double medianCyCoordinate = (y1 + y2) / 2;

                    double centroidX = (double)(x1 + x2 + x3) / 3;
                    double centroidY = (double)(y1 + y2 + y3) / 3;

                    double ratio = a / (b + c);
                    double cuted1 = ratio * b;
                    double cuted2 = ratio * c;

                    double lengthOfBisector = Math.Sqrt((b * c) - (cuted1 * cuted2));


                    double s = perimeter / 2;
                    double radiusOfInscribedCircle = (double)area / s;
                    double areaOfInscribedCircle = Math.PI * Math.Pow(radiusOfInscribedCircle, 2);

                    double radiusOfCircumscribedCircle = (double)(a * b * c) / Math.Sqrt((a + b + c) * (b + c - a) * (c + a - b) * (a + b - c));
                    double areaOfCircumscribedCircle = Math.PI * Math.Pow(radiusOfCircumscribedCircle, 2);





                    double max;
                    double min1 = b;
                    double min2 = c;

                    if (a >= b && a >= c)
                    {
                        max = a;
                        min1 = b;
                        min2 = c;

                    }
                    else if (b >= a && b >= c)
                    {
                        max = b;
                        min1 = a;
                        min2 = c;
                    }
                    else
                    {
                        max = c;
                        min1 = a;
                        min2 = b;
                    }



                    string typeOfTriangle;

                    if (Math.Pow(min1, 2) + Math.Pow(min2, 2) > Math.Pow(max, 2))
                    {
                        typeOfTriangle = "Acute-angled";
                    }
                    else if (Math.Pow(min1, 2) + Math.Pow(min2, 2) == Math.Pow(max, 2))
                    {
                        typeOfTriangle = "Right-angled";
                    }
                    else
                    {
                        typeOfTriangle = "Obtose-angled";
                    }

                    String typeOfTriangle2;

                    if (a != b && a != c && b != c)
                    {
                        typeOfTriangle2 = "Scalene";

                    }
                    else if (a == b && a == c && b == c)
                    {
                        typeOfTriangle2 = "Equilateral";
                    }
                    else
                    {
                        typeOfTriangle2 = "Isosceles";
                    }




                    double area1 = 0.5 * Math.Abs((x1 * y2 + x2 * randomY + randomX * y1) - (x2 * y1 + randomX * y2 + x1 * randomY));
                    double area2 = 0.5 * Math.Abs((x1 * randomY + randomX * y3 + x3 * y1) - (randomX * y1 + x3 * randomY + x1 * y3));
                    double area3 = 0.5 * Math.Abs((randomX * y2 + x2 * y3 + x3 * randomY) - (x2 * randomY + x3 * y2 + randomX * y3));

                    double totalAreaAccordingToRandom = area1 + area2 + area3;







                    Console.WriteLine();
                    Console.WriteLine("MENU");
                    Console.WriteLine("PLEASE SELECT FROM THE OPTIONS BELOW:");
                    Console.WriteLine("2 – Ship info ");
                    Console.WriteLine("3 – Shoot at the ship ");
                    Console.WriteLine("4 – Show high score table");
                    Console.WriteLine("5 – Exit");
                    Console.WriteLine();
                    Console.Write("Your selection: ");
                    selection = Console.ReadLine();


                    if (selection == "2")
                    {
                        Console.WriteLine();
                        Console.WriteLine("The size of the ship is a=" + Math.Round(a, 2) + ", b=" + Math.Round(b, 2) + ", c=" + Math.Round(c, 2));
                        Console.WriteLine("The perimeter of the ship: " + Math.Round(perimeter, 2));
                        Console.WriteLine("The area of the ship: " + Math.Round(area, 2));
                        Console.WriteLine("The angles of the ship: A=" + Math.Round(angleA, 2) + " B=" + Math.Round(angleB, 2) + " C=" + Math.Round(angleC, 2));
                        Console.WriteLine("The median points: (" + Math.Round(medianAxCoordinate, 2) + "," + Math.Round(medianAyCoordinate, 2) + ") (" + Math.Round(medianBxCoordinate, 2) + "," + Math.Round(medianByCoordinate, 2) + ") (" + Math.Round(medianCxCoordinate, 2) + "," + Math.Round(medianCyCoordinate, 2) + ")");
                        Console.WriteLine("The centroid of the ship: (" + Math.Round(centroidX, 2) + "," + Math.Round(centroidY, 2) + ")");
                        Console.WriteLine("The length of the bisector: " + Math.Round(lengthOfBisector, 2));
                        Console.WriteLine("The area of the inscribed circle: " + Math.Round(areaOfInscribedCircle, 2));
                        Console.WriteLine("The area of circumscribed circle: " + Math.Round(areaOfCircumscribedCircle, 2));
                        Console.WriteLine("The type of the ship: " + typeOfTriangle2 + "(" + typeOfTriangle + ")");


                        Console.WriteLine();
                        Console.WriteLine("MENU");
                        Console.WriteLine("PLEASE SELECT FROM THE OPTIONS BELOW:");
                        Console.WriteLine("3 – Shoot at the ship ");
                        Console.WriteLine("4 – Show high score table");
                        Console.WriteLine("5 – Exit");
                        Console.WriteLine();
                        Console.Write("Your selection: ");
                        selection = Console.ReadLine();

                        if (selection == "3")
                        {
                            Console.WriteLine("Shoot: (" + randomX + "," + randomY + ")");

                            Console.WriteLine();

                            Console.Clear();


                            Console.WriteLine("12|");
                            Console.WriteLine("11|");
                            Console.WriteLine("10|");
                            Console.WriteLine(" 9|");
                            Console.WriteLine(" 8|");
                            Console.WriteLine(" 7|");
                            Console.WriteLine(" 6|");
                            Console.WriteLine(" 5|");
                            Console.WriteLine(" 4|");
                            Console.WriteLine(" 3|");
                            Console.WriteLine(" 2|");
                            Console.WriteLine(" 1|");
                            Console.WriteLine("  +------------------------------");
                            Console.WriteLine("   123456789012345678901234567890");

                            Console.SetCursorPosition(x1 + 2, 12 - y1);
                            Console.WriteLine("A");
                            Console.SetCursorPosition(x2 + 2, 12 - y2);
                            Console.WriteLine("B");
                            Console.SetCursorPosition(x3 + 2, 12 - y3);
                            Console.WriteLine("C");
                            Console.SetCursorPosition(randomX + 2, 12 - randomY);
                            Console.WriteLine("X");

                            Console.SetCursorPosition(0, 15);



                            string name = "";


                            if (area == totalAreaAccordingToRandom)
                            {
                                Console.WriteLine("Your ship sank! Total score is 0");


                                Console.WriteLine();
                                Console.WriteLine("MENU");
                                Console.WriteLine("PLEASE SELECT FROM THE OPTIONS BELOW:");
                                Console.WriteLine("2 – Ship info ");
                                Console.WriteLine("4 – Show high score table");
                                Console.WriteLine("5 – Exit");
                                Console.WriteLine();
                                Console.Write("Your selection: ");
                                selection = Console.ReadLine();



                                if (selection == "2")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The size of the ship is a=" + Math.Round(a, 2) + ", b=" + Math.Round(b, 2) + ", c=" + Math.Round(c, 2));
                                    Console.WriteLine("The perimeter of the ship: " + Math.Round(perimeter, 2));
                                    Console.WriteLine("The area of the ship: " + Math.Round(area, 2));
                                    Console.WriteLine("The angles of the ship: A=" + Math.Round(angleA, 2) + " B=" + Math.Round(angleB, 2) + " C=" + Math.Round(angleC, 2));
                                    Console.WriteLine("The median points: (" + Math.Round(medianAxCoordinate, 2) + "," + Math.Round(medianAyCoordinate, 2) + ") (" + Math.Round(medianBxCoordinate, 2) + "," + Math.Round(medianByCoordinate, 2) + ") (" + Math.Round(medianCxCoordinate, 2) + "," + Math.Round(medianCyCoordinate, 2) + ")");
                                    Console.WriteLine("The centroid of the ship: (" + Math.Round(centroidX, 2) + "," + Math.Round(centroidY, 2) + ")");
                                    Console.WriteLine("The length of the bisector: " + Math.Round(lengthOfBisector, 2));
                                    Console.WriteLine("The area of the inscribed circle: " + Math.Round(areaOfInscribedCircle, 2));
                                    Console.WriteLine("The area of circumscribed circle: " + Math.Round(areaOfCircumscribedCircle, 2));
                                    Console.WriteLine("The type of the ship: " + typeOfTriangle2 + "(" + typeOfTriangle + ")");
                                    Console.WriteLine();
                                    Console.WriteLine("Program is being terminated...");

                                    Thread.Sleep(4000);
                                    Environment.Exit(0);


                                }
                                else if (selection == "4")
                                {
                                    Console.WriteLine("Name  	        	Score");
                                    Console.WriteLine("Nazan Kaya		60 ");
                                    Console.WriteLine("Ali Kurt		30 ");
                                    Console.WriteLine("Sibel Arslan            10");
                                    Console.WriteLine();
                                    Console.WriteLine("Program is being terminated...");
                                    Thread.Sleep(1500);
                                    Environment.Exit(0);

                                }

                                else if (selection == "5")
                                {
                                    Environment.Exit(0);
                                }

                                else
                                {
                                    Console.WriteLine("Invalid selection!");
                                    Console.WriteLine();
                                    Console.WriteLine("Program is being terminated...");
                                    Thread.Sleep(1500);
                                    Environment.Exit(0);
                                }



                            }
                            else
                            {

                                Console.WriteLine("Your ship survived! Total score is " + area);
                                Console.Write("Enter your name: ");
                                name = Console.ReadLine();

                                Console.WriteLine("Name  	        	Score");

                                if (area < 60 && area > 30)
                                {
                                    Console.WriteLine("Nazan Kaya		60 ");
                                    Console.WriteLine(name + empty_string.Substring(0, 24 - name.Length) + area);
                                    Console.WriteLine("Ali Kurt		30 ");
                                }

                                else if (area < 30 && area > 10)
                                {
                                    Console.WriteLine("Nazan Kaya		60 ");
                                    Console.WriteLine("Ali Kurt		30 ");
                                    Console.WriteLine(name + empty_string.Substring(0, 24 - name.Length) + area);
                                }

                                else if (area <= 10)
                                {
                                    Console.WriteLine("Nazan Kaya		60 ");
                                    Console.WriteLine("Ali Kurt		30 ");
                                    Console.WriteLine("Sibel Arslan            10");
                                }


                                else if (area == 60)
                                {
                                    Console.WriteLine("Nazan Kaya		60 ");
                                    Console.WriteLine(name + empty_string.Substring(0, 24 - name.Length) + area);
                                    Console.WriteLine("Ali Kurt               30 ");
                                }

                                else if (area == 30)
                                {
                                    Console.WriteLine("Nazan Kaya		60 ");
                                    Console.WriteLine("Ali Kurt		30 ");
                                    Console.WriteLine(name + empty_string.Substring(0, 24 - name.Length) + area);
                                }



                                Console.WriteLine();
                                Console.WriteLine("MENU");
                                Console.WriteLine("PLEASE SELECT FROM THE OPTIONS BELOW:");
                                Console.WriteLine("2 – Ship info ");
                                Console.WriteLine("5 – Exit");
                                Console.WriteLine();
                                Console.Write("Your selection: ");
                                selection = Console.ReadLine();

                                if (selection == "2")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("The size of the ship is a=" + Math.Round(a, 2) + ", b=" + Math.Round(b, 2) + ", c=" + Math.Round(c, 2));
                                    Console.WriteLine("The perimeter of the ship: " + Math.Round(perimeter, 2));
                                    Console.WriteLine("The area of the ship: " + Math.Round(area, 2));
                                    Console.WriteLine("The angles of the ship: A=" + Math.Round(angleA, 2) + " B=" + Math.Round(angleB, 2) + " C=" + Math.Round(angleC, 2));
                                    Console.WriteLine("The median points: (" + Math.Round(medianAxCoordinate, 2) + "," + Math.Round(medianAyCoordinate, 2) + ") (" + Math.Round(medianBxCoordinate, 2) + "," + Math.Round(medianByCoordinate, 2) + ") (" + Math.Round(medianCxCoordinate, 2) + "," + Math.Round(medianCyCoordinate, 2) + ")");
                                    Console.WriteLine("The centroid of the ship: (" + Math.Round(centroidX, 2) + "," + Math.Round(centroidY, 2) + ")");
                                    Console.WriteLine("The length of the bisector: " + Math.Round(lengthOfBisector, 2));
                                    Console.WriteLine("The area of the inscribed circle: " + Math.Round(areaOfInscribedCircle, 2));
                                    Console.WriteLine("The area of circumscribed circle: " + Math.Round(areaOfCircumscribedCircle, 2));
                                    Console.WriteLine("The type of the ship: " + typeOfTriangle2 + "(" + typeOfTriangle + ")");
                                    Console.WriteLine();
                                    Console.WriteLine("Program is being terminated...");
                                    Thread.Sleep(4000);
                                    Environment.Exit(0);

                                }

                                else if (selection == "5")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection!");
                                    Console.WriteLine("Program is being terminated...");
                                    Environment.Exit(0);
                                }



                            }



                        }


                        else if (selection == "4")
                        {
                            Console.WriteLine("Name  	        	Score");
                            Console.WriteLine("Nazan Kaya		60 ");
                            Console.WriteLine("Ali Kurt		30 ");
                            Console.WriteLine("Sibel Arslan            10");
                            Console.WriteLine();
                            Console.WriteLine("Program is being terminated...");
                            Thread.Sleep(1500);
                            Environment.Exit(0);

                        }
                        else if (selection == "5")
                        {
                            Environment.Exit(0);
                        }

                        else
                        {
                            Console.WriteLine("Invalid selection!");
                            Console.WriteLine("Program is being terminated...");
                            Console.WriteLine();
                            Thread.Sleep(1500);
                            Environment.Exit(0);
                        }

                    }



                    else if (selection == "3")
                    {
                        Console.WriteLine("Shoot: (" + randomX + "," + randomY + ")");

                        Console.WriteLine();

                        Console.Clear();


                        Console.WriteLine("12|");
                        Console.WriteLine("11|");
                        Console.WriteLine("10|");
                        Console.WriteLine(" 9|");
                        Console.WriteLine(" 8|");
                        Console.WriteLine(" 7|");
                        Console.WriteLine(" 6|");
                        Console.WriteLine(" 5|");
                        Console.WriteLine(" 4|");
                        Console.WriteLine(" 3|");
                        Console.WriteLine(" 2|");
                        Console.WriteLine(" 1|");
                        Console.WriteLine("  +------------------------------");
                        Console.WriteLine("   123456789012345678901234567890");

                        Console.SetCursorPosition(x1 + 2, 12 - y1);
                        Console.WriteLine("A");
                        Console.SetCursorPosition(x2 + 2, 12 - y2);
                        Console.WriteLine("B");
                        Console.SetCursorPosition(x3 + 2, 12 - y3);
                        Console.WriteLine("C");
                        Console.SetCursorPosition(randomX + 2, 12 - randomY);
                        Console.WriteLine("X");

                        Console.SetCursorPosition(0, 15);



                        string name = "";


                        if (area == totalAreaAccordingToRandom)
                        {
                            Console.WriteLine("Your ship sank! Total score is 0");


                            Console.WriteLine();
                            Console.WriteLine("MENU");
                            Console.WriteLine("PLEASE SELECT FROM THE OPTIONS BELOW:");
                            Console.WriteLine("2 – Ship info ");
                            Console.WriteLine("4 – Show high score table");
                            Console.WriteLine("5 – Exit");
                            Console.WriteLine();
                            Console.Write("Your selection: ");
                            selection = Console.ReadLine();



                            if (selection == "2")
                            {
                                Console.WriteLine();
                                Console.WriteLine("The size of the ship is a=" + Math.Round(a, 2) + ", b=" + Math.Round(b, 2) + ", c=" + Math.Round(c, 2));
                                Console.WriteLine("The perimeter of the ship: " + Math.Round(perimeter, 2));
                                Console.WriteLine("The area of the ship: " + Math.Round(area, 2));
                                Console.WriteLine("The angles of the ship: A=" + Math.Round(angleA, 2) + " B=" + Math.Round(angleB, 2) + " C=" + Math.Round(angleC, 2));
                                Console.WriteLine("The median points: (" + Math.Round(medianAxCoordinate, 2) + "," + Math.Round(medianAyCoordinate, 2) + ") (" + Math.Round(medianBxCoordinate, 2) + "," + Math.Round(medianByCoordinate, 2) + ") (" + Math.Round(medianCxCoordinate, 2) + "," + Math.Round(medianCyCoordinate, 2) + ")");
                                Console.WriteLine("The centroid of the ship: (" + Math.Round(centroidX, 2) + "," + Math.Round(centroidY, 2) + ")");
                                Console.WriteLine("The length of the bisector: " + Math.Round(lengthOfBisector, 2));
                                Console.WriteLine("The area of the inscribed circle: " + Math.Round(areaOfInscribedCircle, 2));
                                Console.WriteLine("The area of circumscribed circle: " + Math.Round(areaOfCircumscribedCircle, 2));
                                Console.WriteLine("The type of the ship: " + typeOfTriangle2 + "(" + typeOfTriangle + ")");
                                Console.WriteLine();
                                Console.WriteLine("Program is being terminated...");
                                Thread.Sleep(4000);
                                Environment.Exit(0);



                            }

                            else if (selection == "4")
                            {

                                Console.WriteLine("Name  	        	Score");
                                Console.WriteLine("Nazan Kaya		60 ");
                                Console.WriteLine("Ali Kurt		30 ");
                                Console.WriteLine("Sibel Arslan            10");
                                Console.WriteLine();
                                Console.WriteLine("Program is being terminated...");
                                Thread.Sleep(1500);
                                Environment.Exit(0);

                            }

                            else if (selection == "5")
                            {
                                Environment.Exit(0);
                            }

                            else
                            {
                                Console.WriteLine("Invalid selection!");
                                Console.WriteLine();
                                Console.WriteLine("Program is being terminated...");
                                Thread.Sleep(1500);
                                Environment.Exit(0);
                            }



                        }
                        else
                        {

                            Console.WriteLine("Your ship survived! Total score is " + area);
                            Console.Write("Enter your name: ");
                            name = Console.ReadLine();

                            Console.WriteLine("Name  	        	Score");

                            if (area < 60 && area > 30)
                            {
                                Console.WriteLine("Nazan Kaya		60 ");
                                Console.WriteLine(name + empty_string.Substring(0, 24 - name.Length) + area);
                                Console.WriteLine("Ali Kurt		30 ");
                            }

                            else if (area < 30 && area > 10)
                            {
                                Console.WriteLine("Nazan Kaya		60 ");
                                Console.WriteLine("Ali Kurt		30 ");
                                Console.WriteLine(name + empty_string.Substring(0, 24 - name.Length) + area);
                            }

                            else if (area <= 10)
                            {
                                Console.WriteLine("Nazan Kaya		60 ");
                                Console.WriteLine("Ali Kurt		30 ");
                                Console.WriteLine("Sibel Arslan            10");
                            }

                            else if (area == 60)
                            {
                                Console.WriteLine("Nazan Kaya		60 ");
                                Console.WriteLine(name + empty_string.Substring(0, 24 - name.Length) + area);
                                Console.WriteLine("Ali Kurt               30 ");
                            }

                            else if (area == 30)
                            {
                                Console.WriteLine("Nazan Kaya		60 ");
                                Console.WriteLine("Ali Kurt		30 ");
                                Console.WriteLine(name + empty_string.Substring(0, 24 - name.Length) + area);
                            }



                            Console.WriteLine();
                            Console.WriteLine("MENU");
                            Console.WriteLine("PLEASE SELECT FROM THE OPTIONS BELOW:");
                            Console.WriteLine("2 – Ship info ");
                            Console.WriteLine("5 – Exit");
                            Console.WriteLine();
                            Console.Write("Your selection: ");
                            selection = Console.ReadLine();

                            if (selection == "2")
                            {
                                Console.WriteLine();
                                Console.WriteLine("The size of the ship is a=" + Math.Round(a, 2) + ", b=" + Math.Round(b, 2) + ", c=" + Math.Round(c, 2));
                                Console.WriteLine("The perimeter of the ship: " + Math.Round(perimeter, 2));
                                Console.WriteLine("The area of the ship: " + Math.Round(area, 2));
                                Console.WriteLine("The angles of the ship: A=" + Math.Round(angleA, 2) + " B=" + Math.Round(angleB, 2) + " C=" + Math.Round(angleC, 2));
                                Console.WriteLine("The median points: (" + Math.Round(medianAxCoordinate, 2) + "," + Math.Round(medianAyCoordinate, 2) + ") (" + Math.Round(medianBxCoordinate, 2) + "," + Math.Round(medianByCoordinate, 2) + ") (" + Math.Round(medianCxCoordinate, 2) + "," + Math.Round(medianCyCoordinate, 2) + ")");
                                Console.WriteLine("The centroid of the ship: (" + Math.Round(centroidX, 2) + "," + Math.Round(centroidY, 2) + ")");
                                Console.WriteLine("The length of the bisector: " + Math.Round(lengthOfBisector, 2));
                                Console.WriteLine("The area of the inscribed circle: " + Math.Round(areaOfInscribedCircle, 2));
                                Console.WriteLine("The area of circumscribed circle: " + Math.Round(areaOfCircumscribedCircle, 2));
                                Console.WriteLine("The type of the ship: " + typeOfTriangle2 + "(" + typeOfTriangle + ")");
                                Console.WriteLine();
                                Console.WriteLine("Program is being terminated...");
                                Thread.Sleep(4000);
                                Environment.Exit(0);

                            }

                            else if (selection == "5")
                            {
                                Environment.Exit(0);
                            }
                            else
                            {

                                Console.WriteLine("Invalid selection!");
                                Console.WriteLine();
                                Console.WriteLine("Program is being terminated...");
                                Thread.Sleep(1500);
                                Environment.Exit(0);
                            }



                        }



                    }


                    else if (selection == "4")
                    {
                        Console.WriteLine("Name  	        	Score");
                        Console.WriteLine("Nazan Kaya		60 ");
                        Console.WriteLine("Ali Kurt		30 ");
                        Console.WriteLine("Sibel Arslan            10");
                        Console.WriteLine();
                        Console.WriteLine("Program is being terminated...");
                        Thread.Sleep(1500);
                        Environment.Exit(0);

                    }
                    else if (selection == "5")
                    {
                        Environment.Exit(0);
                    }

                    else
                    {
                        Console.WriteLine("Invalid selection!");
                        Console.WriteLine();
                        Console.WriteLine("Program is being terminated...");
                        Thread.Sleep(1500);
                        Environment.Exit(0);

                    }



                }

            }

            else if (selection == "2")
            {
                Console.WriteLine("Firstly you need to enter your coordinates");
                Console.WriteLine();
                Console.WriteLine("Program is being terminated...");
                Thread.Sleep(1500);
                Environment.Exit(0);
            }

            else if (selection == "3")
            {
                Console.WriteLine("Firstly you need to enter your coordinates");
                Console.WriteLine();
                Console.WriteLine("Program is being terminated...");
                Thread.Sleep(1500);
                Environment.Exit(0);
            }

            else if (selection == "4")
            {
                Console.WriteLine("Name  	        	Score");
                Console.WriteLine("Nazan Kaya		60 ");
                Console.WriteLine("Ali Kurt		30 ");
                Console.WriteLine("Sibel Arslan            10");
                Console.WriteLine();
                Console.WriteLine("Program is being terminated...");
                Thread.Sleep(1500);
                Environment.Exit(0);

            }

            else if (selection == "5")
            {
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine("Invalid selection!");
                Console.WriteLine();
                Console.WriteLine("Program is being terminated...");
                Thread.Sleep(1500);
                Environment.Exit(0);

            }


        }

    }
}
