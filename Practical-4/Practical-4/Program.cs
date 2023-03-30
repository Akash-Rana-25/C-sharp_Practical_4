namespace Practical_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine().ToString();

            Console.WriteLine($"Enter marks of {Student.marksLength} subjects:");
            decimal[] marks = new decimal[Student.marksLength];

            for (int i = 0; i < Student.marksLength; i++)
            {
                Console.WriteLine($"Marks[{i + 1}]: ");

                try
                {
                    marks[i] = Convert.ToDecimal(Console.ReadLine());
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Only numbers are allowed, you have entered invalid input");
                    Console.WriteLine($"Exception: {fe.Message}");
                }
            }

            Student student = new Student(name, marks);

            int userChoice;
            do
            {
                Console.WriteLine($"\nSelect the option:");
                Console.WriteLine($"1 - Aggregate (Display the name and average marks)");
                Console.WriteLine($"2 - MinimumMark (Display the minimum mark)");
                Console.WriteLine($"3 - MaximumMark (Display the maximum mark)");
                Console.WriteLine($"4 - Grade (Display the grade)");
                Console.WriteLine($"0 - Exit an application");

                if (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.WriteLine("Only numbers are allowed, you have entered invalid input");
                    userChoice = ~0;
                }
                else
                {
                    Options option = (Options)userChoice;
                    Console.WriteLine(option switch
                    {
                        Options.Aggregate => $"\nYour name is: {student.Name} \nYour average marks is: {student.CalculateAverageMarks()}",
                        Options.Minimummark => $"\nMinimum mark you get is: {student.CalculateMinimumMark()}",
                        Options.MaximumMark => $"\nMaximum mark you get is: {student.CalculateMaximumMark()}",
                        Options.Garde => $"\nYour grades is: {student.CalculateGrade()}",
                        Options.Exit => $"\nExiting an application, bye",
                        _ => "Options between only 0, and 1 to 4 is allowed, you have selected wrong option"
                    }); ;
                }
            } while (userChoice != 0);
        }
    }

    enum Options
    {
        Aggregate = 1,
        Minimummark = 2,
        MaximumMark = 3,
        Garde = 4,
        Exit = 0
    }


}