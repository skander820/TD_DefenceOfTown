using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {
    public float moveSpeed = 30;
    public float mouseSpeed = 200;
    void Update () {
        float h = Input.GetAxis ("Horizontal");
        float v = Input.GetAxis ("Vertical");
        float mouse = Input.GetAxis ("Mouse ScrollWheel");
        transform.Translate (new Vector3 (h, mouse * mouseSpeed, v) * Time.deltaTime * moveSpeed, Space.World);

    }
}