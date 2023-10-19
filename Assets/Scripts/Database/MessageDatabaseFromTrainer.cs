using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MessageDatabaseFromTrainer", menuName = "Database/MessageDatabaseFromTrainer")]
public class MessageDatabaseFromTrainer : ScriptableObject
{
    [SerializeField] private List<MessageFromTrainer> _messages = new List<MessageFromTrainer>();

    public List<MessageFromTrainer> GetMessageDataFromTrainer(eTrainer trainer)
    {
        return _messages.FindAll(x=>x.Trainer == trainer);
    }
}
