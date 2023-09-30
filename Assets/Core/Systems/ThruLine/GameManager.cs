using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yarn;
using Yarn.Unity;

public partial class GameManager : MonoBehaviour
{

    [Header("Game State:")]
    [SerializeField]
    private DialogueRunner dialogueRunner;

    [SerializeField]
    private LocaleSO currentLocale;

    private LocaleSO previousLocale;

    [SerializeField]
    private GameObject Stage;

    [SerializeField]
    private GameObject MainMenu;

    [SerializeField]
    private List<LocaleSO> TravelPoints;

    [SerializeField]
    private List<CharacterSO> StagedCharacters;

    [Header("Library")]
    [SerializeField]
    private List<SpriteRenderer> Positions;

    [SerializeField]
    private List<LocaleSO> LocaleList;

    [SerializeField]
    private List<CharacterSO> CastOfCharacters;

    [Header("Debug Suite")]
    [SerializeField]
    private LocaleSO DebugLocale;

    [SerializeField]
    private CharacterSO DebugCharacter;

    [SerializeField]
    private List<string> songNames;

    [SerializeField]
    private CustomVariableStorage varStorage;

    [SerializeField]
    private Button LoadButtonRef;

    [SerializeField]
    private SaveData currentSave;



    void Start(){

        string savePath = "./saveGame.xml";
        if (File.Exists(savePath))
        {
            XmlSerializer xSerializer = new XmlSerializer(typeof(SaveData));
            using (StreamReader stream = new StreamReader(savePath))
            {
                currentSave = (SaveData)xSerializer.Deserialize(stream);
            }
            // Do something with currentSave
            LoadButtonRef.interactable = true;
        }
        else
        {
            Debug.Log("Save file not found, ya might wanna look into that!");
        }
        //foreach(var test in PlayerPrefs)
        Debug.Log(currentLocale.Name);
        

        Debug.Log(currentLocale.BGList[0].name);
        // We need to have a savegame.json file with 3 slots on it. 
        // This is where we should read that.  
        foreach(CharacterSO chara in CastOfCharacters)
        {
            chara.Position = "";
            chara.Emotion = "";
        }

    }


    // Observer functions

    public void StartGameEvent(int index)
    {
        // Initially, this thing just dumps us into a game.  Instead of doing that
        Debug.Log("This is where the game starts");
        // Switch to starting area locale
        currentLocale = LocaleList[index];
        MainMenu.SetActive(false);
        Stage.SetActive(true);


        // Sets backdrop to index 1 of current locale, which is set to the first gameplay
        // Locale. Changing locale and setting backdrop effectively 
        setBackDropEMIT(0);
        // TEMPORARY - go directly into game without selecting save game
        // need to make players select a save game
        // Disable the menu

        // Set the current node for the dialogue system, and start
        dialogueRunner.StartDialogue("Intro");
        Debug.Log(currentLocale.Name, Stage.GetComponentInChildren<SpriteRenderer>().gameObject);
    }


    // Director Functions
    private void SwitchStudio(string targetScene){
        // Directors need to be able to \
        SceneManager.LoadScene(targetScene);
    }

    public void FreakaversityOne()
    {
        Application.OpenURL("https://matthyy.itch.io/freakaversity");
    }

    public void LoadGame()
    {
        // Initialize dictionaries
        Dictionary<string, float> floatVars = new Dictionary<string, float>();
        Dictionary<string, string> stringVars = new Dictionary<string, string>();
        Dictionary<string, bool> boolVars = new Dictionary<string, bool>();

        // Debug output for currentSave (for verification)
        Debug.Log("=== Debugging currentSave ===");
        Debug.Log($"Node Name: {currentSave.nodeName}");

        Debug.Log("--- Float Variables ---");
        foreach (var kvp in currentSave.floatVars)
        {
            floatVars.Add(kvp.Key, kvp.Value);
            Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        Debug.Log("--- String Variables ---");
        foreach (var kvp in currentSave.stringVars)
        {
            stringVars.Add(kvp.Key, kvp.Value);
            Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        Debug.Log("--- Boolean Variables ---");
        foreach (var kvp in currentSave.boolVars)
        {
            boolVars.Add(kvp.Key, kvp.Value);
            Debug.Log($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
        Debug.Log("=== End Debugging ===");

        // Assuming yarnVariableStorage is your custom variable storage for YarnSpinner
        varStorage.SetAllVariables(floatVars, stringVars, boolVars);

        // Start dialogue
        dialogueRunner.StartDialogue(currentSave.nodeName);

        MainMenu.SetActive(false);
    }



    public void QuitGame()
    {
        Application.Quit();
    }
    // Manager FUnctions

}
