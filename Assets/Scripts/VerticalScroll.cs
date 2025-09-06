using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [SerializeField] float scrollrate = 0.2f;
    void Update()
    {
        transform.Translate(new Vector2(0f, scrollrate * Time.deltaTime));
    }
}
