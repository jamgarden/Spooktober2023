using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class GameManager : MonoBehaviour
{

    [SerializeField]
    private string loadSceneTarget = "Gameplay"; //

    [SerializeField]
    private string[] Background;

    [SerializeField]
    private LocaleSO currentLocale;

    [SerializeField]
    private GameObject Stage;

    [SerializeField]
    private GameObject MainMenu;

    [SerializeField]
    private List<LocaleSO> LocaleList;

    void Start(){
        Debug.Log(currentLocale.Name);
        

        Debug.Log(currentLocale.BGList[0].name);
        // We need to have a savegame.json file with 3 slots on it. 
        // This is where we should read that.  

    }


    // Observer functions

    public void StartGameEvent(int index)
    {
        Debug.Log("This is where the game starts");
        // Switch to starting area locale
        foreach(LocaleSO locale in LocaleList)
        {

            if (locale.Name == "Dorm")
            {
                currentLocale = locale;
                Debug.Log("Found Dorm");
            }
        }
        // Sets backdrop to index 1 of current locale, which is called "Menu"
        setBackDropEMIT(index);
        // TEMPORARY - go directly into game without selecting save game

        // Disable the menu
        MainMenu.SetActive(false);
        
        
    }


    // Director Functions
    private void SwitchStudio(string targetScene){
        // Directors need to be able to \
        SceneManager.LoadScene(targetScene);
    }

    // Manager FUnctions

}
