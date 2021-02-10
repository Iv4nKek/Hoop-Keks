namespace Code.Core
{
    [System.Serializable]
    public class PlayerResources
    {
        private int _money;

        public bool CanBuy(int cost)
        {
            return cost <= _money;
        }

        public bool Buy(int cost)
        {
            if (CanBuy(cost))
            {
                _money -= cost;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddMoney(int amount)
        {
            if (amount > 0)
                _money += amount;
        }
    }
}