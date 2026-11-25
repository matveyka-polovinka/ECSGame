using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.GameMessage
{
    public class GameMessage : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _messageList;
        
        private MessageType _currentType = MessageType.None;
        public static Action<MessageType> ShowMessage;
        private void Start()
        {
            ClearMessage();
            ShowMessage += Show;
        }
        private void Show(MessageType type)
        {
            ClearMessage();
            switch (type)
            {
                case MessageType.ADVShow:
                    _messageList[0].SetActive(true);
                    break;
            }
        }
        private void ClearMessage()
        {
            foreach (var message in _messageList) message.SetActive(false);
        }
    }
    public enum MessageType
    {
        None, 
        ADVShow,

    }
}