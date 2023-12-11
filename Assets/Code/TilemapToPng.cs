using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.Tilemaps;

public class TilemapExporter : MonoBehaviour
{
    public Tilemap tilemap;

    [ContextMenu("Export Tilemap as PNG")]
    public void ExportTilemapToPNG()
    {
        if (tilemap == null)
        {
            Debug.LogWarning("Tilemap component not found!");
            return;
        }

        BoundsInt bounds = tilemap.cellBounds;
        Texture2D texture = new Texture2D(bounds.size.x, bounds.size.y, TextureFormat.RGB24, false);

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                Sprite sprite = tilemap.GetSprite(tilePos);

                if (sprite != null)
                {
                    Color[] tileColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                                  (int)sprite.textureRect.y,
                                                                  (int)sprite.textureRect.width,
                                                                  (int)sprite.textureRect.height);

                    texture.SetPixels(x - bounds.xMin, y - bounds.yMin, (int)sprite.textureRect.width, (int)sprite.textureRect.height, tileColors);
                }
            }
        }

        byte[] bytes = texture.EncodeToPNG();
        string filePath = Application.dataPath + "/" + gameObject.name + "_Tilemap.png";
        File.WriteAllBytes(filePath, bytes);

        Debug.Log("Tilemap exported as PNG at: " + filePath);
    }
}
