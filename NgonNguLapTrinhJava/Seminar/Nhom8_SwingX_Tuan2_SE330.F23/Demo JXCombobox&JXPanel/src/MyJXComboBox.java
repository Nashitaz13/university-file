import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.BorderFactory;
import javax.swing.ImageIcon;

import org.jdesktop.swingx.JXComboBox;
import org.jdesktop.swingx.JXFrame;
import org.jdesktop.swingx.JXLabel;
import org.jdesktop.swingx.JXPanel;
public class MyJXComboBox extends JXFrame {
	private String[] CountryList ={"VN","USA","Japan"};
	JXComboBox Combobox;
	JXPanel panel = new JXPanel();
	JXLabel label = new JXLabel();
	public MyJXComboBox(){
		super("Demo JXComboBox");
		setLayout(new FlowLayout());
		Combobox = new JXComboBox(CountryList);
		Combobox.setPreferredSize(new Dimension(120,30));
		Combobox.setEditable(true);
		
		Combobox.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				JXComboBox cb = (JXComboBox)e.getSource();
				String Country = (String)cb.getSelectedItem();
				label.setIcon(new ImageIcon(Country.trim().toLowerCase()+".jpg"));
			}
		});
		
		label.setIcon(new ImageIcon(CountryList[Combobox.getSelectedIndex()]+".jpg"));
		label.setBorder(BorderFactory.createEmptyBorder(10,0,0,0));
		label.setPreferredSize(new Dimension(800,600));
		//label.setLocation()
		panel.add(label);
		add(Combobox,BorderLayout.NORTH);
		add(panel,BorderLayout.SOUTH);
		setDefaultCloseOperation(JXFrame.EXIT_ON_CLOSE);
		setSize(810,630);
		setLocationRelativeTo(null);
		setResizable(false);
		
	}
	public void LoadImage()
	{
		
	}
	
}
