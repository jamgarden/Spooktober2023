using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "Create ThruLine Character", order = 1)]
public class CharacterSO : ScriptableObject
{
    public string Name;

    public string Position;

    public string Emotion;

    [SerializeField]
    public List<CharacterFrame> CharacterFrames;

    // public Sprite Portrait;
    public Sprite Neutral;

    [SerializeField]
    public List<Sprite> OneOffs;


    public CharacterFrame getFrame(string emotion)
    {
        foreach (CharacterFrame cFrame in CharacterFrames) 
        { 
            if(cFrame.Emotion == emotion)
            {
                return cFrame;
            }
        }

        return null;
    }
}
