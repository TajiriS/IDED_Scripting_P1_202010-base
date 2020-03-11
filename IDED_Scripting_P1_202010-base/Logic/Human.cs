using System;
namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }
        // public EUnitClass currentclass;



        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential, int _atkRange)
            : base(_unitClass, _atk, _def, _spd, _moveRange, _atkRange)
        {
            Potential = _potential;
            //currentclass = _unitClass;
            if (_unitClass == EUnitClass.Orc || _unitClass == EUnitClass.Imp || _unitClass == EUnitClass.Dragon)
			{
                _unitClass = EUnitClass.Villager;
			}
            if (_unitClass == EUnitClass.Villager)
            {
             
                BaseAtk = Clamp(0, 0, 255);
                BaseDef = Clamp(0, 0, 255);
                }
            float result = ((_atk * Potential) / 100) + _atk;
            _atk = Convert.ToInt32(result);
            if (_unitClass == EUnitClass.Ranger || _unitClass == EUnitClass.Mage)
            {
                _atkRange = 3;
            }
            else
            {
                _atkRange = 1;
            }

        }

        public virtual bool ChangeClass(EUnitClass newClass)        
        {
            
            if(newClass == EUnitClass.Squire)
            {
                if (UnitClass == EUnitClass.Soldier) return true;
                else return false;                      
            }
            else if(newClass == EUnitClass.Soldier)
            {
                if (UnitClass == EUnitClass.Squire) return true;
                else return false;
            }
            else if(newClass == EUnitClass.Ranger)
            {
                if (UnitClass == EUnitClass.Mage) return true;
                else return false;
            }
            else if (newClass == EUnitClass.Mage)
            {
                if (UnitClass == EUnitClass.Ranger) return true;
                else return false;
            }
            else return false;
            
        }

    }
}