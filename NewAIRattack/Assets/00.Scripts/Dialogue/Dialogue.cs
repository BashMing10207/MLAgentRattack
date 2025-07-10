using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Message", menuName = "SO/Message/Message")]
public class Dialogue : ScriptableObject
{
    public virtual void Init()
    { 
    
    }
    public List<DialogueList> messages = new();
    public string Say;
}

[Serializable]
public class DialogueList
{
    public List<Dialogue> Dialogues = new();
}
