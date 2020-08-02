using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameState
{
    public class GameMenuController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Restart"))
            {
                var sceneName = SceneManager.GetActiveScene().name;
                SceneManager.UnloadSceneAsync(sceneName);
                EventRepo.DeregisterAll();
                SceneManager.LoadScene(sceneName);
                GameStateData.GameOver = false;
            }
        }
    }
}
