using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SubtitleManager : MonoBehaviour
{
    [SerializeField] private Subtitle currentSubtitle;
    [SerializeField] private RectTransform subtitleCreationPos;
    [SerializeField] private RectTransform endPoint;
    [SerializeField] private GameObject subtitleObject;
    [SerializeField] private RectTransform subtitleBox;
    private TMP_Text subtitleText;
    [HideInInspector]public static SubtitleManager Main;
    [SerializeField] private float secondsBeforeNextSubtitle;
    private Queue<GameObject> subs=new Queue<GameObject>();
    [SerializeField]private double max;
    private void Awake()
    {
        Main = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        subtitleText = subtitleObject.GetComponent<TMP_Text>();
        max=(0.75*(subtitleBox.rect.height/subtitleObject.GetComponent<RectTransform>().rect.height));
        max = Mathf.Floor((float)max);
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
        currentSubtitle = s;
        subtitleText = subtitleObject.GetComponent<TMP_Text>();

        if (s)
        {
            subtitleText.text = currentSubtitle.subtitleText + " " + (currentSubtitle.sourceDirection == Direction.None
                ? " "
                : currentSubtitle.sourceDirection.ToString());
            if (s.italics) subtitleText.fontStyle = FontStyles.Italic;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(secondsBeforeNextSubtitle);
        GameObject a= Instantiate(subtitleObject, subtitleCreationPos);
        a.GetComponent<SubtitleTextBehavior>().StartMoving(endPoint);
        if (subs.Count >= max)
        {
            GameObject temp= subs.Dequeue();
            Destroy(temp);
            subs.Enqueue(a);
        }
        else subs.Enqueue(a);
        Invoke("DeallocateSubtitle",currentSubtitle.duration);
    }

    public void DeallocateSubtitle()
    {
        GameObject a = subs.Dequeue();
        Destroy(a);
    }
}
