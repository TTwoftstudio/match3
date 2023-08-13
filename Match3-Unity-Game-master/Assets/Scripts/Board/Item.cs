using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[Serializable]
public class Item : MonoBehaviour
{
    public GameSettings gameSettings;

    public Cell Cell { get; private set; }

    public virtual void UpdateUI() {}
  
    protected virtual string GetPrefabName() { return string.Empty; }

    public virtual void SetCell(Cell cell)
    {
        Cell = cell;
    }

    internal void AnimationMoveToPosition()
    {
        if (transform == null) return;

        transform.DOMove(Cell.transform.position, 0.2f);
    }

    public void SetViewPosition(Vector3 pos)
    {
        if (transform)
        {
            transform.position = pos;
        }
    }

    public void SetViewRoot(Transform root)
    {
        if (gameObject) 
        {
            transform.SetParent(root);
        }
    }

    public void SetSortingLayerHigher()
    {
        if (transform == null) return;

        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        if (sp)
        {
            sp.sortingOrder = 1;
        }
    }


    public void SetSortingLayerLower()
    {
        if (transform == null) return;

        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        if (sp)
        {
            sp.sortingOrder = 0;
        }

    }

    internal void ShowAppearAnimation()
    {
        if (transform == null) return;

        Vector3 scale = transform.localScale;
        transform.localScale = Vector3.one * 0.1f;
        transform.DOScale(scale, 0.1f);
    }

    internal virtual bool IsSameType(Item other)
    {
        return false;
    }

    internal virtual void ExplodeView()
    {
        if (gameObject)
        {
            transform.DOScale(0.1f, 0.1f).OnComplete(
                () =>
                {
                    Destroy(gameObject);
                }
                );
        }
    }



    internal void AnimateForHint()
    {
        if (gameObject)
        {
            transform.DOPunchScale(transform.localScale * 0.1f, 0.1f).SetLoops(-1);
        }
    }

    internal void StopAnimateForHint()
    {
        if (gameObject)
        {
            transform.DOKill();
        }
    }

    internal void Clear()
    {
        Cell = null;

        if (gameObject)
        {
            Destroy(gameObject);
        }
    }
}
