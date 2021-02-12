using UnityEngine;

public static class CostCrystal
{
    public static int[] cost = new int[] { 1, 5, 125, 250, 500, 1000, 2000, 4000, 7000, 10000, 15000, 20000, 30000, 40000, 50000 };
     public static int[] costWeapon = new int[]{ 1, 5, 10, 30, 50, 125, 250, 500, 1250, 1870, 2500, 3200, 6250, 9370, 12500, 15600, 31200, 46800, 100000, 1000000, 5000000, 1000000000 };
    public static string[] st = new string[] { "Blue: ", "Yellow: ", "Purp: ", "Red: ", "Orange: ", "Red: ", "Purp: ", "Blue: ", "Orange: ", "Yellow: ", "Violet: ", "Blue: ", "Red: ", "Orange: ", "Yellow: "  };
    public static string[] costWeaponText = new string[] { "1", "5", "10", "30", "50", "125", "250", "500", "1.25K", "1.87K", "2.5K", "3.2K", "6.25K", "9.37K", "12.5K", "15.6K", "31.2K", "46.8K", "100K", "1M", "5M", "1T", };
}
