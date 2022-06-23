using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats", fileName ="new PlayerStats")]
public class ActorStats : ScriptableObject
{
    [Header("Player")]
    [SerializeField] private GameObject _actorModel;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _inertiaValue;

    [Header("Rotation")]
    [SerializeField] private float _rotateSpeed;

    //Player
    public GameObject ActorModel => _actorModel;

    //Movement
    public float MoveSpeed => _moveSpeed;
    public float InertiaValue => _inertiaValue;

    //Rotation
    public float RotateSpeed => _rotateSpeed;
}
