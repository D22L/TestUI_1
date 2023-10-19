using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabPanel : MonoBehaviour
{
    [SerializeField] private List<TabButton> _tabButtons;

    private void Awake()
    {
        _tabButtons.ForEach(x => x.Init(OnTabClick));
        _tabButtons.ForEach(x => x.HideContent());
        _tabButtons[0].ShowContent();
    }

    private void OnTabClick(TabButton tabButton)
    {
        tabButton.ShowContent();
        _tabButtons.ForEach(x => { if (x != tabButton) x.HideContent(); });
    }

}
