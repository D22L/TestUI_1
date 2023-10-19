using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TabButton : MonoBehaviour
{
    [SerializeField] private BaseTabContentPanel _contentPanel;
    [SerializeField] private Image image;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

    private Action<TabButton> OnClickAction;
    private Button _button;
    public void Init(Action<TabButton> onClickCallback)
    {
        OnClickAction = onClickCallback;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(()=> OnClickAction.Invoke(this));
    }

    public void ShowContent()
    {
        _contentPanel.Show();
        image.color = _activeColor;
    }

    public void HideContent()
    {
        image.color = _inactiveColor;
        _contentPanel.Hide();
    }
}
