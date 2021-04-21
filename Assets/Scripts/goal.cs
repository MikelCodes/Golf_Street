using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public GameObject GM;

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Ball")
        {
            
            
            GM.GetComponent<game_Manager>().Win = true;
            
        }
    }
}
