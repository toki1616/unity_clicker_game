using My.ClickerGame.MyEnum;

namespace My.ClickerGame.Ex
{
    public static class GachaExtension
    {
        public static string GetGachaName(this GachaType gachaType)
        {
            switch (gachaType)
            {
                case GachaType.Money:
                    return "Money";
                    
                case GachaType.Parts:
                    return "Parts";
                    
                default:
                    return "その他";
            }
        }
    }
}
