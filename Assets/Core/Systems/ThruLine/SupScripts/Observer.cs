using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using FMODUnity;
using FMOD;
using FMOD.Studio;

[System.Serializable]
public class CharacterFrame 
{
    public string Emotion;
    public Sprite Picture;

}

public partial class GameManager 
{
    // This is the Observer
    // Treat this as the input layer for the GameManager

    // // public void E_ChangeBackdrops(){} // Feeds to director, smoothly transitioning backdrops.

    // // public void E_SwapCharacter(){} // Feeds to director, which smoothly transitions characters

    // public void E_ChangeLocale(){}


    [YarnCommand("Place")]
    public void Place_Event(string characterName = "TestDude", string emotion = "Neutral", string position = "Left")
    {
        if(characterName == "Nobody")
        {
            // This is our flag to clear the screen;
            ClearStageAll_Emit();
            return;
        }
        SpriteRenderer target = null;
        foreach(SpriteRenderer spriteRend in Positions)
        {
            if(spriteRend.name == position)
            {
                // if the position is found, 
                target = spriteRend;
            }
        }
        if(target == null)
        {
            UnityEngine.Debug.LogError("That position wasn't found.");
            return;
        }
        //So, we have the position.  We can swap that out pretty easy.
        CharacterSO chosenChara = null;
        foreach(CharacterSO character in CastOfCharacters)
        {
            if(character.Name == characterName)
            {
                chosenChara = character;
            }
        }
        if(chosenChara == null)
        {
            UnityEngine.Debug.LogError("That character was NOT found, character name: " + characterName);
            return;
        }
        // now we have a position and character.  Let's parse the emotion;
        bool trip = false;
        foreach(CharacterFrame frame in chosenChara.CharacterFrames)
        {
            if(frame.Emotion == emotion)
            {
                target.sprite = frame.Picture;
                trip = true;
            }
        }
        if (!trip)
        {
            UnityEngine.Debug.LogWarning("Hey, that picture doesn't exist.  We'll use a placeholder.");
            target.sprite = DebugCharacter.Neutral;
        }


        /* CharacterSO characterHolder = GetCharacterSO(characterName);
       
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
        return; */
        // We have some serious work to do.

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
        // This needs to be moved to the director!
        FMODUnity.RuntimeManager.StudioSystem.setParameterByNameWithLabel("MusicSwitch", songNames[val]);
    }
}
