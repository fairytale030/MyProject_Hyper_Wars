using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT9M : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject bulletPrefab;
    public Transform firePosition;
    public float firecur = 0.18f;
    public float firecool = 0.2f;
    public float power = 25f;
    public int ammo = 15;

    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        firecur += Time.deltaTime;
        if (ammo != 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (firecur >= firecool)
                {
                    ammo--;
                    GameObject bullet = Instantiate(bulletPrefab);
                    firecur = 0;
                    bullet.transform.position = firePosition.position; // 총알이 생성되는 지점을 fireposition에 위치로 정함
                    bullet.GetComponent<Rigidbody>().velocity = cameraTransform.forward * power; // 총알의 컴포넌트중에 리지드 바디 컴포넌트를 가져와 벨로시티에 앞으로 가는 힘을 넣음
                    StartCoroutine(FirePT9M());
                    if (ammo <= 0)
                    {
                        ani.SetBool("Noammo_PT-9M", true);
                        StartCoroutine(Noammo());
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadPT9M());
        }
    }

    IEnumerator ReloadPT9M()
    {
        ani.SetBool("Reload_PT-9M", true);
        yield return new WaitForSeconds(2.0f);
        ani.SetBool("Reload_PT-9M", false);
        ammo = 15;
    }

    IEnumerator Noammo()
    {
        ani.SetBool("Noammo_PT-9M", true);
        yield return new WaitForSeconds(0.2f);
        ani.SetBool("Noammo_PT-9M", false);
    }

    IEnumerator FirePT9M()
    {
        ani.SetBool("Fire_PT-9M", true);
        yield return new WaitForSeconds(0.2f);
        ani.SetBool("Fire_PT-9M", false);
    }
}
