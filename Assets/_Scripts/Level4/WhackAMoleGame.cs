using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WhackAMoleGame : MonoBehaviour
{
    public GameObject molePrefab;
    public GameObject helmetMolePrefab;
    public Transform[] moleSpawnPoints;
    public float spawnInterval = 2f;
    public int maxMoles = 5;

    private int score = 0;
    public TextMeshProUGUI scoreText;

    private float timer = 0f;
    private List<GameObject> activeMoles = new List<GameObject>();

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && activeMoles.Count < maxMoles)
        {
            SpawnMole();
            timer = 0f;
        }
    }

    private void SpawnMole()
    {
        bool useHelmet = Random.value < 0.5f; // Randomly choose mole type

        GameObject molePrefabToSpawn = useHelmet ? helmetMolePrefab : molePrefab;
        Transform spawnPoint = GetRandomSpawnPoint();

        if (IsSpawnPointOccupied(spawnPoint))
        {
            // Spawn point is occupied, abort spawning
            return;
        }

        GameObject mole = Instantiate(molePrefabToSpawn, spawnPoint.position, Quaternion.identity);
        MoleController moleController = mole.GetComponent<MoleController>();
        moleController.whackAMoleGame = this;
        moleController.Spawn();

        activeMoles.Add(mole);
    }

    private Transform GetRandomSpawnPoint()
    {
        int index = Random.Range(0, moleSpawnPoints.Length);
        return moleSpawnPoints[index];
    }

    private bool IsSpawnPointOccupied(Transform spawnPoint)
    {
        foreach (GameObject mole in activeMoles)
        {
            if (mole.transform.position == spawnPoint.position)
            {
                return true;
            }
        }
        return false;
    }

    public void MoleDefeated(GameObject mole)
    {
        score++;
        UpdateScoreText();
        activeMoles.Remove(mole);
        Destroy(mole);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
