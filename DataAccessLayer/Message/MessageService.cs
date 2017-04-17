using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccessLayer.Entites;

namespace DataAccessLayer
{
    public class MessageService : BaseEntity
    {
        public bool SaveMessage(Message messaage)
        {
            try
            {
                messaage.sendDateTime = DateTime.Now;
                dbEntity.Messages.Add(messaage);
                dbEntity.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
