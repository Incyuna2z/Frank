using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesting
{
    class DeviceClassV3
    {
        private string name = "";
        private StatusType status = StatusType.None;

        public DeviceClassV3(string Name)
        {
            name = Name;
        }

        public void set_status(StatusType Status)
        {
            if (IsStatusValid(Status))
            {
                status = Status;
            }
            else
            {
                Exception e = new Exception("You enter a invalid value, Status just could be 'On' or 'Off'");
                throw e;
            }
        }

        public string read_status()
        {
            return status.ToString();
        }

        public string read_name()
        {
            return name;
        }

        public bool IsStatusValid(StatusType Status)
        {
            if (Status == StatusType.Off || Status == StatusType.On)
                return true;
            else
                return false;
        }
    }

    public class testV3
    {
        [Fact]
        public void testMethod1()
        {
            DeviceClassV3 testClassV3 = new DeviceClassV3("Drawing Room Light");
            testClassV3.set_status(StatusType.On);
            Assert.Equal("On", testClassV3.read_status());
        }
    }

}
