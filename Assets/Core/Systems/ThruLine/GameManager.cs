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

    void Start(){
        Debug.Log(currentLocale.Name);
        // We need to have a savegame.json file with 3 slots on it. 
        // This is where we should read that.  

    }


    // Observer functions

    public void StartGameEvent(string targetScene)
    {
        Debug.Log("This is where the game starts");
        // targetScene defaults to chosen loadSceneTarget
        // but is overridable for forced transitions.
        if(targetScene ==""){
            SwitchStudio(loadSceneTarget);
        }

        SwitchStudio(targetScene);
        
        
    }


    // Director Functions
    private void SwitchStudio(string targetScene){
        // Directors need to be able to \
        SceneManager.LoadScene(targetScene);
    }

    // Manager FUnctions

}
