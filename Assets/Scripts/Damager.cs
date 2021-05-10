using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public GameObject GM;
    public int damage;
    private float cooldown;

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    void OnCollisionStay (Collision Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            if (cooldown <= 0)
            {
                GM.GetComponent<game_Manager>().timer -= damage;
                cooldown = 2;

                Collision.gameObject.GetComponent<AudioSource>().Play();


            }
        }
        cooldown -= Time.deltaTime;
    }
}
