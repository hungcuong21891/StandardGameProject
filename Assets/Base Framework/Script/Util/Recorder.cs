#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace BaseFramework {
    /// <summary>
    /// Recorder.
    /// </summary>
    public class Recorder : EditorWindow {
        /// <summary>
        /// My string.
        /// </summary>
        string myString = "FileNameHere";
        /// <summary>
        /// The status.
        /// </summary>
        string status = "Idle";
        /// <summary>
        /// The record button.
        /// </summary>
        string recordButton = "Record";
        /// <summary>
        /// The state.
        /// </summary>
        int state = 0;
        /// <summary>
        /// The fps.
        /// </summary>
        int fps = 24;
        /// <summary>
        /// The fps options.
        /// </summary>
        int[] fpsOptions = new int[] { 12, 24, 30, 60 };
        /// <summary>
        /// The dis options.
        /// </summary>
        string[] disOptions = new string[] { "12", "24", "30", "60" };
        /// <summary>
        /// The last frame time.
        /// </summary>
        float lastFrameTime = 0.0f;
        /// <summary>
        /// The image increment.
        /// </summary>
        int imageIncrement = 0;
        /// <summary>
        /// The record video.
        /// </summary>
        bool recordVideo = false;
        /// <summary>
        /// Init this instance.
        /// </summary>
        [MenuItem("Window/Recorder")]
        static void Init() {
            // Get existing open window or if none, make a new one:
            Recorder window = (Recorder)EditorWindow.GetWindow(typeof(Recorder));
            window.Show();
        }
        /// <summary>
        /// Raises the GUI event.
        /// </summary>
        void OnGUI() {
            GUILayout.Label("Recorder", EditorStyles.boldLabel);
            myString = EditorGUILayout.TextField("File Name:", myString);
            fps = EditorGUILayout.IntPopup(fps, disOptions, fpsOptions);
            if (state == 0) { // idle 
                if (GUILayout.Button(recordButton)) {
                    imageIncrement = 0;
                    recordVideo = true;
                    recordButton = "Stop";
                    state = 1;
                }
            }
            if (state == 1) { // recording 
                if (GUILayout.Button(recordButton)) {
                    status = "Idle";
                    recordButton = "Record";
                    recordVideo = false;
                    state = 0;
                }
            }
            GUILayout.Label(status, EditorStyles.boldLabel);
            //		myString = EditorGUILayout.TextField ("Text Field", myString); 
            //		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled); 
            //		myBool = EditorGUILayout.Toggle ("Toggle", myBool); 
            //		myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3); 
            //		EditorGUILayout.EndToggleGroup ();
        }
        /// <summary>
        /// Update this instance.
        /// </summary>
        void Update() {
            if (recordVideo == true && EditorApplication.isPlaying) {
                RecordImages();
                Repaint();
            } else if (recordVideo == true && !EditorApplication.isPlaying) {
                status = "Waiting for Editor to Play";
            }
        }
        /// <summary>
        /// Records the images.
        /// </summary>
        void RecordImages() {
            if (lastFrameTime < Time.time + (1 / fps)) {
                status = "Recording In Progress: Image_" + myString + "" + imageIncrement;
                Application.CaptureScreenshot(myString + "" + imageIncrement + ".png");
                imageIncrement++;
                lastFrameTime = Time.time;
            }
        }
    }
}
#endif