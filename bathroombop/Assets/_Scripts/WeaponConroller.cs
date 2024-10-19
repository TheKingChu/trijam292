using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConroller : MonoBehaviour
{
    private Animator animator;
    public KeyCode[] assignedKeys;
    private bool canBop = true;
    public float cooldownTime = 1f;
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canBop) return;

        foreach (KeyCode key in assignedKeys)
        {
            if (Input.GetKeyDown(key))
            {
                TriggerBop();
                break;
            }
        }
    }

    private void TriggerBop()
    {
        animator.SetTrigger("Bop");
        canBop = false;
        Invoke(nameof(ResetBop), cooldownTime);
    }

    private void ResetBop()
    {
        canBop = true;
    }
}
