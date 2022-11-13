using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Game_Manager : MonoBehaviour
{
    [SerializeField] private Sound_ScriptableObject_Demo s;
    [SerializeField] private GameObject ghost;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private float speed=1f;
    [SerializeField] private float timetoGhost;
    [SerializeField] private float speedIncrease;
    [SerializeField] private float ghostTimeDecrease;

    [SerializeField] private float timeBetweenSoundAndGhost;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Make());
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    IEnumerator Make()
    {
        while (true)
        {
            yield return new WaitForSeconds(timetoGhost);
          StartCoroutine(CreateGhost());
            speed += speedIncrease;
            timetoGhost -= ghostTimeDecrease;
        }
    }

    IEnumerator CreateGhost()
    {
        float a = Random.Range(-1.0f, 1.0f);
        s.subtitle.sourceDirection = a > 0 ? Direction.Left : Direction.Right;
        SoundManager_Demo.main.PlaySound(s);
        
        yield return new WaitForSeconds(timeBetweenSoundAndGhost);
        
        GameObject g= Instantiate(ghost, a > 0 ? left.position : right.position, left.rotation);
        g.GetComponent<Ghost_Behavior>().dir=(a<0? Vector2.left : Vector2.right);
        g.GetComponent<Ghost_Behavior>().speed = speed;
        g.transform.localScale = new Vector3(a < 0 ? 1 : -1, g.transform.localScale.y, g.transform.localScale.z);

    }


}
