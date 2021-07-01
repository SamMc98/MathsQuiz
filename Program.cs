using System;

namespace MathsQuiz
{
    public class Program
    {
        private static string correctAnswers = "";
        private static int userInput = 0, correctNumOfAnswers, numberOfQuestionsAsked;
        private static int[] numbersRange = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private static string[] operators = { "+", "-", "*", "/" };

        public static string ShowResults()
        {
            string finalResults = "";
            if (correctNumOfAnswers == 0)
            {
                finalResults = $"You got zero out of {numberOfQuestionsAsked} questions correct.";
            }
            else
            {
                finalResults = ($"You got the following {correctNumOfAnswers} questions correct out of {numberOfQuestionsAsked}:\n {correctAnswers}");
            }
            //prints the number of correct answers, if there are any it will include those and their answers.
            return finalResults;
        }
        //reveals the user's results, including the number of correct answers and related questions

        public static int Randomiser()
        {
            Random random = new Random();
            int randomlyGeneratedNumber = random.Next(0, numbersRange.Length);
            return randomlyGeneratedNumber + 1;
        }
        //randomises numbers for randomly generated maths questions

        public static bool CheckInput(string userInput)
        {
            int checkedNumber = 0;
            bool isCorrect = int.TryParse(userInput, out checkedNumber);
            return isCorrect;
        }
        //checks if the user has entered a number
        //@param userInput - the entered input to be checked 

        public static int IdentifyOperator(string selectedOperator, int calculatedAnswer, int randomlyGeneratedFirstNumber, int randomlyGeneratedSecondNumber)
        {
            switch (selectedOperator)
            {
                case "+":
                    calculatedAnswer = randomlyGeneratedFirstNumber + randomlyGeneratedSecondNumber;
                    break;
                case "-":
                    calculatedAnswer = randomlyGeneratedFirstNumber - randomlyGeneratedSecondNumber;
                    break;
                case "/":
                    calculatedAnswer = randomlyGeneratedFirstNumber / randomlyGeneratedSecondNumber;
                    break;
                case "*":
                    calculatedAnswer = randomlyGeneratedFirstNumber * randomlyGeneratedSecondNumber;
                    break;
            }
            return calculatedAnswer;
        }
        //calculates the answer of randomly generated questions
        //@param selectedOperator - the arithmetic operator to be identified
        //@param calculatedAnswer - the answer of the generated equation
        //@param randomlyGeneratedFirstNumber - the number on the left hand side of the operator
        //@param randomlyGeneratedSecondNumber - the number on the left hand side of the operator

        public static void AskQuestion1()
        {
            string question1 = "3 + 2 = ";
            Console.WriteLine($"\nWhat is {question1}?");
            string userInputString = Console.ReadLine();
            bool isValidInput = CheckInput(userInputString);
            //prints a maths question and stores the user input
            if (isValidInput == true)
            {
                userInput = int.Parse(userInputString);
                if (userInput == 5)
                {
                    correctAnswers += $"\n{question1} {userInput}";
                    correctNumOfAnswers++;
                }
            }
            else if (isValidInput == false)
            {
                Console.WriteLine("You must enter a number.");
                AskQuestion1();
            }
            numberOfQuestionsAsked++;
            AskQuestion2();
            //if the given answer is correct, update count and the correct answers
        }
        //asks the user the first maths question

        public static void AskQuestion2()
        {
            string question2 = "3 + 5 = ";
            Console.WriteLine($"\nWhat is {question2}?");
            string userInputString = Console.ReadLine();
            bool isValidInput = CheckInput(userInputString);
            //prints a maths question and stores the user input
            if (isValidInput == true)
            {
                userInput = int.Parse(userInputString);
                if (userInput == 8)
                {
                    correctAnswers += $"\n{question2} {userInput}";
                    correctNumOfAnswers++;
                }
                numberOfQuestionsAsked++;
                AskQuestion3();
            }
            else if (isValidInput == false)
            {
                Console.WriteLine("You must enter a number.");
                AskQuestion2();
            }
            //if the given answer is correct, update count and the correct answers
        }
        //asks the user the second maths question 

        public static void AskQuestion3()
        {
            string question3 = "7 + 8 = ";
            Console.WriteLine($"\nWhat is {question3}?");
            string userInputString = Console.ReadLine();
            bool isValidInput = CheckInput(userInputString);
            //prints a maths question and stores the user input
            if (isValidInput == true)
            {
                userInput = int.Parse(userInputString);
                if (userInput == 15)
                {
                    correctAnswers += $"\n{question3} {userInput}";
                    correctNumOfAnswers++;
                }
                numberOfQuestionsAsked++;
                AskQuestion4();
            }
            else if (isValidInput == false)
            {
                Console.WriteLine("You must enter a number.");
                AskQuestion3();
            }
            //if the given answer is correct, update count and the correct answers
        }
        //asks the user the third maths question 

        public static void AskQuestion4()
        {
            string question4 = "5 + 6 = ";
            Console.WriteLine($"\nWhat is {question4}?");
            string userInputString = Console.ReadLine();
            bool isValidInput = CheckInput(userInputString);
            //prints a maths question and stores the user input
            if (isValidInput == true)
            {
                userInput = int.Parse(userInputString);
                if (userInput == 11)
                {
                    correctAnswers += $"\n{question4} {userInput}";
                    correctNumOfAnswers++;
                }
                numberOfQuestionsAsked++;
                AskRandomlyGeneratedNumberQuestions();
            }
            else if (isValidInput == false)
            {
                Console.WriteLine("You must enter a number.");
                AskQuestion4();
            }
            //if the given answer is correct, update count and the correct answers
        }
        //asks the user the fourth maths question

