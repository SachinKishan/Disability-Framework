using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_Demo : MonoBehaviour
{
    private AudioSource source;

    private Dictionary<Direction, float> soundDirectonPan;

    public static SoundManager_Demo main;

    private void Awake()
    {
        soundDirectonPan=new Dictionary<Direction, float>();
        soundDirectonPan.Add(Direction.Left,-1);
        soundDirectonPan.Add(Direction.Right,1);
        soundDirectonPan.Add(Direction.Up,0);
        main = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        source=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //every sound manager probably has a function that plays a specific sound
    public void PlaySound(Sound_ScriptableObject_Demo s)//the actual sound is sent as argument. In this case, it is a scriptable object
    {
        //call subtitle manager
       
        if(source)source.panStereo=soundDirectonPan[s.subtitle.sourceDirection];
        if(source) source.PlayOneShot(s.clip);
        SubtitleManager.Main.ChangeCurrentSubtitle(s.subtitle);
        SubtitleManager.Main.MakeSubtitle();
    }
}
