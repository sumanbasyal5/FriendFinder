using DataAccessLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccessLayer
{
    public class GenderService:BaseEntity
    {
        public  IEnumerable<Entity.Gender> GetAllGender()
        {
            try
            {
                return dbEntity.Genders.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
