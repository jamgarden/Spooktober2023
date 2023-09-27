using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "Create ThruLine Character", order = 1)]
public class CharacterSO : ScriptableObject
{
    public string Name;

    public string Position;

    [SerializeField]
    public List<CharacterFrame> CharacterFrames;

    // public Sprite Portrait;
    public Sprite Neutral;
    public Sprite Sad;
    public Sprite Happy;
    public Sprite Angry;
    public Sprite SpecialA;
    public Sprite SpecialB;
}
