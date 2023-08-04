using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public HealthBar ExpBar;
    int currentExp = 0;
    int currentLevel = 1;
    int requireExp = 30;

    public GameObject levelUpPanel;

    // Level + exp
    public void UpdateExperience(int addExp)
    {
        currentExp += addExp;
        if (currentExp >= requireExp)
        {
            currentLevel++;
            currentExp = currentExp - requireExp;
            requireExp = (int)(requireExp * 2);
            OpenLevelUpPanel();
            // Level up panel
        }
        // Update Exp bar
        ExpBar.UpdateBar(currentExp, requireExp, "Level " + currentLevel.ToString());
    }

    public void CloseLevelUpPanel()
    {
        CanvasGroup group = levelUpPanel.GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
        Time.timeScale = 1;
    }

    public void OpenLevelUpPanel( )
    {
        CanvasGroup group = levelUpPanel.GetComponent<CanvasGroup>();
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
        Time.timeScale = 0;
    }
}
