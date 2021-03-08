using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public float speed;
    PhotonView view;
    Health healthScript;

    LineRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        healthScript = FindObjectOfType<Health>();
        rend = FindObjectOfType<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
            transform.position += (Vector3)moveAmount;

            rend.SetPosition(0, transform.position);

        }
        else
        {
            rend.SetPosition(1, transform.position);
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (view.IsMine)
        {
            if (collision.tag == "Enemy")
            {
                healthScript.TakeDamage();
            }
        }
      
    }
}
