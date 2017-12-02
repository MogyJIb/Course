using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab5.Models;

namespace lab5.Controllers
{
    public class HomeController : Controller
    {
        private UchetContext _db;

        public HomeController(UchetContext db)
        {
            _db = db;
        }

        public IActionResult Cars()
        {
           
            List<Car> cars = _db.Cars
                .Select(t => new Car {
                    CarID = t.CarID,
                    BrandID = t.BrandID,
                    OwnerID = t.OwnerID,
                    CarRegistrationNumber = t.CarRegistrationNumber,
                    CarPhoto = t.CarPhoto,
                    CarNumberOfBody = t.CarNumberOfBody,
                    CarNumberOfMotor = t.CarNumberOfMotor,
                    CarNumberOfPassport = t.CarNumberOfPassport,
                    CarReleaseDate = t.CarReleaseDate,
                    CarRegistrationDate = t.CarRegistrationDate,
                    CarLastCheckupDate = t.CarLastCheckupDate,
                    CarColor = t.CarColor,
                    CarDescription = t.CarDescription,
                    Brand = t.Brand,
                    Owner = t.Owner
                })
                .Take(10)
                .ToList();
            CarViewModel carViewModel = new CarViewModel { Cars = cars };
            return View(carViewModel);
        }

   

        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
