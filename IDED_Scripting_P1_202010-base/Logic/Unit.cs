using System;
namespace IDED_Scripting_P1_202010_base.Logic
{


    public class Unit
    {
        public int x;
        public int y;
        public int z;
        public int BaseAtk { get; protected set; }
        public int BaseDef { get; protected set; }
        public int BaseSpd { get; protected set; }

        public int MoveRange { get; protected set; }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; }
        public float Defense { get; }
        public float Speed { get; }

        protected Position CurrentPosition;
        //public Position targetPosition;

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, int _atkRange)
        {
            UnitClass = _unitClass;
            BaseAtkAdd = (BaseAtk * x)/100;
            BaseDefAdd = (BaseAtk * y) / 100;
            BaseSpdAdd = (BaseAtk * z) / 100;
            AtkRange = _atkRange;
            BaseAtk = Clamp(_atk + Convert.ToInt32(BaseAtkAdd), 0, 255);
            BaseDef = Clamp(_def + BaseAtk, 0, 255);
            BaseSpd = Clamp(_spd + x, 0, 255);
            MoveRange = Clamp(_moveRange, 0, 10);
            if (_unitClass == EUnitClass.Villager) { x = 0; y = 0; z = 0; }
            if (_unitClass == EUnitClass.Squire) { x = 2; y = 1; z = 0; }
            if(_unitClass == EUnitClass.Soldier) { x = 3; y = 2; z = 1; }
            if (_unitClass == EUnitClass.Ranger) { x = 1; y = 0; z = 3; }
            if (_unitClass == EUnitClass.Mage) { x = 3; y = 1; z = -1; }
            if (_unitClass == EUnitClass.Imp) { x = 1; y = 0; z = 0; }
            if (_unitClass == EUnitClass.Orc) { x = 4; y = 2; z = -2; }
            if (_unitClass == EUnitClass.Dragon) { x = 5; y = 3; z = 2; }
        }


        public virtual int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        public virtual bool Interact(Unit Enemy)
        {
            bool result = true;

            if (Enemy.UnitClass == EUnitClass.Villager)
            {
                result = false;
                return result;
            }
            

            return result;                             
                                                       
        }

        public virtual bool Interact(Prop prop)
        {
            bool result = false;
            if (UnitClass == EUnitClass.Villager)
            { result = true; }
            else result = false;

            return result;

        }

        public virtual bool Move(Position targetPosition)
        {
            if(targetPosition.x <= MoveRange && targetPosition.y <= MoveRange)
            {
                CurrentPosition = targetPosition;
                return true;
            }
            else return false;
        }

        

    }
}