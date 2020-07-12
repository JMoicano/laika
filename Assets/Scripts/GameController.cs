using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [Header("Heat")]
    [Range(0, 400)]
    public float MaxHeat = 100f;
    public float HeatThreshold = 5f;
    public float HeatIncreaseRate = 5f;
    public float HeatDecayRate = 1f;
    public float HeatTimeDecay = 3f;

    private float heatTimer = 0f;
    private float m_CurrentHeat;


    [Range(5, 200)]
    public int AsteroidsCount = 20;
    public Rigidbody2D Rigidbody;

    public SpriteRenderer gameOver;

    private void UpdateHeat()
    {
        if (IsHeating)
        {
            CurrentHeat += HeatIncreaseRate;
            heatTimer = 0;
            return;
        }

        if (heatTimer > HeatTimeDecay)
            CurrentHeat -= HeatDecayRate;
        else
            heatTimer += Time.deltaTime;
    }

    private void CheckEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GotoMenuScene();
    }


    private void FixedUpdate()
    {
        UpdateHeat();
        
        if (gameOver.enabled)
        {
            Time.timeScale = 0f;
        }

        if (CurrentHeat >= MaxHeat)
            GotoGameOverScene();

     
        CheckEsc();
    }
    public void GotoMenuScene() => SceneManager.LoadScene("Menu");
    public void GotoGameOverScene()
    {
        gameOver.enabled = true;
    }
    public bool IsHeating { get => Rigidbody.velocity.magnitude > HeatThreshold; }
    public float CurrentHeat { get => m_CurrentHeat; set => m_CurrentHeat = Mathf.Clamp(0, value, MaxHeat); }
}
