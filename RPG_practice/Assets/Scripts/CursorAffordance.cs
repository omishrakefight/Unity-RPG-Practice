using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {

    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D unknownCursor = null;
    [SerializeField] Texture2D enemyCursor = null;

    [SerializeField] Vector2 cursorHotspot = new Vector2(96, 96);

    CameraRaycaster raycastHit;
	// Use this for initialization
	void Start () {
        raycastHit = GetComponent<CameraRaycaster>();
        raycastHit.onLayerChange += OnLayerChange;
	}
	
	// Update is called once per frame
	void OnLayerChange (Layer newLayer) {
        switch (newLayer)
        {
            case Layer.Walkable:
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(unknownCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Enemy:
                Cursor.SetCursor(enemyCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Debug.Log(" ? not sure what cursor to show...");
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
        }

	}
}
