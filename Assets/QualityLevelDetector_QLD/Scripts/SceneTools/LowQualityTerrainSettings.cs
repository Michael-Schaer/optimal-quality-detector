using UnityEngine;

public class LowQualityTerrainSettings : MonoBehaviour
{
	public Terrain mainTerrain;
    public int highestLowQualityLevel = 1;

    public int maxTreeDistance = 0;
    public int heightmapPixelError = 20;
    public int detailObjectDistance = 10;
    public bool disableFog = true;
    public int heightMapMaximumLOD = 2;

    void Start ()
    {
        if (QualitySettings.GetQualityLevel() <= highestLowQualityLevel)
        {
            QLDLogger.Instance.Log("Terrain Quality lowered");
            mainTerrain.treeDistance = maxTreeDistance;
			mainTerrain.heightmapPixelError = heightmapPixelError;
			mainTerrain.detailObjectDistance = detailObjectDistance;
            mainTerrain.heightmapMaximumLOD = heightMapMaximumLOD;

            if(disableFog)
            RenderSettings.fog = false;
        }
	}
}
