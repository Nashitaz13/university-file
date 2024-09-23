package jxtreetableexamples;

import java.util.List;

public class Department {

	private int id_;
	private String name_;
	private List<Employee> employeeList_;

	public Department(int id, String name, List<Employee> empList) {
		id_ = id;
		name_ = name;
		employeeList_ = empList;
	}

	public List<Employee> getEmployeeList() {
		return employeeList_;
	}

	public void setEmployeeList(List<Employee> employeeList) {
		this.employeeList_ = employeeList;

	}
	
	public int getId(){
		return this.id_;
	}
	
	public String getName(){
		return this.name_;
	}
}
