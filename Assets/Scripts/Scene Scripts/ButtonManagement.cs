using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void ExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Unity Editöründe oyunu durdur
#else
        Application.Quit(); 
#endif
    }
}
