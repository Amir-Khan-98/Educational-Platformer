using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject controlRodJournal;
    public GameObject fuelRodJournal;
    public GameObject moderatorJournal;
    public GameObject coolantJournal;

    public GameObject injectionWellJournal;
    public GameObject hotWaterExtractJournal;

    public GameObject mainJournal;
    public GameObject mainNuclear;
    public GameObject mainGeothermal;

    public void GoToLevelSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void StartFirstLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToJournal()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToSecondLevel()
    {
        SceneManager.LoadScene(5);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void JournalToggle()
    {
        if (!mainJournal.activeSelf)
        {
            mainJournal.SetActive(true);
        }
        else
        {
            mainJournal.SetActive(false);
        }
    }
    public void NuclearToggle()
    {
        if (!mainNuclear.activeSelf)
        {
            mainNuclear.SetActive(true);
        }
        else
        {
            mainNuclear.SetActive(false);
        }
    }
    public void GeothermalToggle()
    {
        if (!mainGeothermal.activeSelf)
        {
            mainGeothermal.SetActive(true);
        }
        else
        {
            mainGeothermal.SetActive(false);
        }
    }
    public void NuclearHub()
    {
        JournalToggle();
        NuclearToggle();
    }
    public void GeothermalHub()
    {
        JournalToggle();
        GeothermalToggle();
    }
    public void JournalFuelRod()
    {
        if (!fuelRodJournal.activeSelf)
        {
            fuelRodJournal.SetActive(true);
            NuclearToggle();
        }
        else
        {
            fuelRodJournal.SetActive(false);
            NuclearToggle();
        }
        
    }
    public void JournalControlRod()
    {
        if (!controlRodJournal.activeSelf)
        {
            controlRodJournal.SetActive(true);
            NuclearToggle();
        }
        else
        {
            controlRodJournal.SetActive(false);
            NuclearToggle();
        }
    }
    public void JournalModerator()
    {
        if (!moderatorJournal.activeSelf)
        {
            moderatorJournal.SetActive(true);
            NuclearToggle();
        }
        else
        {
            moderatorJournal.SetActive(false);
            NuclearToggle();
        }
    }
    public void JournalCoolant()
    {
        if (!coolantJournal.activeSelf)
        {
            coolantJournal.SetActive(true);
            NuclearToggle();
        }
        else
        {
            coolantJournal.SetActive(false);
            NuclearToggle();
        }
    }
    public void JournalInjectionWell()
    {
        if (!injectionWellJournal.activeSelf)
        {
            injectionWellJournal.SetActive(true);
            GeothermalToggle();
        }
        else
        {
            injectionWellJournal.SetActive(false);
            GeothermalToggle();
        }
    }
    public void JournalHotWaterExtract()
    {
        if (!hotWaterExtractJournal.activeSelf)
        {
            hotWaterExtractJournal.SetActive(true);
            GeothermalToggle();
        }
        else
        {
            hotWaterExtractJournal.SetActive(false);
            GeothermalToggle();
        }
    }

}
