using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translator : MonoBehaviour {
    private int count;
    // Use this for initialization


    void Start () {
         count=0;

	}
	
	// Update is called once per frame
	void Update () {

        if (count<=135) {
            count++;
            this.transform.Translate(new Vector3(6, 0, 0) * Time.deltaTime);
        }
        if (count >= 135)
        {
            this.transform.Translate(new Vector3(-6, 0, 0) * Time.deltaTime);
            count++;
            if (count==270)
            {
                count = 0;
            }
        }

    }
}
