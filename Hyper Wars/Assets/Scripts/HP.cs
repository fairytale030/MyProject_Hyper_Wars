using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hp = 100;
    public bool isdead = false;
    public Animator ani;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(hp <= 0)
        {
            isdead = true;
            ani.SetBool("dead", true);
            Destroy(gameObject, 3f);
        }
    }
}
