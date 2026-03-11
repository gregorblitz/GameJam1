using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    public float maxFuel = 100f;
    public float currentFuel;
    public float fuelDrainRate = 1f;

    public Slider fuelSlider;
    private GameManager gameManager;

    void Start()
    {
        fuelSlider.minValue = 0;
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = maxFuel;
        currentFuel = maxFuel;
        UpdateFuelUI();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        currentFuel -= fuelDrainRate * Time.deltaTime;
        currentFuel = Mathf.Clamp(currentFuel, 0f, maxFuel);

        UpdateFuelUI();

        if (currentFuel <= 0f)
        {
            Debug.Log("Se acabó el combustible");
            gameManager.GameOver();

        }
    }

    public void AddFuel(float fuelPickupAmount)
    {
        currentFuel += fuelPickupAmount;
        currentFuel = Mathf.Clamp(currentFuel, 0f, maxFuel);
        UpdateFuelUI();
    }

    void UpdateFuelUI()
    {
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = currentFuel;
    }
}