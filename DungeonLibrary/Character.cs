namespace DungeonLibrary
{
    public abstract class Character
    {
        private string _name;
        private int _hitChance;
        private int _maxLife;
        private int _block;
        private int _life;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set { _life = value <= MaxLife ? value : MaxLife; }
        }

        public Character(string name, int hitChance, int block, int maxLife, int life)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;

        }
        public Character(string name, int hitChance, int block, int maxLife)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = MaxLife;
        }

        public Character()
        {

        }

        //In combat, the attacker's HitChance minus the defender's Block will determine whether the attack hits.        
        public virtual int CalcBlock() { return Block; }
        public virtual int CalcHitChance() { return HitChance; }
        public abstract int CalcDamage();

        public override string ToString()
        {
            return $"---- {Name} ----\n" +
                   $"Life: {Life} / {MaxLife}\n" +
                   $"Hit Chance: {HitChance}%\n" +
                   $"Block: {Block}%";
        }
    }
}