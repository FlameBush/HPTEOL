using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] RectTransform[] tutorials;

    private void Awake()
    {
        StartCoroutine(showTutorials());
    }

    /// <summary>
    /// Shows all movement tutorials.
    /// </summary>
    public IEnumerator showTutorials()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < tutorials.Length; i++)
        {
            tutorials[i].DOAnchorPos(new Vector2(0, 375), 1f).SetEase(Ease.InOutBounce);
            yield return new WaitForSeconds(2);
            tutorials[i].DOAnchorPos(new Vector2(0, 650), 1f).SetEase(Ease.InOutBounce).OnComplete(() => tutorials[i].gameObject.SetActive(false));
            yield return new WaitForSeconds(2);
        }
    }
}
