using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charctermove : MonoBehaviour
{
    public Transform cameratrans;

    public float movespeed = 10f; // 움직이는 스피드
    public float jumpspeed = 10f; // 점프 스피드
    public float gravity = -20f; // 중력
    public float yVelocity = 0; // Velocity(벨로시티)는 속도 라는 뜻
    public bool ghost = false;
    public CharacterController characterController; // rigidbody(리지드바디)가 없어도 움직일수 있게 만들어준다.

    public float sensitivity = 500f;
    public float rotationX;
    public float rotationY;

    public int HP = 100;
    public int sarmor = 25;
    public int barmor = 50;


    void Start()
    {
        characterController = GetComponent<CharacterController>(); // 캐릭터 컨트롤러에 플레이어의 캐릭터 컨트롤러를 넣는다(자동으로)
        cameratrans = transform.GetChild(0); // 자식개체의 1번째에 있는 오브젝트의 트랜스폼을 가져옴(자동으로)
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // 호리즌탈(가로)의 방향을 받음
        float v = Input.GetAxis("Vertical"); // 버티칼(세로)의 방향을 받음

        Vector3 moveDirection = new Vector3(h, 0, v); // 무브 디렉션이라는 이름의 벡터3를 선언해 움직일 방향을 맞춤
        moveDirection = cameratrans.TransformDirection(moveDirection);
        moveDirection *= movespeed;// 무브 디렉션에 무브 스피드를 넣음

        if (characterController.isGrounded) // isGrounded는 땅에 붙어있는지 아닌지 판단함
        {
            yVelocity = 0; // Y벨로시티의 속도를 0으로
            if (Input.GetKeyDown(KeyCode.Space)) // 만약 스페이스바를 누른다면
            {
                yVelocity = jumpspeed; // Y벨로시티에 점프 스피드를 넣는다.
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

        yVelocity += (gravity * Time.deltaTime); // Y벨로시티에서 중력(gravity)의 값을 뺌
        moveDirection.y = yVelocity; // 무브 디렉션에 Y벨로시티를 넣는다.

        characterController.Move(moveDirection * Time.deltaTime); // 무브 디렉션에 Time.deltaTime을 넣어 움직임 속도를 조정함

        if(transform.position.y < 0)
        {
            transform.position = new Vector3(0, 20, 0);
        }

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
