using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveGame", menuName = "Create SaveGame", order = 1)]
public class SaveGameSO : ScriptableObject
{
    public Dictionary<string, float> floatDict = new Dictionary<string, float>();
    public Dictionary<string, string> stringDict = new Dictionary<string, string>();
    public Dictionary<string, bool> boolDict = new Dictionary<string, bool>();

    public string nodeName;
    public LocaleSO LocaleName;
    public List<CharacterSO> stagedCharacters;

    public void AssignVals(Dictionary<string, float> floatDict, Dictionary<string, string> stringDict, Dictionary<string, bool> boolDict)
    {
        this.floatDict = floatDict;
        this.stringDict = stringDict;
        this.boolDict = boolDict;
    }

    
}
