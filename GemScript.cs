using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging) {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown() {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp() {
        dragging = false;
    }
}