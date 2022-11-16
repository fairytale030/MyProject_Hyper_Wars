using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCX : MonoBehaviour
{
    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadMCX());
        }   
    }

    IEnumerator ReloadMCX()
    {
        ani.SetBool("reload_MCX", true);
        yield return new WaitForSeconds(0.45f);
        ani.SetBool("reload_MCX", false);
    }
}
