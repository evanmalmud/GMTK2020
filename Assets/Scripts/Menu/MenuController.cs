using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // If adding a new object make sure to add them to the disable all list and their own active method
    [SerializeField] private GameObject MainMenuCanvas = null, OptionsCanvas = null, CreditsCanvas = null;
    [SerializeField] private GameObject FadeCanvas = null;


        // Start is called before the first frame update
        void Start()
    {
        //Start by Disabling all but mainMenu
        deactivateAllCanvases();
        mainMenuActive(true);
    }

    private void Update()
    {
        if(MainMenuCanvas.activeSelf) {
            if (Input.GetButton("Submit"))
            {
                loadScene();
            }
        }
    }

    // Public Methods

    /// <summary>
    /// Deactivates all Canvases and enabled the Credits Canvas
    /// </summary>
    /// <param name="active"></param>
    public void creditsActiveAndDeactiveOthers(bool active)
    {
        deactivateAllCanvases();
        creditsActive(active);
    }

    /// <summary>
    /// Deactivates all Canvases and enabled the MainMenu Canvas
    /// </summary>
    /// <param name="active"></param>
    public void mainMenuActiveAndDeactiveOthers(bool active)
    {
        deactivateAllCanvases();
        mainMenuActive(active);
    }

    /// <summary>
    /// Deactivates all Canvases and enabled the Options Canvas
    /// </summary>
    /// <param name="active"></param>
    public void optionsActiveAndDeactiveOthers(bool active)
    {
        deactivateAllCanvases();
        optionsActive(active);
    }

    /// <summary>
    /// Opens Game Scene
    /// </summary>
    public void playSceneLoad()
    {
        // Update Scene to GamePlay Scene
        FadeCanvas.GetComponent<FadeInOut>().fadeIn(this);

        // TODO: Update for whatever GameScene you are using
    }

    public void loadScene() {
        SceneManager.LoadScene("Game");
    }

    /// Private Methods

    private void deactivateAllCanvases()
    {
        mainMenuActive(false);
        optionsActive(false);
        creditsActive(false);
    }

    private void creditsActive(bool active)
    {
        if (CreditsCanvas != null)
        {
            CreditsCanvas.SetActive(active);
        }
        else
        {
            Debug.Log("CreditsCanvas is not set on MenuController.");
        }
    }

    private void mainMenuActive(bool active) 
    {
        if (MainMenuCanvas != null)
        {
            MainMenuCanvas.SetActive(active);
        } else {
            Debug.Log("MainMenuCanvas is not set on MenuController.");
        }
        
    }

    private void optionsActive(bool active)
    {
        if (OptionsCanvas != null)
        {          
            OptionsCanvas.SetActive(active);
        } else {
            Debug.Log("OptionsCanvas is not set on MenuController.");
        }
    }

    public void quitGame() {
        Application.Quit();
    }
}
