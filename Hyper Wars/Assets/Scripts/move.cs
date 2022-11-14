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
        float mouseMoveValueX = Input.GetAxis("Mouse X"); // 반드시 마우스 입력후 띄고 X
        float mouseMoveValueY = Input.GetAxis("Mouse Y"); // 반드시 마우스 입력후 띄고 Y

        rotationY += mouseMoveValueX * sensitivity * Time.deltaTime; // 로테이션 Y에는 X를 넣고
        rotationX += mouseMoveValueY * sensitivity * Time.deltaTime; // 로테이션 X에는 Y를 넣어야함

        if (rotationX > 85f)
            rotationX = 85f;

        if (rotationX < -85f)
            rotationX = -85f;

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);
    }
}
