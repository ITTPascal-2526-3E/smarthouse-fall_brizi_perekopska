using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public sealed class MatrixLed
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
                    Columns = columns;
                else
                    throw new Exception();
                if (Rows > 0)
                    Rows = rows;
                else
                    throw new Exception();
            } catch (Exception ex)
            {
                Console.WriteLine("There is an error:");
                Console.WriteLine(ex.Message);
            }
            for(int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                    _MatrixLed[r,c] = CreateMatrix(r,c);
            }
        }

        //Takes the values ​​of the lamps as input to subsequently put them into the matrix
        private Led CreateMatrix(int i,int j)
        {
            Random rnd = new Random();
            string name = i.ToString() +","+ j.ToString();
            bool isOn = rnd.Next(2)==1;
            byte brightness = 0;
            if (isOn == true)
                brightness = Convert.ToByte(rnd.Next(101));

            byte[] colors = new byte[3];
            for (int col = 0; col < 3; col++)
            {
                byte color = Convert.ToByte(rnd.Next(256));
                colors[col] = color;
            }
            Led _Led = new Led(name, isOn, Brightness.From(brightness), colors);
            return _Led;
        }

        //Gets the number of rows and columns
        public int GetRowsNumber() => Rows;
        public int GetColumnsNumber() => Columns;

        //Turn on all the led
        public void SwitchOnAll()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < Rows; c++)
                {
                    if (_MatrixLed[r, c].TurnOnOrOff()==false) 
                        _MatrixLed[r, c].TurnOnOrOff();
                }
            }
        }
        //Turn off all the led
        public void SwitchOffAll()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < Rows; c++)
                {
                    if (_MatrixLed[r, c].TurnOnOrOff() == true)
                        _MatrixLed[r, c].TurnOnOrOff();
                }
            }
        }

        //Change the intensity of oll the led in a one specified
        public void SetIntensityAll(byte intensity)
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < Rows; c++)
                    _MatrixLed[r, c].ChangeBrightness(intensity);
            }
        }

        //Return the led
        public Led GetLed(int row, int column)
        {
            return _MatrixLed[row, column];
        }
        //Return all the led in a determined row
        public Led[] GetLedInRow(int row)
        {
            Led[] leds= new Led[Rows];
            for (int c = 0; c < Columns; c++)
                leds[c]=_MatrixLed[row, c];
            return leds;
        }
        //Return all the led in a determined column
        public Led[] GetLedInColumn(int column)
        {
            Led[] leds = new Led[Columns];
            for (int r = 0; r < Rows; r++)
                leds[r] = _MatrixLed[r, column];
            return leds;
        }
    }
}