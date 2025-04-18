/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System.Collections.Generic;
using SkyForge.MVVM;
using System.Linq;
using UnityEngine;

namespace SkyForge.Services.ConsoleService
{
    public class ConsoleServiceView : View
    {
        [SerializeField] private int m_maxMessages = 28;
        [SerializeField] private int m_maxMessagesInGame = 15;
        
        [SerializeField] private MessageItemView m_messageItemViewPrefab;
        [SerializeField] private Transform m_parentMessageList;
        
        private List<MessageItemView> m_messageItemViews = new();
        
        public void AddMessage(Message message)
        {
            if (message.MessageType.Equals(MessageType.Empty))
                return;

            DeleteUnnecessaryMessage();
            
            var newMessageItem = Instantiate(m_messageItemViewPrefab, m_parentMessageList);
            newMessageItem.SetMessage(message);
            m_messageItemViews.Add(newMessageItem);
        }
        
        public void IsOpenOrCloseConsole(bool isOpen)
        {
            if (isOpen)
            {
                var messageItemsHidden  = m_messageItemViews.Where(item => !item.IsVisible);
                foreach (var messageItem in messageItemsHidden)
                {
                    messageItem.IsVisible = true;
                    messageItem.gameObject.SetActive(true);
                }
            }
            else
            {
                
                if (m_messageItemViews.Count > m_maxMessagesInGame)
                {
                    var messageItemsHidden = m_messageItemViews.Where((item, index) => index < m_messageItemViews.Count - m_maxMessagesInGame - 1);
                    foreach (var messageItem in messageItemsHidden)
                    {
                        messageItem.IsVisible = false;
                        messageItem.gameObject.SetActive(false);
                    }
                }
            }
        }
        
        private void DeleteUnnecessaryMessage()
        {
            if (m_messageItemViews.Count >= m_maxMessages)
            {
                var messageItemRemove = m_messageItemViews.FirstOrDefault();
                
                if (messageItemRemove == null)
                    return;
                
                messageItemRemove.gameObject.SetActive(false);
                Destroy(messageItemRemove.gameObject);
                m_messageItemViews.Remove(messageItemRemove);
            }
        }
    }
}
