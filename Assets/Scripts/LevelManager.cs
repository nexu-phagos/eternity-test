using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	AsyncOperation asyncThisLevelReloader;
	AsyncOperation asyncMainMenuLoader;
	
	AsyncOperation asyncEternityEdgeLoader;
	AsyncOperation asyncForestPath1Loader;
	AsyncOperation asyncForestPath2Loader;
	AsyncOperation asyncForestPath3Loader;
	
	AsyncOperation asyncHomeLoader;
	
	AsyncOperation asyncZone1Loader;
	AsyncOperation asyncZone2Loader;
	AsyncOperation asyncZone3Loader;
	AsyncOperation asyncZone4Loader;
	AsyncOperation asyncZone5Loader;
	AsyncOperation asyncZone6Loader;
	AsyncOperation asyncZone7Loader;
	AsyncOperation asyncZone8Loader;
	AsyncOperation asyncZone9Loader;
	AsyncOperation asyncZone10Loader;
	AsyncOperation asyncZone11Loader;
	
	AsyncOperation asyncLimboZoneLoader;	
	
	private int mainMenu = 0;
	private int eternityEdge = 1;
	private int forestPath1 = 2;
	private int forestPath2 = 3;
	private int forestPath3 = 4;
	
	private int home = 5;
	
	private int zone1 = 6;
	private int zone2 = 7;
	private int zone3 = 8;
	private int zone4 = 9;
	private int zone5 = 10;
	private int zone6 = 11;
	private int zone7 = 12;
	private int zone8 = 13;
	private int zone9 = 14;
	private int zone10 = 15;
	private int zone11 = 16;
	
	private int limboZone = 99;
	
	private int thisLevel;
	
	void Start()
	{
		
	}
	
	public void CheckLevel(int _thisLevel)
	{
		thisLevel = _thisLevel;
	}
	
	public void ThisLevelReload()
	{
		SceneManager.LoadScene(thisLevel);
	}
	
	IEnumerator LoadMainMenu()
    {
		asyncMainMenuLoader = SceneManager.LoadSceneAsync(mainMenu);

        while (!asyncMainMenuLoader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadEternityEdge()
    {
		asyncEternityEdgeLoader = SceneManager.LoadSceneAsync(eternityEdge);

        while (!asyncEternityEdgeLoader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadForestPath1()
    {
		asyncForestPath1Loader = SceneManager.LoadSceneAsync(forestPath1);

        while (!asyncForestPath1Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadForestPath2()
    {
		asyncForestPath2Loader = SceneManager.LoadSceneAsync(forestPath2);

        while (!asyncForestPath2Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadForestPath3()
    {
		asyncForestPath3Loader = SceneManager.LoadSceneAsync(forestPath3);

        while (!asyncForestPath3Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadHome()
    {
		asyncHomeLoader = SceneManager.LoadSceneAsync(home);

        while (!asyncHomeLoader.isDone)
        {
            yield return null;
        }
    }
	 
    IEnumerator LoadZone1()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.

        // AsyncOperation asyncLoad = SceneManager.LoadScene(3);
		asyncZone1Loader = SceneManager.LoadSceneAsync(zone1);

        // Wait until the asynchronous scene fully loads
        while (!asyncZone1Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadZone2()
    {
		asyncZone2Loader = SceneManager.LoadSceneAsync(zone2);

        while (!asyncZone2Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadZone3()
    {
		asyncZone3Loader = SceneManager.LoadSceneAsync(zone3);

        while (!asyncZone3Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadZone4()
    {
		asyncZone4Loader = SceneManager.LoadSceneAsync(zone4);

        while (!asyncZone4Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadZone5()
    {
		asyncZone5Loader = SceneManager.LoadSceneAsync(zone5);

        while (!asyncZone5Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadZone6()
    {
		asyncZone6Loader = SceneManager.LoadSceneAsync(zone6);

        while (!asyncZone6Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadZone7()
    {
		asyncZone7Loader = SceneManager.LoadSceneAsync(zone7);

        while (!asyncZone7Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadZone8()
    {
		asyncZone8Loader = SceneManager.LoadSceneAsync(zone8);

        while (!asyncZone8Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadZone9()
    {
		asyncZone9Loader = SceneManager.LoadSceneAsync(zone9);

        while (!asyncZone9Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadZone10()
    {
		asyncZone10Loader = SceneManager.LoadSceneAsync(zone10);

        while (!asyncZone10Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadZone11()
    {
		asyncZone11Loader = SceneManager.LoadSceneAsync(zone11);

        while (!asyncZone11Loader.isDone)
        {
            yield return null;
        }
    }
	
	IEnumerator LoadLimboZone()
    {
		asyncLimboZoneLoader = SceneManager.LoadSceneAsync(limboZone);

        while (!asyncLimboZoneLoader.isDone)
        {
            yield return null;
        }
    }
	
	
	
	public void MainMenuLoad()
	{
		StartCoroutine(LoadMainMenu());
	}
	
	public void EternityEdgeLoad()
	{
		StartCoroutine(LoadEternityEdge());
	}
	
	public void ForestPath1Load()
	{
		StartCoroutine(LoadForestPath1());
	}
	
	public void ForestPath2Load()
	{
		StartCoroutine(LoadForestPath2());
	}
	
	public void ForestPath3Load()
	{
		StartCoroutine(LoadForestPath3());
	}
	
	public void HomeLoad()
	{
        StartCoroutine(LoadHome());
	}
	
	public void Zone1Load()
	{
		// Use a coroutine to load the Scene in the background
        StartCoroutine(LoadZone1());
	}
	
	public void Zone2Load()
	{
        StartCoroutine(LoadZone2());
	}
	
	public void Zone3Load()
	{
        StartCoroutine(LoadZone3());
	}
	
	public void Zone4Load()
	{
        StartCoroutine(LoadZone4());
	}
	
	public void Zone5Load()
	{
        StartCoroutine(LoadZone5());
	}
	
	public void Zone6Load()
	{
        StartCoroutine(LoadZone6());
	}
	
	public void Zone7Load()
	{
        StartCoroutine(LoadZone7());
	}
	
	public void Zone8Load()
	{
        StartCoroutine(LoadZone8());
	}
	
	public void Zone9Load()
	{
        StartCoroutine(LoadZone9());
	}
	
	public void Zone10Load()
	{
        StartCoroutine(LoadZone10());
	}
	
	public void Zone11Load()
	{
        StartCoroutine(LoadZone11());
	}
	
	public void LimboZoneLoad()
	{
        StartCoroutine(LoadLimboZone());
	}
}