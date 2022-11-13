using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleTextBehavior : MonoBehaviour
{
     [SerializeField]private RectTransform rt;
    [SerializeField] private float timeToMove;
    [SerializeField] private float timeToLive;
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void StartMoving(RectTransform r)
    {
        var pos = r.localPosition;
        //sayDialog.localPosition = new Vector3(pos.x, 840, pos.z);
        pos = new Vector3(pos.x, pos.y, pos.z);
        //StartCoroutine(LerpPosition(pos, timeToMove));
   
    }
    
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = rt.localPosition;
        while (time < duration)
        {
            rt.localPosition = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        rt.localPosition = targetPosition;
        Destroy(gameObject,timeToLive);

    }
}
