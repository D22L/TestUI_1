using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TrainerButton : MonoBehaviour
{
    [field: SerializeField] public eTrainer Trainer { get; private set; }
    [SerializeField] private Image _back;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

    private Action<eTrainer> OnClickAction;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Active();
         OnClickAction?.Invoke(Trainer);
    }
    public void Active()
    {
        _back.color = _activeColor;
    }
    public void Inactive()
    {
        _back.color = _inactiveColor;
    }
    public void Init(Action<eTrainer> onClickAction)
    {
        OnClickAction = onClickAction;
    }
}
