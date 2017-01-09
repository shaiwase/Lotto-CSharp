using System;



//********************************************************************************************************************************************//
// Author : Karine Or  ///GOOD save
// TZ : 310261243
// Project 1 
// Basic C#
// Subject : Lottery program. User will recive a menu with options : Manual or automatic Lottery. User will be able to fill between 1 to 10 
//           The program /user will generate the numbers in one/multidimention array (based on the tours number selected by the user).
//           The program will check for hits numbers in each row and will print the results.
//           The program will give the option to re-play or exit once the game is over
//********************************************************************************************************************************************//           


namespace Lotto
{
    class Lottery
    {

        #region Main driver

        static void Main(string[] args)
        {
            Random rdn = new Random();

            PrintMenuStartOfGame(rdn); //Call the Print Menu function
        }

        #endregion Main close
        
        #region Class variables and constants

        //Constant variables used by the program
        const int COLUMNS = 6;
        const int MINNUMRANDOM = 1;
        const int MAXNUMRANDOM = 46;
        const int MAXROW = 10;
        const int MINROW = 1;

       public static int gRowNum ;


        #endregion Class variables and constants

        #region Switch Menu

        /// <summary>
        /// This method routes the user to the choosen lotto game or exit.
        /// </summary>
        /// <param name="rdn"></param>
        public static void MenuSwitchOptions(Random rdn)
        {
            var selection = int.Parse(Console.ReadLine());
            //Read the user's selection input number and turns it to int number
            while (selection != 3)
            {
                switch (selection) //Switch condition invoked by the menu 
                {
                    case 1:
                        //ManualLotto(rdn);
                        IsManual(true, rdn);
                        break;
                    case 2:
                        IsManual(false, rdn);
                        break;
                    case 3:
                        Console.WriteLine("Exiting....");
                        break;
                    default:
                        MenuErrorMsgInvalidStartOption();
                        PrintMenuStartOfGame(rdn);
                        break;
                }
            } //While the number is different from 3 actions, the loop will rerun, otherwise will leave the loop.
        }

        #endregion


        #region User interaction menus

        /// <summary> 
        /// Prints the lottery starting menu on the user's console
        ///  </summary>
        public static void PrintMenuStartOfGame(Random rdn)
        {
            MenuYellowColor();
            Console.WriteLine("********************************************************************");
            Console.WriteLine("*             Welcome to No Chance 's lottery simulator            *");
            Console.WriteLine("********************************************************************\n\n\n");
            Console.WriteLine("Please enter your selection :");
            Console.WriteLine("1 - Manual lotto ");
            Console.WriteLine("2 - Automatic lotto ");
            Console.WriteLine("3 - Exit ");
            MenuResetColor();

            MenuSwitchOptions(rdn);
        }

        /// <summary>
        /// Menu to ask the user how many tours he wants to play.
        /// </summary>
        /// <returns></returns>
        public static int MenuAskNumberOfTours()
        {
            MenuYellowColor();
            Console.WriteLine("Please enter the number of tours you want to fill (between 1 to 10) :");
            MenuResetColor();
            gRowNum = int.Parse(Console.ReadLine()); //Read the number of tours given by the user.
            Console.WriteLine("\n\n");

            return gRowNum;
        }

        /// <summary>
        /// This method asks the user to enter numbers for manual lotto
        /// </summary>
        /// <param name="index"></param>
        public static void MenuAskUserToInputNumbers(int index)
        {
            MenuYellowColor();
            Console.WriteLine("Please enter number " + (index + 1) + " for row " + (index + 1) + " :");
            //+1 to start the tour count from 1 when talking to user only
            MenuResetColor();
        }

        /// <summary>
        /// @OVERLOADED
        /// </summary>
        /// <param name="i"></param>
        public static void MenuAskUserToInputNumbers(int i, int j)
        {
            MenuYellowColor();
            Console.WriteLine("Please enter number " + (j + 1) + " for row " + (i + 1) + " :");
            //+1 to start the tour count from 1 when talking to user only
            MenuResetColor();
        }

        /// <summary>
        /// This method is called to read user numbers input from the console
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int MenuReadUserNumber(int number)
        {
            number = Convert.ToInt32(Console.ReadLine());

            return number;
        }

