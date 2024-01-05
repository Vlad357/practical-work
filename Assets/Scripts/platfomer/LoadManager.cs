using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class LoadManager : MonoBehaviour
    {
        public GameObject playerPrefub;

        private string _filePath;
        private GameData _gameData;

        public void SaveGame()
        {
            BinaryFormatter binaryFormater = new BinaryFormatter();
            FileStream fileStream = new FileStream(_filePath, FileMode.Create);

            int idScene = SceneManager.GetActiveScene().buildIndex;
            Player player = FindObjectOfType<Player>();
            Vector2 position = player.transform.position;

            GameData gameData = new GameData(idScene, position, player.Statistic);

            binaryFormater.Serialize(fileStream, gameData);
            fileStream.Close();
        }

        public void LoadGame()
        {
            if (!File.Exists(_filePath))
                return;

            BinaryFormatter binaryFormater = new BinaryFormatter();
            FileStream fileStream = new FileStream(_filePath, FileMode.Open);

            _gameData = binaryFormater.Deserialize(fileStream) as GameData;

            fileStream.Close();
            SceneManager.sceneLoaded += OnSceneLoad;
            SceneManager.LoadScene(_gameData.idSceane);
        }

        private void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            Player player = FindObjectOfType<Player>();
            player.transform.position = new Vector2(_gameData.x, _gameData.y);
            player.Statistic = new Statistic(_gameData.takenDamage, _gameData.damageDone, _gameData.coins);
            SceneManager.sceneLoaded -= OnSceneLoad;
        }
        private void Start()
        {
            _filePath = Application.persistentDataPath + "/save.gamesave";
        }
    }

    [System.Serializable]
    public class GameData
    {
        public int idSceane;

        public float x, y;

        public float takenDamage;
        public float damageDone;
        public int coins;

        public GameData(int idSceane, Vector2 position, Statistic statistic)
        {
            this.idSceane = idSceane;
            x = position.x;
            y = position.y;
            takenDamage = statistic.takenDamage;
            damageDone = statistic.damageDone;
            coins = statistic.coins;
        }
    }
}