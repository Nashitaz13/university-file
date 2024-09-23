import java.util.Scanner;
import java.util.Random;

public class Mang1Chieu {
	public static void main(String args[])
	{	
		int n, x;
		int a[];
		System.out.printf("Nhap so phan tu: ");
		Scanner scanner = new Scanner(System.in);
		n = scanner.nextInt();
		a = new int[n];
		Nhap(n,a);
		System.out.printf("_Mang: ");
		Xuat(n,a);
		System.out.println("\n_Phan tu lon nhat: " + Max(n,a));
		System.out.println("_Phan tu nho nhat: " + Min(n,a));
		System.out.println("_So phan tu chan: " + SoChan(n,a));
		XuatSNT(n,a);
		System.out.printf("\n_Mang tang dan: ");
		XepTang(n,a); Xuat(n,a);
		System.out.printf("\nNhap phan tu can tim: ");
		x = scanner.nextInt();
		TimKiem(n,a,x);
	}
	public static void Nhap(int n, int a[])
	{
		for(int i = 0; i < n; i++)
			a[i] = new Random().nextInt(100);
	}
	public static void Xuat(int n, int a[])
	{
		for(int i = 0; i < n; i++)
			System.out.printf(a[i] + " ");
	}
	public static int Max(int n, int a[])
	{
		int max = a[0];
		for(int i = 0; i < n; i++)
			if(a[i] > max)
				max = a[i];
		return max;
	}
	public static int Min(int n, int a[])
	{
		int min = a[0];
		for(int i = 0; i < n; i++)
			if(a[i] < min)
				min = a[i];
		return min;
	}
	public static int SoChan(int n, int a[])
	{
		int d = 0;
		for(int i = 0; i < n; i++)
			if(a[i] % 2 == 0)
				d++;
		return d;
	}
	public static void XuatSNT(int n, int a[])
	{
		int d=0;
		for(int i = 0; i < n; i++)
			if(KTSNT(a[i]))
				d++;
		if(d != 0)
		{
			System.out.printf("_Cac so nguyen to trong mang: ");
			for(int i = 0; i < n; i++)
				if(KTSNT(a[i]))
					System.out.printf(a[i] + " ");
		}
		else
			if(d == 0)
				System.out.printf("_Mang da cho khong co so nguyen to nao!");
	}
    public static boolean KTSNT(int a)
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
    public static void XepTang(int n, int a[])
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
    public static void TimKiem(int n, int a[], int x)
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
}
