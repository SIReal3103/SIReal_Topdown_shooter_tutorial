using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISelectCharacterPanel : MonoBehaviour
{
    [Header("MENUS")]
    public GameObject canv_Main;
    public GameObject canv_SelectCharacter;

    public GameObject selectHightlight;
    public List<GameObject> Characters;

    public AllPlayerData_SO AllPlayerData_SO;
    public List<PlayerData> playerDatas = new List<PlayerData>();

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI health;
    public GameObject StartGameButton;

    void Start()
    {
        ClosePanel(canv_SelectCharacter);

        foreach (PlayerData_SO data in AllPlayerData_SO.characters)
        {
            playerDatas.Add(data.GetDataInstance());
        }
    }

    public void ClosePanel(GameObject panel)
    {
        CanvasGroup group = panel.GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
    }

    public void OpenPanel(GameObject panel)
    {
        CanvasGroup group = panel.GetComponent<CanvasGroup>();
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
    }

    public void OpenSelectCharacterCanvas()
    {
        OpenPanel(canv_SelectCharacter);
        canv_Main.SetActive(false);
        SelectCharacter(0);
    }

    public void SelectMode(int index)
    {
        PlayerPrefs.SetInt("gameMode", index);
    }

    public void SelectCharacter(int index)
    {
        Debug.Log(Characters[index].transform.position);
        selectHightlight.transform.position = Characters[index].transform.position;
        PlayerPrefs.SetInt("characterPreference", index);

        if (index < playerDatas.Count && playerDatas[index] != null)
        {
            health.text = playerDatas[index].maxHealth.ToString();
            damage.text = playerDatas[index].damage.ToString();
            nameText.text = playerDatas[index].playerName;
            StartGameButton.SetActive(true);
        }
        else
        {
            StartGameButton.SetActive(false);
            nameText.text = "Locked";
            health.text = "0";
            damage.text = "0";
        }
    }
}
