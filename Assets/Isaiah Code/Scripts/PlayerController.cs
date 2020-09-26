﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    private LayerMask moveableObjects = 9;

    public Animator anim;

    public float vertPosition;
    private float horPosition;

    private bool vertMove;
    private bool horMove;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;

        horMove = true;
        vertMove = true;

        MoveNumber.moveCount = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime); //Moves the player towards the move point always

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f) //If the player is close on the move point, allows them to move again
        {
            

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((Input.GetAxisRaw("Horizontal") * .72f), 0f, 0f), .2f, whatStopsMovement) && horMove == true) //Checks if there is something to collide with in the player move spot
                {
                    StartCoroutine(MoveCooldownHorizontal());

                    horMove = false;

                    movePoint.position += new Vector3((Input.GetAxisRaw("Horizontal") * .72f), 0f, 0f);
                    horPosition = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
                    vertPosition = 0;

                    anim.SetBool("moving", false);

                }//Basic movement, moves player on 72px grid

            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, (Input.GetAxisRaw("Vertical") * .72f), 0f), .2f, whatStopsMovement) && vertMove == true)
                {
                    StartCoroutine(MoveCooldownVertical());

                    vertMove = false;

                    movePoint.position += new Vector3(0f, (Input.GetAxisRaw("Vertical") * .72f), 0f);
                    vertPosition = Mathf.Abs(Input.GetAxisRaw("Vertical"));
                    horPosition = 0;

                    anim.SetBool("moving", false);

                }//Basic movement, moves player on 72px grid
            }

        }
        else
        {
            anim.SetBool("moving", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Moveable"))
        {
            var relativePosition = transform.InverseTransformPoint(collision.transform.position);

            if (relativePosition.y > 0)
            {
                Debug.Log("up");
<<<<<<< HEAD
                if (!Physics2D.OverlapCircle(collision.transform.position + new Vector3(0f, (Input.GetAxisRaw("Vertical") * .72f), 0f), .5f, whatStopsMovement) &&
                !Physics2D.OverlapCircle(collision.transform.position + new Vector3(0f, (Input.GetAxisRaw("Vertical") * .72f), 0f), .4f, moveableObjects))
=======
                collision.transform.position += new Vector3(0f, .72f, 0f);

                if (!Physics2D.OverlapCircle(collision.transform.position + new Vector3(0f, (Input.GetAxisRaw("Vertical") * .72f), 0f), .5f, whatStopsMovement))
>>>>>>> e6d57d42317b14f3dc66fe2ee7993341476a3c0e
                {
                    collision.transform.position += new Vector3(0f, .72f, 0f);
                }
                else
                {
                    movePoint.transform.position += new Vector3(0f, -.72f, 0f);
                }
            }
            else if (vertPosition == 0)
            {
                if (relativePosition.x < 0)
                {
                    Debug.Log("left");
<<<<<<< HEAD
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((Input.GetAxisRaw("Horizontal") * .72f), 0f, 0f), 1.6f, whatStopsMovement) &&
                    !Physics2D.OverlapCircle(movePoint.position + new Vector3((Input.GetAxisRaw("Horizontal") * .72f), 0f, 0f), .4f, moveableObjects))
=======
                    collision.transform.position += new Vector3(-.72f, 0f, 0f);

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((Input.GetAxisRaw("Horizontal") * .72f), 0f, 0f), 1.6f, whatStopsMovement))
>>>>>>> e6d57d42317b14f3dc66fe2ee7993341476a3c0e
                    {
                        collision.transform.position += new Vector3(-.72f, 0f, 0f);
                    }
                    else
                    {
                        movePoint.transform.position += new Vector3(.72f, 0f, 0f);
                    }
<<<<<<< HEAD
=======

>>>>>>> e6d57d42317b14f3dc66fe2ee7993341476a3c0e
                }
                else if (relativePosition.x > 0)
                {
                    Debug.Log("right");
<<<<<<< HEAD
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((Input.GetAxisRaw("Horizontal") * .72f), 0f, 0f), 1.6f, whatStopsMovement) &&
                    !Physics2D.OverlapCircle(movePoint.position + new Vector3((Input.GetAxisRaw("Horizontal") * .72f), 0f, 0f), .4f, moveableObjects))
=======

                    collision.transform.position += new Vector3(.72f, 0f, 0f);

                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3((Input.GetAxisRaw("Horizontal") * .72f), 0f, 0f), 1.6f, whatStopsMovement))
>>>>>>> e6d57d42317b14f3dc66fe2ee7993341476a3c0e
                    {
                        collision.transform.position += new Vector3(.72f, 0f, 0f);
                    }
                    else
                    {
                        movePoint.transform.position += new Vector3(-.72f, 0f, 0f);
                    }
<<<<<<< HEAD
=======

>>>>>>> e6d57d42317b14f3dc66fe2ee7993341476a3c0e
                }
            }
            else if (relativePosition.y < 0)
            {
                Debug.Log("down");
<<<<<<< HEAD
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, (Input.GetAxisRaw("Vertical") * .72f), 0f), .5f, whatStopsMovement) &&
                !Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, (Input.GetAxisRaw("Vertical") * .72f), 0f), .4f, moveableObjects))
=======

                collision.transform.position += new Vector3(0f, -.72f, 0f);

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, (Input.GetAxisRaw("Vertical") * .72f), 0f), .5f, whatStopsMovement))
>>>>>>> e6d57d42317b14f3dc66fe2ee7993341476a3c0e
                {
                    collision.transform.position += new Vector3(0f, -.72f, 0f);
                }
                else
                {
                    movePoint.transform.position += new Vector3(0f, .72f, 0f);
                }
<<<<<<< HEAD
=======

>>>>>>> e6d57d42317b14f3dc66fe2ee7993341476a3c0e
            }
        } //Checks where the player is in relationship to the moveable object and then moves the object accordingly
    }

    public IEnumerator MoveCooldownHorizontal()
    {
        MoveNumber.moveCount -= 1;

        yield return new WaitForSeconds(.3f);

        horMove = true;

        yield break;
    }

    public IEnumerator MoveCooldownVertical()
    {
        MoveNumber.moveCount -= 1;

        yield return new WaitForSeconds(.3f);

        vertMove = true;

        yield break;
    }
}
