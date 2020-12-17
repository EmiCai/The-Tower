using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nouvelle : MonoBehaviour
{
    // Update is called once per frame
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
