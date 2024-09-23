import javax.microedition.lcdui.*;
import javax.microedition.midlet.MIDlet;
import javax.microedition.midlet.MIDletStateChangeException;


public class Bai1 extends MIDlet implements CommandListener{

	private Form form;
	private TextField textField;
	private Command nhapDuLieu, exit;

	public Bai1() {
		form = new Form("Vi du ve nhap lieu so dien thoai");
		textField = new TextField("Phone :", "", 11, TextField.PHONENUMBER);
		nhapDuLieu = new Command("Nhap Du Lieu", Command.OK, 1);
		exit = new Command("Exit", Command.EXIT, 0);
	}

	protected void destroyApp(boolean arg0) throws MIDletStateChangeException {
		// TODO Auto-generated method stub

	}

	protected void pauseApp() {
		// TODO Auto-generated method stub

	}

	protected void startApp() throws MIDletStateChangeException {
		form.append(textField);
		form.addCommand(nhapDuLieu);
		form.addCommand(exit);
		form.setCommandListener(this);
		Display.getDisplay(this).setCurrent(form);


	}
	public void commandAction(Command m, Displayable s) {
		String str = textField.getString();
		if (m == nhapDuLieu) {
			System.out.println("So Phone :" + str);
		} else if (m == exit) {
			try {
				destroyApp(false);
				notifyDestroyed();
			} catch (MIDletStateChangeException e) {
				e.printStackTrace();
			}
		}
	}


}
