using UnityEngine;
using System;

public class ZombieLife : MonoBehaviour
{
    private Action onDeath;

    public void Init(Action _onDeath)
    {
        onDeath = _onDeath;
    }

    public void Kill()
    {
        var callback = onDeath;
        if (callback != null)
        {
            callback.Invoke();
        }

        Destroy(gameObject);
    }
}
