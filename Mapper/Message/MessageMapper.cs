using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Message
{
    public class MessageMapper
    {
        public static Entity.Message ConvertToEntity(Model.Message message)
        {
            Entity.Message entityMessage = new Entity.Message();
            try
            {
                entityMessage.senderId = message.SenderId;
                entityMessage.sendDateTime = message.SendDateTime;
                entityMessage.seen = message.Seen;
                entityMessage.receiverId = message.ReceiverId;
                entityMessage.messageId = message.MessageId;
                entityMessage.message1 = message.Messages;
                entityMessage.sendReceive = message.SendReceive;
                return entityMessage;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static IEnumerable<Model.Message> ConvertToListModel(IEnumerable<Entity.Message> entityList)
        {
            try
            {
                IList<Model.Message> listMessage = new List<Model.Message>();
                foreach(var entity in entityList)
                {
                    Model.Message message = new Model.Message();
                    message.MessageId = entity.messageId;
                    message.Messages = entity.message1;
                    message.ReceiverId = entity.receiverId;
                    message.Seen = entity.seen;
                    message.SendDateTime = entity.sendDateTime;
                    message.SenderId = entity.senderId;
                    message.SendReceive = entity.sendReceive;
                    listMessage.Add(message);

                }
                return listMessage;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
