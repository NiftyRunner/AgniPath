using TMPro;
using UnityEngine;

public class PersonRescue : MonoBehaviour
{
    [SerializeField] static int rescueCount;
    [SerializeField] TextMeshProUGUI rescueText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeToHold = 3f;
    [SerializeField] float timer;
    [SerializeField] Animator personAnimator;
    [SerializeField] LevelManager_Parth levelManager;

    AudioSource personSource;
    bool increaseTimer;

    private void Awake()
    {
        rescueCount = 0;
        if (rescueText != null) { rescueText.text = "0/2"; }
        else { Debug.Log("Rescue text ref not set"); }
        personSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        personSource.Play();
        timer = 1f;
        increaseTimer = false;
        timerText.text = "";
    }

    private void Update()
    {
        if (increaseTimer)
        {
            timer += Time.deltaTime;
            timerText.text = Mathf.FloorToInt(timer % 60f).ToString();
        }

        if (timer >= timeToHold)
        {
            levelManager.IncreaseRescueCount();
            rescueCount++;
            Debug.Log("Person Rescued");
            increaseTimer = false;
            timer = 1f;
            timerText.text = "";
            if (rescueText != null)
            { rescueText.text = rescueCount.ToString() + "/2"; }
            RescueAnimPart();

        }
    }

    private void RescueAnimPart()
    {
        //Edit code during anim here
        personSource.Stop();
        Destroy(this.gameObject);
    }

    public void TouchedHands()
    {
        increaseTimer = true;
        //Place your animation start script here.
        Debug.Log("Play rescue animation");
    }

    public void ReleasedHands()
    {
       increaseTimer = false;
       timer = 1f;
       timerText.text = "";
    }

}
