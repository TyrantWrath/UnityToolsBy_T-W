using UnityEngine;
using UnityEngine.UI;

namespace TyrantsWrath.UserInterface
{
    public class ShowFPS : MonoBehaviour
    {
        [SerializeField] private Text fpsText;

        [Tooltip("updateTime is time on how fast FPS should be updated")]
        [SerializeField] private float updateTime = 0.1f;
        private float timer;
        private float updateDeltaTime;

        void Update()
        {
            timer += Time.deltaTime;

            if (timer >= updateTime)
            {
                updateDeltaTime += (Time.deltaTime - updateDeltaTime) * 0.1f;
                float fps = 1.0f / updateDeltaTime;

                fpsText.text = Mathf.Ceil(fps).ToString();
                timer = 0;
            }
        }
    }
}

