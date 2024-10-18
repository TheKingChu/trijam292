using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureBase : MonoBehaviour
{
    protected bool isPoppedUp = false;
    protected float timer = 0f;

    public KeyCode assignedKey;

    public float popupTime = 2f;
    public float popdownTime = 1f;

    protected virtual void Popup()
    {
        isPoppedUp = true;
        timer = 0f;
        transform.Translate(Vector3.up * 1f);
    }

    protected virtual void Popdown()
    {
        isPoppedUp = false;
        timer = 0f;
        transform.Translate(Vector3.down * 3f);

        //FindObjectOfType<OverflowManager>().MissedCreature;
    }

    protected virtual void Bop()
    {
        isPoppedUp = false;
        timer = 0f;
        transform.Translate(Vector3.up * 1f);
        //add points
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;

        if (!isPoppedUp && timer >= popupTime)
        {
            Popdown();
        }

        if(isPoppedUp && Input.GetKeyDown(assignedKey))
        {
            Bop();
        }
    }
}
