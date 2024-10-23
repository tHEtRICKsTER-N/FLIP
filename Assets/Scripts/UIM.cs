using UnityEngine;
using UnityEngine.UI;

public class UIM : MonoBehaviour
{
    #region OBJ
    public static UIM obj;

    private void Awake()
    {
        obj = this;
    }
    #endregion

    public Text scoreText;
    public Text timerText;
    public Text restartText;

    [HideInInspector] public int goldCount=0;

    [SerializeField] private Player _player;
    [SerializeField] private GameObject _normalMenu;
 

    void Start()
    {
        scoreText.text = "" + goldCount;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
