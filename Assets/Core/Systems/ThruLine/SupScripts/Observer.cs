using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public partial class GameManager 
{
    // This is the Observer
    // Treat this as the input layer for the GameManager

    // // public void E_ChangeBackdrops(){} // Feeds to director, smoothly transitioning backdrops.

    // // public void E_SwapCharacter(){} // Feeds to director, which smoothly transitions characters

    // public void E_ChangeLocale(){}


    [YarnCommand("Place")]
    public void Place_Event(string characterName = "TestDude", string position = "Left", bool flip = false)
    {
        // Let's handle some preprocessing here:
        // Let's put 

        CharacterSO characterHolder = new CharacterSO();
        
        bool flag = false;
        foreach(CharacterSO character in CastOfCharacters)
        {
            if(characterName == character.Name)
            {
                characterHolder = character;
                flag = true;
                Debug.LogWarning("Found character cached");
            }
        }

        if(!flag)
        {
            Debug.LogError("That character wasn't found! Character name is: " + characterName);
            return;
        }
        else
        {
            foreach(CharacterSO character in StagedCharacters)
            {
                if(character.Name == characterName)
                {
                    Debug.Log("They're already up here!");
                    // fire off move event
                    MoveCharacter_Emit(character, getStagePos(position));
                    return;
                }
            }
            StagedCharacters.Add(characterHolder);
            characterHolder.Position = position;
        }

        // And let's call our Director from here:
        Place_Emit(characterHolder, position);

    }

    [YarnCommand("Clear")]
    public void Clear_Event(string position = "All")
    {
        // check to see if all need to be cleared
        if(position == "All")
        {
            ClearStageAll_Emit();
            StagedCharacters.Clear();
        }
    }

}
