using UnityEngine;

namespace Kravchuk
{
    public sealed class GameController : MonoBehaviour
    {
        private GameObject _playerObj;
        private PlayerController _playerController = new PlayerController();

        private void Awake()
        {
            _playerObj = GameObject.FindGameObjectWithTag("Player");
        }

        private void Start()
        {
            _playerController.PlayerRigidBody = _playerObj.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _playerController.LetMove();
            
        }
    }

}
