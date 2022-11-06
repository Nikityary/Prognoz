namespace Prognoz
{
    internal class Main
    {
        public double _temp;
        public double temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value - 273.15; 
            }
        }

        public double _pressure;
        public double pressure
        {
            get
            {
                return _pressure;
            }
            set 
            { 
                _pressure = value/1.3332239; 
            }
        }

        public double humidity;
    }
}
