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
    public CharacterController characterController; // rigidbody(리지드바디)가 없어도 움직일수 있게 만들어준다.


    void Start()
    {
        characterController = GetComponent<CharacterController>(); // 캐릭터 컨트롤러에 플레이어의 캐릭터 컨트롤러를 넣는다(자동으로)
        cameratrans = transform.GetChild(0); // 자식개체의 1번째에 있는 오브젝트의 트랜스폼을 가져옴(자동으로)a
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // 처음으로 엑시스라는 함수 사용 // 호리즌탈(가로)의 방향을 받음
        float v = Input.GetAxis("Vertical"); // 처음으로 엑시스라는 함수 사용 // 버티칼(세로)의 방향을 받음

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

        yVelocity += (gravity * Time.deltaTime); // Y벨로시티에서 중력(gravity)의 값을 뺌
        moveDirection.y = yVelocity; // 무브 디렉션에 Y벨로시티를 넣는다.

        characterController.Move(moveDirection * Time.deltaTime); // 무브 디렉션에 Time.deltaTime을 넣어 움직임 속도를 조정함

        if(transform.position.y < 0)
        {
            transform.position = new Vector3(0, 20, 0);
        }
    }
}
