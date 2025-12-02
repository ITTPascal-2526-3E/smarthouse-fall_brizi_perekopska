using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.HomeAppliances;
using BlaisePascal.SmartHouse.Domain.UsefullClasses;

namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class AirFryerTests
    {
        [Fact]
        public void StartTheCooking_TemperatureIs79_CookingNotStart() 
        {
            var AirFryer = new AirFryer("AirFryer1", true);

            AirFryer.StartTheCooking(AirFryer.CookingType.Fryed, 79 ,new Time(0,0,15));

            Assert.NotEqual(AirFryer.CookingType.Fryed,AirFryer.LastCookingMethod);
        }

        [Fact]
        public void StartTheCooking_TemperatureIs201_CookingNotStart() 
        {
            var AirFryer = new AirFryer("AirFryer1", true);

            AirFryer.StartTheCooking(AirFryer.CookingType.Fryed, 201, new Time(0, 0, 15));

            Assert.NotEqual(AirFryer.CookingType.Fryed, AirFryer.LastCookingMethod);
        }

        [Fact]
        public void StartTheCooking_TemperatureIsInTheAcceptable_CookingStart()
        {
            var AirFryer = new AirFryer("AirFryer1", true);

            AirFryer.StartTheCooking(AirFryer.CookingType.Fryed, 180, new Time(0, 0, 15));

            Assert.Equal(AirFryer.CookingType.Fryed, AirFryer.LastCookingMethod);
        }

        [Fact]
        public async Task StartTheCooking_StopTurnTrueFromTheMethod_TheCookingStop() 
        {
            var AirFryer = new AirFryer("AirFryer1", true);

            AirFryer.StartTheCooking(AirFryer.CookingType.Fryed, 180, new Time(0, 0, 15));
            AirFryer.StopTheCooking();
            await Task.Delay(1000);
            Assert.Equal(AirFryer.Stop, false);
        }

    }
}
