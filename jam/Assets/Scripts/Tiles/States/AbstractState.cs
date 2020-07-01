using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.WSA;


using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public abstract class AbstractState : ITileState
    {
        public AbstractState(ITile tile)
        {
            thisTile = tile;
        }
        protected ITile thisTile;
        
        
        
  

        public abstract void ResolveTurn();
    }
    
    
    
}