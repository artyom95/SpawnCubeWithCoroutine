using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   [SerializeField]
   private GameObject _prefab;
  
   [SerializeField]
   private float _waitingTime;

   private GameObject[,] _gameObjects;

   private void Start()
   {
      _gameObjects = new GameObject[20, 20];
      StartCoroutine(Coroutine());
   }

   private IEnumerator Coroutine()
   {
      for (int i = 0; i < _gameObjects.GetLength(0); i++)
      {
         for (int j = 0; j < _gameObjects.GetLength(1); j++)
         {
            var cube = Instantiate(_prefab);
            cube.transform.position = new Vector3(260f+21.052f*j,360f - 21.052f*i, 0f);
            _gameObjects[i, j] = cube;
            yield return new WaitForSeconds(_waitingTime);
         }
         

      }
   }

   public GameObject[,] GetArray()
   {
      return _gameObjects;
   }
}
