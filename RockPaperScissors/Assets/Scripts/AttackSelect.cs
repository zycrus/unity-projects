using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelect : MonoBehaviour
{
    public int selectPos = 0;
    public RectTransform[] images;

    private void Start()
    {
        images[selectPos].transform.localScale = new Vector3(0.8f, 0.8f, images[selectPos].transform.localScale.z);
    }

    private void Update()
    {
        ScrollSelect();
    }

    private void ScrollSelect()
    {
        images[selectPos].transform.localScale = Vector3.one;
        if (Input.mouseScrollDelta.y < 0.0f)
        {
            if (selectPos < 2)
                selectPos += 1;
            else
                selectPos = 0;
        }
        if (Input.mouseScrollDelta.y > 0.0f)
        {
            if (selectPos > 0)
                selectPos -= 1;
            else
                selectPos = 2;
        }
        images[selectPos].transform.localScale = new Vector3(0.8f, 0.8f, images[selectPos].transform.localScale.z);
    }
}