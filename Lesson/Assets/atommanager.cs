using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atommanager : MonoBehaviour
{
    public int currentElectronNum = 0;
    int correctElectronNum = -1;
    public int currentProtonNum = 0;
    int correctProtonNum = -1;

    public Textcontrol atomInfo;

    public Vector3 firstProtonPosition;
    public Vector3 firstElectronPosition;
    public float electronAngleDivide;
    public float protonAngleDivide;

    public void AddElectron()
    {
        currentElectronNum++;
        electronAngleDivide = 360 / currentElectronNum;
        CheckCorrectAtom();
    }

    public void SubtractElectron()
    {
        currentElectronNum--;
        electronAngleDivide = 360 / currentElectronNum ;

        CheckCorrectAtom();

    }

    //new
    public void AddProton()
    {

        currentProtonNum++;

        protonAngleDivide = 360 / currentProtonNum;

        CheckCorrectAtom();

    }
    public void SubtractProton()
    {
        currentProtonNum--;
        protonAngleDivide = 360 / currentProtonNum;

        CheckCorrectAtom();

    }


    void CheckCorrectAtom()
    {
        //new
        if (currentElectronNum == correctElectronNum && currentProtonNum == correctProtonNum)
        {
            atomInfo.ShowNewText("Correct!");
            StartCoroutine("WaitAndNextLevel");
        }
    }

    IEnumerator WaitAndNextLevel()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<Levelmanager>().NextLevel();
    }

    public void SetNextLevel(Levelmanager.Atom nextAtom)
    {
        correctElectronNum = nextAtom.electrons;
        correctProtonNum = nextAtom.protons;
        currentProtonNum = 0;
        currentElectronNum = 0;
    }
}
