using UnityEngine;

[System.Serializable]
public class MessageFromTrainer
{
    [field: SerializeField] public eTrainer Trainer { get; private set; }
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: SerializeField] public string Title { get; private set; }
    [field: SerializeField] public Color TitleColor { get; private set; }
    [field: SerializeField] public string Message { get; private set; }
    [field: SerializeField] public string Date { get; private set; }
}
