using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCorotine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(testco());
        Debug.Log("222");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator testco()
    {
        Debug.Log("1111");
        yield return null;
        Debug.Log("pass 3");
        yield return new WaitForSeconds(1);
        Debug.Log("pass 1");
    }
}
