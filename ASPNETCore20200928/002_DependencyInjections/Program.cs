﻿using System;

namespace _002_DependencyInjections
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BadCar Sample

            BadCarService badCarService = new BadCarService();
            badCarService.RepairCar(new BadCar { Marke = "Opel", Baujahr = DateTime.Now, Radio = true, Type="Kadett" });
            #endregion

            #region Car Sample

            ICarService carService = new CarService();
            carService.RepairCar(new Car { Marke = "BMW", Type = "3", Baujahr = DateTime.Now, Radio = true });


            ICarService testService = new CarService();
            carService.RepairCar(new MockCar());
            #endregion
        }
    }


    #region Bad Sample
    public class BadCar // Beispiel1: Entwicklungsabläuft mit Testen: Car-Klasse benötigt 2-3 Wochen
                     // Beispiel2: Car - Klasse liegt in einer Dll (Entities.dll) 
    {
        public string Marke { get; set; } //AutoProperties -> Zur Laufzeit wird eine Variable mit für Marke im Hintergrund angelegt 

        public string Type { get; set; }

        public DateTime Baujahr { get;set; }

        private bool _radio { get; set; }

        public bool Radio
        {
            get 
            {
                return  this._radio;  
            }

            set
            {
                this._radio = value;
            }
        }
    }



    public class BadCarService // Beispiel1: Entwicklungsabläuft mit Testen: 1-2 Wochen
                            //Beispiel 2: CarService liegt in der Service.dll
    {
        // RepairCar Methode ist erst Testbar, wenn die Car-Klasse fertig implementiert ist. 
        public void RepairCar(BadCar car)
        {
            //mach was mit dem car-objekt
        }
    }
    #endregion

    
    #region DependencyInjection Beispiel


    //ICar -> ProjectSharedLibrary.dll
    public interface ICar
    {
        string Marke { get; set; }
        string Type { get; set; }
        DateTime Baujahr { get; set; }
        bool Radio { get; set; }
    }


    // Car -> Entities.dll 
    public class Car : ICar
    {
        public string Marke { get; set; }
        public string Type { get; set; }
        public DateTime Baujahr { get; set; }
        public bool Radio { get; set; }
    }



    public interface ICarService
    {
        void RepairCar(ICar car);
    }





    //Welche Referenzen werden benötigt? -> ProjectSharedLibrary.dll
    public class CarService : ICarService
    {
        public void RepairCar(ICar car)
        {
            //Mach was....
        }
    }


    //Test.dll
    public class MockCar : ICar
    {
        public string Marke { get; set; } = "Porsche";
        public string Type { get; set; } = "der schnellste";
        public DateTime Baujahr { get; set; } = new DateTime(2020, 08, 23);
        public bool Radio { get; set; } = false;
    }


    #endregion
}