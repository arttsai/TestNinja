namespace TestNinja.Fundamentals
{
    public class LeapYearCalculator
    {
        public bool IsLeapYear(int year)
        {
            // rules:  https://keisan.casio.com/exec/system/1532572418
            // another comment line 
            if (year % 4 != 0) return false;
            if (year % 100 != 0) return true;
            if (year % 400 != 0) return false;
            return true;
        }
    }
}