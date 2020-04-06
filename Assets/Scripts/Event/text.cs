using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class text : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {

        //EventCenter.AddListener(EventType.ShowText, Show_hello);
        EventCenter.AddListener<string>(EventType.ShowText, Show_text);
    }

    void Show_hello()
    {
        Text text = this.GetComponent<Text>();
        text.text = "hello";
    }
    void Show_text( string word )
    {
        Text text = this.GetComponent<Text>();
        text.text = word;

    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<string>(EventType.ShowText, Show_text);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
