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

        public int FindMessageNumber(string email)
        {
            try
            {
                int userId=dbEntity.Users.FirstOrDefault(x => x.email == email).userId;
                int messagaeNumber=dbEntity.Messages.Count(x => x.receiverId == userId && x.seen==false);
                return messagaeNumber;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public List<Entity.Message> GetAllMessageFromSender(int senderId, int receiverId)
        {
            try
            {
                var list= dbEntity.Messages.Where(x => x.senderId == senderId && x.receiverId==receiverId).ToList();
                var messages = dbEntity.Messages.Where(x => x.senderId == senderId && x.seen == false);
                foreach (var unseenMesagae in messages)
                {
                    unseenMesagae.seen = true;
                }
                dbEntity.SaveChanges();
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<string> GetAllUnSeenMessagesFromSender(int senderId, int receiverId)
        {
            try
            {
                var listMessage= dbEntity.Messages.Where(x => x.senderId == senderId && x.receiverId==receiverId && x.seen==false).Select(x => x.message1).ToList();
                var messages = dbEntity.Messages.Where(x => x.senderId == senderId && x.receiverId == receiverId && x.seen == false);
                foreach(var unseenMesagae in messages)
                {
                    unseenMesagae.seen = true;
                }
                dbEntity.SaveChanges();
                return listMessage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
