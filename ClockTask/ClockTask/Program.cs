namespace ClockTask
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double oneHourDegrees = 360 / 12;
            double oneMinuteDegrees = 360 / 60;
            double inputHour;
            double inputMinute;

            Console.WriteLine("Enter the value of the hour hand: ");
            inputHour = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the value of the minute hand: ");
            inputMinute = double.Parse(Console.ReadLine());
            if (inputHour > 24 && inputMinute > 60)
            {
                Console.WriteLine("Please enter valid values for both of the variables");
                return;
            }
            if (inputHour > 24)
            {
                Console.WriteLine("Please enter the hour hand value that is between 0 and 24.");
                return;
            }
            if(inputMinute > 60)
            {
                Console.WriteLine("Please enter the minute hand value that is between 0 and 60");
                return;
            }
            double angle = LesserAngleCalculation(oneHourDegrees, oneMinuteDegrees, inputHour, inputMinute);
            Console.WriteLine("The lesser angle between the hour and minute hands is: ");
            Console.WriteLine(angle);

        }
        public static double LesserAngleCalculation(double oneHourDegrees, double oneMinuteDegrees, double inputHour, double inputMinute)
        {
            double angleResult = 0;
            if(inputHour > 12)
            {
                inputHour -= 12;
            }
            double hourAngle = oneHourDegrees * inputHour + (oneHourDegrees / 60 * inputMinute);
            double minuteAngle = oneMinuteDegrees * inputMinute;
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
