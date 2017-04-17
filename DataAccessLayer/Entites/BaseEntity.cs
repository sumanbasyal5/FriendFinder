using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entites
{
    public  class BaseEntity
    {
        protected static finderAppEntities dbEntity;
        public BaseEntity()
        {
            dbEntity = new finderAppEntities();
        }
    }
}
