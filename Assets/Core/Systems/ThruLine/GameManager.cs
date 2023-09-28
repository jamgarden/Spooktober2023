using System.Collections;
using System.Collections.Generic;
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

    // debug sound
    // debug music
    // debug voiceline?












    void Start(){
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

    // Manager FUnctions

}
