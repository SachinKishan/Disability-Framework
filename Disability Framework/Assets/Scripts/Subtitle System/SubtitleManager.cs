using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SubtitleManager : MonoBehaviour
{
    [SerializeField] private Subtitle currentSubtitle;
    [SerializeField] private RectTransform subtitleCreationPos;
    [SerializeField] private RectTransform endPoint;
    [SerializeField] private GameObject subtitleObject;
    private TMP_Text subtitleText;
    [HideInInspector]public static SubtitleManager Main;
    [SerializeField] private float secondsBeforeNextSubtitle;

    private void Awake()
    {
        Main = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        subtitleText = subtitleObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeSubtitle()
    { 
        StartCoroutine(Wait());
        
    }

    public void ChangeCurrentSubtitle(Subtitle s)
    {
        currentSubtitle = s;//
        
        subtitleText.text = currentSubtitle.subtitleText+" "+ (currentSubtitle.sourceDirection == Direction.None? " ":currentSubtitle.sourceDirection.ToString());

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(secondsBeforeNextSubtitle);

        GameObject a= Instantiate(subtitleObject, subtitleCreationPos);
        a.GetComponent<SubtitleTextBehavior>().StartMoving(endPoint);
        
    }
}
