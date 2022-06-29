using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    public conversation conversation;

    public GameObject speakerLeft;
    public GameObject speakerRight;
    public string nameScene;

    private UiController speakerUILeft;
    private UiController speakerUIRight;
    private int activeLineIndex;
    private bool conversationStarted = false;

    public void ChangeConversation(conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }

    private void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<UiController>();
        speakerUIRight = speakerRight.GetComponent<UiController>();
        AdvanceLine();
    }

    public void nextLine() {
        AdvanceLine();
    }
    public void exit()
    {
        EndConversation();
    }
    private void EndConversation()
    {

        conversationStarted = false;
        speakerUILeft.Hide();
        speakerUIRight.Hide();
        SceneManager.LoadScene(nameScene);

    }

    private void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;
    }

    private void AdvanceLine()
    {
        if (conversation == null) return;
        if (!conversationStarted) Initialize();

        if (activeLineIndex < conversation.lines.Length)
            DisplayLine();
        else
            EndConversation();
    }

    private void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        character character = line.character;

        if (speakerUILeft.SpeakerIs(character))
        {
            SetDialog(speakerUILeft, speakerUIRight, line,Color.gray);
        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line,Color.white);
        }

        activeLineIndex += 1;
    }



    private void SetDialog(
        UiController activeSpeakerUI,
        UiController inactiveSpeakerUI,
        Line line,
        Color color
    )
    {
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();

        activeSpeakerUI.Dialog = "";

        activeSpeakerUI.SetValue=color;

        StopAllCoroutines();
        StartCoroutine(EffectTypewriter(line.text, activeSpeakerUI));
    }

    private IEnumerator EffectTypewriter(string text, UiController controller)
    {
        foreach (char character in text.ToCharArray())
        {
            controller.Dialog += character;
            yield return new WaitForSeconds(0.005f);
            // yield return null;
        }
    }
}
