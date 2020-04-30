using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace GetToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean runProgram = true;
            Boolean reRunProgram = true;

            int studentIDNum = 0;

            Dictionary<int, string> classGroupOfStudents = new Dictionary<int, string>();
            classGroupOfStudents.Add(1, "deshawn");
            classGroupOfStudents.Add(2, "mathan");
            classGroupOfStudents.Add(3, "josh");
            classGroupOfStudents.Add(4, "amanda");
            classGroupOfStudents.Add(5, "roy");
    
            Dictionary<int, string> homeTowns = new Dictionary<int, string>();
            homeTowns.Add(1, "New Haven");
            homeTowns.Add(2, "Detroit");
            homeTowns.Add(3, "Lansing");
            homeTowns.Add(4, "Grand Rapids");
            homeTowns.Add(5, "Chicago");

            Dictionary<int, string> favoriteFoods = new Dictionary<int, string>();
            favoriteFoods.Add(1, "Crab Legs");
            favoriteFoods.Add(2, "Pizza");
            favoriteFoods.Add(3, "Omelette");
            favoriteFoods.Add(4, "Sushi");
            favoriteFoods.Add(5, "Grilled Steak");

            Dictionary<int, string> favoriteMusic = new Dictionary<int, string>();
            favoriteMusic.Add(1, "Instrumentals");
            favoriteMusic.Add(2, "Country");
            favoriteMusic.Add(3, "Pop");
            favoriteMusic.Add(4, "Hip Hop");
            favoriteMusic.Add(5, "Jazz");

            Dictionary<int, string> funFacts = new Dictionary<int, string>();
            funFacts.Add(1, "Has dreams about the future.");
            funFacts.Add(2, "Will shed 40 pounds of skin in his life.");
            funFacts.Add(3, "Thinks 4-year olds ask 400 questions per day.");
            funFacts.Add(4, "Spread awareness that more humans die from vending machine than sharks per year.");
            funFacts.Add(5, "Work for the company that turned down buying google in 1999");

            Dictionary<string, Dictionary<int, String>> listOfDictionaries = new Dictionary<string, Dictionary<int, string>>();
            listOfDictionaries.Add("hometown", homeTowns);
            listOfDictionaries.Add("favorite food", favoriteFoods);
            listOfDictionaries.Add("favorite music", favoriteMusic);
            listOfDictionaries.Add("fun fact", funFacts);
            



            while (runProgram)
            {
                GreetingPrompt();
                string userString = ReadAndReturnInput();
                studentIDNum = SearchAndReturnStudent(userString, classGroupOfStudents);


                if (ValidateStudent(userString, classGroupOfStudents))
                {
                    Boolean dictionaryLoop = true;

                    while (dictionaryLoop)
                    {
                        string dictionaryName = GetDictionaryName(studentIDNum, classGroupOfStudents);

                        if (ValidateDictionary(dictionaryName, listOfDictionaries))
                        {
                            SelectDictionaryInformation(dictionaryName, listOfDictionaries);
                            dictionaryLoop = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid response please try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The input you entered does not match any current students in the class.");
                }

                while(reRunProgram)
                {
                    Console.WriteLine("Do you want to try again?");
                    string reRunInput = 
                }



            }
        }

        public static void GreetingPrompt()
        {
            Console.WriteLine("Welcome to our C# class. Which student would you like to learn more about? (Enter a name)");
            Console.WriteLine("You can type \"all\" for a list of the students in the class");
        }

        public static string ReadAndReturnInput()
        {
            string input = Console.ReadLine().ToLower();
            return input;
        }

        public static Dictionary<int, string> AddStudentToClass(Dictionary<int, string> collectionOfStudents)
        {
            int studentNum = 0;
            foreach(KeyValuePair<int, string> studentNumAndName in collectionOfStudents)
            {
                studentNum++;
            }
            studentNum = studentNum + 1;
            collectionOfStudents.Add(studentNum, ReadAndReturnInput());

            return collectionOfStudents;
        }

        public static Boolean ValidateStudent(string studentSelector, Dictionary<int, string> studentList)
        {
            Boolean isAStudent = false;

            foreach (var student in studentList)
            {
                string nameInList = student.Value;

                if (nameInList == studentSelector)
                {
                    isAStudent = true;
                    return isAStudent;
                }
            }
            return isAStudent;
        }

        public static int SearchAndReturnStudent(string studentName, Dictionary<int, string> collectionOfStudents)
        {
            int studentNum = 0;

            foreach (KeyValuePair<int, string> item in collectionOfStudents)
            {
                if(item.Value == studentName)
                {
                    return item.Key;
                }
            }
            return studentNum;
        }

        public static string GetDictionaryName(int studentNum, Dictionary<int, string> collectionOfStudents)
        {
            Console.WriteLine($"What would you like to learn about {collectionOfStudents[studentNum]}?");
            return ReadAndReturnInput();
        }

        public static void PrintDictionaryValue(int studentID)
        {
            Console.WriteLine("This is the value");
        }

        public static Boolean ValidateDictionary(string testingIfDictName, Dictionary<string, Dictionary<int, string>> dictionaryList)
        {
            Boolean isNameofDictionary = false;
            foreach (KeyValuePair<string, Dictionary<int, string>> workingDictionaryElement in dictionaryList)
            {
                if (workingDictionaryElement.Key == testingIfDictName.ToLower())
                {
                    isNameofDictionary = true;
                    return isNameofDictionary;
                }
            }
            return isNameofDictionary;
        }

        public static string SelectDictionaryInformation(string nameOfDictionary, Dictionary<string, Dictionary<int, string>> dictionaryList)

        {
            string studentInfo = "";
            foreach(KeyValuePair<string, Dictionary<int, string>> workingDictionaryElement in dictionaryList)
            {
                foreach (var innerDictionary in workingDictionaryElement.Value)
                {
                    if (workingDictionaryElement.Key == nameOfDictionary.ToLower())
                    {
                        studentInfo = innerDictionary.Value;
                        Console.WriteLine($"This is the selected student's {workingDictionaryElement.Key}: {studentInfo}");
                        return studentInfo;
                    }
                }
            }
            return studentInfo;
        }
    }
}
