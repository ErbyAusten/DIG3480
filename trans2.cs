using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trans2 : MonoBehaviour {

    private int count;
    // Use this for initialization


    void Start()
    {
        count = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (count <= 260)
        {
            count++;
            this.transform.Translate(new Vector3(2, 0, 0) * Time.deltaTime);
        }
        if (count >= 260)
        {
            this.transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime);
            count++;
            if (count == 520)
            {
                count = 0;
            }
        }

    }
}
