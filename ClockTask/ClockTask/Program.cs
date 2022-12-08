using System.Text;
namespace ClockTask
{
    internal class Program
    {
        private const double ONE_HOUR_DEGREES = 360 / 12;
        private const double ONE_MINUTE_DEGREES = 360 / 60;
        public static void Main(string[] args)
        {
            
            double inputHour;
            double inputMinute;
            bool minutes, hours; //will save information if the console input was successfully parsed

            Console.WriteLine("Enter the value of the hour hand: ");
            hours = double.TryParse(Console.ReadLine(), out inputHour);
            Console.WriteLine("Enter the value of the minute hand: ");
            minutes = double.TryParse(Console.ReadLine(), out inputMinute);

            if (hours == false || minutes == false) //checks if the input was a number or not
            {
                Console.WriteLine("Please enter a number when defining the values of both clock hands");
                return;
            }

            if (inputHour > 24 && inputMinute > 60) //checks if both inputs have a valid value
            {
                Console.WriteLine("Please enter valid values for both of the variables");
                return;
            }
            
            if (inputHour > 24) //checks if the hour input has a valid value
            {
                Console.WriteLine("Please enter the hour hand value that is between 0 and 24.");
                return;
            }

            if(inputMinute > 60) //checks if the minute input has a valid value
            {
                Console.WriteLine("Please enter the minute hand value that is between 0 and 60");
                return;
            }

            if (inputHour < 0 || inputMinute < 0) //checks if the input is negative
            {
                Console.WriteLine("Please enter a value that is above 0");
                return;
            }

            double angle = LesserAngleCalculation(inputHour, inputMinute);
            Console.WriteLine("The lesser angle between the hour and minute hands is: ");
            Console.WriteLine(angle);

        }
        /// <summary>
        /// Calculates the lesser angle between the two hands of the clock
        /// </summary>
        /// <param name="inputHour">the value of the hour hand that the user has written</param>
        /// <param name="inputMinute">the value of minute hand that the user has written</param>
        /// <returns>the calculated angle between the two hands of the clock</returns>
        public static double LesserAngleCalculation(double inputHour, double inputMinute)
        {
            double angleResult = 0;
            if(inputHour > 12)
            {
                inputHour -= 12;
            }
            double hourAngle = ONE_HOUR_DEGREES * inputHour + (ONE_HOUR_DEGREES / 60 * inputMinute);
            double minuteAngle = ONE_MINUTE_DEGREES * inputMinute;
            if(hourAngle > minuteAngle)
            {
                angleResult = hourAngle - minuteAngle;
            }
            else
            {
                angleResult = minuteAngle - hourAngle;
            }
            if(angleResult > 180)
            {
                angleResult = 360 - angleResult;
            }

            return angleResult;
        }
    }
}
