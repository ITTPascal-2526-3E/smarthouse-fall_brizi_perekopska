using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Security;

namespace BlaisePascal.SmartHouse.Domain.UnitTests
{
    public class DoorTests
    {
        [Fact]
        public void LockUnlockTheDoor_IsLockAndTurnedUnlock()
        {
            bool isClosed = true;
            var door = new Door(isClosed);

            var initialState = isClosed;
            var newState = door.LockUnlockTheDoor();
            Assert.NotEqual(initialState, newState);
        }
    }
}
