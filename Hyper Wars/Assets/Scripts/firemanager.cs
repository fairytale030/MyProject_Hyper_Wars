using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firemanager : MonoBehaviour
{
    public Transform cameraTransform;
    public GameObject bulletPrefab;
    public Transform firePosition;

    public float power = 25f;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = firePosition.position; // 총알이 생성되는 지점을 fireposition에 위치로 정함
            bullet.GetComponent<Rigidbody>().velocity = cameraTransform.forward * power; // 총알의 컴포넌트중에 리지드 바디 컴포넌트를 가져와 벨로시티에 앞으로 가는 힘을 넣음
        }
    }
}