        /// <summary>
        /// The method prints a lotto welcome message
        /// </summary>
        public static void MenuWelcomeToLotto(bool isManual)
        {
            MenuYellowColor();
            var scenario = isManual ? "Manual" : "Automatic";
            Console.WriteLine("WELCOME {0} TO lOTTERY GAME ! GOOD LUCK ! \n\n", scenario);
            MenuResetColor();
        }

        /// <summary>
        /// This method prints an error message if wrong input is given at the start menu
        ///</summary>
        public static void MenuErrorMsgInvalidStartOption()
        {
            MenuRedColor();
            Console.WriteLine("!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("Invalid selection.");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!\n\n\n");
            MenuResetColor();
        }

        /// <summary>
        /// This method prints an error message if wrong number of tour is given
        /// </summary>
        public static void MenuErrorMsgIfWrongNumOfRow()
        {
            MenuRedColor();
            Console.WriteLine("    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("         Please enter a valid number between 1 to 10 ");
            Console.WriteLine("    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n\n");
            MenuResetColor();
        }

        /// <summary>
        /// This method prints an error message if the number inserted is out of range 1 to 45
        /// </summary>
        /// <param name="index"></param>
        /// <param name="number"></param>
        public static void MenuErrorMsgIfWrongNumNotInRange(int number)
        {
            MenuRedColor();
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("  Value '{0}' is out of allowed range.", number);
            Console.WriteLine("  Please enter a correct number between 1 to 45.");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// This method prints an error message if the user enter a number which is already in the row
        /// </summary>
        public static void MenuErrorMessageIfNumNotUnique()
        {
            Console.WriteLine();
            MenuRedColor();
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("  The number has already been entered and must be unique");
            Console.WriteLine("  Please select another unique number");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n");
            MenuResetColor();
        }

        /// <summary>
        /// This Method changes the fonts color to yellow
        /// </summary>
        public static void MenuYellowColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        /// <summary>
        /// This Method changes the fonts color to red
        /// </summary>
        public static void MenuRedColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        /// <summary>
        /// This Method changes the fonts color to green
        /// </summary>
        public static void MenuGreenColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        /// <summary>
        /// This Method changes the fonts color to white
        /// </summary>
        public static void MenuWhiteColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// This method reset the fonts to default 
        /// </summary>
        public static void MenuResetColor()
        {
            Console.ResetColor();
        }

        #endregion user interaction menus


        #region Lottery  validators methods

        /// <summary>
        /// This method sets the manual lotto to true for future check if manual or automatic.
        /// </summary>
        /// <param name="isManual"></param>
        /// <param name="rdn"></param>
        /// <returns></returns>
        public static void IsManual(bool isManual, Random rdn)
        {
            ValidateLottoNumberOfRows(isManual, rdn);
        }

        /// <summary>  
        /// ValidateLottoArrayManual Function - Validity check (Must be greater than 1 row and fewer than 6 rows)
        /// Invoque the relevant Lotto array constructor method (1 row or more)
        /// Winner numbers method is invoked.
        /// </summary>
        /// <param name="isManual"></param>
        /// <param name="rdn"></param>
        public static void ValidateLottoNumberOfRows(bool isManual, Random rdn)
        {
            gRowNum = MenuAskNumberOfTours();
            //Ask the number of tours - USER MENUS AND OTHER INTERACTION WITH USER METHODS. 

            while (gRowNum < MINROW || gRowNum > MAXROW) //loop while number of rows out of range
            {
                MenuErrorMsgIfWrongNumOfRow();
                //Prints red error message because of invalid row number - USER MENUS AND OTHER INTERACTION WITH USER METHODS.
                gRowNum = MenuAskNumberOfTours();
            }

            LottoSelection(isManual, gRowNum, rdn);
            //will create the lottery game according to the input variable passed to the method.

        }

        /// <summary>
        /// This method calls the relevant method according to the input received by the user.
        /// </summary>
        /// <param name="rowNum"></param>
        /// <param name="rdn"></param>
        /// <param name="isManual"></param>
        public static void LottoSelection(bool isManual, int rowNum, Random rdn)
        {
            #region Array creation for lotto game

            int[] winnerLottoNumbers = new int[COLUMNS]; //Empty array creation to store winner numbers
            int[] userNumbersOneTour = new int[COLUMNS]; //Creates array 1 tour to store the 6 user'numbers.

            int[] result = new int[COLUMNS]; //Creates a new array to store the user's winning numbers

            #endregion Array creation for lotto game

            if (rowNum == MINROW && isManual) //If the selection is Manual lotto 1 row
            {
                PlayLottoManual(userNumbersOneTour, winnerLottoNumbers, result, rdn, isManual);
            }
            else if (rowNum == MINROW && !isManual)
            {
                PlayLottoAutomatic(userNumbersOneTour, winnerLottoNumbers, result, rdn, isManual);
            }
            else if (rowNum > MINROW && isManual)
            {
                int[,] userNumbersMultipleTour = new int[rowNum, COLUMNS];
                PlayLottoManual(userNumbersMultipleTour, winnerLottoNumbers, result, rdn, isManual);
            }
            else if (rowNum > MINROW && !isManual)
            {
                int[,] userNumbersMultipleTour = new int[rowNum, COLUMNS];
                PlayLottoAutomatic(userNumbersMultipleTour, winnerLottoNumbers, result, rdn, isManual);
            }
        }

        /// <summary>  
        ///  Method for manual lottery, User is asked to input 6 numbers for each tour
        ///  If the numbers given by the user are valid it creates the row with given numbers   Validity method is invoqued to check numbers are valids.      
        /// </summary>
        /// 
        public static void InsertUserNumbersInArray(int[] lottoArr)
        {
            int number = 0; //Variable for input number that will be check if valid.

            for (int i = 0; i < COLUMNS;) //invoque manual for loop to fill the row with numbers entered by the user
            {
                MenuAskUserToInputNumbers(i);
                //interacts for user input numbers - USER MENUS AND OTHER INTERACTION WITH USER METHODS. 
                number = MenuReadUserNumber(number);
                if (!IsNumberInRange(number))
                {
                    number = CheckIfNumInRange(number);
                    lottoArr[i] = number;
                }
                if (i > 0)
                {
                    if (!IsNumberUnique(lottoArr, i, number))
                    {
                        number = CheckIfNumberUnique(lottoArr, i, number);
                        lottoArr[i] = number;
                    }
                }
                lottoArr[i] = number;
             i++;
            }
        }

        /// <summary>  
        /// @OVERLOAD
        ///  Method for manual lottery, User is asked to input 6 numbers for each tour
        ///  If the numbers given by the user are valid it creates the row with given numbers   Validity method is invoqued to check numbers are valids.      
        /// </summary>
        /// 
        public static void InsertUserNumbersInArray(int[,] lottoArr)
        {
            int number = 0; //Variable for input number that will be check if valid.
            int i, j;

            for (i = 0; i < lottoArr.GetLength(0); i++)
            {
                for (j = 0; j < lottoArr.GetLength(1); j++)
                {
                    do
                    {
                        MenuAskUserToInputNumbers(i, j); //Ask the user to enter numbers for each row (multiple rows)
                        number = MenuReadUserNumber(number);
                    } while ((!IsNumberInRange(number)) || (!IsNumberUnique(lottoArr, i, j, number)));

                    lottoArr[i, j] = number;
                } //i
            } //i
        }

        /// <summary>  
        /// This function check if the number entered by the user is within a valid range (1 - 45)                 
        /// </summary>
        /// <param name="number"></param>
        public static int CheckIfNumInRange(int number)
        {
            while (number < 1 || number > 45) //Loop error message if not in range
            {
                MenuErrorMsgIfWrongNumNotInRange(number);
                number = MenuReadUserNumber(number);
            }
            return number;
        }

        /// <summary>
        /// Sets boolean to false or true isNumberInRange
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns> 
        public static bool IsNumberInRange(int number)
        {
            bool isNumberInRange = !(number < 1 || number > 45);

            if (!isNumberInRange)
                MenuErrorMsgIfWrongNumNotInRange(number);

            return isNumberInRange;
        }

        /// <summary>
        /// Sets boolean to false or true isNumberUnique
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsNumberUnique(int[] arr, int i, int number)
        {
            bool isNumberUnique = true;

            for (int ind = 0; ind <= i;)
            {
                if (number == arr[i - 1])
                {
                    isNumberUnique = false;
                }
                ind++;
            }
            return isNumberUnique;
        }

        /// <summary>
        /// @OVERLOAD
        /// Sets boolean to false or true isNumberUnique
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsNumberUnique(int[,] arr, int i, int j, int number)
        {
            bool isNumberUnique = true;

            if (i >= 0 && j > 0)
            {
                {
                    for (int h = 0; h < j; h++)
                    {
                        if (arr[i, h] == number)
                        {
                            isNumberUnique = false;
                            MenuErrorMessageIfNumNotUnique();
                        }
                    }
                }
            }
            return isNumberUnique;
        }

        /// <summary>
        /// This method check if the number is unique in the array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int CheckIfNumberUnique(int[] arr, int i, int number)
        {
            while (!IsNumberUnique(arr, i, number))
            {
                MenuErrorMessageIfNumNotUnique();
                number = MenuReadUserNumber(number);
            }
            return number;
        }

        #endregion


        #region The lotto game
     

        /// <summary>
       /// This method runs the lotto game for Manual 1 row.
      /// </summary>
      /// <param name="userNumbersOneTour"></param>
      /// <param name="winnerLottoNumbers"></param>
      /// <param name="result"></param>
      /// <param name="rdn"></param>
      /// <param name="isManual"></param>
        public static void PlayLottoManual(int[] userNumbersOneTour, int[] winnerLottoNumbers, int[] result, Random rdn, bool isManual)
        {
            MenuWelcomeToLotto(isManual); //Print welcome
            InsertUserNumbersInArray(userNumbersOneTour); //inserts the user numbers in the previously created array.
            CreateWinnerNumbers(rdn, winnerLottoNumbers); //Generate lottery winner numbers
            int howManyWinnerNumbers = CheckUserWinnerNumbers(userNumbersOneTour, winnerLottoNumbers, result);
            PrintDecisionWhatToPrint(howManyWinnerNumbers, result, gRowNum, winnerLottoNumbers, userNumbersOneTour, rdn); //invoque the check method to check how many numbers won.
        }

        /// <summary>
        /// This method runs the lotto game for Manual more than 1 row.
        /// </summary>
        /// <param name="userNumbersMultipleTour"></param>
        /// <param name="winnerLottoNumbers"></param>
        /// <param name="result"></param>
        /// <param name="rdn"></param>
        /// <param name="isManual"></param>
        public static void PlayLottoManual(int[,] userNumbersMultipleTour, int[] winnerLottoNumbers, int[] result, Random rdn, bool isManual)
        {
            MenuWelcomeToLotto(isManual); //Print welcome
            InsertUserNumbersInArray(userNumbersMultipleTour); //inserts the user numbers in [,] userNumbersMultipleTour
            CreateWinnerNumbers(rdn, winnerLottoNumbers); //Generate lottery winner numbers
            CheckWinnerNumbers(userNumbersMultipleTour, winnerLottoNumbers, rdn);
        }

        /// <summary>
        /// This method runs the lotto game for Automatic 1 row.
        /// </summary>
        /// <param name="userNumbersOneTour"></param>
        /// <param name="winnerLottoNumbers"></param>
        /// <param name="result"></param>
        /// <param name="rdn"></param>
        /// <param name="isManual"></param>
        public static void PlayLottoAutomatic(int[] userNumbersOneTour, int[] winnerLottoNumbers, int[] result, Random rdn, bool isManual)
        {
            MenuWelcomeToLotto(isManual); //Print welcome
            CreateWinnerNumbers(rdn, userNumbersOneTour); //Generate lottery user number
            CreateWinnerNumbers(rdn, winnerLottoNumbers); //Generate lottery winner numbers
            int howManyWinnerNumbers = CheckUserWinnerNumbers(userNumbersOneTour, winnerLottoNumbers, result);
            PrintDecisionWhatToPrint(howManyWinnerNumbers, result, gRowNum, winnerLottoNumbers, userNumbersOneTour, rdn); //invoque the check method to check how many numbers won.
        }


        /// <summary>
        /// @OVERLOADED
        /// This method runs the lotto game for Automatic multiple rows.
        /// </summary>
        /// <param name="userNumbersOneMultipleTour"></param>
        /// <param name="winnerLottoNumbers"></param>
        /// <param name="result"></param>
        /// <param name="rdn"></param>
        /// <param name="isManual"></param>
        public static void PlayLottoAutomatic(int[,] userNumbersOneMultipleTour, int[] winnerLottoNumbers, int[] result, Random rdn, bool isManual)
        {
            MenuWelcomeToLotto(isManual); //Print welcome
            AutomaticLotoGeneratorMultipleRows(userNumbersOneMultipleTour, rdn); //Generate lottery user number
            CreateWinnerNumbers(rdn, winnerLottoNumbers); //Generate lottery winner numbers
            CheckWinnerNumbers(userNumbersOneMultipleTour, winnerLottoNumbers, rdn);
        }

        #endregion The Lotto game


        #region Automatic lottery number generators

        /// <summary>
        /// This method creates 6 lottery game winning numbers
        ///</summary>
        /// <param name="rdn"></param>
        /// <param name="arr"></param>
        public static void CreateWinnerNumbers(Random rdn, int[] arr)
        {
            for (int i = 0; i < COLUMNS; i++) //invoque manual for loop to fill the row with numbers entered by the user
            {
                int generatedNum = rdn.Next(MINNUMRANDOM, MAXNUMRANDOM);

                while (i > 0 && !IsNumberUnique(arr, i, generatedNum))
                {
                    generatedNum = rdn.Next(MINNUMRANDOM, MAXNUMRANDOM);
                    arr[i] = generatedNum;
                }
                arr[i] = generatedNum;
            }
        }

        /// <summary>
        ///  This method fills unique numbers in the array (from 1 to 45) for automatic lotto multiple tours        
        ///  it makes sure numbers are unique in the row.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="rdn"></param>
        /// <returns></returns>
        public static void AutomaticLotoGeneratorMultipleRows(int [,] arr, Random rdn)
        {
          for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    int automaticNumber = rdn.Next(MINNUMRANDOM, MAXNUMRANDOM);
                    arr[i, j] = automaticNumber;

                    if (i >= 0 || j >= 0) //Check numbers are unique in each row of multidim array.
                    {
                        for (int h = 0; h < j; h++)
                        {
                            while (arr[i, h] == automaticNumber)
                            {
                                arr[i, j] = rdn.Next(MINNUMRANDOM, MAXNUMRANDOM);
                                automaticNumber = arr[i, j];
                            } //while
                        } //h
                    } //if
                } //j
            } //i
          }

