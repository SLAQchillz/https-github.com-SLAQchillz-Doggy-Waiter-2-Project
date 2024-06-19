using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable_EventRouter : MonoBehaviour
{
    public UnityEvent onBreakableFirstStack;
    public UnityEvent onBreakableStack;
    public UnityEvent onBreakableUnstack;
    public GameObjectUnityEvent onBreakableBreakWithObject;

    public void AcceptNewObject(GameObject go)
    {
        CheckBreakableStackEvents(go);
        CheckBreakableOnBreakEvents(go);
    }

    private void CheckBreakableOnBreakEvents(GameObject go)
    {
        Breakable_OnCollision component = go.GetComponentInChildren<Breakable_OnCollision>();
        if (component != null)
        {
            SubscribeToOnBreakWithObject(component);
        }
    }

    private void SubscribeToOnBreakWithObject(Breakable_OnCollision component) { component.onBreakWithObject.AddListener((obj) => onBreakableBreakWithObject?.Invoke(obj)); }

    #region Breakable Stack Events
    private void CheckBreakableStackEvents(GameObject go)
    {
        Breakable_ScoreStack component = go.GetComponentInChildren<Breakable_ScoreStack>();
        if (component != null)
        {
            SubscribeToOnFirstStack(component);
            SubscribeToOnStack(component);
            SubscribeToOnUnstack(component);
        }
    }
    private void SubscribeToOnFirstStack(Breakable_ScoreStack component) { component.onFirstStack.AddListener(() => onBreakableFirstStack.Invoke()); }
    private void SubscribeToOnStack(Breakable_ScoreStack component) { component.onStack.AddListener(() => onBreakableStack.Invoke()); }
    private void SubscribeToOnUnstack(Breakable_ScoreStack component) { component.onUnstack.AddListener(() => onBreakableUnstack.Invoke()); }
    private void UnsubscribeFromOnFirstStack(Breakable_ScoreStack component) { component.onFirstStack.RemoveListener(() => onBreakableFirstStack.Invoke()); }
    #endregion
}
