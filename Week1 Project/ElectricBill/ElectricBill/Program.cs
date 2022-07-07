using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        List<meter> meters = new List<meter>();
        meters.Add(new commercial("Usman", 01, 890));
        meters.Add(new residential("Ali", 02, 450));
        meters.Add(new residential("Bob", 03, 642));
        meters.Add(new residential("Alice", 04, 321));
        meters.Add(new residential("Robert", 05, 643));
        meters.Add(new residential("Nawaz", 06, 231));
        meters.Add(new commercial("Imran", 07, 666));
        meters.Add(new commercial("Tom", 08, 545));
        meters.Add(new commercial("Harry", 09, 543));
        meters.Add(new commercial("Jack", 10, 345));
        Console.WriteLine("Enter you meter number : ");
        int meterNo = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < meters.Count; ++i)
        {
            if (meters[i].getMeterNo() == meterNo)
            {
                electricBill bill = new electricBill("June", "2022", meters[i]);
                bill.displayBill();
            }
        }
    }
}
public class meter
{
    private string ownerName;
    private int meterNo;
    private double units;
    string type;
    public meter(string ownerName, int meterNo, double units)
    {
        this.ownerName = ownerName;
        this.meterNo = meterNo;
        this.units = units;
    }
    public void setOwnerName(string ownerName)
    {
        this.ownerName = ownerName;
    }
    public void setMeterNo(int meterNo)
    {
        this.meterNo = meterNo;
    }
    public virtual void setType(string type)
    {
        this.type = type;
    }
    public virtual string getType()
    {
        return this.type;
    }
    public virtual double getTax()
    {
        return 0;
    }
    public void setUnits(double units)
    {
        this.units = units;
    }
    public string getOwnerName()
    {
        return this.ownerName;
    }
    public int getMeterNo()
    {
        return this.meterNo;
    }
    public double getUnits()
    {
        return this.units;
    }
    public virtual double calculateBill()
    {
        return 0;
    }
}

public class residential : meter
{
    private double bill;
    private double tax;
    public residential(string ownerName, int meterNo, double units) : base(ownerName, meterNo, units)
    {
        base.setType("Residential");
        this.bill = 0;
        this.tax = 0;
    }
    public double getBill()
    {
        return this.bill;
    }
    public override double getTax()
    {
        return this.tax;
    }
    public override double calculateBill()
    {
        if (this.getUnits() > 0 && this.getUnits() < 100)
        {
            bill = this.getUnits() * 5;
        }
        else if (this.getUnits() > 100 && this.getUnits() < 200)
        {
            bill = (100 * 5) + (this.getUnits() - 100) * 17;
        }
        else if (this.getUnits() > 200 && this.getUnits() < 500)
        {
            bill = (100 * 5) + (100 * 17) + ((this.getUnits() - 200) * 23);
        }
        else if (this.getUnits() > 500)
        {
            bill = (100 * 5) + (100 * 17) + (300 * 23) + ((this.getUnits() - 500) * 69);
        }

        tax = bill * 0.13;
        return bill;
    }
}

public class commercial : meter
{
    private double bill;
    private double tax;
    public commercial(string ownerName, int meterNo, double units) : base(ownerName, meterNo, units)
    {
        base.setType("Commercial");
        this.bill = 0;
        this.tax = 0;
    }
    public double getBill()
    {
        return this.bill;
    }
    public override double getTax()
    {
        return this.tax;
    }


    public override double calculateBill()
    {
        if (this.getUnits() > 0 && this.getUnits() < 100)
        {
            bill = this.getUnits() * 8;
        }
        else if (this.getUnits() > 100 && this.getUnits() < 200)
        {
            bill = (100 * 8) + (this.getUnits() - 100) * 21;
        }
        else if (this.getUnits() > 200 && this.getUnits() < 500)
        {
            bill = (100 * 8) + (100 * 21) + ((this.getUnits() - 200) * 23);
        }
        else if (this.getUnits() > 500)
        {
            bill = (100 * 8) + (100 * 21) + (300 * 23) + ((this.getUnits() - 500) * 79);
        }
        tax = bill * 0.17;
        return bill;
    }
}

public class electricBill
{
    private string month;
    private string year;
    private meter meterBill;

    public electricBill(string month, string year, meter meterBill)
    {
        this.month = month;
        this.year = year;
        this.meterBill = meterBill;
    }
    public void displayBill()
    {
        Console.WriteLine("The bill details for " + month + " " + year + " are given below: ");
        Console.WriteLine("Meter No : " + meterBill.getMeterNo());
        Console.WriteLine("Owner's Name : " + meterBill.getOwnerName());
        Console.WriteLine("Total units consumed : " + meterBill.getUnits());
        Console.WriteLine("Type of meter : " + meterBill.getType());
        Console.WriteLine("Bill for " + meterBill.getUnits() + " consumed : " + meterBill.calculateBill());
        Console.WriteLine("Tax for " + meterBill.getUnits() + " consumed : " + meterBill.getTax());
        Console.WriteLine("Total bill to be paid : " + (meterBill.calculateBill() + meterBill.getTax()));
    }

}
