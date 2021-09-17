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

    public void AddElectron()
    {
        currentElectronNum++;
        CheckCorrectAtom();

    }

    //new
    public void AddProton()
    {
        currentProtonNum++;
        CheckCorrectAtom();

    }

    
    void CheckCorrectAtom()
    {
        print("Checking electron: " + currentElectronNum + " Checking Proton: "  + correctProtonNum);
        //new
        if (currentElectronNum == correctElectronNum && currentProtonNum == correctProtonNum)
        {
            atomInfo.ShowNewText("Correct");
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
