using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTemperatureSensorDemo
{
    public class SensorTemperatureManager
    {
        public delegate void NotifyTemperatureChangeDelegate(int NewTemperature);

        public event NotifyTemperatureChangeDelegate NotifyForTemperatureChange;

        private int _Temperature = 0;
        public int Temperature
        {
            set
            {
                if (this._Temperature != value)
                {
                    this._Temperature = value;
                    if (this.NotifyForTemperatureChange != null)
                    {
                        this.NotifyForTemperatureChange(value);
                    }

                }
            }
        }




    }
}
