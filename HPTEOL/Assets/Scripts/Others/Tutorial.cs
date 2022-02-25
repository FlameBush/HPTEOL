using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Transform startPosition;
    [SerializeField] Transform player;

    [SerializeField] Image fadeImage;
    [SerializeField] GameObject panel;
    [SerializeField] float fadeSpeed = 3;

    //Movement Tutorials items
    [SerializeField] GameObject movement;
    [SerializeField] RectTransform movementtxt;
    [SerializeField] GameObject jump;
    [SerializeField] RectTransform jumptxt;


    #region MonoBehaviours
    private void Awake()
    {
        fade(0, fadeSpeed);
        //setting player Position to start position.
        player.position = startPosition.position;
        //starting tutorial from here.
        Invoke("showMovementTutorial", 2f);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    } 
    #endregion


    public void fade(float alpha,float speed)
    {
        fadeImage.DOFade(alpha, speed);
    }

    public void showMovementTutorial()
    {
        movement.SetActive(true);
        movementtxt.DOAnchorPos(new Vector2(0,290), 1f).SetEase(Ease.InOutBounce);
        Invoke("hideMovementTutorial", 2);
    }
    public void hideMovementTutorial()
    {
        movementtxt.DOAnchorPos(new Vector2(0,754), 1f).SetEase(Ease.InOutBounce).OnComplete(() => movement.SetActive(false));
        Invoke("showJumpTutorial", 2);
    }
    public void showJumpTutorial()
    {
        jump.SetActive(true);
        jumptxt.DOAnchorPos(new Vector2(0,290), 1f).SetEase(Ease.InOutBounce);
        Invoke("hideJumpTutorial", 2);
    }
    public void hideJumpTutorial()
    {
        jumptxt.DOAnchorPos(new Vector2(0,754), 1f).SetEase(Ease.InOutBounce).OnComplete(() => jump.SetActive(false));
    }
}
