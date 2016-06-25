using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Canvas settingsMenu;
    public Button playButton;
    public Button buildButton;
    public Button settingsButton;
    public Button exitButton;

    ArrayList mainMenu = new ArrayList();

	// Use this for initialization
	void Start () {

        //collect the necessary components for making the menu interactable
        //Canvases
        quitMenu = quitMenu.GetComponent<Canvas>();
        settingsMenu = settingsMenu.GetComponent<Canvas>();

        //Buttons
        playButton = playButton.GetComponent<Button>();
        buildButton = buildButton.GetComponent<Button>();
        settingsButton = settingsButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

        //Set secondary menus inactive (Hide them)
        quitMenu.enabled = false;
        settingsMenu.enabled = false;

        //Add components to menus
        //Main menu components
        mainMenu.Add(playButton);
        mainMenu.Add(buildButton);
        mainMenu.Add(settingsButton);
        mainMenu.Add(exitButton);
    }
	
    void ToggleActive(ArrayList elements)
    {
        foreach(Behaviour elem in elements)
        {
            if (elem.enabled)
            {
                elem.enabled = false;
            }else
            {
                elem.enabled = true;
            }
        }
    }

	public void ExitPress()
    {
        quitMenu.enabled = true;
        ToggleActive(mainMenu);
    }

    public void CancelExit()
    {
        quitMenu.enabled = false;
        ToggleActive(mainMenu);
    }

    public void PlayGame()
    {
        //Load next level
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        //quit the game
        Application.Quit();
    }

    public void BuildDeck()
    {
        //Load deck Builder
        SceneManager.LoadScene(2);
    }

    public void Settings()
    {
        //Bring Up the settings menu
        settingsMenu.enabled = true;
        ToggleActive(mainMenu);
    }

    public void ExitSettings()
    {
        //exit the settings menu
        settingsMenu.enabled = false;
        ToggleActive(mainMenu);
    }
}
