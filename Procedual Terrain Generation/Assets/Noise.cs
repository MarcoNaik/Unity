using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise
{
   public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale,int octaves, float persistance, float lacunarity, Vector2 offset)
   {
      float[,] noiseMap = new float[mapWidth, mapHeight];
      Vector2[] octavesOffsets = new Vector2[octaves];
      
      System.Random prng = new System.Random(seed);
      for (int i = 0; i < octaves; i++)
      {
         float offsetX = prng.Next(-100000, 100000) + offset.x;
         float offsetY = prng.Next(-100000, 100000) + offset.y;
         octavesOffsets[i] = new Vector2(offsetX, offsetY);
      }
      

      if (scale <= 0) scale = 0.0001f;

      float maxNoiseHeight = 0;
      float minNoiseHeight = 0;

      float halfWidth = mapWidth / 2f;
      float halfHeight = mapHeight / 2f;
      
      for (int y = 0; y < mapHeight; y++)
      {
         for (int x = 0; x < mapWidth; x++)
         {
            float amplitude = 1;
            float frecuency = 1;
            float noiseHeight = 0;
            for (int i = 0; i < octaves; i++)
            {
               float sampleX = (x-halfWidth)/scale * frecuency + octavesOffsets[i].x;
               float sampleY = (y-halfHeight)/scale * frecuency + octavesOffsets[i].y;

               //we are getting the value to insert on the map
               float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
               
               //we += bc we are overlaping all octaves
               noiseHeight += perlinValue * amplitude;
               
               //persistance is a value between 0 and 1 so amplitude decreases
               amplitude *= persistance;
               
               //lacunaritu its a value >1 so the frecuency increases
               frecuency *= lacunarity;
            }

            if (noiseHeight > maxNoiseHeight) maxNoiseHeight = noiseHeight;
            else if (noiseHeight < minNoiseHeight) minNoiseHeight = noiseHeight;
            
            noiseMap[x, y] = noiseHeight;
         }
      }

      //normalize values to [0,1]
      for (int y = 0; y < mapHeight; y++)
      {
         for (int x = 0; x < mapWidth; x++)
         {
            noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            
         }
      }

      return noiseMap;
   }
}
