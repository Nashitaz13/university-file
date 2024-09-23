import java.util.Scanner;

public class MaTran {
	public static void main(String args[])
	{		
		int m,n;
		int a[][];
		Scanner scanner = new Scanner(System.in);
		System.out.printf("Nhap so hang: ");
		m = scanner.nextInt();
		System.out.printf("Nhap so cot: ");
		n = scanner.nextInt();
		a = new int[m][n];
		Nhap(m,n,a);
		System.out.println("_Ma tran: ");
		Xuat(m,n,a);
		System.out.println("_Phan tu nho nhat: " + Min(m,n,a));
		System.out.println("_Phan tu le lon nhat: " + MaxLe(m,n,a));
		System.out.println("_Dong co tong lon nhat: " + DongCoTongLonNhat(m,n,a));
		System.out.println("_Tong cac so khong phai la so nguyen to: " + TongCacSoKhongPhaiLaSoNguyenTo(m,n,a));	
	}
	public static void Nhap(int m, int n, int a[][])
	{
		Scanner scanner = new Scanner(System.in);
		for(int i = 0; i < m; i++)
			for(int j = 0; j < n; j++)
			{
				System.out.printf("Nhap phan tu a[");
				System.out.printf(i+1 + "][");
				System.out.printf(j+1 + "]: ");
				a[i][j] = scanner.nextInt();
			}
	}
	public static void Xuat(int m, int n, int a[][])
	{
		for(int i = 0; i < m; i++)
			for(int j = 0; j < n; j++)
			{
				System.out.printf(a[i][j] + "\t");
				if(j == n-1)
					System.out.printf("\n");
			}
	}
	public static int Min(int m, int n, int a[][])
	{
		int min = a[0][0];
		for(int i = 0; i < m; i++)
			for(int j = 0; j < n; j++)
			{
				if(a[i][j] < min)
					min = a[i][j];
			}
		return min;
	}
	public static int MaxLe(int m, int n, int a[][])
	{
		int maxle = a[0][0];
		for(int i = 0; i < m; i++)
			for(int j = 0; j < n; j++)
			{
				if(a[i][j] > maxle && a[i][j] % 2 != 0)
					maxle = a[i][j];
			}
		return maxle;
	}
	public static int DongCoTongLonNhat(int m, int n, int a[][])
	{
		int i = 0;
		int s = 0;
		int b[];
		b = new int[m];
		while(i < m)
		{
			for (int j = 0; j < n; j++)
				s = s + a[i][j];
			b[i] = s;
			s = 0;
			i++;
		}
		int x = 0, max = b[0];
		for(int k = 0; k < m; k++ )
			if(b[k] >= max)
			{
				max = b[k];
				x = k + 1;
			}
		return x;
	}
	public static int TongCacSoKhongPhaiLaSoNguyenTo(int m, int n, int a[][])
	{
		int s = 0;
		for(int i = 0; i < m; i++)
			for(int j = 0; j < n; j++)
			{
				if(!KTSNT(a[i][j]))
					s = s + a[i][j];
			}
		return s;
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
}