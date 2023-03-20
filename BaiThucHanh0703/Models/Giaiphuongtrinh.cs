namespace BaiThucHanh0703.Models.Process
{
    public class GiaiPhuongTrinh 
    {
        public string Giaiphuongtrinhbac1(double a, double b)

        {
           //xay dung pt
           double x = -b/a;
           return "Nghiem cua phuong trinh x= " + x;
        }
        public string Giaiphuongtrinhbac2(double a, double b, double c)
        {
            double delta = Math.Pow(b,2) - 4*a*c;
            if(delta<0)
            return "Phuong trinh vo nghiem";
            else if(delta == 0)
            {
                double x1 = -b/(2*a);
                return "Phuong trinh co nghiem kep = " + x1;
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta))/(2*a);
                double x2 = (-b - Math.Sqrt(delta))/(2*a);
                return "Phuong trinh co 2 nghiem phan biet: x1 =" + x1 + ",x2 =" + x2;

            }
        }


    }
}