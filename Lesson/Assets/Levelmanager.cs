using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelmanager : MonoBehaviour
{
    public Textcontrol levelInfo;
    int currentLevel = 0;
    public bool gamePaused = false;
    public GameObject winScreen;

    LevelInfo lvl;

    //new
    public class Atom
    {
        public string atomName;
        public int electrons;
        public int protons;

        public Atom(string name, int e, int p)
        {
            atomName = name;
            electrons = e;
            protons = p;
        }
    }

    //new
    List<Atom> atoms;

    void Start()
    {
        lvl = FindObjectOfType<LevelInfo>();
        //new
        AddAtomlist();
        //new
        atommanager[] neutrons = FindObjectsOfType<atommanager>();

        //new
        foreach (atommanager neutron in neutrons)
        {
            //new
            neutron.SetNextLevel(atoms[lvl.currentLevel]);
        }
        StartCoroutine("ShowTextAfterTime");
    }

    //new
    private void AddAtomlist()
    {
        atoms = new List<Atom>();

        atoms.Add(new Atom("Hydrogen", 1, 1));
        atoms.Add(new Atom("Helium", 2, 2));
        atoms.Add(new Atom("Lithium", 3, 3));
    }

    IEnumerator ShowTextAfterTime()
    {
        yield return new WaitForSeconds(1.3f);
        int tempCurrentLvl = lvl.currentLevel + 1;
        levelInfo.ShowNewText("Level " + tempCurrentLvl + ": Build a " + atoms[lvl.currentLevel].atomName + " atom");
    }

    public void NextLevel()
    {
        lvl.currentLevel++;

        if(lvl.currentLevel >= atoms.Count)
        {
            lvl.YouWon();
        }

        SceneManager.LoadScene("levelTransition");
        /*
        Orbit[] interactiveParticles = FindObjectsOfType<Orbit>();

        foreach (Orbit particle in interactiveParticles)
        {
            particle.ResetLayout();
        }

        atommanager[] neutrons = FindObjectsOfType<atommanager>();

        foreach (atommanager neutron in neutrons)
        {
            //new
            neutron.SetNextLevel(atoms[currentLevel]);
        }
        */
        //new
        //int currentLevelForText = lvl.currentLevel + 1;
        //levelInfo.ShowNewText("Level " + currentLevelForText + ": Build A " + atoms[lvl.currentLevel].atomName +  " Atom");

    }

    public void TogglePause()
    {
        gamePaused = !gamePaused;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
