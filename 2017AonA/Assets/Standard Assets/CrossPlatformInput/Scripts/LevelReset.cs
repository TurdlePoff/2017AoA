using UnityEngine;
using UnityEngine.EventSystems;

public class LevelReset : MonoBehaviour , IPointerClickHandler
{

	public void OnPointerClick (PointerEventData data) {

        // reload the scene
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevelAsync(Application.loadedLevelName);
#pragma warning restore CS0618 // Type or member is obsolete
    }

    private void Update()
    {
    }
}
