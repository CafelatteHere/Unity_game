using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThrowable 
{
    Transform transform { get; }

    void Launch(Vector2 direction);
}
