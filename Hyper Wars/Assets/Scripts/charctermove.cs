using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charctermove : MonoBehaviour
{
    public Transform cameratrans;

    public float movespeed = 10f; // �����̴� ���ǵ�
    public float jumpspeed = 10f; // ���� ���ǵ�
    public float gravity = -20f; // �߷�
    public float yVelocity = 0; // Velocity(���ν�Ƽ)�� �ӵ� ��� ��
    public bool ghost = false;
    public CharacterController characterController; // rigidbody(������ٵ�)�� ��� �����ϼ� �ְ� ������ش�.

    public float sensitivity = 500f;
    public float rotationX;
    public float rotationY;

    public int HP = 100;
    public int sarmor = 25;
    public int barmor = 50;


    void Start()
    {
        characterController = GetComponent<CharacterController>(); // ĳ���� ��Ʈ�ѷ��� �÷��̾��� ĳ���� ��Ʈ�ѷ��� �ִ´�(�ڵ�����)
        cameratrans = transform.GetChild(0); // �ڽİ�ü�� 1��°�� �ִ� ������Ʈ�� Ʈ�������� ������(�ڵ�����)
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // ȣ����Ż(����)�� ������ ����
        float v = Input.GetAxis("Vertical"); // ��ƼĮ(����)�� ������ ����

        Vector3 moveDirection = new Vector3(h, 0, v); // ���� �𷺼��̶�� �̸��� ����3�� ������ ������ ������ ����
        moveDirection = cameratrans.TransformDirection(moveDirection);
        moveDirection *= movespeed;// ���� �𷺼ǿ� ���� ���ǵ带 ����

        if (characterController.isGrounded) // isGrounded�� ���� �پ��ִ��� �ƴ��� �Ǵ���
        {
            yVelocity = 0; // Y���ν�Ƽ�� �ӵ��� 0����
            if (Input.GetKeyDown(KeyCode.Space)) // ���� �����̽��ٸ� �����ٸ�
            {
                yVelocity = jumpspeed; // Y���ν�Ƽ�� ���� ���ǵ带 �ִ´�.
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            ghost = true;
            movespeed = 3;
        }
        else
        {
            ghost = false;
            movespeed = 5;
        }

        yVelocity += (gravity * Time.deltaTime); // Y���ν�Ƽ���� �߷�(gravity)�� ���� ��
        moveDirection.y = yVelocity; // ���� �𷺼ǿ� Y���ν�Ƽ�� �ִ´�.

        characterController.Move(moveDirection * Time.deltaTime); // ���� �𷺼ǿ� Time.deltaTime�� �־� ������ �ӵ��� ������

        if(transform.position.y < 0)
        {
            transform.position = new Vector3(0, 20, 0);
        }

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
