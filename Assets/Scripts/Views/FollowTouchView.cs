using JoostenProductions;
using UnityEngine;

public class FollowTouchView : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trailRenderer;

    public void Init()
    {
        //Cursor.visible = false;
        UpdateManager.SubscribeToUpdate(RenderTail);
    }

    private void OnDestroy()
    {
        UpdateManager.UnsubscribeFromUpdate(RenderTail);
    }

    private void RenderTail()
    {
        if (Input.touchCount <= 0)
            return;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        transform.position = pos;

#if DEBUG
        Debug.Log($"mousePos {pos} tr.pos {transform.position}");
#endif

    }
}
