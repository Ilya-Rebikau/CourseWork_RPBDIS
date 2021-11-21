using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate
{
    /// <summary>
    /// Class of car brand
    /// </summary>
    public class CarBrand : IEntity
    {
        /// <summary>
        /// Constructor of class CarBrand
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="producer">Producer</param>
        /// <param name="country">Country</param>
        /// <param name="dateStart">Date of starting car brand producing</param>
        /// <param name="dateFinish">Date of finishing car brand producing</param>
        /// <param name="characteristics">Car brand characteristics</param>
        /// <param name="category">Car brand category</param>
        /// <param name="description">Car brand description</param>
        public CarBrand(string name, string producer, string country, DateTime dateStart, DateTime dateFinish,
                        string characteristics, string category, string description)
        {
            Name = name;
            Producer = producer;
            Country = country;
            DateStart = dateStart;
            DateFinish = dateFinish;
            Characteristics = characteristics;
            Category = category;
            Description = description;
        }
        /// <summary>
        /// Constructor of class CarBrand
        /// </summary>
        public CarBrand()
        { }
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets name of car brand
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets company-producer of car brand
        /// </summary>
        public string Producer { get; set; }
        /// <summary>
        /// Gets or sets country of car brand
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets date of starting car brand producing
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Gets or sets date of finishing car brand producing
        /// </summary>
        public DateTime DateFinish { get; set; }
        /// <summary>
        /// Gets or sets car brand characteristics
        /// </summary>
        public string Characteristics { get; set; }
        /// <summary>
        /// Gets or sets car brand category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets description of car brand
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Navigation property for DB Cars
        /// </summary>
        public List<Car> Cars { get; set; }
    }
}
