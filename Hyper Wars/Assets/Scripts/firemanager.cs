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
            bullet.transform.position = firePosition.position; // �Ѿ��� �����Ǵ� ������ fireposition�� ��ġ�� ����
            bullet.GetComponent<Rigidbody>().velocity = cameraTransform.forward * power; // �Ѿ��� ������Ʈ�߿� ������ �ٵ� ������Ʈ�� ������ ���ν�Ƽ�� ������ ���� ���� ����
        }
    }
}
