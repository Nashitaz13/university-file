import java.util.Scanner;

class HinhTron extends HinhHoc{
	private int r;
	private double pi = 3.14;
	
	public void Nhap()
	{
		Scanner scanner = new Scanner(System.in);
		System.out.printf("Nhap ban kinh hinh tron: ");
		r = scanner.nextInt();
	}
	public double ChuVi()
	{
		return 2*pi*r;
	}
	public double DienTich()
	{
		return pi*r*r;
	}
	public void Xuat()
	{
		System.out.println("Chu vi hinh tron: " + ChuVi());
		System.out.println("Dien tich hinh tron: " + DienTich());
	}
}