        #endregion Automatic lottery number generators


        #region Result printing

        /// <summary>
        /// This Method prints the Lottery 6 winner numbers randomly generated
        /// </summary>
        /// <param name="winningNumbers"></param>
        public static void PrintLotteryWinnerNumbers(int[] winningNumbers)
        {
            MenuGreenColor();
            Console.WriteLine("Lottery 6 winner numbers are :\n\n");

            foreach (int t in winningNumbers)
            {
                // if (t != 0)
                Console.Write("{0} ", t);
            }
            Console.WriteLine("\n");
            MenuResetColor();
        }

        /// <summary>
        /// This method prints the numbers the user has selected for the lotto game
        /// </summary>
        /// <param name="arrLottoWinNum"></param>
        public static void PrintUserLottoNumbers(int[] arrLottoWinNum)
        {
            MenuGreenColor();
            Console.WriteLine("Your selected numbers are :\n\n");

            foreach (int t in arrLottoWinNum)
            {
                if (t != 0)
                    Console.Write("{0} ", t);
            }
            Console.WriteLine("\n");
            MenuResetColor();
        }

        /// <summary> 
        /// @OVERLOADED
        /// This method prints the numbers selected by the user for multidimentional array.
        /// </summary>
        /// <param name="arrLottoWinNum"></param>
        public static void PrintUserLottoNumbers(int[,] arrLottoWinNum)
        {
            MenuYellowColor();
            int rowNum = 1;
            for (int row = 0; row < arrLottoWinNum.GetLength(0); row++)
            {
                Console.WriteLine("Your numbers at row number : " + rowNum);
                Console.WriteLine();

                for (int column = 0; column < arrLottoWinNum.GetLength(1); column++)
                {
                    Console.Write(arrLottoWinNum[row, column] + " "); //writing data
                } //column

                Console.Write(Environment.NewLine); //adding new line, so that next loop will start from new line
                rowNum++;
                Console.WriteLine();
            } //row
            MenuResetColor();
        }

