import java.util.Scanner;

public class Bai2 {
	final static Scanner scanner = new Scanner(System.in);
	public void Nhap(int n, int a[][])
	{
		for(int i = 0; i < n; i++)
			for(int j = 0; j < n; j++)
			{
				System.out.printf("Nhap phan tu a[");
				System.out.printf(i+1 + "][");
				System.out.printf(j+1 + "]: ");
				a[i][j] = scanner.nextInt();
			}
	}
	public void Xuat(int n, int a[][])
	{
		for(int i = 0; i < n; i++)
			for(int j = 0; j < n; j++)
			{
				System.out.printf(a[i][j] + "\t");
				if(j == n-1)
					System.out.printf("\n");
			}
	}
	public int TongTamGiacTren(int n, int a[][])
	{
		int s = 0;
		for(int i = 0; i < n; i++)
			for(int j = 0; j < n; j++)
			{
				if(i < j)
					s += a[i][j];
			}
		return s;
	}
	public int TongTamGiacDuoi(int n, int a[][])
	{
		int s = 0;
		for(int i = 0; i < n; i++)
			for(int j = 0; j < n; j++)
			{
				if(i > j)
					s += a[i][j];
			}
		return s;
	}
	public boolean MaTranDoiXung(int n,int a[][])
	{
		for(int i = 0; i < n; i++)
			for(int j = 0; j < n; j++)
			{
				if(a[i][j] != a[j][i])
					return false;
			}
		return true;
	}
	public static void main(String args[])
	{
		Bai2 bai2 = new Bai2();
		int n;
		int a[][];
		System.out.printf("a)Nhap so cap ma tran: ");
		n = scanner.nextInt();
		a = new int[n][n];
		bai2.Nhap(n,a);
		System.out.println("b)Ma tran: ");
		bai2.Xuat(n, a);
		System.out.println("c)Tong cac phan tu thuoc tam giac tren :" + bai2.TongTamGiacTren(n,a));
		System.out.println("d)Tong cac phan tu thuoc tan giac duoi: " + bai2.TongTamGiacDuoi(n,a));	
		if(bai2.MaTranDoiXung(n, a))
			System.out.println("e)Ma tran da cho la ma tran doi xung!");
		else
			System.out.println("e)Ma tran da cho khong phai la ma tran doi xung!");
	}
}
