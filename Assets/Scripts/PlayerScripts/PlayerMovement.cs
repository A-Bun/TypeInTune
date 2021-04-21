using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Fader fader;
    public GameObject piano;

    private float moveSpeed = 5f;
    private Vector3 movement;
    private bool canMove = true;

    void Start()
    {
        if(fader.gameObject.GetComponent<Image>().color.a != 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ReachPiano();

        if (fader.gameObject.GetComponent<Image>().color.a == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (canMove)
        {
            movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        transform.position += movement * Time.fixedDeltaTime * moveSpeed;
    }

    public void ReachPiano()
    {
        if((transform.position.x * 1.5) <= piano.transform.position.x)
        {
            canMove = false;
            gameObject.SetActive(false);
            fader.FadeToNextLevel();
        }
    }
}