        /// <summary>
        /// This Method prints the user's winning numbers (only)
        /// </summary>
        /// <param name="result"></param>
        public static void PrintUserWinnerNumbers(int[] result)
        {
            MenuWhiteColor();
            Console.WriteLine("\n");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Your winning numbers are : ");
            Console.WriteLine("------------------------------\n");
            foreach (int t in result)
            {
                if (t != 0)
                    Console.Write("{0} ", t);
            }
            MenuResetColor();
        }


        /// <summary>
        /// Method that prints the header "Printing the results"
        /// </summary>
        public static void PrintTheResultHeader()
        {
            MenuGreenColor();
            Console.WriteLine("***********Printing the results *************\n\n");
            MenuResetColor();
        }

        /// <summary>
        /// The method prints Sorry message if the user has no winning number
        /// </summary>
        /// <param name="userRowNumber"></param>
        /// <param name="rdn"></param>
        public static void PrintIfNoWinningNumber(int userRowNumber, Random rdn)
        {
            MenuWhiteColor();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("***********Printing the results *************\n\n\n");
            Console.WriteLine("Sorry, you have no winner number for tour " + userRowNumber);
            MenuResetColor();
            GameOverOption(rdn);
            Console.WriteLine("\n\n");
        }

        /// <summary>
        /// This method prints how many hits in row and for each row
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="r"></param>
        static void PrintsHowManyHitsInRow(int counter, int r)
        {
            MenuGreenColor();
            Console.WriteLine("***********Printing the results *************\n\n");
            Console.WriteLine("You have " + counter + " hit(s) in row : " + "'" + (r) + "'\n");
            // ". The(se) number(s) is(are) : \n");   
            MenuResetColor();
        }

