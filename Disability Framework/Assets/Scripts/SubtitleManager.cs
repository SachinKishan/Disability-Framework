using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SubtitleManager : MonoBehaviour
{
    [SerializeField] private Subtitle currentSubtitle;
    [SerializeField] private RectTransform subtitleCreationPos;

    [SerializeField] private GameObject subtitleObject;

    public static SubtitleManager Main;

    private void Awake()
    {
        Main = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeSubtitle()
    {
        Instantiate(subtitleObject, subtitleCreationPos);
    }
}
