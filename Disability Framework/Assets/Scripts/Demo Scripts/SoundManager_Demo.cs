using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_Demo : MonoBehaviour
{
    private AudioSource source;
    
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
        source.PlayOneShot(s.clip);
        SubtitleManager.Main.ChangeCurrentSubtitle(s.subtitle);
        SubtitleManager.Main.MakeSubtitle();
    }
}
