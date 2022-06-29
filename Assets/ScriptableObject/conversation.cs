using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public character character;

    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class conversation : ScriptableObject
{
    public character speakerLeft;
    public character speakerRight;
    public Line[] lines;
}