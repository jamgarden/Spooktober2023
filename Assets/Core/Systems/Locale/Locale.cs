using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ESection
{
    Aux, // used for menus
    School,
    Town
}

[CreateAssetMenu(fileName = "Locale", menuName = "Create ThruLine Locale", order = 1)]
public class LocaleSO : ScriptableObject
{
    public string Name;

    public ESection Section;

    public Sprite[] BGList;

    [SerializeField]
    private bool canTravelTo;

    public List<LocaleSO> linkedLocations;

    public List<CharacterSO> WhoIsHere;
}
