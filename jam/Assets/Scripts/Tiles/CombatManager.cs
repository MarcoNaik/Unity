using System.Collections.Generic;
using Tiles.States;
using Units;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tiles
{
    public class CombatManager : MonoBehaviour
    {
        private TileController tileController;
        private void Awake()
        {
            tileController = GetComponent<TileController>();
        }

        
        
        #region CombatFeatures

        // 1 TIE
        // 2 AC WIN
        // 3 B WIN
        public int DoubleOneWaySingleAttack(List<IUnit> A, List<IUnit> B, List<IUnit> C) //B ATTACK FIRST
        {
            while (true)
            {
                int resultAB;
            
                int resultBC = SingleAttack(B, C);
                if (resultBC == 1 || resultBC == 3)
                {
                    resultAB = OneWayAttackLoop(A, B);
                    if (resultAB == 1) return 1; 
                    if (resultAB == 2 || resultAB == 3) return 2; 

                }

                if (resultBC == 2)
                {
                    resultAB = Versus(A, B, true);
                    if (resultAB == 1)
                    {
                        resultAB = OneWayAttackLoop(B, A);
                        if (resultAB == 1) return 1;
                        if (resultAB == 2 || resultAB == 3) return 3;
                    }
                    if (resultAB == 2 || resultAB == 3) return 2;
                    if (resultAB == 4)
                    {
                        resultAB = OneWayAttackLoop(A, B);
                        if (resultAB == 1) return 1;
                        if (resultAB == 2 || resultAB == 3) return 2;
                    }
                    if (resultAB == 5 || resultAB == 6) return 3;
                }
            
                resultAB = SingleAttack(A, B);
                if (resultAB == 1)
                {
                    resultBC = OneWayAttackLoop(B, C);
                    if (resultBC == 1 || resultBC == 3) return 1;  //tiene q terminar aqui el turno. caso en el que A Y B no le quedan attackers (y also si C muere)
                    if (resultBC == 2){
                    
                        resultAB = OneWayAttackLoop(B, A);
                        if (resultAB == 1) return 1;
                        if (resultAB == 2 || resultAB == 3) return 3;
                    }
                }

                if (resultAB == 2 || resultAB == 3) return 2; //ganaron gg wi
            }
            
        }

        /*
         * 2: B Dead
         * 3: A not available while attacking and B dead while defending
         * 
         * 5: A Dead
         * 6: B not available while attacking and A dead while defending
         *
         * 7: A and B not available TIE
         */
        public int Versus(List<IUnit> A, List<IUnit> B, bool Afirst)
        {

            if (Random.value < 0.5 || Afirst)
            {
                return VersusLoop(A, B);

            }
            //else B first
            int invertLoop = VersusLoop(B, A);
            if (invertLoop == 7) return invertLoop;
            if (invertLoop > 3) return invertLoop - 3;
            return invertLoop + 3;
        }

        private int VersusLoop(List<IUnit> A, List<IUnit> B)
        {
            int result = 0;
            while (true)
            {
                result = SingleAttack(A, B);
                if (result == 1)
                {
                    result = OneWayAttackLoop(B, A);
                    if (result == 1) return 7;
                    if (result == 2 || result == 3) return result+3;
                }
                if (result != 0) return result;
                
                
                result = SingleAttack(B, A);
                if (result == 1)
                {
                    result = OneWayAttackLoop(A, B);
                    if (result == 1) return 7;
                    if (result == 2 || result == 3) return result;
                }
                if (result == 2) return 5;
                if (result == 3) return 6;
            }
        }
        
        
        
        //asume A has Alive units
        public int OneWayAttackLoop(List<IUnit> A, List<IUnit> B)
        {
            int result = SingleAttack(A, B);
            
            while (result == 0) result = SingleAttack(A, B);
            
            return result;
        }

        
        public int SingleAttack(List<IUnit> A, List<IUnit> B)
        {
            IUnit AUnit = Picker.AttackerAvailable(A);
            IUnit BUnit = Picker.UnitAlive(B);

            if (AUnit == null && BUnit != null) return 1; // A not available or dead
            if (BUnit == null && AUnit != null) return 2; // B dead
            if (BUnit == null && AUnit == null) return 3; // A notavailable B dead

            AUnit.Attack(BUnit);
            Debug.Log(AUnit + " attacked "+  BUnit);
            
            tileController.addCoroutine(AUnit.AttackCoroutine(BUnit.UnitController.unit, BUnit.Alive));
            
            return 0; //attack completed
        }
        
        #endregion
        
    }
}