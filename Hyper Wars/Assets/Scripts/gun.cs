using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public Transform GIZMO; //�ѱ� ��ǥ
    public LineRenderer BEAM;   //����
    public float firecur = 0f;
    public float firecool = 0.25f;

    // Use this for initialization
    void Awake()
    {
        BEAM.startWidth = 0.05f;
        BEAM.endWidth = 0.001f;     //���� �β� ���� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {   //�߻� ������ ����� ���� FixedUpdate ������ ����
        RaycastHit hit;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            firecur += Time.deltaTime;
            if(firecur >= firecool)
            {
                firecur = 0f;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 1000.0f))
                {
                    BEAM.SetPosition(1, hit.point); //���̰� �¾Ҵٸ� ���� ���������� �������� �׸���.
                }
                else
                {
                    BEAM.SetPosition(1, transform.position + transform.forward * 1000.0f);    //���̰� ���� �ʾҴٸ� ������ �ִ� �Ÿ��� �������� ������ �׸���.
                }

                StartCoroutine(ShootBeam());    //������ �׸��� �ڷ�ƾ �۵�.
            }

            //StartCoroutine(ShootBeam());    //������ �׸��� �ڷ�ƾ �۵�.
        }
        else
        {
            firecur = 0.24f;
        }
    }

    IEnumerator ShootBeam()
    {
        BEAM.SetPosition(0, GIZMO.position);    //������ �������� ���� ������� ��ġ�� �Ѵ�.
        BEAM.gameObject.SetActive(true);
        yield return null;
        BEAM.gameObject.SetActive(false);
    }
}