        /// <summary>
        /// This Method decides what to print according to the hits 
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="result"></param>
        /// <param name="userRowNumber"></param>
        /// <param name="winningNumbers"></param>
        /// <param name="userNumbers"></param>
        /// <param name="rdn"></param>
        public static void PrintDecisionWhatToPrint(int counter, int[] result, int userRowNumber, int[] winningNumbers, int[] userNumbers, Random rdn)
        {
            if (counter > 0) //If the user has at least 1 winning number, it prints the results
            {
                PrintsHowManyHitsInRow(counter, userRowNumber);
                PrintUserWinnerNumbers(result);
                Console.WriteLine("\n");
                PrintLotteryWinnerNumbers(winningNumbers);
                PrintUserLottoNumbers(userNumbers);
                GameOverOption(rdn);
            }
            else
            {
                if (counter == 0) //User has no winning number.
                {
                    PrintIfNoWinningNumber(userRowNumber, rdn);
                }
            }

        }

        
 
        /// <summary>
        /// This Method prints the user's winning numbers
        /// </summary>
        /// <param name="arr"></param>
        static void PrintResultInRow(int[] arr)
        {
            // if (arr == null) throw new ArgumentNullException("arr"); //throws exception if arr[] is null
            foreach (int t in arr)
            {
                if (t != 0)
                    Console.Write("{0} ", t);
            }
        }

