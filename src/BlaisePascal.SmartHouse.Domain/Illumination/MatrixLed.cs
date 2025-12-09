using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public class MatrixLed
    {
        //Attributes:
        public Led[,] _MatrixLed { get; private set; }
        private int Columns;
        private int Rows;

        //Constructor:
        public MatrixLed(int columns, int rows)
        {
            try
            {
                if (Columns > 0)
                {
                    Columns = columns;
                }
                else
                {
                    throw new Exception();
                }
                if (Rows > 0)
                {
                    Rows = rows;
                }
                else
                {
                    throw new Exception();
                }
            } catch (Exception ex)
            {
                Console.WriteLine("There is an error:");
                Console.WriteLine(ex.Message);
            }
            for(int r = 0; r < 3; r++)
            {
                for (int c = 0; c < Rows; c++)
                {
                    _MatrixLed[c, r] = CreateMatrix();
                }
            }
        }
        //Prende i valori delle lampade in input per metterli sccessivamente nella matrice.
        private Led CreateMatrix()
        {
            string name = Console.ReadLine() ?? "aaa";
            bool isOn = Convert.ToBoolean(Console.ReadLine());
            byte brightness = Convert.ToByte(Console.ReadLine());
            byte[] colors = new byte[3];
            for (int col = 0; col < 3; col++)
            {
                byte color = Convert.ToByte(Console.ReadLine());
                colors[col] = color;
            }
            Led _Led = new Led(name, isOn, brightness, colors);

            return _Led;
        }

        //Turn on al the led.
        public void SwitchOnAll()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < Rows; c++)
                {
                    _MatrixLed[r, c].TurnOn();
                }
            }
        }
        //Turn off all the led.
        public void SwitchOffAll()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < Rows; c++)
                {
                    _MatrixLed[r, c].TurnOff();
                }
            }
        }

        //Change the intensity of oll the led in a one specified.
        public void SetIntensityAll(byte intensity)
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < Rows; c++)
                {
                    _MatrixLed[r, c].ChangeBrightness(intensity);
                }
            }
        }

        //Return the led.
        public Led GetLed(int row, int column)
        {
            return _MatrixLed[row, column];
        }
        //Return the row of led.
        public Led[] GetLedInRow(int row)
        {
            Led[] leds= new Led[Rows];
            for (int c = 0; c < Columns; c++)
            {
                leds[c]=_MatrixLed[row, c];
            }
            return leds;
        }
        //Return the columnsof the led.
        public Led[] GetLedInColumn(int column)
        {
            Led[] leds = new Led[Columns];
            for (int r = 0; r < Rows; r++)
            {
                leds[r] = _MatrixLed[r, column];
            }
            return leds;
        }
    }
}
