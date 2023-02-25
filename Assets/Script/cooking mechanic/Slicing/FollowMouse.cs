using UnityEngine;
using UnityEngine.EventSystems;

namespace Slicing.FollowMouse
{
    public class FollowMouse : MonoBehaviour
    {
        void Update()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // Mendapatkan posisi pointer mouse di dunia game
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = transform.position.z;

                // Mendapatkan batas area tampilan kamera
                float cameraHeight = Camera.main.orthographicSize;
                float cameraWidth = cameraHeight * Camera.main.aspect;
                float xMax = Camera.main.transform.position.x + cameraWidth;
                float xMin = Camera.main.transform.position.x - cameraWidth;
                float yMax = Camera.main.transform.position.y + cameraHeight;
                float yMin = Camera.main.transform.position.y - cameraHeight;

                // Jika pointer mouse berada di dalam area tampilan kamera
                if (mousePosition.x <= xMax && mousePosition.x >= xMin && mousePosition.y <= yMax && mousePosition.y >= yMin)
                {
                    // Menggerakkan game object ke posisi pointer mouse
                    transform.position = mousePosition;
                }
            }
        }
    }
}
