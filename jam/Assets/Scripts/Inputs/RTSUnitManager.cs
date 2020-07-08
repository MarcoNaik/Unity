using System;
using System.Collections.Generic;
using Inputs.Commands;
using Units;
using Units.UnitTypes;
using UnityEngine;

namespace Inputs
{
    public class RTSUnitManager : MonoBehaviour
    {
        private List<GameObject> UnitsSelected;
        private GameController gameController;
        private Vector3 selectedStartPos;
    
        private MeshCollider selectionBox;
        private Mesh selectionMesh;

        private void Awake()
        {
            gameController = FindObjectOfType<GameController>();
            UnitsSelected = new List<GameObject>();
        }

        public void AddUnitByTap(GameObject unit)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            { 
                UnShowSelectedUI();
                UnitsSelected.Clear();
            } 
            if(!UnitsSelected.Contains(unit))
                UnitsSelected.Add(unit);
            
            ShowUnitSelectedUI(unit);
                
            if (GetComponent<PlayerInput>().rightClickInput == GetComponent<SetDefaultSpawnPositionCommand>())
            {
                GetComponent<PlayerInput>().rightClickInput = GetComponent<MoveUnitsCommand>();
            }
                
            Debug.Log("we have selected " + UnitsSelected[0].name);
            
        }
    
        public void StartUnitSelectionAt(Vector3 planePosMouse)
        {
            GetComponent<DrawSquare>().enabled = true;
            selectedStartPos = planePosMouse;
        }
    
        public void EndUnitSelectionAt(Vector3 planePosMouse)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                UnShowSelectedUI();
                UnitsSelected.Clear();
            }
            
            if (GetComponent<PlayerInput>().rightClickInput == GetComponent<SetDefaultSpawnPositionCommand>())
            {
                GetComponent<PlayerInput>().rightClickInput = GetComponent<MoveUnitsCommand>();
            }
            
            GetComponent<DrawSquare>().enabled = false;
        
            selectionMesh = generateSelectionMesh(getBoundingBox(selectedStartPos, planePosMouse));
            selectionBox = gameObject.AddComponent<MeshCollider>();
            selectionBox.sharedMesh = selectionMesh;
            selectionBox.convex = true;
            selectionBox.isTrigger = true;
        
            Destroy(selectionBox, 0.02f);
            

        }
    
        private void OnTriggerEnter(Collider other)
        {
            GameObject unit = other.gameObject;
            if (unit.GetComponent<UnitController>().Owner == gameController.CurrentPlayer)
            {
                UnitsSelected.Add(unit);
                ShowUnitSelectedUI(unit);
                Debug.Log(unit.name + "added to selected units");
            }
            
        }
    
        Vector3[] getBoundingBox(Vector3 p1,Vector3 p2)
        {
            Vector3 newP1;
            Vector3 newP2;
            Vector3 newP3;
            Vector3 newP4;

            if (p1.x < p2.x) //if p1 is to the left of p2
            {
                if (p1.y > p2.y) // if p1 is above p2
                {
                    newP1 = p1;
                    newP2 = new Vector3(p2.x, p1.y, p1.z);
                    newP3 = new Vector3(p1.x, p2.y, p2.z);
                    newP4 = p2;
                }
                else //if p1 is below p2
                {
                    newP1 = new Vector3(p1.x, p2.y, p2.z);
                    newP2 = p2;
                    newP3 = p1;
                    newP4 = new Vector3(p2.x, p1.y, p1.z);
                }
            }
            else //if p1 is to the right of p2
            {
                if (p1.y > p2.y) // if p1 is above p2
                {
                    newP1 = new Vector3(p2.x, p1.y, p1.z);
                    newP2 = p1;
                    newP3 = p2;
                    newP4 = new Vector3(p1.x, p2.y, p2.z);
                }
                else //if p1 is below p2
                {
                    newP1 = p2;
                    newP2 = new Vector3(p1.x, p2.y, p2.z);
                    newP3 = new Vector3(p2.x, p1.y, p1.z);
                    newP4 = p1;
                }

            }

            Vector3[] corners = { newP1, newP2, newP3, newP4 };
            return corners;

        }
    
        Mesh generateSelectionMesh(Vector3[] corners)
        {
            Vector3[] verts = new Vector3[8];
            int[] tris = { 0, 1, 2, 2, 1, 3, 4, 6, 0, 0, 6, 2, 6, 7, 2, 2, 7, 3, 7, 5, 3, 3, 5, 1, 5, 0, 1, 1, 4, 0, 4, 5, 6, 6, 5, 7 }; //map the tris of our cube

            for(int i = 0; i < 4; i++)
            {
                verts[i] = corners[i];
            }

            for(int j = 4; j < 8; j++)
            {
                verts[j] = corners[j - 4] + Vector3.up * 100.0f;
            }

            Mesh mesh = new Mesh();
            mesh.vertices = verts;
            mesh.triangles = tris;

            return mesh;
        }

        public void MoveUnitsTo(GameObject tileClicked, Vector3 planePosMouse)
        {
            if (UnitsSelected.Count == 0)
            {
                Debug.Log("there are not unit selected");
                return;
            }
            foreach (GameObject unit in UnitsSelected)
            {
                unit.GetComponent<UnitController>().MoveTo(tileClicked, planePosMouse);
            }
        }

        public void UnShowSelectedUI()
        {
            foreach (GameObject unit in UnitsSelected)
            {
                unit.GetComponentInChildren<Canvas>().enabled = false;
            }
        }

        private void ShowUnitSelectedUI(GameObject unit)
        {
            unit.GetComponentInChildren<Canvas>().enabled = true;
        }
        private void ShowSelectedUI()
        {
            foreach (GameObject unit in UnitsSelected)
            {
                unit.GetComponentInChildren<Canvas>().enabled = true;
               
            }
        }

        public void Build(GameObject tileClicked, Vector3 planePosMouse, String prefab, int cost)
        {
            
            StartCoroutine(UnitsSelected[0].GetComponent<Gatherer>().Build(tileClicked, planePosMouse ,prefab, cost));
            
        }
    }
}
