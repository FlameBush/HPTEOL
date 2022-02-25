using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    [SerializeField] RectTransform[] tutorials;

    private void Awake()
    {
        StartCoroutine(movementTutorial());
    }

    /// <summary>
    /// Shows all movement tutorials.
    /// </summary>
    public IEnumerator movementTutorial()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < tutorials.Length; i++)
        {
            tutorials[i].DOAnchorPos(new Vector2(0, 290), 1f).SetEase(Ease.InOutBounce);
            yield return new WaitForSeconds(2);
            tutorials[i].DOAnchorPos(new Vector2(0, 754), 1f).SetEase(Ease.InOutBounce).OnComplete(() => tutorials[i].parent.gameObject.SetActive(false));
            yield return new WaitForSeconds(2);
        }
    }
}
