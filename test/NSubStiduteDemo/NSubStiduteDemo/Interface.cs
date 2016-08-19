using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSubStiduteDemo
{
    public interface ICalculator
    {

        int add(int x, int y);

        string State { get; set; }
    }

}
