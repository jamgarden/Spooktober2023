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

        // 
        foreach(CharacterSO chara in CastOfCharacters)
        {
            if(chara.Name == characterName)
            {
                chara.Position = position;
                chara.Emotion = emotion;
                bool found = false;
                foreach(CharacterSO stagedChara in StagedCharacters)
                {
                    if(stagedChara.Position == position && stagedChara.Name != chara.Name)
                    {
                        stagedChara.Position = "";
                        stagedChara.Emotion = "";
                        
                    }else if(stagedChara.Position == position && stagedChara.Name == chara.Name)
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    StagedCharacters.Add(chara);
                }
            }
        }

        // now sift out all staged characters with no position
        List<CharacterSO> emptyStaged = new List<CharacterSO>();
        foreach(CharacterSO chara in StagedCharacters)
        {
            if(chara.Position == "")
            {
                emptyStaged.Add(chara);
            }
        }

        if(emptyStaged.Count > 0)
        {

            foreach (CharacterSO chara in emptyStaged)
            {
                StagedCharacters.Remove(chara);
            }
        }


        foreach(SpriteRenderer sRender in Positions)
        {
            sRender.sprite = null;
        }


        foreach(CharacterSO chara in StagedCharacters)
        {
            foreach(SpriteRenderer sRender in Positions)
            {
                if(sRender.gameObject.name == chara.Position)
                {
                    sRender.sprite = chara.getFrame(chara.Emotion).Picture;
                    break;
                }
            }
        }

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
