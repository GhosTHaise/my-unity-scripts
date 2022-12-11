using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public int waitForSecond;
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter(){
        yield return new WaitForSecondsRealtime(waitForSecond);
        Destroy(gameObject);
    } 
}
