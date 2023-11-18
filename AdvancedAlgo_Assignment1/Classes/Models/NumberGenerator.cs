using AdvancedAlgo_Assignment1.Classes.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace AdvancedAlgo_Assignment1.Classes.Models
{
    internal class NumberGenerator
    {
        private string unsortedPath = AppDomain.CurrentDomain.BaseDirectory + "\\Data.txt";
        private string sortedPath = AppDomain.CurrentDomain.BaseDirectory + "\\SortedData.txt";

        public async Task<bool> GenerateUnsortedNumbers()
        {
            await Task.Run(() =>
            {
                try
                {
                    int count = NumbersConfig.countNums;
                    List<string> unsortedNumbers = new List<string>();
                    Random rnd = new Random();
                    for (int i = 0; i < count; i++)
                    {
                        float num=rnd.Next(-1, 1);
                        if (NumbersConfig.negativeNums && num!=0)
                        {
                                int newRand = rnd.Next(0, count);
                                num = newRand * num;
                        }
                        else
                            num = rnd.Next(0, count);
                        if (NumbersConfig.floatingNums)
                        {
                            float divider = rnd.Next(1, 10);
                            num = num / divider;
                        }
                        unsortedNumbers.Add(num.ToString());
                    }
                    System.IO.File.WriteAllLines(unsortedPath, unsortedNumbers);
                    return true;
                }
                catch (SecurityException securityEx)
                {
                    Utils.DisplayMessage("Security issue: " + securityEx.Message.ToString());
                    return false;
                }
                catch (Exception ex)
                { 
                    
                    Utils.DisplayMessage(ex.Message.ToString());
                    return false;
                }
            });
            return false;
        }

        public async Task<bool> GenerateSortedNumbers()
        {
            //NumbersConfig numsConfig
            await Task.Run(() =>
            {
                try
                {
                    Random rnd = new Random();
                    int count = NumbersConfig.countNums;
                    int diffBetweenEachNum = 7;
                    float total = 0.0f;
                    
                    List<string> sortedNumbers = new List<string>();
                    int min = 0;
                    int max = count;
                    if (NumbersConfig.negativeNums)
                    {
                        min = count / 2 * -1;
                        max = count / 2;
                    }
                    

                    for (int i=min; i < max; i++)
                    {
                        sortedNumbers.Add(total.ToString());
                        total += diffBetweenEachNum;
                        if (NumbersConfig.floatingNums)
                            total /= 10;
                    }

                    System.IO.File.WriteAllLines(sortedPath, sortedNumbers);
                    return true;
                }
                catch (SecurityException securityEx)
                {
                    Utils.DisplayMessage("Security issue: " + securityEx.Message.ToString());
                    return false;
                }
                catch (Exception ex)
                {
                    Utils.DisplayMessage(ex.Message.ToString());
                    return false;
                }
            });
            return false;
        }
    }
}
