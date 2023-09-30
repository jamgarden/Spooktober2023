using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public partial class GameManager
{
    // This is the Director.
    // All actions flow from here.

    public void setBackDropEMIT(int index)
    {
        Debug.Log("Setting backdrop");

        Stage.GetComponentInChildren<SpriteRenderer>().sprite = currentLocale.BGList[index];
    }

    public void Place_Emit(CharacterSO character, string position, bool flip = false)
    {
        
    }

    public void ClearStageAll_Emit()
    {
        foreach(CharacterSO chara in StagedCharacters)
        {
            chara.Position = "";
            chara.Emotion = "";
        }
        foreach(SpriteRenderer rend in Positions)
        {
            rend.sprite = null;
        }

        StagedCharacters = new List<CharacterSO>();
        
    }

    private SaveData saveGen(string source)
    {
        // JsonSerializer.Deserialize<SaveData>(source);

        return null;
    }
    public void ClearPosition_Emit(string position)
    {
        
    }


    public void MoveCharacter_Emit(CharacterSO character, GameObject position)
    {
        ClearPosition_Emit(position.name);
        Image image = position.GetComponent<Image>();
        getStagePos(character.Position).GetComponent<Image>().sprite = null;
        image.sprite = character.Neutral; // Please note that this is neutral and needs to be changed
        character.Position = position.name;
    }


    public void ChangeLocale_Emit(LocaleSO locale, int index)
    {
        previousLocale = currentLocale;
        currentLocale = locale;

        setBackDropEMIT(index);

    }

    // ***********************************************

    private SpriteRenderer getStagePos(string position)
    {
        // Defunct, mark for deletion
        return null;
    }


    //private void findStagedCharacter

    private LocaleSO GetLocaleSO(string locale)
    {

        foreach(LocaleSO place in LocaleList)
        {
            if(place.Name == locale)
            {
                return place;
            }
        }
        Debug.LogError("Yoooo, we couldn't find that location! Locale: " + locale);
        return DebugLocale;
    }

    private CharacterSO GetCharacterSO(string name)
    {

        foreach (CharacterSO character in CastOfCharacters)
        {
            if (character.Name == name)
            {
                return character;
            }
        }
        Debug.LogError("Yoo, we couldn't find that character. Here's a demon instead. :P");
        return DebugCharacter;
    }


    public void SaveGame()
    {
        // savedGame.stagedCharacters = new List<CharacterSO>();
        Dictionary<string, float> floatDictX = new Dictionary<string, float>();
        Dictionary<string, string> stringDictX = new Dictionary<string, string>();
        Dictionary<string, bool> boolDictX = new Dictionary<string, bool>();

        (floatDictX, stringDictX, boolDictX) = varStorage.GetAllVariables();

        SaveData testerX = new SaveData();

        Debug.Log("Saving Game here");
        List<SerializableKeyValuePair<string, float>> floatsForAll = new List<SerializableKeyValuePair<string, float>>();
        foreach (KeyValuePair<string, float> record in floatDictX)
        {
            floatsForAll.Add(new SerializableKeyValuePair<string, float>(record.Key, record.Value));
            Debug.Log("String key: " + record.Key);
            Debug.Log("Float value: " + record.Value);
        }
        testerX.floatVars = floatsForAll;
        List<SerializableKeyValuePair<string, string>> stringsForAll = new List<SerializableKeyValuePair<string, string>>();
        foreach (KeyValuePair<string, string> record in stringDictX)
        {
            stringsForAll.Add(new SerializableKeyValuePair<string, string>(record.Key, record.Value));
            Debug.Log("String key: " + record.Key);
            Debug.Log("String value: " + record.Value);
        }
        testerX.stringVars = stringsForAll;
        List<string> boolKeys = new List<string>();
        List<bool> boolVals = new List<bool>();
        List<SerializableKeyValuePair<string, bool>> heinous = new List<SerializableKeyValuePair<string, bool>>();
        foreach (KeyValuePair<string, bool> record in boolDictX)
        {
            heinous.Add(new SerializableKeyValuePair<string, bool>(record.Key, record.Value));
            Debug.Log(testerX);
            Debug.Log("String key: " + record.Key);
            Debug.Log("Bool val: " + record.Value);
        }
        testerX.boolVars = heinous;
        PlayerPrefs.SetString("CurrentNode", dialogueRunner.CurrentNodeName);
        PlayerPrefs.Save();
        /*testerX.boolVars = boolDictX;
        testerX.stringVars = stringDictX;
        testerX.floatVars = floatDictX; */
        testerX.nodeName = dialogueRunner.CurrentNodeName;

        XmlSerializer xSerialize = new XmlSerializer(typeof(SaveData));

        using (StreamWriter stream = new StreamWriter("./saveGame.xml"))
        {
            xSerialize.Serialize(stream, testerX);
        }


        // Application.Quit();
    }
}

[System.Serializable]
public class SerializableKeyValuePair<TKey, TValue>
{
    public TKey Key;
    public TValue Value;

    public SerializableKeyValuePair() { }

    public SerializableKeyValuePair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}


[System.Serializable]
public class SaveData
{
    public List<SerializableKeyValuePair<string, bool>> boolVars { get; set; } = new List<SerializableKeyValuePair<string, bool>>();
    public List<SerializableKeyValuePair<string, float>> floatVars { get; set; } = new List<SerializableKeyValuePair<string, float>>();
    public List<SerializableKeyValuePair<string, string>> stringVars { get; set; } = new List<SerializableKeyValuePair<string, string>>();
    public string nodeName { get; set; }
}
