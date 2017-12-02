using lab5.Models;
using lab5.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab5.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UchetContext db)
        {
            db.Database.EnsureCreated();

            int brandsNumber = 40;
            int ownersNumber = 40;
            int carsNumber = 100;

            InitializeBrands(db,  brandsNumber);
            InitializeOwners(db, ownersNumber);
            InitializeCars(db, carsNumber, brandsNumber, ownersNumber);

        }

        private static void InitializeCars(UchetContext db, int carsNumber, int brandsNumber , int ownersNumber)
        {
            db.Database.EnsureCreated();

            // Проверка занесены ли Cars
            if (db.Cars.Any())
            {
                return;   // База данных инициализирована
            }


            int brandID;
            int ownerID;
            int carRegistrationNumber;
            int carPhoto;
            int carNumberOfBody;
            int carNumberOfMotor;
            int carNumberOfPassport;
            DateTime carReleaseDate;
            DateTime carRegistrationDate;
            DateTime carLastCheckupDate;
            string carColor;
            string carDescription;


            Random randObj = new Random(1);

            //Заполнение таблицы емкостей
            for (int OwnerID = 1; OwnerID <= ownersNumber; OwnerID++)
            {
                carColor = MyRandom.RandomString(7);
                carDescription = MyRandom.RandomString(10);

                carReleaseDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                carRegistrationDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                carLastCheckupDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));

                brandID = randObj.Next(1, brandsNumber - 1);
                ownerID = randObj.Next(1, ownersNumber - 1);
                carRegistrationNumber = randObj.Next(1, 60000);
                carPhoto = randObj.Next(1, 500);
                carNumberOfBody = randObj.Next(1, 1000);
                carNumberOfMotor = randObj.Next(1, 1000);
                carNumberOfPassport = randObj.Next(1, 1000);




                db.Cars.Add(new Car
                {
                    BrandID = brandID,
                    OwnerID = ownerID,
                    CarRegistrationNumber = carRegistrationNumber,
                    CarPhoto = carPhoto,
                    CarNumberOfBody = carNumberOfBody,
                    CarNumberOfMotor = carNumberOfMotor,
                    CarNumberOfPassport = carNumberOfPassport,
                    CarReleaseDate = carReleaseDate,
                    CarRegistrationDate = carRegistrationDate,
                    CarLastCheckupDate = carLastCheckupDate,
                    CarColor = carColor,
                    CarDescription = carDescription,
                });
             
            

            }

            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

        }
        private static void InitializeBrands(UchetContext db, int brandsNumber)
        {
            db.Database.EnsureCreated();

            // Проверка занесены ли Brands
            if (db.Brands.Any())
            {
                return;   // База данных инициализирована
            }

            string brandName;
            string brandCompany;
            string brandCountry;
            DateTime brandStartDate;
            DateTime brandEndingDate;
            string brandCharacteristic;
            string brandCategory;
            string brandDescription;

            
            Random randObj = new Random(1);
            
            //Заполнение таблицы емкостей
            for (int BrandID = 1; BrandID <= brandsNumber; BrandID++)
            {
                brandName = MyRandom.RandomString(7);
                brandCompany = MyRandom.RandomString(10);
                brandCountry = MyRandom.RandomString(10);
                brandStartDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                brandEndingDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                brandCharacteristic = MyRandom.RandomString(15);
                brandCategory = MyRandom.RandomString(7);
                brandDescription = MyRandom.RandomString(10);


                db.Brands.Add(new Brand {  BrandName = brandName,
                 BrandCompany = brandCompany,
                    BrandCountry = brandCountry,
                    BrandStartDate = brandStartDate,
                    BrandEndingDate = brandEndingDate,
                    BrandCharacteristic = brandCharacteristic,
                    BrandCategory = brandCategory,
                    BrandDescription = brandDescription
                });
            }

            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

        }
        private static void InitializeOwners(UchetContext db, int ownersNumber)
        {
            db.Database.EnsureCreated();

            // Проверка занесены ли Owners
            if (db.Owners.Any())
            {
                return;   // База данных инициализирована
            }


            string ownerName;
            DateTime ownerBirthDate;
            string ownerAddress;
            string ownerPassport;
            int ownerNumberOfDriverLicense;
            DateTime ownerLicenseDeliveryDate;
            DateTime ownerLicenseValidityDate;
            string ownerCategory;
            string ownerMoreInformation;

            Random randObj = new Random(1);

            //Заполнение таблицы емкостей
            for (int OwnerID = 1; OwnerID <= ownersNumber; OwnerID++)
            {
                ownerName = MyRandom.RandomString(7);
                ownerAddress = MyRandom.RandomString(10);
                ownerPassport = MyRandom.RandomString(10);
                ownerBirthDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                ownerLicenseDeliveryDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                ownerLicenseValidityDate = new DateTime(randObj.Next(1990, 2016),
                   randObj.Next(1, 12),
                    randObj.Next(1, 28));
                ownerCategory = MyRandom.RandomString(15);
                ownerNumberOfDriverLicense = randObj.Next(1, 3000);
                ownerMoreInformation = MyRandom.RandomString(10);
                


                db.Owners.Add(new Owner
                {
                    OwnerName = ownerName,
                    OwnerBirthDate= ownerBirthDate,
                    OwnerAddress= ownerAddress,
                    OwnerPassport= ownerPassport,
                    OwnerNumberOfDriverLicense= ownerNumberOfDriverLicense,
                    OwnerLicenseDeliveryDate= ownerLicenseDeliveryDate,
                    OwnerLicenseValidityDate = ownerLicenseValidityDate,
                    OwnerCategory =ownerCategory,
                    OwnerMoreInformation =ownerMoreInformation
                });
            }

            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

        }


    }

}
