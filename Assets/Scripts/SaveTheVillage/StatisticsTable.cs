using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace SaveTheVillage
{
    public class StatisticsTable : MonoBehaviour
    {
        [Header("Statistics")]
        public TextMeshProUGUI productedEat;
        public TextMeshProUGUI usedEat;
        public TextMeshProUGUI productedWarriors;
        public TextMeshProUGUI fallenWarriors;
        public TextMeshProUGUI productedPeasants;
        public TextMeshProUGUI cyclesLived;

        public void SetStatistics(int ProductedEat, int UsedEat, int ProductedWarriors, 
            int FallenWarriors, int ProductedPeasants, int CyclesLived)
        {
            productedEat.text = ProductedEat.ToString();
            usedEat.text = UsedEat.ToString();
            productedWarriors.text = ProductedWarriors.ToString();
            fallenWarriors.text = FallenWarriors.ToString();
            productedPeasants.text = ProductedPeasants.ToString();
            cyclesLived.text = CyclesLived.ToString();
        }
    }
}