        /// <summary>
        /// This method prints the result of the lottery.
        /// </summary>
        /// <param name="_result"></param>
        /// <param name="_counter"></param>
        /// <param name="_userRowNumber"></param>
        static void SaveRowToPrint(int[] _result, int _counter, int _userRowNumber)
        {
            Console.WriteLine();//Prints how many hits +  the user's winning numbers  
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You have " + _counter + " hit(s) in row : " + "'" + _userRowNumber + "'" + ". The(se) number(s) is(are) : ");
            Console.WriteLine();
            PrintResultInRow(_result);
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// This method is invoked at the end of the game to check wether the user wants to continue or end the lottery game.
        /// if 'y' is entered, the user will receive the lottery menu, if 'n' is entered, the application will exit.
        /// </summary>
        public static void GameOverOption(Random rdn)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("*************** Game Over *****************\n");
            Console.WriteLine("Do you want to continue to play ? Select : y / n \n"); //Asks the user if he wants to continue the lottery
            string option = Console.ReadLine();

            if (option == "y")
            {
                PrintMenuStartOfGame(rdn); //If 'y' is selected, the user will receive the lottery menu.
            }
            else
            {
                Console.WriteLine("Bye Bye. See you next time"); //If 'n' is selected, application exits.
                Environment.Exit(0);
            }
            Console.WriteLine("Bye Bye. See you next time"); //If 'n' is selected, application exits.
            Environment.Exit(0);
        }

