using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTesting
{
    public class DeviceClassV1
    {
        public string name = "";
        public string status = "";

        public DeviceClassV1(string Name)
        {
            name = Name;
        }

        public void set_status(string Status)
        {
            status = Status;
        }

        public string read_status()
        {
            return status;
        }
    }

    public class testV1
    {
        [Fact]
        public void testingMethod1()
        {
            DeviceClassV1 testClassV1 = new DeviceClassV1("kitchen light");
            testClassV1.set_status("on");
            Assert.Equal("on", testClassV1.read_status());
            //Assert.Equal("off", status);

            /*
            1. The specification of the variable status say that it should display the current switching state of a device using the values "On" or "Off",
            but in our case, status can be allocated to any other value, such as "30%"
            2. Once this check has been buit in, we also have to make sure that status can not be manipulated as well. 
            */
        }
    }

}
