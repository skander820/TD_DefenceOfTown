using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            EventCenter.BroadCast<string>(EventType.ShowText,"你好");
            //Debug.Log(EventCenter.eventTable);
        });
    }

}
