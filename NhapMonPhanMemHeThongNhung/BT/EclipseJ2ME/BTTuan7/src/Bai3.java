import java.util.Calendar;
import java.util.Date;
import javax.microedition.lcdui.*;
import javax.microedition.midlet.MIDlet;
import javax.microedition.midlet.MIDletStateChangeException;


public class Bai3 extends MIDlet implements CommandListener {
	private Display display;

	private Form form;

	private Date today;

	private Command exit;
	private Command ok;

	private DateField datefield;

	public Bai3() {
		form = new Form("DateField");
		today = new Date(System.currentTimeMillis());
		exit = new Command("Exit", Command.EXIT, 0);
		ok = new Command("OK", Command.OK, 1);
		datefield = new DateField("Date\t\t\t\t", DateField.DATE_TIME);
	}

	protected void destroyApp(boolean unconditional) throws MIDletStateChangeException {
		// TODO Auto-generated method stub

	}

	protected void pauseApp() {
		// TODO Auto-generated method stub

	}

	protected void startApp() throws MIDletStateChangeException {
		display = Display.getDisplay(this);
		datefield.setDate(today);
		form.append(datefield);
		form.addCommand(exit);
		form.addCommand(ok);
		form.setCommandListener(this);
		display.setCurrent(form);
	}
	
	public void commandAction(Command c, Displayable d) {
		if (c == exit) {
			try {
				destroyApp(false);
				notifyDestroyed();
			} catch (MIDletStateChangeException e) {
				e.printStackTrace();
			}
		} else {
			if (c == ok) {
				StringItem str = new StringItem("Năm ", ChangeDay());
				form.append(str);
			}
		}
	}

	public String ChangeDay() {
		String strCan = "";
		String strChi = "";

		Calendar calendar = Calendar.getInstance();
		calendar.setTime(datefield.getDate());
		int year = calendar.get(Calendar.YEAR);
		int can = year % 10;
		int chi = year % 12;

		switch (can) {
		case 0:
			strCan = "Canh";
			break;
		case 1:
			strCan = "Tân";
			break;
		case 2:
			strCan = "Nhâm";
			break;
		case 3:
			strCan = "Quý";
			break;
		case 4:
			strCan = "Giáp";
			break;
		case 5:
			strCan = "Ất";
			break;
		case 6:
			strCan = "Bính";
			break;
		case 7:
			strCan = "Đinh";
			break;
		case 8:
			strCan = "Mậu";
			break;
		case 9:
			strCan = "Kỷ";
			break;
		default:
			break;
		}

		switch (chi) {
		case 0:
			strChi = "Thân";
			break;
		case 1:
			strChi = "Dậu";
			break;
		case 2:
			strChi = "Tuất";
			break;
		case 3:
			strChi = "Hợi";
			break;
		case 4:
			strChi = "Tý";
			break;
		case 5:
			strChi = "Sửu";
			break;
		case 6:
			strChi = "Dần";
			break;
		case 7:
			strChi = "Mão";
			break;
		case 8:
			strChi = "Thìn";
			break;
		case 9:
			strChi = "Tỵ";
			break;
		case 10:
			strChi = "Ngọ";
			break;
		case 11:
			strChi = "Mùi";
			break;
		}
		String strAmLich = strCan + " " + strChi;
		return strAmLich;
	}

}