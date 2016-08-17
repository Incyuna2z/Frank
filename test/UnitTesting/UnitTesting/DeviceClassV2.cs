using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesting
{
    class DeviceClassV2
    {
        private string name = "";
        private string status = "";

        public DeviceClassV2(string Name)
        {
            name = Name;
            status = String.Empty;
        }

        public void set_status(string Status)
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
            return status;
        }

        public string read_name()
        {
            return status;
        }

        public bool IsStatusValid(string Status)
        {
            if(Status == "On" || Status == "Off")
                return true;
            else
            return false;
        }
    }
    
    public class testV2
    {
        [Fact]
        public void testingMethod1()
        {
            DeviceClassV2 testClassV2 = new DeviceClassV2("Bedroom light");
            testClassV2.set_status("On");
            Assert.Equal("On", testClassV2.read_status());
        }
    }
}
