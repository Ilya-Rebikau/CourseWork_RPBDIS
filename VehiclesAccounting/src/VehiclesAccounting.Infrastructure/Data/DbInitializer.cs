using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Infrastructure.Data;
/// <summary>
/// Initializer of data for database
/// </summary>
public static class DbInitializer
{
    /// <summary>
    /// Initialize data
    /// </summary>
    /// <param name="db">DbContext object</param>
    public static void Initialize(VehiclesContext db)
    {
        db.Database.EnsureCreated();
        Random rand = new();
        string name, surname, patronymic;
        string[] maleNames = { "Илья", "Александр", "Максим", "Павел", "Дмитрий", "Артём", "Сергей", "Андрей", "Алексей", "Кирилл",
                    "Михаил", "Никита", "Матвей", "Роман", "Егор", "Арсений", "Иван", "Денис", "Евгений", "Тимофей", "Владислав", "Игорь",  };
        string[] femaleNames = { "Анастасия", "Мария", "Анна", "Виктория", "Екатерина", "Наталья", "Марина", "Полина", "София",
                    "Дарья", "Алиса", "Ксения", "Александра", "Елена", "Ольга", "Евгения", "Ирина" };
        string[] maleSurnames = { "Ребиков", "Мозоль", "Корнеев", "Снежко", "Скуратович", "Климанский", "Ходанович", "Серенков",
                    "Ракицкий", "Крупка", "Бондарец", "Касьян", "Пантюшечкин", "Иванов", "Петров", "Васильев", "Смирнов", "Михайлов", "Попов",
                    "Павленок", "Бородий", "Лебедев", "Орлов" };
        string[] femaleSurnames = { "Ребикова", "Мозоль", "Корнеева", "Снежко", "Скуратович", "Климанская", "Ходанович", "Серенкова",
                    "Ракицкая", "Крупка", "Бондарец", "Касьян", "Пантюшечкина", "Иванова", "Петрова", "Васильева", "Смирнова", "Михайлова", "Попова",
                    "Павленок", "Бородий", "Лебедева", "Орлова" };
        string[] malePatronymics = { "Геннадьевич", "Александрович", "Павлович", "Сергеевич", "Ильич", "Максимович", "Дмитриевич",
                    "Артёмович", "Егорович", "Арсеньевич", "Иванович", "Евгеньевич", "Владиславович", "Игоревич", "Романович", "Михайлович"};
        string[] femalePatronymics = { "Геннадьевна", "Александровна", "Павловна", "Сергеевна", "Ильинична", "Максимовна", "Дмитриевна",
                    "Артёмовна", "Егоровна", "Арсеньевна", "Ивановна", "Евгеньевна", "Владиславовна", "Игоревна", "Романовна", "Михайловна"};
        string[] categories = { "A", "AM", "A1", "B", "C", "D", "BE", "CE", "DE", "F", "I" };
        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P",
                    "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        int countAlphabet = alphabet.GetLength(0);
        int countMaleNames = maleNames.GetLength(0);
        int countFemaleNames = femaleNames.GetLength(0);
        int countMaleSurnames = maleSurnames.GetLength(0);
        int countFemaleSurnames = femaleSurnames.GetLength(0);
        int countMalePatronymics = malePatronymics.GetLength(0);
        int countFemalePatronymics = femalePatronymics.GetLength(0);
        int countCategories = categories.GetLength(0);

        void CreateMale()
        {
            name = maleNames[rand.Next(1, countMaleNames)];
            surname = maleSurnames[rand.Next(1, countMaleSurnames)];
            patronymic = malePatronymics[rand.Next(1, countMalePatronymics)];
        }
        void CreateFemale()
        {
            name = femaleNames[rand.Next(1, countFemaleNames)];
            surname = femaleSurnames[rand.Next(1, countFemaleSurnames)];
            patronymic = femalePatronymics[rand.Next(1, countFemalePatronymics)];
        }
        DateTime RandomDate(int yearStart, int yearFinish)
        {
            DateTime start = new(yearStart, 1, 1);
            int range = (new DateTime(yearFinish, 12, 31) - start).Days;
            return start.AddDays(rand.Next(range));
        }

        if (!db.TrafficPoliceOfficers.Any())
        {
            int officersNumber = 500;
            string post;
            string[] officerPosts = { "Рядовой", "Младший сержант", "Сержант", "Старший сержант", "Старшина", "Прапорщик", "Старший прапорщик",
                    "Младший лейтенант", "Лейтенант", "Старший лейтенант", "Капитан", "Майор", "Подполковник", "Полковник", "Генерал-Майор",
                    "Генерал-Лейтенант", "Генерал-Полковник" };
            int countPosts = officerPosts.GetLength(0);
            for (int id = 1; id <= officersNumber / 2; id++)
            {
                CreateMale();
                post = officerPosts[rand.Next(countPosts)];
                db.TrafficPoliceOfficers.Add(new TrafficPoliceOfficer { Name = name, Surname = surname, Patronymic = patronymic, Post = post });
                CreateFemale();
                post = officerPosts[rand.Next(countPosts)];
                db.TrafficPoliceOfficers.Add(new TrafficPoliceOfficer { Name = name, Surname = surname, Patronymic = patronymic, Birthday = RandomDate(1960, 2000), Post = post });
            }
            db.SaveChanges();
        }
        if (!db.Owners.Any())
        {
            string CreateCategories()
            {
                string ownerCategories = "";
                int numberCategories = rand.Next(1, countCategories);
                for (int i = 0; i < numberCategories; i++)
                {
                    ownerCategories += categories[i] + " ";
                }
                return ownerCategories;
            }
            string GenerateLicenseNumber()
            {
                return rand.Next(0, 10).ToString() + alphabet[rand.Next(1, countAlphabet)] + alphabet[rand.Next(1, countAlphabet)] + " "
                    + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString();
            }
            string GeneratePassportInfo()
            {
                return alphabet[rand.Next(1, countAlphabet)] + alphabet[rand.Next(1, countAlphabet)] + rand.Next(0, 10).ToString()
                    + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString();
            }
            int ownersNumber = 500;
            for (int id = 1; id <= ownersNumber / 2; id++)
            {
                CreateMale();
                DateTime LicenseDate = RandomDate(1968, 2021);
                db.Owners.Add(new Owner
                {
                    Name = name,
                    Surname = surname,
                    Patronymic = patronymic,
                    Birthday = RandomDate(1950, 2005),
                    PassportInfo = GeneratePassportInfo(),
                    Categories = CreateCategories(),
                    LicenseNumber = GenerateLicenseNumber(),
                    LicenseStart = LicenseDate,
                    LicenseEnd = LicenseDate.AddYears(10),
                    ExtraInformation = "Нет дополнительной информации"
                });
                CreateFemale();
                db.Owners.Add(new Owner
                {
                    Name = name,
                    Surname = surname,
                    Patronymic = patronymic,
                    Birthday = RandomDate(1950, 2005),
                    PassportInfo = GeneratePassportInfo(),
                    Categories = CreateCategories(),
                    LicenseNumber = GenerateLicenseNumber(),
                    LicenseStart = LicenseDate,
                    LicenseEnd = LicenseDate.AddYears(10),
                    ExtraInformation = "Нет дополнительной информации"
                });
            }
            db.SaveChanges();
        }
        if (!db.CarBrands.Any())
        {
            int brandsNumber = 100;
            string category;
            for (int id = 1; id <= brandsNumber; id++)
            {
                DateTime dateTime = RandomDate(1970, 2021);
                category = categories[rand.Next(1, countCategories)];
                db.CarBrands.Add(new CarBrand
                {
                    Name = "Бренд " + id.ToString(),
                    Producer = "Производитель " + id.ToString(),
                    Country = "Страна " + id.ToString(),
                    DateStart = dateTime,
                    DateFinish = dateTime.AddYears(10),
                    Characteristics = "Нет данных о характеристиках",
                    Category = category,
                    Description = "Нет дополнительного описания"
                });
            }
            db.SaveChanges();
        }
        if (!db.Cars.Any())
        {
            int carsNumber = 1000;
            string[] colors = { "Чёрный", "Белый", "Зелёный", "Жёлтый", "Красный", "Синий", "Фиолетовый", "Серый", "Серебристый",
                "Золотой", "Аква", "Голубой" };
            int countColors = colors.GetLength(0);
            string GenerateRegistrationNumber()
            {
                string[] letters = { "A", "B", "E", "I", "K", "M", "H", "O", "P", "C", "T", "X" };
                int countLetters = letters.GetLength(0);
                return rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString()
                    + " " + letters[rand.Next(1, countLetters)]
                    + letters[rand.Next(1, countLetters)] + "-" + rand.Next(1, 7);
            }
            string GenerateBodyNumber()
            {
                return alphabet[rand.Next(1, countAlphabet)] + alphabet[rand.Next(1, countAlphabet)]
                    + alphabet[rand.Next(1, countAlphabet)] + alphabet[rand.Next(1, countAlphabet)]
                    + alphabet[rand.Next(1, countAlphabet)] + alphabet[rand.Next(1, countAlphabet)]
                    + alphabet[rand.Next(1, countAlphabet)] + alphabet[rand.Next(1, countAlphabet)]
                    + rand.Next(0, 10).ToString() + alphabet[rand.Next(1, countAlphabet)] + alphabet[rand.Next(1, countAlphabet)]
                    + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString();
            }
            string GenerateEngineNumber()
            {
                return alphabet[rand.Next(1, countAlphabet)] + alphabet[rand.Next(1, countAlphabet)]
                    + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() +
                    rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString();
            }
            string GenerateTechPassportNumber()
            {
                return alphabet[rand.Next(1, countAlphabet)] + alphabet[rand.Next(1, countAlphabet)] + alphabet[rand.Next(1, countAlphabet)]
                    + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString();
            }

            for (int id = 1; id <= carsNumber; id++)
            {
                DateTime dateTime = RandomDate(1970, 2021);
                db.Cars.Add(new Car
                {
                    RegistrationNumber = GenerateRegistrationNumber(),
                    BodyNumber = GenerateBodyNumber(),
                    EngineNumber = GenerateEngineNumber(),
                    TechPassportNumber = GenerateTechPassportNumber(),
                    DateCreating = dateTime,
                    DateRegistration = dateTime.AddDays(15),
                    DateInspection = RandomDate(2018, 2021),
                    Color = colors[rand.Next(1, countColors)],
                    Description = "Нет дополнительного описания",
                    OwnerId = rand.Next(1, 501),
                    TrafficPoliceOfficerId = rand.Next(1, 501),
                    CarBrandId = rand.Next(1, 101)
                });
            }
            db.SaveChanges();
        }
        if (!db.StolenCars.Any())
        {
            int stolenCarsNumber = 50;
            bool GetRandomStatement()
            {
                bool statement;
                int number = rand.Next(1, 3);
                if (number == 1)
                {
                    statement = true;
                }
                else
                {
                    statement = false;
                }
                return statement;
            }
            int i = 1;
            for (int id = 1; id <= stolenCarsNumber; id++)
            {
                string[] insurances = { "ОСАГО", "КАСКО", "ДСАГО" };
                int countInsurances = insurances.GetLength(0);
                DateTime dateTime = RandomDate(2021, 2021);
                db.StolenCars.Add(new StolenCar
                {
                    CarId = i,
                    StatementDate = dateTime.AddDays(1),
                    Circumstances = "Нет данных об обстоятельствах",
                    InsuranceType = insurances[rand.Next(1, countInsurances)],
                    MarkAboutFinding = GetRandomStatement(),
                    TheftDate = dateTime,
                    InspectorId = rand.Next(1, 501)
                });
                i += 4;
            }
            db.SaveChanges();
        }
    }
}
