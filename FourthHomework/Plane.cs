using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthHomework
{
    public partial class Plane
    {
        private string brandOfThePlane;         // Название самолета
        private string typeOfThePlane;          // Тип самолета
        private DateTime dateOfManufacture;     // Дата производства
        private double operatingEmptyWeight;    // Рабочий пустой вес
        private double maximumTakeoffWeight;    // Максимальная взлетная масса
        private int fuelTankCapacity;           // Объем топливного бака
        private int maxSpeed;                   // Максимальная скорость
        private static int totalNeededFuel = 0; // Общее необходимое количество топлива
        private static int countOfPlane = 0;    // Количество самолетов

        static Plane() {}

        public Plane()
        {
            CountOfPlane++;
        }
        public Plane(DateTime dateOfManufacture)
        {
            this.dateOfManufacture = dateOfManufacture;
        }
        public Plane(string brandOfThePlane, string typeOfThePlane)
        {
            this.brandOfThePlane = brandOfThePlane;
            this.typeOfThePlane = typeOfThePlane;
            CountOfPlane++;
        }
        public Plane(string brandOfThePlane, string typeOfThePlane, DateTime dateOfManufacture, double operatingEmptyWeight,
            double maximumTakeoffWeight, int fuelTankCapacity, int maxSpeed, int flightRange)
        {
            this.brandOfThePlane = brandOfThePlane;
            this.typeOfThePlane = typeOfThePlane;
            this.dateOfManufacture = dateOfManufacture;
            this.operatingEmptyWeight = operatingEmptyWeight;
            this.maximumTakeoffWeight = maximumTakeoffWeight;
            this.fuelTankCapacity = fuelTankCapacity;
            this.maxSpeed = maxSpeed;
            CountOfPlane++;
            totalNeededFuel += fuelTankCapacity;
        }
        
        #region Методы доступа
        public string BrandOfThePlane // Название самолета
        {
            get
            {
                return brandOfThePlane;
            }
            set
            {
                brandOfThePlane = value;
            }
        }
        public string TypeOfThePlane // Тип самолета
        {
            get
            {
                return typeOfThePlane;
            }
            set
            {
                typeOfThePlane = value;
            }
        }
        public DateTime DateOfManufacture // Дата производства
        {
            get
            {
                return dateOfManufacture;
            }
            set
            {
                dateOfManufacture = value;
            }
        }
        public double OperatingEmptyWeight // O.E.W рабочий пустой вес
        {
            get
            {
                return operatingEmptyWeight;
            }
            set
            {
                operatingEmptyWeight = value;
            }
        }
        public double MaximumTakeoffWeight // M.T.O.W максимальная взлетная масса
        {
            get
            {
                return maximumTakeoffWeight;
            }
            set
            {
                maximumTakeoffWeight = value;
            }
        }
        public int FuelTankCapacity // Объем топливного бака
        {
            get
            {
                return fuelTankCapacity;
            }
            set
            {
                totalNeededFuel += (value - fuelTankCapacity);
                fuelTankCapacity = value;
            }
        }
        public int MaxSpeed // Максимальная скорость
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                maxSpeed = value;
            }
        }
        public static int CountOfPlane { get => countOfPlane; set => countOfPlane = value; }
        public static int TotalNeededFuel { get => totalNeededFuel; set => totalNeededFuel = value; }
        #endregion

        public void Show() // вывод на консоль
        {
            Console.WriteLine("Название самолета:\t\t" + brandOfThePlane + 
                "\nТип самолета:\t\t" + typeOfThePlane + 
                "\nДата производства:\t\t" + dateOfManufacture +
                "\nРабочий пустой вес:\t\t" + operatingEmptyWeight +
                "\nМаксимальная взлетная масса:\t\t" + maximumTakeoffWeight +
                "\nОбъем топливного бака:\t\t" + fuelTankCapacity +
                "\nМаксимальная скорость:\t\t" + maxSpeed);
        }
        public string PlaneAge() // подсчет возраста самолета
        {
            DateTime difference = new DateTime((DateTime.Now - dateOfManufacture).Ticks);

            string age = string.Format("{0} лет {1} месяцев", difference.Year - 1, difference.Month - 1 /*difference.Day - 1*/);
            return age;
        }
        public bool IsSupersonic() // является ли самолет сверхзвуковым
        {
            const double MACH_NUMBER = 1.2;             // начальное число Маха для сверхзвуковых самолетов
            const int MACH_NUMBER_2= 5;                 // конечное число Маха для сверхзвуковых самолетов
            const double SPEED_OF_SOUND = 1191.6;       // скорость звука в воздухе

            if ((maxSpeed / SPEED_OF_SOUND > MACH_NUMBER) && (maxSpeed / SPEED_OF_SOUND) < MACH_NUMBER_2)
                return true;
            return false;
        }
        public void ComparisonOfSpeed(ref int FastestPlaneTopSpeed) // сравнение максимальных скоростей
        {
            if (FastestPlaneTopSpeed < maxSpeed) FastestPlaneTopSpeed = maxSpeed;
        }
    }
}