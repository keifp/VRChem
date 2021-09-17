using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager3 : MonoBehaviour
{
    public Textcontrol levelInfo;

    private void Start()
    {
        StartCoroutine("ShowTextAfterTime");
    }

    IEnumerator ShowTextAfterTime()
    {
        yield return new WaitForSeconds(2f);
        levelInfo.ShowNewText("Level 1: Build a Hydrogen Atom.");
    }
}