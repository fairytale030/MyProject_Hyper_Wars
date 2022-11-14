using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public Transform GIZMO; //총구 좌표
    public LineRenderer BEAM;   //궤적
    public float firecur = 0f;
    public float firecool = 0.25f;

    // Use this for initialization
    void Awake()
    {
        BEAM.startWidth = 0.05f;
        BEAM.endWidth = 0.001f;     //궤적 두께 설정 초기화
    }

    // Update is called once per frame
    void Update()
    {   //발사 간격의 등간격을 위해 FixedUpdate 내에서 진행
        RaycastHit hit;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            firecur += Time.deltaTime;
            if(firecur >= firecool)
            {
                firecur = 0f;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 1000.0f))
                {
                    BEAM.SetPosition(1, hit.point); //레이가 맞았다면 맞은 지점까지를 궤적으로 그린다.
                }
                else
                {
                    BEAM.SetPosition(1, transform.position + transform.forward * 1000.0f);    //레이가 맞지 않았다면 에임이 있는 거리에 가상으로 끝점을 그린다.
                }

                StartCoroutine(ShootBeam());    //궤적을 그리는 코루틴 작동.
            }

            //StartCoroutine(ShootBeam());    //궤적을 그리는 코루틴 작동.
        }
        else
        {
            firecur = 0.24f;
        }
    }

    IEnumerator ShootBeam()
    {
        BEAM.SetPosition(0, GIZMO.position);    //궤적의 시작점을 현재 기즈모의 위치로 한다.
        BEAM.gameObject.SetActive(true);
        yield return null;
        BEAM.gameObject.SetActive(false);
    }
}