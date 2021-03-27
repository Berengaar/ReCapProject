using Business.Concrete;
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
            // CarTest();
            //ColorTest();

            // DtoTest1();

            //ModelTest();

            //ModelDetails();

            RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();

            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.RentDate);
            }
        }

        private static void ModelDetails()
        {
            ModelManager modelManager = new ModelManager(new EfModelDal());
            var result = modelManager.GetModelDetails();
            foreach (var detail in result.Data)
            {
                Console.WriteLine("ModelId : " + detail.ModelId + " ----- " + "BrandName : " + detail.BrandName);
                Console.WriteLine("----");
                Console.WriteLine("To the join is completed");
            }
        }

        private static void ModelTest()
        {
            ModelManager modelManager = new ModelManager(new EfModelDal());
            var result = modelManager.GetAll();
            foreach (var model in result.Data)
            {
                Console.WriteLine(model.ModelYear);
            }
        }

        private static void DtoTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAllCarsDetails();
            foreach (var detail in result.Data)
            {
                Console.WriteLine("CarId : " + detail.CarId + " ----- " + "ColorId : " + detail.ColorId);
                Console.WriteLine("----");
                Console.WriteLine("To the join is completed");
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

           if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId+"   /   "+car.DailyPrice);
                }
            }
        }
    }
}
