using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Subtitle", menuName = "Subtitle System/Create a Subtitle")]

public class Subtitle : ScriptableObject
{
    [SerializeField] private string subtitleName;

    [TextArea] public string subtitleText;
    public Direction sourceDirection;
    
    public Subtitle GetSubtitle()
    {
        
        return this;
    }
    
}
