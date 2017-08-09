using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace PawnSystem.UI.Backend.Methods
{
    public class ComputationHelper
    {
        public double getInterest(double principal, int interest , int multiplier)
        {
            return Math.Round(((double)principal / 100) * interest, 2) * multiplier;
        }

        public double getPenalty(double principal, int penalty, int multiplier)
        {
            return Math.Round(((double)principal / 100) * penalty, 2) * multiplier;
        }

        public double getServiceCharge(double principal)
        {
            if (principal >= Convert.ToInt32(ConfigurationManager.AppSettings["ServiceChargeHigh"].ToString()))
            {
                return Convert.ToDouble(ConfigurationManager.AppSettings["ServiceChargeHighAmount"].ToString());
            }
            else
            {
                return Math.Round(((double)principal / 100) * Convert.ToInt32(ConfigurationManager.AppSettings["ServiceChargeLowAmount"].ToString()), 2);
            }
        }


    }
}
