namespace Exceptions_Miller_Gabriella
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare and initialize floating-point variables
            float myFloat = 65.4f;
            float myOtherFloat = 0.0f;
            float result = 0f;

            // Generate a random integer between 2 and 30
            Random rand = new Random();
            int myInt = rand.Next(2, 30);

            try
            {
                // Attempt to divide by myOtherFloat, which is initially zero
                result = Divide(myFloat, myOtherFloat);
            } 
            catch (Exception e)
            {
                // Catch divide by zero exception and prompt user for a new number
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter a number other than zero");
                myOtherFloat = (float)Convert.ToDouble(Console.ReadLine());
                
                try
                {
                    // Retry division with the user-provided value
                    result = Divide(myFloat, myOtherFloat);
                }
                catch (Exception e2)
                {
                    // Catch any remaining exceptions from division
                    Console.WriteLine(e2.Message);
                }
            }
            finally
            {
                // Ensure that this message is always displayed
                Console.WriteLine("Calculations comepletes with a result of " + result);
            }

            try
            {
                // Check if the randomly generated age meets the required threshold
                CheckAge(myInt);
            }
            catch
            {
                // Handle the case where age is below the required threshold
                Console.WriteLine($"You are {myInt}! You are not old enough! Be gone, minor! Your parents are being contacted immediately!");
            }
        }



        // Method to perform division, throws an exception if dividing by zero
        static float Divide(float x, float y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                return x / y;
            }
        }

        // Method to check age eligibility for mature content
        static void CheckAge(int age)
        {
            if(age >= 17)
            {
                Console.WriteLine($"You are {age}, you can play mature games!");
            }
            else
            {
                // Incorrect exception type used, should be a more appropriate one like ArgumentException
                throw new DivideByZeroException();
            }
        }
    }
}