using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using FMODUnity;
using FMOD;
using FMOD.Studio;

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
        
        CharacterSO characterHolder = GetCharacterSO(characterName);
       
        foreach(CharacterSO character in StagedCharacters)
        {
            if(character.Name == characterHolder.Name)
            {
                UnityEngine.Debug.Log("They're already up here!");
                // fire off move event
                MoveCharacter_Emit(character, getStagePos(position));
                return;
            }
        }
        StagedCharacters.Add(characterHolder);
        characterHolder.Position = position;
        

        // And let's call our Director from here:
        Place_Emit(characterHolder, position);
        return;
    }

    [YarnCommand("Clear")]
    public void Clear_Event(string position = "All")
    {
        // check to see if all need to be cleared
        if (position == "All")
        {
            ClearStageAll_Emit();
            StagedCharacters.Clear();
        }
        else
        {
            ClearPosition_Emit(position);
        }
    }

    [YarnCommand("Travel")]
    public void ChangeLocale_Event(string localeName = "MainMenu", int index = 0)
    {

        
        ChangeLocale_Emit(GetLocaleSO(localeName), index);
    }

    [YarnCommand("LocaleList")]
    public void LocaleList_Event()
    {

        // This fires when we request locations.
    }

    [YarnCommand("shiftmusic")]
    public void ShiftMusic(int val = 0)
    {
        
        FMODUnity.RuntimeManager.StudioSystem.setParameterByNameWithLabel("MusicSwitch", songNames[val]);
    }
}
