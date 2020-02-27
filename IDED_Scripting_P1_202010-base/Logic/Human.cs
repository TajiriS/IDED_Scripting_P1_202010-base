namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }
       // public EUnitClass currentclass;
    
        

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential, int _AtkRange)
            : base(_unitClass, _atk, _def, _spd, _moveRange, _AtkRange)
        {
            Potential = _potential;
            currentclass = _unitClass;
            if (_unitClass == EUnitClass.Ranger || _unitClass == EUnitClass.Mage)
            {
                _AtkRange = 3;
            }
            else if (_unitClass == Dragon)
            {
                _AtkRange = 5;
            }
            else
            {
                _AtkRange = 1;
            }

        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            if(newClass == EUnitClass.UnitClass || UnitClass == EUnitClass.Villager)
            {
                return false;
            }
            if(newClass == EUnitClass.Squire /*|| newClass == EUnitClass.Soldier*/)
            {
                if (UnitClass == Soldier) return true;
                else return false;
            }
            if(newClass == EUnitClass.Soldier)
            {
                if (UnitClass == Squire) return true;
                else return false;
            }
            if(newClass == EUnitClass.Ranger)
            {
                if (UnitClass == Mage) return true;
                else return false;
            }
            if (newClass == EUnitClass.Mage)
            {
                if (UnitClass == Ranger) return true;
                else return false;
            }
            
        }

    }
}