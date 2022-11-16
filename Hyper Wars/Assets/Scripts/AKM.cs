using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKM : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject bulletPrefab;
    public Transform firePosition;
    public float firecur = 0.12f;
    public float firecool = 0.5f;

    public bool IsMove = false;

    public float power = 25f;
    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            IsMove = true;
        }
        else
        {
            IsMove = false;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            firecur += Time.deltaTime;
            if (firecur >= firecool)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                firecur = 0;
                bullet.transform.position = firePosition.position; // 총알이 생성되는 지점을 fireposition에 위치로 정함
                bullet.GetComponent<Rigidbody>().velocity = cameraTransform.forward * power; // 총알의 컴포넌트중에 리지드 바디 컴포넌트를 가져와 벨로시티에 앞으로 가는 힘을 넣음
            }
        }
        else
        {
            firecur = 0.24f;
        }
    }
}
