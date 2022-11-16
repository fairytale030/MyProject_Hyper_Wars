using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public Transform GIZMO; //�ѱ� ��ǥ
    public LineRenderer BEAM;   //����

    public float firedaly = 0f;
    public float firedalyf = 0f;

    public float reset = 100f;
    public LineRenderer width;

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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (firedaly <= 0)
            {
                firedaly = 4f;
                reset = 3f;
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
        BEAM.SetPosition(0, GIZMO.position);    //������ �������� ���� ������� ��ġ�� �Ѵ�.
        yield return null;
        BEAM.gameObject.GetComponent<LineRenderer>().enabled = true;
        width.GetComponent<LineRenderer>().startWidth = 0.3f;
        width.GetComponent<LineRenderer>().endWidth = 0.3f;
    }
}
