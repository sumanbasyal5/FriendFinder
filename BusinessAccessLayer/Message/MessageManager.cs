using DataAccessLayer;
using Helper;
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
            modelMessage.SendReceive = MessageHelper.MESSAGE_SEND;
            return _messageService.SaveMessage(MessageMapper.ConvertToEntity(modelMessage));
        }

        public int FindMessageNumber(string email)
        {
            return _messageService.FindMessageNumber(email);
        }

        public IEnumerable<Model.Message> GetAllMessageFromSender(int senderId,int receiverId)
        {
            return MessageMapper.ConvertToListModel(_messageService.GetAllMessageFromSender(senderId,receiverId));
        }

        public List<string> GetAllUnSeenMessagesFromSender(int senderId,int receiverId)
        {
            return _messageService.GetAllUnSeenMessagesFromSender(senderId,receiverId);
        }
    }
}
