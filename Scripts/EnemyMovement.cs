using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;
    Rigidbody2D myrigidbody;
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FacingRight())
        {
            myrigidbody.velocity = new Vector2(movespeed, 0f);
        }
        else
        {
            myrigidbody.velocity = new Vector2(-movespeed, 0f);
        }
    }

    bool FacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myrigidbody.velocity.x)),1f);
    }
}
