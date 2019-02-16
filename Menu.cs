using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace AS5_REGEX
{
    class Menu
    {
        private static string line = "";
        private static string key = "";
        private static string pattern = "[a-lq]";

        public static Dictionary<string, List<string>> TestingContent { get; private set; }

        static void Main(string[] args)
        {
            if (args.Length < 1)
                UserEnterInput();
            else
                UserEnterFile(args[0]);
        }

        private static void ExpressionTester()
        {
            Console.WriteLine("");
            foreach (string key in TestingContent.Keys)
            {
                if (key != "q") Console.WriteLine(key);
                foreach (string testString in TestingContent[key])
                {
                    switch (key)
                    {
                        case "a":
                            Console.WriteLine(Questions.Question_A(testString)); break;
                        case "b":
                            Console.WriteLine(Questions.Question_B(testString)); break;
                        case "c":
                            Console.WriteLine(Questions.Question_C(testString)); break;
                        case "d":
                            Console.WriteLine(Questions.Question_D(testString)); break;
                        case "e":
                            Console.WriteLine(Questions.Question_E(testString)); break;
                        case "f":
                            Console.WriteLine(Questions.Question_F(testString)); break;
                        case "g":
                            Console.WriteLine(Questions.Question_G(testString)); break;
                        case "h":
                            Console.WriteLine(Questions.Question_H(testString)); break;
                        case "i":
                            Console.WriteLine(Questions.Question_I(testString)); break;
                        case "j":
                            Console.WriteLine(Questions.Question_J(testString)); break;
                        case "k":
                            Console.WriteLine(Questions.Question_K(testString)); break;
                        case "l":
                            Console.WriteLine(Questions.Question_L(testString)); break;
                        case "q":
                            Environment.Exit(1); break;
                    }
                }
                Console.WriteLine("");
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("REGULAR EXPRESSIONS\n-------------------\n\n");
            Console.WriteLine("Select a menu option\n\n");

            Console.WriteLine("a:) Social Security Number\n");
            Console.WriteLine("b:) US Phone Number\n");
            Console.WriteLine("c:) E-mail Address\n");
            Console.WriteLine("d:) Name on class roster, assuming one or more middle initials - Last name, First name, MI\n");
            Console.WriteLine("e:) Date in MM-DD-YYYY format\n");
            Console.WriteLine("f:) Hourse address - Street number, street name, abbreviation, for road, street, boulevard or avenue\n");
            Console.WriteLine("g:) City followed by state followed by zip as it should appear on a letter\n");
            Console.WriteLine("h:) Military time, including seconds\n");
            Console.WriteLine("i:) US Currency down to the penny (ex: $123,456,789.23)\n");
            Console.WriteLine("j:) URL, including http:// (upper and lower case should be accepted)\n");
            Console.WriteLine("k:) A password that contains at least 10 characters and includes at least one upper case character, lower case character, digit, punctuation mark, and does not have more than 3 consecutive lower case characters\n");
            Console.WriteLine("l:) All words containing an odd number of alphabetic characters, ending in \"ion\"\n");
            Console.WriteLine("q:) Quit\n");
        }

        private static void UserEnterFile(string filename)
        {
            TestingContent = new Dictionary<string, List<string>>();
            var file = new FileStream(@"../../" + filename, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(file))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Length == 1 && Regex.IsMatch(line, pattern))
                    {
                        key = line;
                        if (!TestingContent.ContainsKey(key))
                            TestingContent[key] = new List<string>();
                    }
                    else
                        TestingContent[key].Add(line);
                }
            }
            ExpressionTester();
        }

        private static void UserEnterInput()
        {
            for (; ; )
            {
                TestingContent = new Dictionary<string, List<string>>();

                DisplayMenu();

                Console.Write("\nSelect Menu: ");
                do { key = Console.ReadLine(); }while(!Regex.IsMatch(key, pattern));
                if (key != "q")
                {
                    Console.Write("\nTest Expression: ");
                    line = Console.ReadLine();
                    Console.Write("\n");
                }

                if (!TestingContent.ContainsKey(key))
                    TestingContent[key] = new List<string>();
                TestingContent[key].Add(line);
                ExpressionTester();

                Console.WriteLine("\n\n");
            }
        }
    }
}