        #endregion Result printing


        #region   Winner checker

        /// <summary>
        /// This Method compares the user numbers in the row with the winning numbers.
        ///  </summary>
        /// <param name="userNumbers"></param>
        /// <param name="winningNumbers"></param>
        /// <param name="result"></param>
        public static int CheckUserWinnerNumbers(int[] userNumbers, int[] winningNumbers, int[] result)
        {
            #region Variables
            int i;
            int counter = 0;
            int nextIndex = 0;
            #endregion
            for (i = 0; i < COLUMNS; i++) //Compare the userNumbers array and WinningNumbers array to check if there are matches
            {
                for (int k = 0; k < COLUMNS; k++)//Run over the winning numbers array to find a match of the usernumber at 
                {
                    if (userNumbers[i] == winningNumbers[k])
                    {
                        counter++;
                        for (int r = nextIndex; r < result.Length; )//Write the user match number into result array to store the result
                        {
                            nextIndex++; //Set the next index to update in result array
                            result[r] = userNumbers[i];
                            break;
                        }
                        break;
                    }//if close   
                }//k
            }//i
            return counter;
        }

        /// <summary>
        /// CheckWinnerNumbers overload - Method takes multidimentional array in passed parameter
        /// This Method compares the user numbers in the rows and look for a match comparing to  the numbers stored in the winning numbers array.
        /// </summary>
        /// <param name="userNumbers"></param>
        /// <param name="winningNumbers"></param>
        /// <param name="rdn"></param>
        static void CheckWinnerNumbers(int[,] userNumbers, int[] winningNumbers, Random rdn)
        {

            #region variables
            int i;
            int j;
            int counter;
            int userRowNumber = 0;
            int userColNumber = 0; //Used as a counter for the tours in the multidimentional array
            int[] result = new int[COLUMNS]; //Creates a new array to store the user's winning numbers
            #endregion variables
            PrintTheResultHeader(); //Prints header
            PrintLotteryWinnerNumbers(winningNumbers); //prints the lottery winning numbers

            for (i = 0; i < userNumbers.GetLength(0); i++)
            //Compare the userNumbers array and WinningNumbers array to check if there are matches. 
            {
                userRowNumber++;
                counter = 0;
                int nextIndex = 0;
                for (j = 0; j < userNumbers.GetLength(1); j++)
                {
                    userColNumber++;

                    for (int k = 0; k < COLUMNS; k++)
                    //Run over the winning numbers array to find a match of the usernumber at 
                    {
                        if (userNumbers[i, j] == winningNumbers[k])
                        {
                            counter++;

                            for (int r = nextIndex; r < result.Length; )
                            {
                                nextIndex++;
                                result[r] = userNumbers[i, j];
                                //Write the user match number into result array to store the result.
                                break;
                            }
                        } //if close   
                    } //k
                    if (counter > 0 && j >= 5) //If the user has at least 1 winning number, it prints the results
                    {
                        SaveRowToPrint(result, counter, userRowNumber);
                    }
                } //j

                if (counter == 0 && i >= 5 || counter == 0 && j >= 5) //User has no winning number.
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Sorry, you have no winner number for tour " + userRowNumber);
                    Console.ResetColor();
                    Console.WriteLine();
                }
                // CheckIfUserHasHits(result, userRowNumber, counter, i, j);
            } //i

            PrintUserLottoNumbers(userNumbers);
            GameOverOption(rdn); //Method to continue or stop the game. "y" to continue, "n" to stop
        }

      

        #endregion Winner checker

    } //Class close
}//Namespace close


