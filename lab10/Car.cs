using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace lab10
{
    public class Car
    {
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("year")]
        public int Year { get; set; }
        [XmlElement("engine")]
        public Engine Motor { get; set; }

        public Car() { }

        public Car(string model, Engine motor, int year)
        {
            Model = model;
            Motor = motor;
            Year = year;
        }

        [XmlIgnore]
        public string EngineModel => $"{Motor.Model}";
        public string EngineDisplacement => $"{Motor.Displacement}L";
        public string EnginePower => $"{Motor.HorsePower}HP";
        
    }

    public class Engine : IComparable<Engine>
    {
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlElement("displacement")]
        public double Displacement { get; set; }
        [XmlElement("horsePower")]
        public double HorsePower { get; set; }

        public Engine() { }

        public Engine(double displacement, double horsePower, string model)
        {
            Displacement = displacement;
            HorsePower = horsePower;
            Model = model;
        }

        public int CompareTo(Engine other)
        {
            if (other == null) return 1;
            return HorsePower.CompareTo(other.HorsePower);
        }
    }

    [XmlRoot("cars")]
    public class Cars
    {
        [XmlElement("car")]
        public List<Car> MyCars { get; set; }
    }
}
