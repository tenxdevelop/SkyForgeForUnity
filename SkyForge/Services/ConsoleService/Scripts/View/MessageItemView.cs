/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using TMPro;

namespace SkyForge.Services.ConsoleService
{
    public class MessageItemView : MonoBehaviour
    {
        public bool IsVisible { get; set; }
        
        [SerializeField] private Color m_errorColor = Color.red;
        [SerializeField] private Color m_warningColor = Color.yellow;
        [SerializeField] private Color m_messageColor = Color.white;
        
        [SerializeField] private TextMeshProUGUI m_textMeshPro;
        
        private void Awake()
        {
            IsVisible = true;
            m_textMeshPro = GetComponent<TextMeshProUGUI>();
        }
        
        public void SetMessage(Message message)
        {
            switch (message.MessageType)
            {
                case MessageType.Error:
                    m_textMeshPro.color = m_errorColor;
                    break;
                case MessageType.Warning:
                    m_textMeshPro.color = m_warningColor;
                    break;
                case MessageType.Message:
                    m_textMeshPro.color = m_messageColor;
                    break;
                default:
                    m_textMeshPro.color = m_messageColor;
                    break;
            }
            m_textMeshPro.text = message.MessageText;
        }
    }
}
