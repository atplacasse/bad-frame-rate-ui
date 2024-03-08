using System;
using UnityEngine;
using UnityEngine.UI;

namespace Arcane
{
    public class Controller : MonoBehaviour
    {
        [SerializeField]
        Slider mainSlider;

        [SerializeField]
        Button cursorModeButton;

        [SerializeField]
        Texture2D handCursor;

        [SerializeField]
        CursorMode cursorMode = CursorMode.Auto;

        Vector3 originalCameraPosition;

        public void Start()
        {
            originalCameraPosition = Camera.main.transform.position;

            mainSlider.onValueChanged.AddListener(delegate { OnMainSliderValueChanged(); });
            cursorModeButton.onClick.AddListener(delegate { OnCursorModeButtonClicked(); });

            SetCursor();
        }

        void OnCursorModeButtonClicked()
        {
            cursorMode = cursorMode == CursorMode.Auto ? CursorMode.ForceSoftware : CursorMode.Auto;
            SetCursor();
        }

        void SetCursor()
        {
            var hotspot = new Vector2(0.35f * handCursor.width, 0 * handCursor.height);
            Cursor.SetCursor(handCursor, hotspot, cursorMode);

            cursorModeButton.GetComponentInChildren<Text>().text = $"Current cursor mode: {cursorMode}";
        }

        void OnMainSliderValueChanged()
        {
            var newCameraPosition = originalCameraPosition;
            newCameraPosition.x += mainSlider.value;
            Camera.main.transform.position = newCameraPosition;
        }
    }
}
