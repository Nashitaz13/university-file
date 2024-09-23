import java.util.Scanner;

public class Bai6 {
	protected int ma,ngay,thang,nam;
	protected double toan,van,anh;
	protected String hoten = "" ;
	final static Scanner scanner = new Scanner(System.in);
	public double Tong()
	{
		return (toan+van+anh);
	}
	public void Nhap()
	{
		System.out.printf("Nhap ma so: ");
		ma = scanner.nextInt();
		System.out.printf("Nhap ho ten: ");
		hoten = scanner.next();
		System.out.printf("Nhap ngay: ");
		ngay = scanner.nextInt();
		System.out.printf("Nhap thang: ");
		thang = scanner.nextInt();
		System.out.printf("Nhap nam: ");
		nam = scanner.nextInt();
		System.out.printf("Nhap diem Toan: ");
		toan = scanner.nextDouble();
		System.out.printf("Nhap diem Van: ");
		van = scanner.nextDouble();
		System.out.printf("Nhap diem Anh: ");
		anh = scanner.nextDouble();
	}
	public void Xuat()
	{
		System.out.println("\nMa so: " + ma);
		System.out.println("Ho ten: " + hoten);
		System.out.println("Ngay sinh: " + ngay + "/" + thang + "/" + nam);
		System.out.println("Diem Toan: " + toan);
		System.out.println("Diem Van: " + van);
		System.out.println("Diem Anh: " + anh);
		System.out.println("Tong diem: " + Tong());
	}
}
