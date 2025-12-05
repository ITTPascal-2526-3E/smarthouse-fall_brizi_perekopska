using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.UsefulClasses;
using BlaisePascal.SmartHouse.Domain.Illumination;

namespace BlaisePascal.SmartHouse.Domain.UnitTests.IlluminationTests
{
    public class LampsRowTests
    {
        // Constructor test
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            int lampsNum = 3;
            var LampsRow = new LampsRow(lampsNum, newLamp);
            Assert.Equal(lampsNum, LampsRow.LampsList.Count);
            foreach (var lamp in LampsRow.LampsList)
                Assert.Equal(newLamp, lamp);
        }

        public void Constructor_NegativeLampsNum_ShouldThrowArgumentException()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            Assert.Throws<ArgumentException>(() => new LampsRow(-1, newLamp));
        }

        // CountLamps test
        [Fact]
        public void CountLamps_ShouldReturnCorrectCount()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(5, newLamp); /// Create a LampsRow with 5 lamps
            int expectedCount = 5;
            int actualCount = LampsRow.CountLamps();
            Assert.Equal(expectedCount, actualCount);
        }

        // AddLamp tests
        [Fact]
        public void AddLamp_ValidLamp_ShouldIncreaseLampsCount()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
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
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            Assert.Throws<ArgumentNullException>(() => LampsRow.AddLamp(null));
        }

        // InsertLampInPosition tests
        [Fact]
        public void InsertLampInPosition_ValidPosition_ShouldIncreaseLampsCount()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            int initialCount = LampsRow.LampsList.Count;
            LampsRow.InsertLampInPosition(newLamp, 1); /// Insert at position 1
            int finalCount = LampsRow.LampsList.Count;
            Assert.Equal(initialCount + 1, finalCount);
        }

        [Fact]
        public void InsertLampInPosition_InvalidPosition_ShouldThrowExeption()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            Assert.Throws<ArgumentOutOfRangeException>(() => LampsRow.InsertLampInPosition(newLamp, 5)); /// Invalid position
        }

        // RemoveLamp tests
        [Fact]
        public void RemoveLamp_ExistingLamp_ShouldThrowExeption()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            int initialCount = LampsRow.LampsList.Count;
            LampsRow.RemoveLamp(newLamp);
            int finalCount = LampsRow.LampsList.Count;
            Assert.Equal(initialCount - 1, finalCount);
        }

        [Fact]
        public void RemoveLamp_NullLamp_ShouldThrowExetpion()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            Assert.Throws<ArgumentException>(() => LampsRow.RemoveLamp(null));
        }

        [Fact]
        public void RemoveLamp_EmptyLampsList_ShouldThrowExetpion()
        {
            bool isOn = true;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(0, newLamp); /// Create a LampsRow with 0 lamps
            Assert.Throws<ArgumentException>(() => LampsRow.RemoveLamp(newLamp));
        }

        [Fact]
        public void RemoveLamp_NonExistingLamp_ShouldThrowExetpion()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            var nonExistingLamp = new Lamp("aaa", isOn, 50, [0, 0, 0], "Incandescent", new Time(9, 0, 0), new Time(21, 0, 0)); /// Different lamp
            Assert.Throws<ArgumentException>(() => LampsRow.RemoveLamp(nonExistingLamp));
        }

        // RemoveLamp by name tests
        [Fact]
        public void RemoveLampByName_ExistingLamp_ShouldDecreaseLampsCount()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            int initialCount = LampsRow.LampsList.Count;
            LampsRow.RemoveLampByName("aaa");
            int finalCount = LampsRow.LampsList.Count;
            Assert.Equal(initialCount - 1, finalCount);
        }

        [Fact]
        public void RemoveLampByName_NonExistingLamp_ShouldThrowExetpion()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            Assert.Throws<ArgumentException>(() => LampsRow.RemoveLampByName("bbb"));
        }

        // RemoveLampById tests
        [Fact]
        public void RemoveLampById_ExistingLamp_ShouldDecreaseLampsCount()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            var lampId = LampsRow.LampsList[0].Id; /// Get the ID of the first lamp
            int initialCount = LampsRow.LampsList.Count;
            LampsRow.RemoveLampById(lampId);
            int finalCount = LampsRow.LampsList.Count;
            Assert.Equal(initialCount - 1, finalCount);
        }

        [Fact]
        public void RemoveLampById_NonExistingLamp_ShouldThrowExetpion()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(2, newLamp); /// Create a LampsRow with 2 lamps
            Guid nonExistingId = Guid.NewGuid(); /// Generate a random GUID
            Assert.Throws<ArgumentException>(() => LampsRow.RemoveLampById(nonExistingId));
        }

        // TurnOnOrOff tests
        [Fact]
        public void TurnOnOrOffAllLamps_AllLampsOn_ShouldTurnOffAllLamps()
        {
            bool isOn = true;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(3, newLamp); /// Create a LampsRow with 3 lamps
            LampsRow.TurnOnOrOffAllLamps();
            bool state = true;
            /// Since all lamps are initially off, after turning on, all should be on
            foreach (var lamp in LampsRow.LampsList)
            {
                if (lamp.Brightness != 0)
                    state = false;
            }
            Assert.True(state);
        }

        [Fact]
        public void TurnOnOrOffAllLamps_AllLampsOff_ShouldTurnOnAllLamps()
        {
            bool isOn = false;
            var newLamp = new Lamp("aaa", isOn, 100, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(3, newLamp); /// Create a LampsRow with 3 lamps
            LampsRow.TurnOnOrOffAllLamps();
            bool state = true;
            /// Since all lamps are initially off, after turning on, all should be on
            foreach (var lamp in LampsRow.LampsList)
            {
                if (lamp.Brightness == 0)
                    state = false;
            }
            Assert.Equal(true, state);
        }

        // TurnOnOrOffLampByName tests
        [Fact]
        public void TurnOnOrOffLampByName_ExistingLamp_ShouldChangeState()
        {
            bool isOn = false;
            var defaultLamp = new Lamp("a", isOn, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(1, defaultLamp); /// Create a LampsRow with 1 lamps
            var newLamp = new Lamp("aa", isOn, 50, [0, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Lamp to be added
            LampsRow.AddLamp(newLamp); /// Add a lamp with name "aa"
            var anotherLamp = new Lamp("aaa", isOn, 50, [255, 0, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Another lamp to be added
            LampsRow.AddLamp(anotherLamp); /// Add a lamp with name "aaa"
            LampsRow.TurnOnOrOffLampByName("aaa");
            bool aaaLampState = LampsRow.LampsList.Find(lamp => lamp.Name == "aaa").IsOn;
            /// Check if the lamp with name "aaa" has changed its state
            Assert.True(aaaLampState);
        }

        [Fact]
        public void TurnOnOrOffLampByName_NonExistingLamp_ShouldThrowException()
        {
            bool isOn = false;
            var defaultLamp = new Lamp("a", isOn, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(1, defaultLamp); /// Create a LampsRow with 1 lamps
            Assert.Throws<ArgumentException>(() => LampsRow.TurnOnOrOffLampByName("nonexistent"));
        }

        // TurnOnOrOffLampById tests
        [Fact]
        public void TurnOnOrOffLampById_ExistingLamp_ShouldChangeState()
        {
            bool isOn = false;
            var defaultLamp = new Lamp("a", isOn, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(1, defaultLamp); /// Create a LampsRow with 1 lamps
            var newLamp = new Lamp("aa", isOn, 50, [0, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Lamp to be added
            LampsRow.AddLamp(newLamp); /// Add a lamp
            var lampId = newLamp.Id; /// Get the ID of the newly added lamp
            LampsRow.TurnOnOrOffLampById(lampId);
            bool lampState = LampsRow.LampsList.Find(lamp => lamp.Id == lampId).IsOn;
            /// Check if the lamp with the specified ID has changed its state
            Assert.True(lampState);
        }

        [Fact]
        public void TurnOnOrOffLampById_NonExistingLamp_ShouldThrowException()
        {
            bool isOn = false;
            var defaultLamp = new Lamp("a", isOn, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(1, defaultLamp); /// Create a LampsRow with 1 lamps
            Guid nonExistingId = Guid.NewGuid(); /// Generate a random GUID
            Assert.Throws<ArgumentException>(() => LampsRow.TurnOnOrOffLampById(nonExistingId));
        }

        // ChangeBrightnessAllLamps tests
        [Fact]
        public void ChangeBrightnessForAllLamps_ValidBrightness_ShouldChangeBrightnessOfAllLamps()
        {
            bool isOn = true;
            var newLamp = new Lamp("aaa", isOn, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(3, newLamp); /// Create a LampsRow with 3 lamps
            byte newBrightness = 80;
            LampsRow.ChangeBrightnessForAllLamps(newBrightness);
            bool state = true;
            /// Check if all lamps have the new brightness
            foreach (var lamp in LampsRow.LampsList)
            {
                if (lamp.Brightness != newBrightness)
                    state = false;
            }
            Assert.True(state);
        }

        // ChangeBrightnessByName tests
        [Fact]
        public void ChangeBrightnessByName_ExistingName_ShouldChangeTheBrightness()
        {
            byte newBrightness = 90;
            var defaultLamp = new Lamp("a", false, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(1, defaultLamp); /// Create a LampsRow with 1 lamps
            var newLamp = new Lamp("aa", false, 9, [0, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Lamp to be added
            LampsRow.AddLamp(newLamp); /// Add a lamp with name "aa"
            var anotherLamp = new Lamp("aaa", false, 33, [255, 0, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Another lamp to be added
            LampsRow.AddLamp(anotherLamp); /// Add a lamp with name "aaa"
            LampsRow.ChangeBrightnessByName("aaa", newBrightness);
            byte aaaLampBrightness = LampsRow.LampsList.Find(lamp => lamp.Name == "aaa").Brightness;
            /// Check if the lamp with name "aaa" has changed its state
            Assert.Equal(newBrightness, aaaLampBrightness);
        }
        [Fact]
        public void ChangeBrightnessByName_NonExistingName_ShouldThrowExeption()
        {
            byte newBrightness = 90;
            var defaultLamp = new Lamp("a", false, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(1, defaultLamp); /// Create a LampsRow with 1 lamps
            var newLamp = new Lamp("aa", false, 9, [0, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Lamp to be added
            LampsRow.AddLamp(newLamp); /// Add a lamp with name "aa"
            var anotherLamp = new Lamp("aaa", false, 33, [255, 0, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Another lamp to be added
            LampsRow.AddLamp(anotherLamp); /// Add a lamp with name "aaa"
            Assert.Throws<ArgumentException>(() => LampsRow.ChangeBrightnessByName("wronName", newBrightness));
        }

        // ChangeBrightnessById tests
        [Fact]
        public void ChangeBrightnessById_ExistingName_ShouldChangeTheBrightness()
        {
            var defaultLamp = new Lamp("a", false, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(5, defaultLamp); /// Create a LampsRow with 5 lamps
            var newLamp = new Lamp("aa", false, 50, [0, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Lamp to be added
            LampsRow.AddLamp(newLamp); /// Add a lamp
            var ExistinglampId = newLamp.Id; /// Get the ID of the newly added lamp
            LampsRow.ChangeBrightnessById(ExistinglampId, 20);
            var lampId = LampsRow.LampsList.Find(lamp => lamp.Id == ExistinglampId).Id;
            /// Check if the lamp with the specified ID has changed its state
            Assert.Equal(ExistinglampId, lampId);
        }
        [Fact]
        public void ChangeBrightnessById_NonExistingName_ShouldThrowExeption()
        {
            Guid nonExistingId = Guid.NewGuid();
            byte newBrightness = 90;
            var defaultLamp = new Lamp("a", false, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(3, defaultLamp); /// Create a LampsRow with 3 lamps
            Assert.Throws<ArgumentException>(() => LampsRow.TurnOnOrOffLampById(nonExistingId));
        }

        // ChangeColorAllLamps tests
        [Fact]
        public void ChangeColorForAllLamps_ValidColor_ShouldChangeColorOfAllLamps()
        {
            bool isOn = true;
            var newLamp = new Lamp("aaa", isOn, 50, [255, 255, 255], "LED", new Time(8, 0, 0), new Time(22, 0, 0)); /// Some default lamp settings
            var LampsRow = new LampsRow(3, newLamp); /// Create a LampsRow with 3 lamps
            byte[] newColor = new byte[3] { 0, 255, 0 }; /// Green color
            LampsRow.ChangeColorForAllLamps(newColor);
            bool state = true;
            /// Check if all lamps have the new color
            foreach (var lamp in LampsRow.LampsList)
            {
                if (!lamp.Color.SequenceEqual(newColor))
                    state = false;
            }
            Assert.True(state);
        }

        [Fact]
        public void ChangeColorByName_ExistingName_ShouldChangeColorOfAllLamps()
        {

        }
    }
}
