using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float sensitivity = 500f;
    public float rotationX;
    public float rotationY;

    void Start()
    {
    }

    void Update()
    {
        float mouseMoveValueX = Input.GetAxis("Mouse X"); // �ݵ�� ���콺 �Է��� ��� X
        float mouseMoveValueY = Input.GetAxis("Mouse Y"); // �ݵ�� ���콺 �Է��� ��� Y

        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime; // �����̼� Y���� X�� �ְ�
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime; // �����̼� X���� Y�� �־����

        if (rotationX > 85f)
            rotationX = 85f;

        if (rotationX < -85f)
            rotationX = -85f;

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);
    }
}
