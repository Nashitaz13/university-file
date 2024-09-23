package jxtreetableexamples;

import java.awt.Color;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.swing.JFrame;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.SwingUtilities;

import org.jdesktop.swingx.JXTreeTable;
import org.jdesktop.swingx.decorator.ColorHighlighter;
import org.jdesktop.swingx.decorator.HighlightPredicate;
import org.jdesktop.swingx.decorator.HighlighterFactory;

public class TreeTableTest extends JFrame {

	private JXTreeTable treeTable;

	public TreeTableTest() {
		// sample date
		final Date date = Calendar.getInstance().getTime();
		List<Department> departmentList = new ArrayList<Department>();

		//tao deparment thu nhat
		List<Employee> empList1 = new ArrayList<Employee>();
		empList1.add(new Employee(1, "Kiran", date, "emp1.jpg"));
		empList1.add(new Employee(2, "Prabhu", date, "emp2.jpg"));
		empList1.add(new Employee(3, "Murugavel", date, "emp1.jpg"));
		
		//add employee1 vao goc thu nhat
		departmentList.add(new Department(1, "Sales", empList1));

		// tao deparment thu 2
		List<Employee> empList2 = new ArrayList<Employee>();
		empList2.add(new Employee(4, "Deiveegan", date, "emp2.jpg"));
		empList2.add(new Employee(5, "Saravanan", date, "emp1.jpg"));
		
		departmentList.add(new Department(2, "Production", empList2));

		// add vao root
		NoRootTreeTableModel noRootTreeTableModel = new NoRootTreeTableModel(departmentList);
		
		// khoi tao với TreeTableModel
		treeTable = new JXTreeTable(noRootTreeTableModel);
		treeTable.setAutoResizeMode(JTable.AUTO_RESIZE_OFF);
		treeTable.setRootVisible(false); // 
		
		//hien thi photo
		treeTable.getColumnModel().getColumn(3).setCellRenderer(new PhotoRenderer());
		
		treeTable.setRowHeight(50);
		
		treeTable.setColumnControlVisible(true);
		
		//highlighting
		treeTable.addHighlighter(HighlighterFactory
				.createSimpleStriping(HighlighterFactory.BEIGE));
		
		// Rollver
		treeTable.addHighlighter(new ColorHighlighter(
				HighlightPredicate.ROLLOVER_ROW, null, Color.BLUE));
		
		add(new JScrollPane(treeTable));

		setTitle("JXTreeTable Example");
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setSize(320, 450);
		setLocationRelativeTo(null);
		setVisible(true);
	}

	public static void main(String[] args) {
		SwingUtilities.invokeLater(new Runnable() {
			@Override
			public void run() {
				new TreeTableTest();
			}
		});
	}

}
