using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class TrainingTabContentPanel : BaseTabContentPanel
{
    [SerializeField] private TrainingInformationLine _pfb;
    [SerializeField] private MessageDatabaseFromTrainer _database;
    [SerializeField] private Transform _messageContainer;
    [SerializeField] private List<TrainerButton> _trainerButtons;
    
    private bool _isInited;
    private List<TrainingInformationLine> _createdMessages = new List<TrainingInformationLine>();
    public void Init(eTrainer trainer)
    {
        Clear();
        SelectTrainer(trainer);
        var messages = _database.GetMessageDataFromTrainer(trainer);
        if (messages.Count == 0) return;
        
        messages = SortByDate(messages);
        
      

        for (int i = 0; i < messages.Count; i++)
        {
            DateTime dateTime = new DateTime();
            DateTime dateTimeCurrent = DateTime.Now;
            if (DateTime.TryParse(messages[i].Date, out dateTime))
            {
                if (dateTime > dateTimeCurrent) continue;
            }
            var infoLine = Instantiate(_pfb, _messageContainer);
            infoLine.SetTrainingInformation(messages[i]);
            _createdMessages.Add(infoLine);
        }
    }

    private void SelectTrainer(eTrainer trainer)
    {
        _trainerButtons.ForEach(x =>
        {
            if (x.Trainer != trainer) x.Inactive();
            else x.Active();
        });
    }
    private void Clear()
    {
        _createdMessages.ForEach(x => Destroy(x.gameObject));
        _createdMessages.Clear();
    }
    private List<MessageFromTrainer> SortByDate(List<MessageFromTrainer> data)
    {
        List<MessageFromTrainer> sorted = new List<MessageFromTrainer>();
        Dictionary<DateTime,MessageFromTrainer> messageDic = new Dictionary<DateTime, MessageFromTrainer>();
        for (int i = 0; i < data.Count; i++)
        {
            DateTime dateTime = new DateTime();
            if (DateTime.TryParse(data[i].Date, out dateTime))
            {
                messageDic.Add(dateTime, data[i]);
            }
        }

        var sortedDic = messageDic.OrderBy(x => x.Key);

        foreach (var item in sortedDic)
        {
            sorted.Add(item.Value);
        }

        return sorted;
    }

    public override void Show()
    {
        if (!_isInited)
        {
            _trainerButtons.ForEach(x => x.Init(Init));
            var button = _trainerButtons[0];
            button.Active();
            Init(button.Trainer);
        }

        
        gameObject.SetActive(true);
    }

    public override void Hide()
    {
        _isInited = false;
        gameObject.SetActive(false);
        Clear();
    }
}
