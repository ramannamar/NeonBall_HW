using UnityEngine.SceneManagement;

namespace UI.WinPanel
{
    public static class RestartButton
    {
        public static void LevelRestart()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}