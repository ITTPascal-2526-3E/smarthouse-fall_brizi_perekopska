using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefullClasses;
using BlaisePascal.SmartHouse.Domain.Illumination;

namespace BlaisePascal.SmartHouse.Domain.UnitTests.IlluminationTests
{
    public class LampsRowTests
    {
        // AddLamp tests
        [Fact]
        public void AddLamp_ValidLamp_ShouldIncreaseLampsCount()
        {
            bool isOn = false;
            var newLamp = new Lamp(isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            int initialCount = LampsRow.LampsList.Count;
            LampsRow.AddLamp(newLamp);
            int finalCount = LampsRow.LampsList.Count;
            Assert.Equal(initialCount + 1, finalCount);
        }

        [Fact]
        public void AddLamp_NullLamp_ShouldThrowExeption()
        {
            bool isOn = false;
            var newLamp = new Lamp(isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            Assert.Throws<ArgumentNullException>(() => LampsRow.AddLamp(null));
        }

        // RemoveLamp tests
        [Fact]
        public void RemoveLamp_ExistingLamp_ShouldThrowExeption()
        {
            bool isOn = false;
            var newLamp = new Lamp(isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            int initialCount = LampsRow.LampsList.Count;
            LampsRow.RemoveLamp(newLamp);
            int finalCount = LampsRow.LampsList.Count;
            Assert.Equal(initialCount - 1, finalCount);
        }

        [Fact]
        public void RemoveLamp_NonExistingLamp_ShouldThrowExetpion()
        {
            bool isOn = false;
            var newLamp = new Lamp(isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            var nonExistingLamp = new Lamp(isOn, 50, [255, 0, 0], "Incandescent", new Time(9, 0, 0), new Time(21, 0, 0)); /// Different lamp
            Assert.Throws<ArgumentException>(() => LampsRow.RemoveLamp(nonExistingLamp));
        }

        // TurnOnOrOff tests
        [Fact]
        public void TurnOnOrOffAllLamps_AllLampsOn_ShouldTurnOffAllLamps()
        {
            bool isOn = true;
            var newLamp = new Lamp(isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(3, newLamp); /// Create a LampsRow with 3 lamps
            LampsRow.TurnOnOrOffAllLamps();
            bool state = true;
            /// Since all lamps are initially off, after turning on, all should be on
            foreach (var lamp in LampsRow.LampsList)
            {
                if(lamp.Brightness!=0) 
                    state = false;
            }
            Assert.Equal(true, state);
        }

        [Fact]
        public void TurnOnOrOffAllLamps_AllLampsOff_ShouldTurnOnAllLamps()
        {
            bool isOn = false;
            var newLamp = new Lamp(isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(3, newLamp); /// Create a LampsRow with 3 lamps
            LampsRow.TurnOnOrOffAllLamps();
            bool state = true;
            /// Since all lamps are initially off, after turning on, all should be on
            foreach (var lamp in LampsRow.LampsList)
            {
                if(lamp.Brightness==0) 
                    state = false;
            }
            Assert.Equal(true, state);
        }

        // ChangeBrightnessAllLamps tests
        [Fact]
        public void ChangeBrightnessAllLamps_ValidBrightness_ShouldChangeBrightnessOfAllLamps()
        {
            bool isOn = true;
            var newLamp = new Lamp(isOn, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(3, newLamp); /// Create a LampsRow with 3 lamps
            byte newBrightness = 80;
            LampsRow.ChangeBrightnessAllLamps(newBrightness);
            bool state = true;
            /// Check if all lamps have the new brightness
            foreach (var lamp in LampsRow.LampsList)
            {
                if(lamp.Brightness != newBrightness) 
                    state = false;
            }
            Assert.Equal(true, state);
        }

        // ChangeColorAllLamps tests
        [Fact]
        public void ChangeColorAllLamps_ValidColor_ShouldChangeColorOfAllLamps()
        {
            bool isOn = true;
            var newLamp = new Lamp(isOn, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(3, newLamp); /// Create a LampsRow with 3 lamps
            byte[] newColor = new byte[3] { 0, 255, 0 }; /// Green color
            LampsRow.ChangeColorAllLamps(newColor);
            bool state = true;
            /// Check if all lamps have the new color
            foreach (var lamp in LampsRow.LampsList)
            {
                if(!lamp.Color.SequenceEqual(newColor)) 
                    state = false;
            }
            Assert.Equal(true, state);
        }
    }
}
