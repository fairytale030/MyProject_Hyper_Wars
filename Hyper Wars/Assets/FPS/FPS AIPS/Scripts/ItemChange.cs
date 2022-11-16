using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EvolveGames
{
    public class ItemChange : MonoBehaviour
    {
        [Header("Item Change")]
        [SerializeField] public Animator ani;
        [SerializeField] bool LoopItems = true;
        [SerializeField] int ItemIdInt;
        int MaxItems;
        int ChangeItemInt;
        [HideInInspector] public bool DefiniteHide;
        public GameObject one;
        public GameObject two;
        public GameObject thri;

        private void Start()
        {
            if (ani == null && GetComponent<Animator>()) ani = GetComponent<Animator>();
            DefiniteHide = false;
            ChangeItemInt = ItemIdInt;
            StartCoroutine(ItemChangeObject());
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(ItemChangeObject());
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartCoroutine(ItemChangeObject2());
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                StartCoroutine(ItemChangeObject3());
            }
        }

        public void Hide(bool Hide)
        {
            DefiniteHide = Hide;
            ani.SetBool("Hide", Hide);
        }

        IEnumerator ItemChangeObject()
        {
            if(!DefiniteHide) ani.SetBool("Hide", true);
            yield return new WaitForSeconds(0.3f);
            one.SetActive(true);
            two.SetActive(false);
            thri.SetActive(false);
            if (!DefiniteHide) ani.SetBool("Hide", false);
        }
        IEnumerator ItemChangeObject2()
        {
            if (!DefiniteHide) ani.SetBool("Hide", true);
            yield return new WaitForSeconds(0.3f);
            one.SetActive(false);
            two.SetActive(true);
            thri.SetActive(false);
            if (!DefiniteHide) ani.SetBool("Hide", false);
        }
        IEnumerator ItemChangeObject3()
        {
            if (!DefiniteHide) ani.SetBool("Hide", true);
            yield return new WaitForSeconds(0.3f);
            one.SetActive(false);
            two.SetActive(false);
            thri.SetActive(true);
            if (!DefiniteHide) ani.SetBool("Hide", false);
        }
    }

}
