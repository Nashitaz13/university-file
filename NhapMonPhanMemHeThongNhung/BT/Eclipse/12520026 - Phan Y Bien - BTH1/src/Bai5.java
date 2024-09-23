import java.util.Scanner;
import java.util.Random;

public class Bai5 {
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
	public int SoChan(int n, int a[])
	{
		int d = 0;
		for(int i = 0; i < n; i++)
			if(a[i] % 2 == 0)
				d++;
		return d;
	}
	public void XuatSNT(int n, int a[])
	{
		int d=0;
		for(int i = 0; i < n; i++)
			if(KTSNT(a[i]))
				d++;
		if(d != 0)
		{
			System.out.printf("d)Cac so nguyen to trong mang: ");
			for(int i = 0; i < n; i++)
				if(KTSNT(a[i]))
					System.out.printf(a[i] + " ");
		}
		else
			if(d == 0)
				System.out.printf("d)Mang da cho khong co so nguyen to nao!");
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
		Bai5 bai5 = new Bai5();
		int n, x;
		int a[];
		System.out.printf("Nhap so phan tu: ");
		n = scanner.nextInt();
		a = new int[n];
		bai5.Nhap(n,a);
		System.out.printf("a)Mang: ");
		bai5.Xuat(n,a);
		System.out.println("\nb)Phan tu lon nhat: " + bai5.Max(n,a));
		System.out.println("  Phan tu nho nhat: " + bai5.Min(n,a));
		System.out.println("c)So phan tu chan: " + bai5.SoChan(n,a));
		bai5.XuatSNT(n,a);
		System.out.printf("\ne)Mang tang dan: ");
		bai5.XepTang(n,a); bai5.Xuat(n,a);
		System.out.printf("\nf)Nhap phan tu can tim: ");
		x = scanner.nextInt();
		bai5.TimKiem(n,a,x);
	}
}