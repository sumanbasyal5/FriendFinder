using DataAccessLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StateService:BaseEntity
    {
        public IEnumerable<Entity.State> GetAllStates()
        {
            IEnumerable<Entity.State> listState = new List<Entity.State>();
            try
            {
                listState=dbEntity.States.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
            return listState;
        }

        public IEnumerable<Entity.State> GetAllStatePerCountry(int countryId)
        {
            IEnumerable<Entity.State> listState = new List<Entity.State>();
            try
            {
                listState=dbEntity.States.Where(m => m.countryId.Equals(countryId)).ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
            return listState;
        }
    }
}
