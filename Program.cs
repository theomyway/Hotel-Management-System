using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Hotelmanagementsystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()  //----------------------------Entry-Point-----------------------------------------//
        {
            SingleRoom SR = new SingleRoom();
            SR.Price();
            DoubleRoom DR = new DoubleRoom();
            DR.Price();
            FamilyRoom FR = new FamilyRoom();
            FR.Price();
            DecideMealPlan DMP = new DecideMealPlan("AmericanPlan");
            DecideMealPlan DMP1 = new DecideMealPlan("BednBreakfast", "EuropeanPlan", "_BednBreakfast");
            Economy E = new Economy();
            E.Bill();
            Business B = new Business();
            B.Bill();
            VIP V = new VIP();
            V.Bill();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new Form2());
            
        }
        


    }
    //--------------------------------------------Encapsulation---------------------------------------------------------------------//
    class DecideMealPlan
    {
        private string _AmericanPlan;
        private string _BednBreakfast;
        private string _ContinentalPlan;
        private string _EuropeanPlan;

        public DecideMealPlan(string AmericanPlan)
        {
            this._AmericanPlan = AmericanPlan;
            if(AmericanPlan==_AmericanPlan)
            {
                Console.WriteLine("The cost charged is 5000");
            }
                
        }
        public DecideMealPlan(string BednBreakfast,string ContinentalPlan,string EuropeanPlan)
        {
            this._BednBreakfast = BednBreakfast;
            this._ContinentalPlan = ContinentalPlan;
            this._EuropeanPlan = EuropeanPlan;
            if(_BednBreakfast==BednBreakfast)
            {
                Console.WriteLine("The cost charged is 5000");
            }
            if(ContinentalPlan==_ContinentalPlan)
            {
                Console.WriteLine("The cost charged is 8000");
            }
            if(EuropeanPlan==_EuropeanPlan)
            {
                Console.WriteLine("The cost charged is 10000");
            }
           
        }
      
    }
    //--------------------------------------------Abstraction & Inheritance---------------------------------------------------------------------//
    public abstract class Room    
    {
        public abstract double Price();
        protected double SingleRoomCharges = 8000;


    }
    public class SingleRoom : Room
    {
       
        public override double Price()
        {
            return SingleRoomCharges * 1;

        }
    }
        public class DoubleRoom : Room
        {
        public override double Price()    
            {
            return SingleRoomCharges * 2;
            }

        }
        public class FamilyRoom : Room
        {
        public override double Price()
        {
            return SingleRoomCharges * 3;

        }

    }
    //--------------------------------------------Polymorphism---------------------------------------------------------------------//
    class CustomerType
    {
        protected double BillCharge = 20000;
        public virtual double Bill()
        {
            return BillCharge * 0;
        }
    }
    class Economy:CustomerType
    {
        public override double Bill()
        {
            return BillCharge * 1;
        }
    }
    class Business:CustomerType
    {
        public override double Bill()
        {
            return BillCharge * 2;
        }
    }
    class VIP:CustomerType
    {
        public override double Bill()
        {
            return BillCharge * 3;
        }
    }
    }
    
