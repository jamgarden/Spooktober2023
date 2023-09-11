using System.Collections;
using System.Collections.Generic;
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

    
}
