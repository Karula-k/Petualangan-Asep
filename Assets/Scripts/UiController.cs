using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Image portrait;
    public Text fullName;
    public Text dialog;

    private character speaker;
    public character Speaker
    {
        get { return speaker; }
        set
        {
            speaker = value;
            portrait.sprite = speaker.portrait;
            fullName.text = speaker.fullName;
        }
    }

    public string Dialog
    {
        get { return dialog.text; }
        set { dialog.text = value; }
    }

 
    public Color SetValue
    {
        get { return dialog.color; }
        set { dialog.color = value; }
    }
    public bool HasSpeaker()
    {
        return speaker != null;
    }

    public bool SpeakerIs(character character)
    {
        return speaker == character;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
