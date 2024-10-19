using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConroller : MonoBehaviour
{
    private Animator animator;

    private bool canBop = true;
    public float cooldownTime = 1f;
    public float moveSpeed = 10f;
    private Vector3 initialPos;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canBop) return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("BopW");
            StartCoroutine(BopCooldown());
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("BopA");
            StartCoroutine(BopCooldown());
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("BopS");
            StartCoroutine(BopCooldown());
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("BopD");
            StartCoroutine(BopCooldown());
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetTrigger("BopO");
            StartCoroutine(BopCooldown());
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetTrigger("BopP");
            StartCoroutine(BopCooldown());
        }
    }

    private IEnumerator BopCooldown()
    {
        canBop = false;
        yield return new WaitForSeconds(cooldownTime);
        canBop = true;
    }
}
