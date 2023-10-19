using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrainingInformationLine : MonoBehaviour
{
    [SerializeField] private Image _imageField;
    [SerializeField] private TextMeshProUGUI _titleField;
    [SerializeField] private TextMeshProUGUI _messageField;
    [SerializeField] private TextMeshProUGUI _dateField;

    public void SetTrainingInformation(MessageFromTrainer messageFromTrainer)
    {
        _imageField.sprite = messageFromTrainer.Image;
        _titleField.text = messageFromTrainer.Title;
        _titleField.color = messageFromTrainer.TitleColor;
        _messageField.text = messageFromTrainer.Message;
        _dateField.text = messageFromTrainer.Date;
    }
}
