using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Panel : MonoBehaviour 
{
    public enum Type
    {
        NEWS,
        USER,
        FAVORITE,
        DONATION,
        ABOUT,
        EVENT
    }

    [SerializeField] private Type _type;

    public virtual void AInitialize()
    {
        gameObject.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AUpdate()
    {
    
    }

    public Type GetPanelType()
    {
        return _type;
    }
}
