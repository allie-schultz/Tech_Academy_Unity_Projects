using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
   public void switchScenes(int sceneIndex)
   {
      // Check if the scene index is valid
      if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
      {
         // Load the specified scene
         SceneManager.LoadScene(sceneIndex);
      }
    }
}
