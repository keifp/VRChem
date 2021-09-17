using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Textcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowNewText(string text)
    {
        gameObject.SetActive(true);
        GetComponent<TextMeshPro>().text = text;

        StartCoroutine("HideText");
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}