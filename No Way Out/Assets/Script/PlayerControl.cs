using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerControl : MonoBehaviour {

    Animator anim;
    Rigidbody2D rb;
    CircleCollider2D cir_col;

    AudioManager audioManager;

    public InputManager input;
    public Variables variables;


    public enum AnimState
    {
        Fly,
        FlyBack,
        Death,
        DeathBack
    }

    public AnimState animState;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cir_col = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        animState = AnimState.Fly;
    }


    public bool keyDown()
    {
        return Input.GetMouseButtonDown(0);
    }

    void HandleRigi()
    {
        if (keyDown() && !variables.death)
        {
            AudioManager.PlayJumpSound("Click");

            FindObjectOfType<BeginMove>().enabled = false;

            rb.bodyType = RigidbodyType2D.Dynamic;

            switch (animState)
            {
                case AnimState.Fly:
                    rb.velocity = Vector2.up * variables.forceX + Vector2.right * variables.forceY;
                    break;

                case AnimState.FlyBack:
                    rb.velocity = Vector2.up * variables.forceX - Vector2.right * variables.forceY;
                    break;
            }
        }
    }

    void HandleState()
    {
        switch(animState)
        {
            case AnimState.Fly:
                anim.SetBool("Fly", true);
                anim.SetBool("FlyBack", false);
                break;
            case AnimState.FlyBack:
                anim.SetBool("FlyBack", true);
                anim.SetBool("Fly", false);
                break;
            case AnimState.Death:
                anim.SetBool("Death", true);
                break;
            case AnimState.DeathBack:
                anim.SetBool("DeathBack", true);
                break;

        }
    }

    int number = 0;
    int temp = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!variables.death)
        {
            if (collision.transform.tag == "EdgeRight")
            {
                animState = AnimState.FlyBack;

                //Kích hoạt va chạm tường phải khi đến lần thứ 2
                if (temp == 0)
                {
                    if (number <= 2)
                    {
                        number++;
                    }
                    if (number > 1)
                        variables.hitCollisionEdgeRight = true;
                }

                variables.hitEdgeRight = true;
                variables.hitEdgeLeft = false;
            }
            else if (collision.transform.tag == "EdgeLeft")
            {
                temp = 0;
                animState = AnimState.Fly;
                variables.hitCollisionEdgeLeft = true;
                variables.hitEdgeLeft = true;
                variables.hitEdgeRight = false;
            }

            if (collision.transform.tag == "Spike")
            {
                variables.death = true;

                switch (animState)
                {
                    case AnimState.Fly:
                        animState = AnimState.Death;
                        break;

                    case AnimState.FlyBack:
                        animState = AnimState.DeathBack;
                        break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        variables.hitEdgeRight = false;
        variables.hitEdgeLeft = false;
    }

    int tempAudio = 0;

    private void Update()
    {
        HandleRigi();
        HandleState();

        if(variables.death)
        {
            if(tempAudio == 0)
            {
                AudioManager.PlayJumpSound("Error");
                tempAudio++;
            }
        }
    }
}
