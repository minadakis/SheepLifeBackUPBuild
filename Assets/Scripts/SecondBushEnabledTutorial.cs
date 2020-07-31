using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBushEnabledTutorial : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public void EnableCollider()
    {
        boxCollider2D.enabled = true;
    }
}
