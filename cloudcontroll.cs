using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudcontroll : MonoBehaviour
{
    public float appearTime = 2f;   // 오브젝트가 나타나는 시간
    public float disappearTime = 4f;    // 오브젝트가 사라지는 시간
    public float repeatTime = 6f;   // 반복 시간

    void Start()
    {
        // 오브젝트를 처음에는 보이지 않게 함
        gameObject.SetActive(false);

        // 일정 시간마다 오브젝트를 나타내고 사라지게 함
        InvokeRepeating("ToggleObject", appearTime, repeatTime);
    }


    void ToggleObject()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
