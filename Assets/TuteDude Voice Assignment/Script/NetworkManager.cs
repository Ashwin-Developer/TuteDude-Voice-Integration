using Fusion;
using UnityEngine;


public class NetworkManager : SimulationBehaviour, IPlayerJoined
{
    public static NetworkManager Instance;

    [SerializeField] private GameObject _startButton;
    public GameObject PlayerPrefabs;
    public Transform[] SpawnPoints;
    public NetworkRunner _runner;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
    public void CreateAndJoinLobby()
    {
        StartGame(GameMode.Shared);
    }

    async void StartGame(GameMode gameMode)
    {
        _runner = AddBehaviour<NetworkRunner>();
        _runner.ProvideInput = true;

        await _runner.StartGame(new StartGameArgs()
        {
            GameMode = gameMode,
            SessionName = "1234",
        });

        _startButton.SetActive(false);
    }

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            int _randomSpawnPoints = Random.Range(0, SpawnPoints.Length);

            _runner.Spawn(PlayerPrefabs, SpawnPoints[_randomSpawnPoints].position, Quaternion.identity);
        }
    }
}
