using UnityEngine;

#if UNITY_EDITOR || UNITY_STANDALONE
namespace DragonsDemons.Utils
{
    public enum TouchPhase
    {
        Began = 1,
        Moved = 2,
        Stationary = 3,
        Ended = 4,
        Canceled = 5
    }

    public enum EditorOrientation
    {
        Unknown = 1,
        Portrait = 2,
        PortraitUpsideDown = 3,
        LandscapeLeft = 4,
        LandscapeRight = 5,
        FaceUp = 6,
        FaceDown = 7
    }

    public struct Touch
    {
        public int fingerId;
        public Vector2 position;
        public Vector2 deltaPosition;
        public float deltaTime;
        public int tapCount;
        public TouchPhase phase;
    }

    public class EditorSettings
    {
        static public bool verticalOrientation = true;
        static public bool screenCanDarken = true;
        static public string uniqueIdentifier = "PC";
        static public string name = "PC";
        static public string model = "PC";
        static public string systemName = "PC";
        static public string systemVersion = "PC";
    }

    public class Input
    {
        static public Touch[] touches;
        static public int touchCount;
        static public bool multiTouchEnabled;
        static public EditorOrientation orientation;

        static public Touch GetTouch(int index)
        {
            return touches[index];
        }
    }

    public class TouchEmulator : MonoBehaviour
    {
        private Vector2 pSpeed;
        private Vector3 pLastPos;

        static public void ResetTouch()
        {
            Input.touches[0].deltaTime = Time.deltaTime;
            Input.touches[0].phase = TouchPhase.Canceled;
            Input.touchCount = 0;
        }

        void Awake()
        {
            Input.touches = new Touch[2];
            for (int i = 0; i < Input.touches.Length; ++i)
            {
                Input.touches[i] = new Touch();
                Input.touches[i].fingerId = 0;
                Input.touches[i].position = (Vector2)UnityEngine.Input.mousePosition;
                Input.touches[i].deltaPosition = new Vector2(0, 0);
                Input.touches[i].deltaTime = Time.deltaTime;
                Input.touches[i].tapCount = 0;
                Input.touches[i].phase = TouchPhase.Canceled;
            }
            Input.touchCount = 0;
            Input.multiTouchEnabled = true;
            Input.orientation = EditorOrientation.LandscapeLeft;
        }

        void Update()
        {
            if (Input.touches == null)
                return;
			
            Vector2 curMousePos = (Vector2)UnityEngine.Input.mousePosition;

            switch (Input.touches[0].phase)
            {
                case TouchPhase.Canceled:
                    if (UnityEngine.Input.GetMouseButtonDown(0) == true)
                    {
                        Input.touches[0].fingerId = 0;
                        Input.touches[0].position = curMousePos;
                        Input.touches[0].deltaPosition = new Vector2(0, 0);
                        Input.touches[0].deltaTime = Time.deltaTime;
                        Input.touches[0].tapCount = 0;
                        Input.touches[0].phase = TouchPhase.Began;
                        Input.touchCount = 1;
                    }
                    break;

                case TouchPhase.Began:
                    Input.touches[0].deltaTime = Time.deltaTime;
                    Input.touches[0].phase = TouchPhase.Stationary;
                    break;

                case TouchPhase.Stationary:
                    if (Input.touches[0].position != curMousePos)
                    {
                        Input.touches[0].deltaPosition.x = curMousePos.x - Input.touches[0].position.x;
                        Input.touches[0].deltaPosition.y = curMousePos.y - Input.touches[0].position.y;
                        Input.touches[0].position = curMousePos;
                        Input.touches[0].deltaTime = Time.deltaTime;
                        Input.touches[0].phase = TouchPhase.Moved;
                    }
                    if (UnityEngine.Input.GetMouseButtonUp(0) == true)
                    {
                        Input.touches[0].deltaTime = Time.deltaTime;
                        Input.touches[0].phase = TouchPhase.Ended;
                    }
                    break;

                case TouchPhase.Moved:
                    if (Input.touches[0].position != curMousePos)
                    {
                        Input.touches[0].deltaPosition.x = curMousePos.x - Input.touches[0].position.x;
                        Input.touches[0].deltaPosition.y = curMousePos.y - Input.touches[0].position.y;
                        Input.touches[0].position = curMousePos;
                        Input.touches[0].deltaTime = Time.deltaTime;
                        Input.touchCount = 1;
                    }
                    else
                    {
                        Input.touches[0].deltaPosition = new Vector2(0, 0);
                        Input.touches[0].deltaTime = Time.deltaTime;
                        Input.touches[0].phase = TouchPhase.Stationary;
                    }
                    if (UnityEngine.Input.GetMouseButtonUp(0) == true)
                    {
                        Input.touches[0].deltaTime = Time.deltaTime;
                        Input.touches[0].phase = TouchPhase.Ended;
                    }
                    break;

                case TouchPhase.Ended:
                    Input.touches[0].deltaTime = Time.deltaTime;
                    Input.touches[0].phase = TouchPhase.Canceled;
                    Input.touchCount = 0;
                    break;
            }
        }
    }
}
#endif
