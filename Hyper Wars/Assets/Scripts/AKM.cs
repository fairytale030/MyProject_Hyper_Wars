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
