
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class BattleState: AbstractState, ITileState
    {
        
        public void ResolveTurn()
        {
            Combat();
        }
        
        public BattleState(ITile tile) : base(tile)
        {
            
        }

       

        //battle state
        private void Combat()
        {
            if (thisTile.Defenders.Count > 0) DefendersCombat();
            else
            {
                NoDefendersCombat();
            }
        }

        // def vs att
        private void DefendersCombat()
        {
            int result = Versus(thisTile.Defenders, thisTile.EnemyAtackers, false);
            switch (result)
            {
                case 1:
                    result = DoubleOneWaySingleAttack(thisTile.Gatherers, thisTile.EnemyAtackers, thisTile.Defenders);
                    if (result == 1) Tie();
                    if (result == 2) DefendersWin();
                    if (result == 3) AttackersWin();
                    return;
                    
                case 2: DefendersWin();
                    return;
                case 3: DefendersWin();
                    return;

                case 5: result = Versus(thisTile.Gatherers, thisTile.EnemyAtackers, true);
                    if (result == 1)
                    {
                        result = OneWayAttackLoop(thisTile.EnemyAtackers , thisTile.Gatherers);
                        if (result == 1) Tie();
                        if (result == 2 || result == 3) AttackersWin();
                        return;
                    }
                    break;
                case 6: result = OneWayAttackLoop(thisTile.Gatherers, thisTile.EnemyAtackers);
                    break;

                case 7: result = OneWayAttackLoop(thisTile.Gatherers, thisTile.EnemyAtackers);
                    break;
            }

            switch (result)
            {
                case 1: Tie();
                    return;
                case 2: DefendersWin();
                    return;
                case 3: DefendersWin();
                    return;
                case 5: AttackersWin();
                    return;
                case 6: AttackersWin();
                    return;
                case 7: Tie();
                    return;
            }

        }
        

        private void Tie()
        {
            Debug.Log("hey we tied");
        }

        private void AttackersWin()
        {
            thisTile.Owner = thisTile.EnemyAtackers[0].Owner;
            thisTile.SetState(new PacificState(thisTile));
            Debug.Log("hey we lost :-(");
        }

        private void DefendersWin()
        {
            Debug.Log("hey we won fuck yeah! XD");
        }

        // gath vs att
        private void NoDefendersCombat()
        {
            int result = Versus(thisTile.Gatherers, thisTile.EnemyAtackers, false);
            switch (result)
            {
                case 1:
                    result = OneWayAttackLoop(thisTile.EnemyAtackers , thisTile.Gatherers);
                    if (result == 1) Tie();
                    if (result == 2 || result == 3) AttackersWin();
                    break;
                case 2:
                    DefendersWin();
                    break;
                case 3:
                    DefendersWin();
                    break;
                case 5:
                    AttackersWin();
                    break;
                case 6:
                    AttackersWin();
                    break;
                case 7:
                    Tie();
                    break;
                
            }
        }



        // 1 TIE
        // 2 AC WIN
        // 3 B WIN
        private int DoubleOneWaySingleAttack(List<IUnit> A, List<IUnit> B, List<IUnit> C) //B ATTACK FIRST
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
        private int Versus(List<IUnit> A, List<IUnit> B, bool Afirst)
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
        private int OneWayAttackLoop(List<IUnit> A, List<IUnit> B)
        {
            int result = SingleAttack(A, B);
            
            while (result == 0) result = SingleAttack(A, B);
            
            return result;
        }

        
        private int SingleAttack(List<IUnit> A, List<IUnit> B)
        {
            IUnit AUnit = AttackerAvailable(A);
            IUnit BUnit = UnitAlive(B);

            if (AUnit == null && BUnit != null) return 1; // A not available or dead
            if (BUnit == null && AUnit != null) return 2; // B dead
            if (BUnit == null && AUnit == null) return 3; // A notavailable B dead

            AUnit.Attack(BUnit);
            
            return 0; //attack completed
        }
        
        //pick an alive unit who can also attack, return null if there are no attack availables
        private IUnit AttackerAvailable(List<IUnit> list)
        {
            return CandidatePicker(list, true);

        }
        
        //pick an alive unit, return null if there are not unit alives
        private IUnit UnitAlive(List<IUnit> list)
        {
            return CandidatePicker(list, false);
        }

        //pick an alive Unit and if is asked it has to have an attack available
        private IUnit CandidatePicker(List<IUnit> list, bool alsoAttacker )
        {
            List<IUnit> candidateList = new List<IUnit>();
            foreach (var unit in list.Where(unit => unit.Alive))
            {
                if (alsoAttacker)
                {
                    if (!unit.HasAttacked())
                    {
                        candidateList.Add(unit);
                    }
                }
                else
                {
                    candidateList.Add(unit);
                }
            }
            int range = candidateList.Count;
            if (range == 0) return null;
            return candidateList[Random.Range(0, range)];
        }
    }
}