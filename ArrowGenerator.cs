using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowprehab;
    float span = 1.0f;
    float delta = 0;
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowprehab);
            int px = Random.Range(-3, 3); //화살 생성 범위
            go.transform.position = new Vector3(px, 20, 0); //생성 높이
        }

    }
}