        public static void AskRandomlyGeneratedNumberQuestions()
        {
            for (int i = 0; i < operators.Length; i++)
            {
                int randomlyGeneratedFirstNumber = Randomiser(), randomlyGeneratedSecondNumber = Randomiser();

                while (randomlyGeneratedFirstNumber % randomlyGeneratedSecondNumber == 0 == false)
                {
                    randomlyGeneratedFirstNumber = Randomiser();
                    randomlyGeneratedSecondNumber = Randomiser();
                }
                //Generate random numbers
                int calculatedAnswer = 0;

                string askedQuestion = $"{randomlyGeneratedFirstNumber} {operators[i]} {randomlyGeneratedSecondNumber} =";
                Console.WriteLine($"\nWhat is {askedQuestion} ?");

                string selectedOperator = operators[i];
                calculatedAnswer = IdentifyOperator(selectedOperator, calculatedAnswer, randomlyGeneratedFirstNumber, randomlyGeneratedSecondNumber);

                GenerateQuestionsAndCheckAnswers(calculatedAnswer, askedQuestion);
            }
            AskRandomlyGeneratedQuestions(4);
        }
        //asks the user maths questions with randomly generated numbers

        public static void AskRandomlyGeneratedQuestions(int questionNumbersRequest)
        {
            for (int i = 0; i < questionNumbersRequest; i++)
            {
                Random random = new Random();
                int randomlyGeneratedOperator = random.Next(operators.Length);
                int calculatedAnswer = 0;
                int randomlyGeneratedFirstNumber = Randomiser(), randomlyGeneratedSecondNumber = Randomiser();

                while (randomlyGeneratedFirstNumber % randomlyGeneratedSecondNumber == 0 == false)
                {
                    randomlyGeneratedFirstNumber = Randomiser();
                    randomlyGeneratedSecondNumber = Randomiser();
                }

                string askedQuestion = $"{randomlyGeneratedFirstNumber} {operators[randomlyGeneratedOperator]} {randomlyGeneratedSecondNumber} =";
                Console.WriteLine($"\nWhat is {askedQuestion} ?");

                string selectedOperator = operators[randomlyGeneratedOperator];
                calculatedAnswer = IdentifyOperator(selectedOperator, calculatedAnswer, randomlyGeneratedFirstNumber, randomlyGeneratedSecondNumber);
                GenerateQuestionsAndCheckAnswers(calculatedAnswer, askedQuestion);

            }
            Console.WriteLine(ShowResults());
        }
        //asks the user maths questions with randomly generated numbers and operators 
        //@param questionNumbersRequest - the number of questions the user specifies

        public static void GenerateQuestionsAndCheckAnswers(int calculatedAnswer, string askedQuestion)
        {
            string userInputString = Console.ReadLine();
            bool isValidInput = CheckInput(userInputString);
            if (isValidInput == true)
            {
                userInput = int.Parse(userInputString);
                if (userInput == calculatedAnswer)
                {
                    correctAnswers += $"\n{askedQuestion} {userInput}";
                    correctNumOfAnswers++;
                }
                numberOfQuestionsAsked++;
            }
            else if (isValidInput == false)
            {
                Console.WriteLine("You must enter a number.");
                GenerateQuestionsAndCheckAnswers(calculatedAnswer, askedQuestion);
            }
        }
        //generates random questions and checks the user's input
        //@param calculatedAnswer - the answer of the generated equation
        //@param askedQuestion - the question that the user reads

        public static void AmountOfQuestions()
        {
            Console.WriteLine("\nHow many questions would you like to complete?");
            string questionNumbersRequest = Console.ReadLine();
            bool isValidInput = CheckInput(questionNumbersRequest);
            if (isValidInput == true)
            {
                userInput = int.Parse(questionNumbersRequest);
                if (userInput > 0)
                {
                    AskRandomlyGeneratedQuestions(userInput);
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                    AmountOfQuestions();
                }
            }
            else
            {
                AmountOfQuestions();
            }
        }
        //asks the user how many questions they wish to answer

        public static void MenuOption()
        {
            Console.WriteLine("\nType 'default' or 'd' if you would like to complete 12 default questions or\ntype 'custom' or 'c' if you would like to choose how many questions to complete.");
            string userInput = Console.ReadLine().ToLower();
            {
                if (userInput == "default" || userInput == "d")
                {
                    AskQuestion1();
                    PlayAgainOption();
                }
                else if (userInput == "custom" || userInput == "c")
                {
                    AmountOfQuestions();
                    PlayAgainOption();
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                    MenuOption();
                }
            }
        }
        //a prompt to give the user a choice between 12 default questions or a custom range of their own

        public static void PlayAgainOption()
        {
            Console.WriteLine("\nWould you like to complete more questions?");
            string userInputAgain = Console.ReadLine().ToLower();
            if (userInputAgain == "yes" || userInputAgain == "y")
            {
                correctNumOfAnswers = 0;
                numberOfQuestionsAsked = 0;
                correctAnswers = "";
                MenuOption();
            }
            else if (userInputAgain == "no" || userInputAgain == "n")
            {
                Console.WriteLine("Goodbye");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Something went wrong.");
                PlayAgainOption();
            }
        }
        //asks the user if they wish to continue using the application

        public static void Main(string[] args)
        {
            Console.WriteLine("Maths Quiz Program\n\nWelcome!\n");
            MenuOption();
            //starts the application
        }
    }
}