using UnityEngine;

public class MainEntryPoint : MonoBehaviour
{
    [SerializeField] private ActorStats playerStats;
    [SerializeField] private ActorStats projectileStats;
    [SerializeField] private ActorStats asteroidStats;
    [SerializeField] private ActorStats UFOStats;
    [Space(10)]
    [SerializeField] private int maxAsteroids;
    [SerializeField] private int UFOCount;

    private PlayerController playerController;
    private ProjectileController projectileController;
    private AsteroidController asteroidController;
    private UFOController UFOController;

    private GameObject playerModel;

    private Controls inputs;

    private void Awake()
    {
        inputs = new Controls();
    }
    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }

    private void Start()
    {
        playerModel = Instantiate(playerStats.ActorModel, Vector2.zero, Quaternion.identity);

        playerController = new PlayerController(playerStats, inputs, playerModel);

        projectileController = new ProjectileController(projectileStats);

        asteroidController = new AsteroidController(asteroidStats, maxAsteroids);

        UFOController = new UFOController(UFOStats, UFOCount);
    }

    private void FixedUpdate()
    {
        playerController.Move();
        playerController.Trigger();

        projectileController.Move();

        asteroidController.Move();
        asteroidController.Trigger();

        UFOController.Move();
        UFOController.Trigger();
    }
}
