using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Timer
{
    [SerializeField] private float count;
    [SerializeField] private float time;
    public Timer( float time = 1.0f, float count = 0.0f )
	{
        this.count = count;
        this.time = time;
	}

    public void DoUpdate( float deltaTime )
	{
        count += deltaTime;
        if (count > time) count = time;
	}

    public bool IsEnd() { return count >= time; }
    public float GetRate() { return count / time; }
    public void Reset( float rate = 0.0f )
	{
        count = rate * time;
	}
}