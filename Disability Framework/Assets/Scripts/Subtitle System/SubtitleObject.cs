using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum Direction
{
    None,Right,Left,Up,Down
}
public class SubtitleObject : MonoBehaviour
{
    [SerializeField]private TMP_Text text;
    private Subtitle subtitle;

    private Direction direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSubtitle(Subtitle s)
    {
        subtitle = s;
        text.text = s.subtitleText;
        text.text += s.sourceDirection;
    }
}
