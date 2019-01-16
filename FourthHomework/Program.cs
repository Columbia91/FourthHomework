using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ARRAY_SIZE = 5;
            Plane[] plane = new Plane[ARRAY_SIZE];
            for (int i = 0; i < plane.Length; i++)
            {
                plane[i] = new Plane();
            }

            int FastestPlaneTopSpeed = 0;
            for (int i = 0; i < plane.Length; i++)
            {
                plane[i].ComparisonOfSpeed(ref FastestPlaneTopSpeed);
            }
            Console.WriteLine(FastestPlaneTopSpeed);
            
            Console.WriteLine(Plane.CountOfPlane);
            
            Console.ReadLine();
        }
    }
    public partial class Plane
    {
        public double Payload() // расчет полезной нагрузки
        {
            return maximumTakeoffWeight - operatingEmptyWeight;
        }
    }
}
