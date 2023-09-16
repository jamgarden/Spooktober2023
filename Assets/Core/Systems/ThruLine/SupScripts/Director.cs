using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public partial class GameManager
{
    // This is the Director.
    // All actions flow from here.

    public void setBackDropEMIT(int index)
    {
        Debug.Log("Setting backdrop");
        Stage.GetComponentInChildren<Image>().sprite = currentLocale.BGList[index];
    }

    public void Place_Emit(CharacterSO character, string position, bool flip = false)
    {

        // get StagedCharacter by name
        // switch stage position sprite to StagedCharacter by emotion label.
        // switch case for emotion strings
        //      Sprite selectedImage = StagedCharacter.Neutral;
        switch (position)
        {

            case "FarLeft": 
                Debug.Log("FarLeft PING *************");
                Positions[0].sprite = StagedCharacters.Last().Neutral;
                break;
            case "Left":
                Debug.Log("Left PING **************");
                Positions[1].sprite = StagedCharacters.Last().Neutral;
                break;
            case "Center":
                Debug.Log("Center PING ****************");
                Positions[2].sprite = StagedCharacters.Last().Neutral;
                break;
            case "Right":
                Debug.Log("Right PING *****************");
                Positions[3].sprite = StagedCharacters.Last().Neutral;
                //Positions[3].gameObject.transform.localScale = new Vector3(-1, 1, 1);
                break;
            case "FarRight":
                Debug.Log("FarRight PING ***************");
                Positions[4].sprite = StagedCharacters.Last().Neutral;
                //Positions[3].gameObject.transform.localScale = new Vector3(-1, 1, 1);
                break;
            default:
                Debug.LogError("Default PING ERROR ******************");
                // Positions[5].sprite = StagedCharacters.Last().Neutral;
                break;
        }
                
    }

    public void ClearStageAll_Emit()
    {
        foreach(Image position in Positions)
        {
            position.sprite = null;
        }
        Debug.Log("Stage cleared!");
    }
}
