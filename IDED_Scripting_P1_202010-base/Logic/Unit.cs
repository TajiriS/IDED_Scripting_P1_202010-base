﻿namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        public int BaseAtk { get; protected set; } = Mathf.Clamp(0,255);
        public int BaseDef { get; protected set; } = Mathf.Clamp(0, 255);
        public int BaseSpd { get; protected set; } = Mathf.Clamp(0, 255);

        public int MoveRange { get; protected set; } = Mathf.Clamp(1, 10);
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

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;
        }

        public virtual bool Interact(Unit otherUnit)
        {
            return false;
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

        public virtual bool Interact(Prop prop) => false;

        public bool Move(Position targetPosition) => false;
    }
}