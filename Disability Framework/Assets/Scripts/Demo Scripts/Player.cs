using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject right;
    [SerializeField] private GameObject left;

    [SerializeField] private float timeForGun;
    // Start is called before the first frame update
    void Start()
    {
        TurnOff();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left.SetActive(true);
            Invoke("TurnOff",Time.deltaTime*timeForGun);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right.SetActive(true);
            Invoke("TurnOff",Time.deltaTime*timeForGun);
        }
    }

    public void TurnOff()
    {
        left.SetActive(false);
        right.SetActive(false);
    }
}
