/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Services.ConsoleService
{
    public class Message
    {
        public string MessageText { get; }
        public MessageType MessageType { get; }

        public Message(string messageText, MessageType messageType)
        {
            MessageText = messageText;
            MessageType = messageType;
        }

        public static Message Empty() => new Message(string.Empty, MessageType.Empty);
    }
}