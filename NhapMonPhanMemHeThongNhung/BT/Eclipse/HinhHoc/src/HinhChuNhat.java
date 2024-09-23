import java.util.Scanner;

class HinhChuNhat extends HinhHoc{
	private int x;
	private int y;
	
	public void Nhap()
	{
		Scanner scanner = new Scanner(System.in);
		System.out.printf("Nhap canh x: ");
		x = scanner.nextInt();
		System.out.printf("Nhap canh y: ");
		y = scanner.nextInt();
	}
	public double ChuVi()
	{
		return 2*(x+y);
	}
	public double DienTich()
	{
		return x*y;
	}
	public void Xuat()
	{
		System.out.println("Chu vi hinh chu nhat: " + ChuVi());
		System.out.println("Dien tich hinh chu nhat: " + DienTich());
	}
}