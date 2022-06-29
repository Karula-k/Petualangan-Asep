using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uifirenotif : MonoBehaviour
{
   public Image fireIcon;
   public Text score;

    public string Score
    {
        get { return score.text; }
        set { score.text = value; }
    }
}
