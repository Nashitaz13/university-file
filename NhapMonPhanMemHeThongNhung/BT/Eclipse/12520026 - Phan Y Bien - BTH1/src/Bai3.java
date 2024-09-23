import java.util.Scanner;

public class Bai3 {
	final static Scanner scanner = new Scanner(System.in);
	public static void main(String args[])
	{
		int a,b,c;
		double delta,x1,x2;
		System.out.printf("Nhap a: ");
		a = scanner.nextInt();
		System.out.printf("Nhap b: ");
		b = scanner.nextInt();
		System.out.printf("Nhap c: ");
		c = scanner.nextInt();
		if(a == 0)
			System.out.printf("Phuong trinh da cho khong phai la phuong trinh bac 2!");
		else
		{
			delta = b*b-4*a*c;
			if(delta > 0)
			{
				x1 = (-b + Math.sqrt(delta)) / (2*a);
				x2 = (-b - Math.sqrt(delta)) / (2*a);
				System.out.println("Phuong trinh co 2 nghiem:");
				System.out.println("x1 = " + x1);
				System.out.println("x2 = " + x2);
			}
			if(delta == 0)
			{
				x1 = -b/(2*a);
				System.out.println("Phuong trinh co 1 nghiem: x = " + x1);
			}
			if(delta < 0)
				System.out.println("Phuong trinh vo nghiem!");
		}
	}
}
