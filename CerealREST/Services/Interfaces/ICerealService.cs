using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CerealREST.Models;

namespace CerealREST.Services.Interfaces
{
    public interface ICerealService
    {
        /// <summary>
        /// Retrieves all Cereal objects from the database
        /// </summary>
        /// <returns>A List of Cereal</returns>
        List<Cereal> GetAllCereal();
        /// <summary>
        /// Retrieves a specific Cereal from the database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>A single Cereal object</returns>
        Cereal GetCerealFromId(int Id);
        /// <summary>
        /// Retrieves a specific Cereal from the database, using a char
        /// </summary>
        /// <param name="mfc"></param>
        /// <returns>A single Cereal object</returns>
        Cereal GetCerealFromManufacturer(char mfc);
        /// <summary>
        /// Retrieves a specific Cereal from the database, using two strings to choose which variable and the search target
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="target"></param>
        /// <returns>A single Cereal </returns>
        Cereal GetCerealFromVariable(string variable, string target);
        /// <summary>
        /// Takes a Cereal object and inserts it into the database
        /// </summary>
        /// <param name="cereal"></param>
        /// <returns>A bool to determine success/failure (true/false, respectively)</returns>
        bool CreateCereal(Cereal cereal);
        /// <summary>
        /// Updates a specific Cereal object from the database, using the ID variable
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>A bool to determine success/failure (true/false, respectively)</returns>
        bool UpdateCereal(Cereal cereal, int Id);
        /// <summary>
        /// Deletes a specific Cereal object from the database, using the ID variable
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>The deleted Cereal object, or null if the object wasn't found</returns>
        Cereal DeleteCereal(int Id);
    }
}
