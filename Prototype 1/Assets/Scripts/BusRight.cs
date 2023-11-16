using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCome : MonoBehaviour
{
    public float speed = 30;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = this.gameObject.transform.position;
        if (pos.y < -50)
        {
            transform.position = new Vector3(5, 0, 180);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
