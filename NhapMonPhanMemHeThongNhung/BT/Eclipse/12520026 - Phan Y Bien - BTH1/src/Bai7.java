import java.util.Scanner;

public class Bai7 extends Bai6{
	final static Scanner scanner = new Scanner(System.in);
	public void Test()
	{
		int n;
		System.out.printf("Nhap so sinh vien: ");
		n = scanner.nextInt();
		Bai6 ts[] = new Bai6[n];
		for (int i = 0; i < n; i++)
		{
			System.out.println("STT: " + (i+1));
			ts[i] = new Bai6();
			ts[i].Nhap();
		}
		int d = 0;
		System.out.println("\nCac thi sinh co tong diem tren 15: ");
		for (int i = 0; i<n; i++)
		{
			if(ts[i].Tong() > 15)
			{
				ts[i].Xuat();
				d++;
			}
		}
		if(d==0)
			System.out.printf("Khong co thi sinh nao co tong diem tren 15!");
	}
	public static void main(String args[])
	{
		Bai7 bai7 = new Bai7();
		bai7.Test();
	}
}
