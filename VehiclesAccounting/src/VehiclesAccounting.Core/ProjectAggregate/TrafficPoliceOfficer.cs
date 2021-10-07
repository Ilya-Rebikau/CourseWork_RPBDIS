using System;
using System.Collections.Generic;
using VehiclesAccounting.Core.Interfaces;

namespace VehiclesAccounting.Core.ProjectAggregate
{
    /// <summary>
    /// Class of traffic police officer
    /// </summary>
    public class TrafficPoliceOfficer : IEntity
    {
        /// <summary>
        /// Constructor of class TrafficPoliceOfficer
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="patronymic">Patronymic</param>
        /// <param name="birthday">Birthday</param>
        /// <param name="post">Post</param>
        public TrafficPoliceOfficer(string name, string surname, string patronymic, DateTime birthday, string post)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Birthday = birthday;
            Post = post;
        }
        /// <summary>
        /// Constructor of class TrafficPoliceOfficer
        /// </summary>
        public TrafficPoliceOfficer()
        { }
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets patronymic
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Gets or sets birthday
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Gets or sets post
        /// </summary>
        public string Post { get; set; }
        /// <summary>
        /// Navigation property for DB Cars
        /// </summary>
        public List<Car> Cars { get; set; }
        /// <summary>
        /// Navigation property for DB StolenCars
        /// </summary>
        public List<StolenCar> StolenCars { get; set; }
    }
}
