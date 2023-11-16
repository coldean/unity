using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPla : MonoBehaviour
{
    public GameObject player;
    public bool thirdPerson = true;

    public bool player1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player1 && Input.GetKeyDown(KeyCode.U))
            thirdPerson = !thirdPerson;
        else if (!player1 && Input.GetKeyDown(KeyCode.T))
            thirdPerson = !thirdPerson;

        if (thirdPerson)
        {
            transform.SetParent(null);
            transform.position = player.transform.position + new Vector3(0, 5, -7);
            transform.rotation = Quaternion.Euler(10, 0, 0);
        }
        else
        {
            transform.parent = player.transform;
            transform.localPosition = new Vector3(0, 2, 1);
            transform.localRotation = Quaternion.Euler(-3, 0, 0);
        }

    }
}
