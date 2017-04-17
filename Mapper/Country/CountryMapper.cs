using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Mapper
{
    public class CountryMapper
    {
        /// <summary>
        /// Author: Suman Basyal
        /// </summary>
        /// <param name="listEntityCountry"></param>
        /// <returns></returns>
        public static IEnumerable<Model.Country> ConvertCountryEntityToModel(IEnumerable<Entity.Country> listEntityCountry)
        {
            IList<Model.Country> listCountry = new List<Model.Country>();
            try
            {
                foreach(var entity in listEntityCountry)
                {
                    Model.Country modelCountry = new Model.Country();
                    modelCountry.countryId = entity.countryId;
                    modelCountry.countryName = entity.name;
                    listCountry.Add(modelCountry);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return listCountry;
        }
    }
}
