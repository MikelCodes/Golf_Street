using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public GameObject GM;
    public int damage;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    void OnCollisionEnter (Collision Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            if (cooldown <= 0)
            {
                GM.GetComponent<game_Manager>().timer -= damage;
                cooldown = 2;
            }
        }
    }
}
