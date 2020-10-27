using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Example
{
    public class ExampleScript : MonoBehaviour
    {
        private CubeCoordinates _cubeCoordinates;

        private void Awake()
        {
            _cubeCoordinates = gameObject.GetComponent<CubeCoordinates>();
        }

        private void NewMap()
        {
            Debug.Log("NEW MAP");
            _cubeCoordinates.Construct(10);

            
            

            // Display Coordinates
            _cubeCoordinates.ShowCoordinatesInContainer("all");

            // Construct Examples
            ConstructExamples();
        }

        private void ConstructExamples()
        {
            List<Vector3> allCubes = _cubeCoordinates.GetCubesFromContainer("all");

            // Line between the first and last cube coordinate
            _cubeCoordinates.AddCubesToContainer(_cubeCoordinates.GetLineBetweenTwoCubes(allCubes[0], allCubes[allCubes.Count - 1]), "line");

            // Reachable, 3 coordinates away from 0.0.0
            _cubeCoordinates.AddCubesToContainer(_cubeCoordinates.GetReachableCubes(Vector3.zero, 3), "reachable");

            // Spiral, 3 coordinates away from 0.0.0
            _cubeCoordinates.AddCubesToContainer(_cubeCoordinates.GetSpiralCubes(Vector3.zero, 3), "spiral");

            // Path between the first and last cube coordinate
            _cubeCoordinates.AddCubesToContainer(_cubeCoordinates.GetPathBetweenTwoCubes(allCubes[0], allCubes[allCubes.Count - 1]), "path");
        }

        private void ShowExample(string key)
        {
            _cubeCoordinates.HideCoordinatesInContainer("all");
            _cubeCoordinates.ShowCoordinatesInContainer(key);
        }

        private void Start()
        {
            NewMap();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                NewMap();
                return;
            }
            if (_cubeCoordinates.GetCoordinatesFromContainer("all").Count == 0)
                return;

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                _cubeCoordinates.ShowCoordinatesInContainer("all");
            }

            if (Input.GetKeyDown(KeyCode.L))
                ShowExample("line");

            if (Input.GetKeyDown(KeyCode.R))
                ShowExample("reachable");

            if (Input.GetKeyDown(KeyCode.S))
                ShowExample("spiral");

            if (Input.GetKeyDown(KeyCode.P))
                ShowExample("path");
        }
    }
}
