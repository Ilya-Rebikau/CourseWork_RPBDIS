using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate
{
    /// <summary>
    /// Class of car owner
    /// </summary>
    public class Owner : IEntity
    {
        /// <summary>
        /// Constructor of class owner
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="patronymic">Patronymic</param>
        /// <param name="birthday">Birthday</param>
        /// <param name="passportInfo">Passport series and number</param>
        /// <param name="licenseNumber">Number of drive license</param>
        /// <param name="licenseStart">Date when owner got drive license</param>
        /// <param name="licenseEnd">Date when drive license will end</param>
        /// <param name="categories">Driver's license categories</param>
        /// <param name="extraInformation">Extra information about car owner</param>
        public Owner(string name, string surname, string patronymic, DateTime birthday, string passportInfo,
                     long licenseNumber, DateTime licenseStart, DateTime licenseEnd, string categories, string extraInformation)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Birthday = birthday;
            PassportInfo = passportInfo;
            LicenseNumber = licenseNumber;
            LicenseStart = licenseStart;
            LicenseEnd = licenseEnd;
            Categories = categories;
            ExtraInformation = extraInformation;
        }
        /// <summary>
        /// Constructor of class Owner
        /// </summary>
        public Owner()
        {
        }
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets  name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets  surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets  patronymic
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Gets or sets birthday
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Gets or sets passport series and number
        /// </summary>
        public string PassportInfo { get; set; }
        /// <summary>
        /// Gets or sets number of drive license
        /// </summary>
        public long LicenseNumber { get; set; }
        /// <summary>
        /// Gets or sets date when owner got drive license
        /// </summary>
        public DateTime LicenseStart { get; set; }
        /// <summary>
        /// Gets or sets date when drive license will end
        /// </summary>
        public DateTime LicenseEnd { get; set; }
        /// <summary>
        /// Gets or sets driver's license categories
        /// </summary>
        public string Categories { get; set; }
        /// <summary>
        /// Gets or sets extra information about car owner
        /// </summary>
        public string ExtraInformation { get; set; }
        /// <summary>
        /// Navigation property for DB Cars
        /// </summary>
        public List<Car> Cars { get; set; }
    }
}
