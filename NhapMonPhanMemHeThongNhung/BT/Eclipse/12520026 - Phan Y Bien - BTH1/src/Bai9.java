import java.util.Scanner;
import java.util.Random;

public class Bai9 {
	final static Scanner scanner = new Scanner(System.in);
	public void Nhap(int n, int a[])
	{
		for(int i = 0; i < n; i++)
			a[i] = new Random().nextInt(100);
	}
	public void Xuat(int n, int a[])
	{
		for(int i = 0; i < n; i++)
			System.out.printf(a[i] + " ");
	}
	public int Max(int n, int a[])
	{
		int max = a[0];
		for(int i = 0; i < n; i++)
			if(a[i] > max)
				max = a[i];
		return max;
	}
	public int Min(int n, int a[])
	{
		int min = a[0];
		for(int i = 0; i < n; i++)
			if(a[i] < min)
				min = a[i];
		return min;
	}
	public int TongSNT(int n, int a[])
	{
		int s = 0;
		for(int i = 0; i < n; i++)
			if(KTSNT(a[i]))
				s += a[i];
		return s;
	}
    public boolean KTSNT(int a)
    {
    	int i;
        boolean kt = true;
        if (a < 2) kt = false;
        if (a == 2) kt = true;
        if (a > 2)
        {
            for (i = 2; i * i <= a; i++)
                if (a % i == 0) break;
            if (i * i <= a) kt = false; else kt = true;
        }
        return kt;
    }
    public int SoPTCoTongCacChuSoLonHon10(int n, int a[])
    {
    	int d = 0;
    	for(int i = 0; i < n; i++)
    		if(TongCacChuSo(a[i]) > 10)
    			d++;
    	return d;
    }
    public int TongCacChuSo(int a)
    {
    	int s = 0;
    	int ai;
    	do
    	{
    		ai = a%10;
    		s += ai;
    		a = a/10;
    	}
    	while(a >0 );
    	return s;
    }
    public void XepTang(int n, int a[])
    {
    	int temp;
    	for(int i = 0; i < n - 1; i++)
    		for(int j = i + 1; j < n; j++)
    			if(a[j] < a[i])
    			{
    				temp = a[i];
    				a[i] = a[j];
    				a[j] = temp;
    			}
    }
    public void XepGiam(int n, int a[])
    {
    	int temp;
    	for(int i = 0; i < n - 1; i++)
    		for(int j = i + 1; j < n; j++)
    			if(a[j] > a[i])
    			{
    				temp = a[i];
    				a[i] = a[j];
    				a[j] = temp;
    			}
    }
    public void XepChanGiamLeTang(int n, int a[])
    {
    	int temp;
    	for(int i = 0; i < n - 1; i++)
    		for(int j = i + 1; j < n; j++)
    		{
    			if(a[j] %2 == 0)
    			{
	    			if((a[j] > a[i]) || ((a[j] < a[i]) && a[i]%2 != 0))
	    			{
	    				temp = a[i];
	    				a[i] = a[j];
	    				a[j] = temp;
	    			}
    			}
    		}
    	for(int i = n - 1 ; i > 1; i--)
    		for(int j = i - 1; j > 0; j--)
    		{
    			if(a[j] %2 != 0)
    			{
	    			if(a[j] > a[i])
	    			{
	    				temp = a[i];
	    				a[i] = a[j];
	    				a[j] = temp;
	    			}
    			}
    		}
    }
    public void TimKiem(int n, int a[], int x)
    {
    	int d = 0;
    	for(int i = 0; i < n; i++)
    		if(a[i] == x)
    			d++;
    	if(d!=0)
    	{
    		System.out.printf("_Tim thay " + x + " tai vi tri :");
    		for(int i = 0; i < n; i++)
    			if(a[i] == x)
    				System.out.printf(i+1 + " ");
    	}
    	else
    		if(d==0)
    			System.out.printf("_Khong co phan tu " + x + " trong mang!");
    }

	public static void main(String args[])
	{	
		Bai9 bai9 = new Bai9();
		int n, x;
		int a[];
		System.out.printf("Nhap so phan tu: ");
		n = scanner.nextInt();
		a = new int[n];
		bai9.Nhap(n,a);
		System.out.printf("a)Mang: ");
		bai9.Xuat(n,a);
		System.out.println("\nb)Phan tu lon nhat: " + bai9.Max(n,a));
		System.out.println("  Phan tu nho nhat: " + bai9.Min(n,a));
		System.out.println("c)Tong cac phan tu la so nguyen to: " + bai9.TongSNT(n, a));
		System.out.println("d)So phan tu co tong cac chu so lon hon 10: " + bai9.SoPTCoTongCacChuSoLonHon10(n, a));
		System.out.printf("e)Mang tang dan: ");
		bai9.XepTang(n,a); bai9.Xuat(n,a);
		System.out.printf("\n  Mang giam dan: ");
		bai9.XepGiam(n,a); bai9.Xuat(n,a);
		System.out.printf("\nf)Mang so chan giam dan, so le tang dan: ");
		bai9.XepChanGiamLeTang(n,a);
		bai9.Xuat(n,a);
		System.out.printf("\ng)Nhap phan tu can tim: ");
		x = scanner.nextInt();
		bai9.TimKiem(n,a,x);
	}
}