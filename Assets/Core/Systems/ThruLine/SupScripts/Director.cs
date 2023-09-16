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
        foreach(CharacterSO character in StagedCharacters)
        {
            character.Position = null;
        }
        Debug.Log("Stage cleared!");
    }

    public void ClearPosition_Emit(string position)
    {
        bool found = false;
        foreach(Image pos in Positions)
        {
            if(pos.name == position)
            {
                pos.sprite = null;
                found = true;

            }
        }
        if (!found)
        {
            Debug.LogError("Hey, we couldn't find that position at Director. Clear failed!");
            return;
        }
        foreach(CharacterSO character in StagedCharacters)
        {
            if(character.Position == position)
            {
                character.Position = null;
                StagedCharacters.Remove(character);
            }
        }
    }


    public void MoveCharacter_Emit(CharacterSO character, GameObject position)
    {
        ClearPosition_Emit(position.name);
        Image image = position.GetComponent<Image>();
        getStagePos(character.Position).GetComponent<Image>().sprite = null;
        image.sprite = character.Neutral; // Please note that this is neutral and needs to be changed
        character.Position = position.name;
    }

    // ***********************************************

    private GameObject getStagePos(string position)
    {
        foreach(Image pos in Positions)
        {
            if(pos.gameObject.name == position)
            {
                // this means we found it
                return pos.gameObject;
            }
        }
        Debug.LogError("Uh Oh! I couldn't find that position! The listed position is: " + position);
        return null;
    }


    //private void findStagedCharacter
}
