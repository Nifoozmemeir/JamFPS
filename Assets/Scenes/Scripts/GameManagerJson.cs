using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameManagerJson : MonoBehaviour
{
    public Character character;
    [SerializeField] TextMeshProUGUI textPanelS;
    [SerializeField] TextMeshProUGUI textPanelD;
    [SerializeField] TextMeshProUGUI pathText;

    private string json;
    private string saveDirectory;
    private string characterData = "characterData.json";
    private string folderPath = "/AllScenes";

    private void Awake()
    {
        saveDirectory = Application.dataPath + folderPath;
        //saveDirectory = Application.persistentDataPath + folderPath;

        if (!Directory.Exists(saveDirectory))
        {
            Directory.CreateDirectory(saveDirectory);
        }
    }

    public void SerializeCharacter()
    {
        json = JsonUtility.ToJson(character);
        textPanelS.text = json;

        string savePath = Path.Combine(saveDirectory, characterData);
        pathText.text = savePath;

        File.WriteAllText(savePath, json);
    }

    public void DeserializeCharacter()
    {
        string loadPath = Path.Combine(saveDirectory, characterData);

        if (File.Exists(loadPath))
        {
            json = File.ReadAllText(loadPath);
            character = JsonUtility.FromJson<Character>(json);
            textPanelD.text = GetCharacterInfo(character);
        }
        else
        {
            textPanelD.text = "File not find :(";
        }
    }


    private string GetCharacterInfo(Character character)
    {
        return string.Format("Name: {0}\nType: {1}\nLevel: {2}\nCurrentExpPercentage: {3:P}\nInventory: {4}",
            character.Name,
            character.Type,
            character.Level,
            character.CurrentExpPercentage,
            GetInventoryInfo(character.Inventory));
    }

    private string GetInventoryInfo(List<Item> inventory)
    {
        string inventoryInfo = "";
        foreach (Item item in inventory)
        {
            inventoryInfo += string.Format("\n-Name: {0}, \n-Type: {1}", item.Name, item.Type);
        }
        return inventoryInfo;
    }
}