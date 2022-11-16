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

    public float power = 25f;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            firecur += Time.deltaTime;
            if (firecur >= firecool)
            {
                firecur = 0;
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = firePosition.position; // �Ѿ��� �����Ǵ� ������ fireposition�� ��ġ�� ����
                bullet.GetComponent<Rigidbody>().velocity = cameraTransform.forward * power; // �Ѿ��� ������Ʈ�߿� ������ �ٵ� ������Ʈ�� ������ ���ν�Ƽ�� ������ ���� ���� ����
                
            }
        }
        else
        {
            firecur = 0.24f;
        }
    }
}
