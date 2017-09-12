using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace BaseFramework {
    /// <summary>
    /// Gradient background.
    /// </summary>
    public class GradientBackground : MonoBehaviour {
        /// <summary>
        /// The list start colors.
        /// </summary>
        public List<Color> listStartColors;
        /// <summary>
        /// The list end colors.
        /// </summary>
        public List<Color> listEndColors;
        /// <summary>
        /// The time of change.
        /// </summary>
        public float timeOfChange;
        /// <summary>
        /// The index of the current color.
        /// </summary>
        private int currentColorIndex;
        /// <summary>
        /// The color of the need change.
        /// </summary>
        private bool needChangeColor;
        /// <summary>
        /// The color of the time.
        /// </summary>
        private float timeColor;
        /// <summary>
        /// The current color start.
        /// </summary>
        private Color currentColorStart;
        /// <summary>
        /// The current color end.
        /// </summary>
        private Color currentColorEnd;
        /// <summary>
        /// The start color.
        /// </summary>
        private Color startColor = Color.red;
        /// <summary>
        /// The end color.
        /// </summary>
        private Color endColor = Color.blue;
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
            //init
            currentColorIndex = 0;
            needChangeColor = false;
            startColor = listStartColors[currentColorIndex];
            endColor = listEndColors[currentColorIndex];
            currentColorStart = startColor;
            currentColorEnd = endColor;
            //set mesh color
            var mesh = GetComponent<MeshFilter>().mesh;
            var colors = new Color[mesh.vertices.Length];
            colors[0] = startColor;
            colors[1] = endColor;
            colors[2] = startColor;
            colors[3] = endColor;
            mesh.colors = colors;
            //listen to events
            EventManager.StartListening("ChangeColor", UpdateCurrentColorIndex);
        }
        /// <summary>
        /// Update this instance.
        /// </summary>
        void Update() {
            var mesh = GetComponent<MeshFilter>().mesh;
            var colors = new Color[mesh.vertices.Length];
            colors[0] = startColor;
            colors[1] = endColor;
            colors[2] = startColor;
            colors[3] = endColor;
            mesh.colors = colors;
            if (needChangeColor) {
                timeColor = timeColor + Time.deltaTime / timeOfChange;
                Color tempStartColor = Color.Lerp(currentColorStart, listStartColors[currentColorIndex], timeColor);
                Color tempEndColor = Color.Lerp(currentColorEnd, listEndColors[currentColorIndex], timeColor);
                startColor = tempStartColor;
                endColor = tempEndColor;
                if (timeColor >= timeOfChange) {
                    startColor = listStartColors[currentColorIndex];
                    endColor = listEndColors[currentColorIndex];
                    currentColorStart = startColor;
                    currentColorEnd = endColor;
                    needChangeColor = false;
                    timeColor = 0;
                }
            }
        }
        /// <summary>
        /// Updates the index of the current color.
        /// </summary>
        /// <param name="info">Info.</param>
        void UpdateCurrentColorIndex(EventInfo info) {
            currentColorIndex += 1;
            if (currentColorIndex >= listStartColors.Count) {
                currentColorIndex = 0;
            }
            needChangeColor = true;

        }
    }
}
