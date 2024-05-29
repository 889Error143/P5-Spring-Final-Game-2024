using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    //Only if you need to collect items to complete the level, add variable below
    [SerializeField] private int _itemsCollected = 0;
    [SerializeField] private int _totalItemsCollected = 5;
    [SerializeField] private TextMeshProUGUI _itemsCollectText;
    [SerializeField] private string _sceneName;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private CrossFade _crossFade;

    // Start is called before the first frame update
    void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;
        _itemsCollectText.text = "Items: " + _itemsCollected.ToString() + "/" + _totalItemsCollected.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerHealth.GetPlayerHealth() <= 0)
        {
            StartCoroutine("EndLevel");
        }
      

      //  if (_endpoint.HasReached() && _sceneName == "Level 2")
        //{
          //  StartCoroutine("YouWonGame");
        //}
    }

        IEnumerator EndLevel()
        {
            _crossFade.FadeIn();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Level Select");
        }


    public void UpdateItemsCollected(int amount)
    {
        _itemsCollected += amount;
        _itemsCollectText.text = "Items: " + _itemsCollected.ToString() + "/" + _totalItemsCollected.ToString();

        if (_itemsCollected >= _totalItemsCollected)
        {
            StartCoroutine("EndLevel");
        }
    }

    //End of Game - you won all the levels
    IEnumerator YouWonGame()
    {
        _crossFade.FadeIn();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("You Won");
    }
}