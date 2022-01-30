using System;
using System.IO;

namespace TickitingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string choice;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1) Proccess data from file.");
                Console.WriteLine("2) Add data to the file.");
                Console.WriteLine("Enter any other key to exit.");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // proccess data from file
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] arr = line.Split(',');
                            Console.WriteLine("ID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}",
                             arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                            Console.WriteLine("");
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // add data to file
                    StreamWriter sw = new StreamWriter(file, true);
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine("Add new ticket data (Y/N)?");
                        string resp = Console.ReadLine().ToUpper();
                        if (resp != "Y") { break; }


                        Console.WriteLine("What is the TicketID?");
                        string id = Console.ReadLine();
                        Console.WriteLine("A short ticket summary please.");
                        string summary = Console.ReadLine();
                        Console.WriteLine("What is the tickets status?");
                        string status = Console.ReadLine();
                        Console.WriteLine("What is the priority level of the ticket?");
                        string priority = Console.ReadLine();
                        Console.WriteLine("Who submitted the ticket?");
                        string submitter = Console.ReadLine();
                        Console.WriteLine("Who was assigned the ticket?");
                        string assigned = Console.ReadLine();
                        Console.WriteLine("Who is watching the ticket?");
                        string watcher = Console.ReadLine();
                        sw.WriteLine(" {0},{1},{2},{3},{4},{5},{6}", id, summary, status, priority, submitter, assigned, watcher, "\n");
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}