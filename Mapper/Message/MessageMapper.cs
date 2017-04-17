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
                return entityMessage;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
