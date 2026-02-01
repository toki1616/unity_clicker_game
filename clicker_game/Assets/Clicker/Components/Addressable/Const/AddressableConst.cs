namespace My.ClickerGame.Const
{
    public static class AddressableConst
    {
        //Group Name
        public static string uiGroup = "UIGroup";
        public static string uiPartsGroup = "UIPartsGroup";

        //Asset Name
        private static string home = "Home";
        private static string battle = "Battle";
        private static string gacha = "Gacha";
        private static string other = "Other";
        private static string setting = "Setting";

        private static string select = "Select";
        private static string result = "Result";

        //UI
        public static string homeUI = $"{home}UI";

        //Battle
        public static string battleSelectUI = $"{battle}{select}UI";
        public static string battleUI = $"{battle}UI";
        public static string battleResultUI = $"{battle}{result}UI";

        //Gacha
        public static string gachaSelectUI = $"{gacha}{select}UI";
        public static string gachaUI = $"{gacha}UI";
        public static string gachaResultUI = $"{gacha}{result}UI";


        public static string otherUI = $"{other}UI";
        public static string settingUI = $"{setting}UI";

        //UI Parts
        public static string battleSelectButtonUI = $"{battle}SelectButtonUI";
        public static string gachaSelectButtonUI = $"{gachaSelectUI}ButtonUI";
        public static string upgradeableItemUI = $"UpgradeableItemUI";
    }
}
