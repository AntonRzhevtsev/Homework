using UnityEngine;
using UnityEngine.SceneManagement;

namespace Homework2_2Task_2
{
    public class GameManager : MonoBehaviour
    {
        public void StartGame()
        {
            Debug.Log("Game started!");
        }

        public void RestartGame() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        public void EndGame()
        {
            Debug.Log("Game Over!");
        }
    }
}
