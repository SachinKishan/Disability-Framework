using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Sound(Demo)", menuName = "Subtitle System/Create a subtitle sound(Demo)")]

public class Sound_ScriptableObject_Demo : ScriptableObject
{
    public AudioClip clip;
    public float volume;
    public Subtitle subtitle;
}
