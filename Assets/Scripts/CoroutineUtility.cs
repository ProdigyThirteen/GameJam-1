using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineUtility : MonoBehaviour
{
    public static IEnumerator DelayAction(float delay, System.Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

}
