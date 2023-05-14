using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RecoloringBehaviour : MonoBehaviour
{
 

  [SerializeField] 
  private float _intervalRecoloring;
  [SerializeField] 
  private float _durationRecoloring;
  [SerializeField]
  private Spawner _spawner;
  private GameObject[,] _array = new GameObject[20, 20];

  private void FillArray()
  {
    _array = _spawner.GetArray();
  }
  private Color GetCurrentColor()
  {
    var material = gameObject.GetComponent<Renderer>().material;
    var color = material.color;
    return color;
  }
  private Color GetNextColor()
  {
     var color = Random.ColorHSV(0f,1f,1f,1f,1f,1f);
    return color;
  }

  public void Recolor()
  {
    FillArray();
    StartCoroutine(GetObjectInArray());
  }
  private IEnumerator GetObjectInArray()
  {
    var currentColor = GetCurrentColor();
    var nextColor = GetNextColor();
    for (int i = 0; i < _array.GetLength(0); i++)
    {
     for (int j = 0; j < _array.GetLength(1); j++)
     {
       StartCoroutine(ChangeColor(_array[i,j], currentColor,nextColor));
       yield return new WaitForSeconds(_intervalRecoloring);
     }
    }
  }
  private IEnumerator ChangeColor(GameObject gameObject, Color currentColor, Color nextColor)
  {
    var time = 0f;
    
    while (time < _durationRecoloring)
    {
      gameObject.GetComponent<Renderer>().material.color =
        Color.Lerp(currentColor, nextColor, time / _durationRecoloring);
      time += Time.deltaTime;
      yield return null;
    }
  }
}
