using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public Transform GIZMO; //총구 좌표
    public LineRenderer BEAM;   //궤적

    public float firedaly = 0f;
    public float firedalyf = 0f;

    public float reset = 100f;
    public LineRenderer width;

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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (firedaly <= 0)
            {
                firedaly = 4f;
                reset = 3f;
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
        }
        firedaly -= Time.deltaTime;
        reset -= Time.deltaTime;
        width.GetComponent<LineRenderer>().startWidth -= 0.1f*Time.deltaTime;
        width.GetComponent<LineRenderer>().endWidth -= 0.1f*Time.deltaTime;
        if(width.GetComponent<LineRenderer>().startWidth <= 0f)
        {
            width.GetComponent<LineRenderer>().startWidth = 0f;
        }
        if (width.GetComponent<LineRenderer>().endWidth <= 0f)
        {
            width.GetComponent<LineRenderer>().endWidth = 0;
        }
        if (reset <= 0)
        {
            BEAM.gameObject.GetComponent<LineRenderer>().enabled = false;
        }
    }

    IEnumerator ShootBeam()
    {
        BEAM.SetPosition(0, GIZMO.position);    //궤적의 시작점을 현재 기즈모의 위치로 한다.
        yield return null;
        BEAM.gameObject.GetComponent<LineRenderer>().enabled = true;
        width.GetComponent<LineRenderer>().startWidth = 0.3f;
        width.GetComponent<LineRenderer>().endWidth = 0.3f;
    }
}
