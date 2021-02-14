﻿using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.Entity_Framework;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();

            // DtoTest1();

            //ModelTest();

            ModelManager modelManager = new ModelManager(new EfModelDal());
            foreach (var detail in modelManager.GetModelDetails())
            {
                Console.WriteLine("ModelId : " + detail.ModelId + " ----- " + "BrandName : " + detail.BrandName);
                Console.WriteLine("----");
                Console.WriteLine("Join edildi");
            }
        }

        private static void ModelTest()
        {
            ModelManager modelManager = new ModelManager(new EfModelDal());
            foreach (var model in modelManager.GetAll())
            {
                Console.WriteLine(model.ModelYear);
            }
        }

        private static void DtoTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var detail in carManager.GetCarDetails())
            {
                Console.WriteLine("CarId : " + detail.CarId + " ----- " + "ColorId : " + detail.ColorId);
                Console.WriteLine("----");
                Console.WriteLine("Join edildi");
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ColorId);
            }
        }
    }
}