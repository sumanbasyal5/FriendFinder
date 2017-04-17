using DataAccessLayer;
using Mapper.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class MessageManager
    {
        private MessageService _messageService;
        public MessageManager()
        {
            _messageService = new MessageService();
        }

        public bool SaveMessage(string message, int receiverId, int senderId)
        {
            Model.Message modelMessage = new Model.Message();
            modelMessage.Messages = message;
            modelMessage.ReceiverId = receiverId;
            modelMessage.SenderId=senderId;
            modelMessage.Seen = false;
            return _messageService.SaveMessage(MessageMapper.ConvertToEntity(modelMessage));
        }
    }
}
