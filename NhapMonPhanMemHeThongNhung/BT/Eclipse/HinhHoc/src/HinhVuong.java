import java.util.Scanner;

class HinhVuong extends HinhHoc{
	private int a;
	
	public void Nhap()
	{
		Scanner scanner = new Scanner(System.in);
		System.out.printf("Nhap canh hinh vuong: ");
		a = scanner.nextInt();
	}
	public double ChuVi()
	{
		return 4*a;
	}
	public double DienTich()
	{
		return a*a;
	}
	public void Xuat()
	{
		System.out.println("Chu vi hinh vuong: " + ChuVi());
		System.out.println("Dien tich hinh vuong: " + DienTich());
	}
}