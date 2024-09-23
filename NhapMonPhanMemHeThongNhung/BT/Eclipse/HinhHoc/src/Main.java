import java.util.Scanner;

public class Main {
	static HinhHoc [] hh = new HinhHoc[3];
	public static void main (String args[])
	{
		Nhap();
		Xuat();
		System.out.printf("MaxS: " + MaxDienTich());
	}
	
	public static void Nhap(){
		int ch = 0;
		Scanner scan = new Scanner(System.in);
		System.out.print("Nhap lua chon: ");
		ch = scan.nextInt();
		// do while
		switch(ch)
		{
		case 1:
			hh[0] = new HinhTron();
			hh[0].Nhap();
			break;
		case 2:
			hh[1] = new HinhVuong();
			hh[1].Nhap();
			break;
		case 3:
			hh[2] = new HinhChuNhat();
			hh[2].Nhap();
			break;
		}
		
	}
	public static void Xuat(){
		for(int i = 0; i < 3;i++)
		{
			hh[i].Xuat();
		}
	}
	public static double MaxDienTich(){
		double max = hh[0].DienTich();
		for(int i = 0;i < 3; i++)
		{
			if(hh[i].DienTich() > max)
				max = hh[i].DienTich(); 
		}
		return max;
	}
}
