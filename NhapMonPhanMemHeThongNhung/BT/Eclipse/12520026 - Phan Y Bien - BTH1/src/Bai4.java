import java.util.Scanner;

public class Bai4 {
	final static Scanner scanner = new Scanner(System.in);
	public static void main(String args[])
	{
		int x,HangTram,HangChuc,HangDonVi;
		do
		{
			System.out.printf("Nhap so nguyen co 3 chu so: ");
			x = scanner.nextInt();
			if(x < 100 || x > 999)
				System.out.println("Nhap sai! Xin vui long nhap lai!");
		}
		while(x < 100 || x > 999);
		HangTram = x/100;
		HangChuc = (x % 100)/10;
		HangDonVi = x % 10;
		System.out.printf(HangTram + " tram " + HangChuc + HangDonVi);
	}
}